namespace FoodApplication.Helpers;

public class ApiSettings
{
    public string? ApiKey { get; set; } = default!;
    public string BaseUrl { get; set; } = default!;
    public string ClientName { get; set; } = default!;
    public Endpoints Endpoints { get; set; } = default!;
}

public class Endpoints
{
    public string GetRecipesEndpoint { get; set; } = default!;
    public string CreateRecipeEndpoint { get; set; } = default!;
    public string GetRecipeEndpoint { get; set; } = default!;
    public string DeleteRecipeEndpoint { get; set; } = default!;
}