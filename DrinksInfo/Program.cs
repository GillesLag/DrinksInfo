using DrinksInfo.Services;

var test = new DrinksService();
var result = await test.GetDrinkCategories();