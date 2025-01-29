using DrinksInfo;
using DrinksInfo.Models;
using DrinksInfo.Services;
using System.Reflection;

var drinkService = new DrinksService();
var tableMaker = new ConsoleVisualEngine();

while (true)
{
    Console.Clear();
    var categories = await drinkService.GetDrinkCategories();

    Console.WriteLine("choose a category");
    tableMaker.ShowTable(categories, "Categories");

    string input = Console.ReadLine();

    Console.Clear();
    Console.WriteLine("choose a drink");
    var drinks = await drinkService.GetDrinksFromCategory(input);
    tableMaker.ShowTable(drinks, input);

    input = Console.ReadLine();

    Console.Clear();
    var drinkDetail = await drinkService.GetDrinkDetail(input);
    tableMaker.ShowTable(GetDetails(drinkDetail), input);

    Console.ReadKey();
}

List<object> GetDetails(DrinkDetail drinkDetail)
{
    List<object> prepList = new();

    string formattedName = "";

    foreach (PropertyInfo prop in drinkDetail.GetType().GetProperties())
    {

        if (prop.Name.Contains("str"))
        {
            formattedName = prop.Name.Substring(3);
        }

        if (!string.IsNullOrEmpty(prop.GetValue(drinkDetail)?.ToString()))
        {
            prepList.Add(new
            {
                Key = formattedName,
                Value = prop.GetValue(drinkDetail)
            });
        }
    }

    return prepList;
}
