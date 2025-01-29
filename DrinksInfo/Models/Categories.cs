
using System.Text.Json.Serialization;

namespace DrinksInfo.Models;

public class Categories
{
    [JsonPropertyName("drinks")]
    public List<Category>? CategoryList { get; set; }
}

public class Category
{
    [JsonPropertyName("strCategory")]
    public required string DrinkCategory { get; set; }
}
