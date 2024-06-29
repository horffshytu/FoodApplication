using FoodApplication.APIHandler;
using FoodApplication.APIHandler.GetRecipe;
using FoodApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodApplication.Controllers;

public class RecipeController : Controller
{
    private readonly IForkifyApiHandler _forkifyApiHandler;

    public RecipeController(IForkifyApiHandler forkifyApiHandler)
    {
        _forkifyApiHandler = forkifyApiHandler;
    }

    public async Task<IActionResult> Index(string search="carrot")
    {
        var response = await _forkifyApiHandler.GetRecipeList(search);

        if (response.Status != "success")
        {
            return RedirectToAction("ErrorPage");
        }

        var model = RecipeMapper.MapToViewModel(response);

        return View(model);
    }

    public IActionResult ErrorPage()
    {
        return View();
    }
}
