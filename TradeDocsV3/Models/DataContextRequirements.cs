using System.Collections.Generic;

namespace TradeDocsV3.Models;

public static class DataContextRequirements
{
    public static List<string> GetRequiredFields(DataContextRole role) => role switch
    {
        DataContextRole.Nomenclature    => new List<string> { "Id", "Name", "ParentId", "IsFolder"},
        DataContextRole.Shops           => new List<string> { "Id", "Name", "EDRPOU" },
        DataContextRole.PriceRegister   => new List<string> { "Id", "Name" },
        _                               => new List<string>()
    };

    public static string GetTargetTableName(DataContextRole role) => role switch
    {
        DataContextRole.Nomenclature    => "Nomenclature",
        DataContextRole.Shops           => "Shops",
        DataContextRole.PriceRegister   => "PriceRegister",
        _                               => string.Empty
    };
}