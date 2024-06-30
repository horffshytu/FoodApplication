using Newtonsoft.Json;

namespace FoodApplication.APIHandler.CreateRecipeResp;

public record CreateRecipeResponse
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

public record Recipe
{
    [JsonProperty("createdAt")]
    public DateTime CreatedAt { get; set; }

    [JsonProperty("publisher")]
    public string Publisher { get; set; }  = default!;

    [JsonProperty("source_url")]
    public string SourceUrl { get; set; }  = default!;

    [JsonProperty("image_url")]
    public string ImageUrl { get; set; }  = default!;

    [JsonProperty("cooking_time")]
    public int CookingTime { get; set; }

    [JsonProperty("servings")]
    public int Servings { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; }  = default!;

    [JsonProperty("key")]
    public string Key { get; set; }  = default!;

    [JsonProperty("ingredients")]
    public List<Ingredient>? Ingredients { get; set; }  = default!;

    [JsonProperty("id")]
    public string Id { get; set; }  = default!;
}

public record Ingredient
{
    public int? Quantity { get; set; }
    public string Unit { get; set; } = default!;
    public string Description { get; set; } = default!;
}
