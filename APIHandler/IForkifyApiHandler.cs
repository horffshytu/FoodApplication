using FoodApplication.APIHandler.CreateRecipe;
using FoodApplication.APIHandler.CreateRecipeResp;
using FoodApplication.APIHandler.GetRecipe;
using FoodApplication.APIHandler.GetRecipes;

namespace FoodApplication.APIHandler;

public interface IForkifyApiHandler
{
    Task<GetRecipesResponse> GetRecipeList(string search);

    Task<CreateRecipeResponse> CreateRecipe(CreateRecipeRequest request, string search);

    Task<GetRecipeResponse> GetRecipe(string recipeId);
}
