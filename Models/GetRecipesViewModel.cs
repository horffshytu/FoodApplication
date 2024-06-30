using FoodApplication.APIHandler.GetRecipes;

namespace FoodApplication.Models;

public record GetRecipesViewModel
{
    public string Publisher { get; set; } = default!;
    public string ImageUrl { get; set; } = default!;
    public string Title { get; set; } = default!;
    public string Id { get; set; } = default!;
}


public class RecipesMapper
{
    public static List<GetRecipesViewModel> MapToViewModel(GetRecipesResponse response)
    {
        return response.Data.Recipes.Select(recipe => new GetRecipesViewModel
        {
            Publisher = recipe.Publisher,
            ImageUrl = recipe.ImageUrl,
            Title = recipe.Title,
            Id = recipe.Id
        })
        .ToList();
    }
}