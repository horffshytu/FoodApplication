
using Newtonsoft.Json;

namespace FoodApplication.APIHandler.CreateRecipe;

public record CreateRecipeRequest
{
    [JsonProperty("publisher")]
    public string Publisher { get; set; } = default!;

    [JsonProperty("source_url")]
    public string SourceUrl { get; set; } = default!;

    [JsonProperty("image_url")]
    public string ImageUrl { get; set; } = default!;

    [JsonProperty("cooking_time")]
    public int CookingTime { get; set; }

    [JsonProperty("servings")]
    public int Servings { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; } = default!;

    public List<Ingredient>? Ingredients { get; set;}    
}

public record Ingredient
{
    public int? Quantity { get; set; }
    public string Unit { get; set; } = default!;
    public string Description { get; set; } = default!;
}
