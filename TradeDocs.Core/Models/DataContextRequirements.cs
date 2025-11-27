using System.Collections.Generic;

namespace TradeDocsV3.Models;

public static class DataContextRequirements
{
    // 1. Визначаємо ТИП для кожної Ролі
    public static DataContextType GetType(DataContextRole role)
    {
        return role switch
        {
            DataContextRole.Номенклатура or
            DataContextRole.Контрагенти or
            DataContextRole.Працівники or
            DataContextRole.Магазини or
            DataContextRole.ОдиниціВиміру
                => DataContextType.Довідник,

            DataContextRole.Замовлення or
            DataContextRole.Повернення or
            DataContextRole.Прихід or
            DataContextRole.Специфікація
                => DataContextType.Документ,

            DataContextRole.Замовлення_Товари or
            DataContextRole.Повернення_Товари or
            DataContextRole.Прихід_Товари or
            DataContextRole.Специфікація_Товари
                => DataContextType.ТабличнаЧастина,

            DataContextRole.РегістрЦін
                => DataContextType.Регістр,

            _ => DataContextType.Невизначено
        };
    }

    // 2. Назва таблиці в SQLite (автоматично з назви ролі)
    public static string GetTargetTableName(DataContextRole role)
    {
        return role.ToString(); // Наприклад: "Номенклатура", "Замовлення_Товари"
    }

    // 3. Список полів (базується на ТИПІ)
    public static List<string> GetRequiredFields(DataContextRole role)
    {
        var fields = new List<string>();
        var type = GetType(role);

        // --- БАЗОВІ ПОЛЯ ЗАЛЕЖНО ВІД ТИПУ ---
        switch (type)
        {
            case DataContextType.Довідник:
                // Усі довідники мають Id та Name
                fields.Add("Id");
                fields.Add("Name");

                // Ієрархічні довідники
                if (role == DataContextRole.Номенклатура || role == DataContextRole.Контрагенти)
                {
                    fields.Add("ParentId");
                    fields.Add("IsFolder");
                }

                // Специфічні поля
                if (role == DataContextRole.Контрагенти) fields.Add("EDRPOU");
                break;

            case DataContextType.Документ:
                // Усі документи мають ці поля
                fields.AddRange(new[] { "Id", "Number", "Date", "ContractorId", "Sum" });

                if (role == DataContextRole.Специфікація)
                {
                    fields.Add("DateStart"); // Дата початку дії
                    fields.Add("DateEnd");   // Дата закінчення
                }
                break;

            case DataContextType.ТабличнаЧастина:
                // Зв'язок з шапкою (DocumentId) та Товар (ItemId)
                fields.AddRange(new[] { "DocumentId", "ItemId", "Quantity", "Price", "Sum" });
                break;

            case DataContextType.Регістр:
                if (role == DataContextRole.РегістрЦін)
                {
                    fields.AddRange(new[] { "ItemId", "PriceTypeId", "Price", "Currency" });
                }
                break;
        }

        return fields;
    }
}