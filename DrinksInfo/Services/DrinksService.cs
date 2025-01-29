using DrinksInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

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
    public async Task<List<Category>> GetDrinkCategories()
    {
        var response = await _client.GetStringAsync("/api/json/v1/1/list.php?c=list");

        var categoryList = new List<Category>();

        if (!string.IsNullOrWhiteSpace(response))
        {
            Categories Categories = JsonSerializer.Deserialize<Categories>(response);
            categoryList = Categories.CategoryList;
        }


        return categoryList;
    }

    public async Task<List<Drink>> GetDrinksFromCategory(string category)
    {
        var drinks = new List<Drink>();
        var response = await _client.GetStringAsync($"/api/json/v1/1/filter.php?c={category}");

        if (!string.IsNullOrWhiteSpace(response))
        {
            DrinkList drinkList = JsonSerializer.Deserialize<DrinkList>(response);
            drinks = drinkList.Drinks;
        }

        return drinks;
    }

    public async Task<DrinkDetail> GetDrinkDetail(string name)
    {
        var response = await _client.GetStringAsync($"/api/json/v1/1/search.php?s={name}");
        DrinkDetail drinkDetails = new DrinkDetail();

        if (!string.IsNullOrWhiteSpace(response))
        {
            DrinkDetailObject dringDetailObject = JsonSerializer.Deserialize<DrinkDetailObject>(response);
            drinkDetails = dringDetailObject.DrinkDetailList.FirstOrDefault();
        }

        return drinkDetails;
    }
}
