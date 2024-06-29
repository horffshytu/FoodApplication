using FoodApplication.APIHandler.GetRecipe;

namespace FoodApplication.Models;

public class GetRecipeViewModel
{
    public string Publisher { get; set; } = default!;
    public string ImageUrl { get; set; } = default!;
    public string Title { get; set; } = default!;
    public string Id { get; set; } = default!;
}


public class RecipeMapper
{
    public static List<GetRecipeViewModel> MapToViewModel(GetRecipeResponse response)
    {
        return response.Data.Recipes.Select(recipe => new GetRecipeViewModel
        {
            Publisher = recipe.Publisher,
            ImageUrl = recipe.ImageUrl,
            Title = recipe.Title,
            Id = recipe.Id
        })
        .ToList();
    }
}