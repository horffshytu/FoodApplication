using Newtonsoft.Json;

namespace FoodApplication.APIHandler.GetRecipe;

public record GetRecipeResponse
{
    [JsonProperty("status")]
    public string Status { get; set; } = default!;

    [JsonProperty("results")]
    public int Results { get; set; }

    [JsonProperty("data")]
    public Data Data { get; set; } = default!;
}

public record Data
{
    [JsonProperty("recipes")]
    public List<Recipe> Recipes { get; set; } = [];
}

public record Recipe
{
    [JsonProperty("publisher")]
    public string Publisher { get; set; } = default!;

    [JsonProperty("image_url")]
    public string ImageUrl { get; set; } = default!;

    [JsonProperty("title")]
    public string Title { get; set; } = default!;

    [JsonProperty("id")]
    public string Id { get; set; } = default!;
}