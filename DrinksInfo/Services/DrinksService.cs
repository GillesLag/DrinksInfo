using DrinksInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DrinksInfo.Services;

public class DrinksService
{
    private readonly HttpClient _client = new HttpClient();

    public DrinksService()
    {
        _client.BaseAddress = new Uri("https://www.thecocktaildb.com");
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept.Add(
            new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
    }
    public async Task<List<Category>?> GetDrinkCategories()
    {
        var response = await _client.GetStringAsync("/api/json/v1/1/list.php?c=list");

        Categories Categories = JsonConvert.DeserializeObject<Categories>(response) ?? new Categories();

        return Categories.CategoryList;
    }
}
