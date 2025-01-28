using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinksInfo.Models;

public class Categories
{
    [JsonProperty("drinks")]
    public List<Category>? CategoryList { get; set; }
}

public class Category
{
    [JsonProperty("strCategory")]
    public required string DrinkCategory { get; set; }
}
