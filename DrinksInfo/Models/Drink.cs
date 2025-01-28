﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
