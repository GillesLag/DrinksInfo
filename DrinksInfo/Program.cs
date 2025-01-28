using DrinksInfo.Services;

var test = new DrinksService();
var result = await test.GetDrinkCategories();
var kak = await test.GetDrinksFromCategory(result[0].DrinkCategory);