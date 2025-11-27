using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using TradeDocsV3.Models;

namespace TradeDocsV3.Data;

public class DocumentRepository
{
    private readonly string _connectionString;

    public DocumentRepository(string conn)
    {
        _connectionString = conn;
        Initialize();
    }

    private void Initialize()
    {
        using var conn = new SqliteConnection(_connectionString);
        conn.Open();
        using var cmd = conn.CreateCommand();
        cmd.CommandText = @"
        CREATE TABLE IF NOT EXISTS Documents (
            Id TEXT PRIMARY KEY,
            Type TEXT NOT NULL,
            Number TEXT,
            Date TEXT,
            Status TEXT,
            TotalSum REAL,
            Synced INTEGER,
            CreatedBy TEXT
        );
        CREATE TABLE IF NOT EXISTS DocumentItems (
            Id TEXT PRIMARY KEY,
            DocumentId TEXT NOT NULL,
            ItemName TEXT,
            Quantity REAL,
            Price REAL,
            Sum REAL
        );";
        cmd.ExecuteNonQuery();
    }

    public List<DocumentModel> GetAll()
    {
        var result = new List<DocumentModel>();
        using var conn = new SqliteConnection(_connectionString);
        conn.Open();
        using var cmd = conn.CreateCommand();
        cmd.CommandText = "SELECT * FROM Documents ORDER BY Date DESC;";
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            result.Add(new DocumentModel
            {
                Id = reader.GetString(0),
                Type = reader.GetString(1),
                Number = reader.IsDBNull(2) ? "" : reader.GetString(2),
                Date = DateTime.Parse(reader.GetString(3)),
                Status = reader.GetString(4),
                TotalSum = reader.GetDouble(5),
                Synced = reader.GetInt32(6) == 1,
                CreatedBy = reader.GetString(7)
            });
        }
        return result;
    }

    public void Save(DocumentModel doc, List<DocumentItemModel> items)
    {
        using var conn = new SqliteConnection(_connectionString);
        conn.Open();
        using var tran = conn.BeginTransaction();

        using (var cmd = conn.CreateCommand())
        {
            cmd.Transaction = tran;
            cmd.CommandText = @"
            INSERT OR REPLACE INTO Documents
            (Id, Type, Number, Date, Status, TotalSum, Synced, CreatedBy)
            VALUES ($Id, $Type, $Number, $Date, $Status, $TotalSum, $Synced, $CreatedBy);";
            cmd.Parameters.AddWithValue("$Id", doc.Id);
            cmd.Parameters.AddWithValue("$Type", doc.Type);
            cmd.Parameters.AddWithValue("$Number", doc.Number);
            cmd.Parameters.AddWithValue("$Date", doc.Date.ToString("yyyy-MM-dd HH:mm:ss"));
            cmd.Parameters.AddWithValue("$Status", doc.Status);
            cmd.Parameters.AddWithValue("$TotalSum", doc.TotalSum);
            cmd.Parameters.AddWithValue("$Synced", doc.Synced ? 1 : 0);
            cmd.Parameters.AddWithValue("$CreatedBy", doc.CreatedBy);
            cmd.ExecuteNonQuery();
        }

        // Видаляємо старі позиції
        using (var cmd = conn.CreateCommand())
        {
            cmd.Transaction = tran;
            cmd.CommandText = "DELETE FROM DocumentItems WHERE DocumentId=$doc;";
            cmd.Parameters.AddWithValue("$doc", doc.Id);
            cmd.ExecuteNonQuery();
        }

        // Додаємо нові позиції
        foreach (var i in items)
        {
            using var cmd = conn.CreateCommand();
            cmd.Transaction = tran;
            cmd.CommandText = @"
            INSERT INTO DocumentItems (Id, DocumentId, ItemName, Quantity, Price, Sum)
            VALUES ($Id, $Doc, $Item, $Qty, $Price, $Sum);";
            cmd.Parameters.AddWithValue("$Id", i.Id);
            cmd.Parameters.AddWithValue("$Doc", doc.Id);
            cmd.Parameters.AddWithValue("$Item", i.ItemName);
            cmd.Parameters.AddWithValue("$Qty", i.Quantity);
            cmd.Parameters.AddWithValue("$Price", i.Price);
            cmd.Parameters.AddWithValue("$Sum", i.Sum);
            cmd.ExecuteNonQuery();
        }

        tran.Commit();
    }

    public void Delete(string documentId)
    {
        using var conn = new SqliteConnection(_connectionString);
        conn.Open();
        using var tran = conn.BeginTransaction();

        using (var cmd = conn.CreateCommand())
        {
            cmd.Transaction = tran;
            cmd.CommandText = "DELETE FROM DocumentItems WHERE DocumentId = $docId;";
            cmd.Parameters.AddWithValue("$docId", documentId);
            cmd.ExecuteNonQuery();
        }
        using (var cmd = conn.CreateCommand())
        {
            cmd.Transaction = tran;
            cmd.CommandText = "DELETE FROM Documents WHERE Id = $id;";
            cmd.Parameters.AddWithValue("$id", documentId);
            cmd.ExecuteNonQuery();
        }
        tran.Commit();
    }
}