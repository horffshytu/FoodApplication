using Newtonsoft.Json;

namespace FoodApplication.APIHandler.GetRecipe;

public record GetRecipeResponse
{
    [JsonProperty("status")]
    public string Status { get; set; } = default!;

    [JsonProperty("data")]
    public Data Data { get; set; } = default!;
}

public record Data
{
    [JsonProperty("recipe")]
    public Recipe Recipe { get; set; } = default!;
}

public record Ingredient
{
    [JsonProperty("quantity")]
    public double? Quantity { get; set; }

    [JsonProperty("unit")]
    public string Unit { get; set; } = default!;

    [JsonProperty("description")]
    public string Description { get; set; } = default!;
}

public record Recipe
{
    [JsonProperty("publisher")]
    public string Publisher { get; set; } = default!;

    [JsonProperty("ingredients")]
    public List<Ingredient> Ingredients { get; set; } = default!;

    [JsonProperty("source_url")]
    public string SourceUrl { get; set; } = default!;

    [JsonProperty("image_url")]
    public string ImageUrl { get; set; } = default!;

    [JsonProperty("title")]
    public string Title { get; set; } = default!;

    [JsonProperty("servings")]
    public int Servings { get; set; }

    [JsonProperty("cooking_time")]
    public int CookingTime { get; set; }

    [JsonProperty("id")]
    public string Id { get; set; } = default!;
}
