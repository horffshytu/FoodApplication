using FoodApplication.APIHandler.GetRecipe;

namespace FoodApplication.Models;

public record GetRecipeViewModel
{
    public string Publisher { get; set; } = default!;
    public IEnumerable<Ingredient> Ingredients { get; set; } = default!;
    public string SourceUrl { get; set; } = default!;
    public string ImageUrl { get; set; } = default!;
    public string Title { get; set; } = default!;
    public int Servings { get; set; }
    public int CookingTime { get; set; }
    public string Id { get; set; } = default!;
}

public record Ingredient
{
    public double? Quantity { get; set; }
    public string Unit { get; set; } = default!;
    public string Description { get; set; } = default!;
}

public class RecipeMapper
{
    public static GetRecipeViewModel MapToViewModel(GetRecipeResponse response)
    {
        var data = new GetRecipeViewModel
        {
            Publisher = response.Data.Recipe.Publisher,
            ImageUrl = response.Data.Recipe.ImageUrl,
            Title = response.Data.Recipe.Title,
            Id = response.Data.Recipe.Id,
            SourceUrl = response.Data.Recipe.SourceUrl,
            Servings = response.Data.Recipe.Servings,
            CookingTime = response.Data.Recipe.CookingTime,
            Ingredients = response.Data.Recipe.Ingredients.Select(x => new Ingredient
            {
                Quantity = x.Quantity,
                Unit = x.Unit,
                Description = x.Description
            }).ToList(),
        };

        return data;
    }
}