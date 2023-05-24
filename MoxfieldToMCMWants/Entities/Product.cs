namespace MoxfieldToMCMWants.Entities;

public class Product
{
    public int IdProduct { get; set; }
    public int IdMetaProduct { get; set; }
    public int CountReprints { get; set; }
    public string? EnName { get; set; }
    public string? Website { get; set; }
    public int Number { get; set; }
    public string? Rarity { get; set; }
    public string? Expansion { get; set; }
}
