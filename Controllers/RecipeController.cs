using AspNetCoreHero.ToastNotification.Abstractions;
using FoodApplication.APIHandler;
using FoodApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodApplication.Controllers;

public class RecipeController : Controller
{
    private readonly IForkifyApiHandler _forkifyApiHandler;
    private readonly INotyfService _notyfService;

    public RecipeController(IForkifyApiHandler forkifyApiHandler, INotyfService notyfService)
    {
        _forkifyApiHandler = forkifyApiHandler;
        _notyfService = notyfService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> Search(string search) 
    {
        if (string.IsNullOrWhiteSpace(search))
        {
            return View("Index");
        }

        var response = await _forkifyApiHandler.GetRecipeList(search);

        if (response.Status != "success")
        {
            _notyfService.Error("An error occured!");

            return View("Index");
        }

        var model = RecipesMapper.MapToViewModel(response);

        return View("Index", model);
    }

    [HttpGet("RecipeDetail/{recipeId}")]
    public async Task<IActionResult> RecipeDetail([FromRoute] string recipeId)
    {
        if (string.IsNullOrWhiteSpace(recipeId)) 
        {
            _notyfService.Error("Recipe Id is missing!");
            return View("Index");
        }

        var response = await _forkifyApiHandler.GetRecipe(recipeId);
        var model = RecipeMapper.MapToViewModel(response);

        return View(model);
    }
}
