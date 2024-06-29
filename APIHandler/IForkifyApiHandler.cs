using FoodApplication.APIHandler.CreateRecipe;
using FoodApplication.APIHandler.GetRecipe;

namespace FoodApplication.APIHandler;

public interface IForkifyApiHandler
{
    Task<GetRecipeResponse> GetRecipeList(string search);

    Task<CreateRecipeResponse> CreateRecipe(CreateRecipeRequest request, string search);
}
