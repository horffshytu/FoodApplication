using FoodApplication.APIHandler.CreateRecipe;
using FoodApplication.APIHandler.GetRecipe;

namespace FoodApplication.APIHandler;

public interface IForkifyApiHandler
{
    Task<GetRecipeResponse> GetRecipeList(string searchParam);

    Task<CreateRecipeResponse> CreateRecipe(CreateRecipeRequest request, string searchParam);
}
