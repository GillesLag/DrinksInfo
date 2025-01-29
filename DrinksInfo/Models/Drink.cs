using System.Text.Json.Serialization;

namespace DrinksInfo.Models;

public class Drink
{
    [JsonPropertyName("strDrink")]
    public string Name { get; set; }

    [JsonPropertyName("idDrink")]
    public string Id { get; set; }
}

public class DrinkList
{
    [JsonPropertyName("drinks")]
    public List<Drink> Drinks { get; set; }
}
