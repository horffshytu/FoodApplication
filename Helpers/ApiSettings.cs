namespace FoodApplication.Helpers;

public class ApiSettings
{
    public string ApiKey { get; set; } = default!;
    public string BaseUrl { get; set; } = default!;
    public string ClientName { get; set; } = default!;
    public Endpoints Endpoints { get; set; } = default!;
}

public class Endpoints
{
    public string GetAllOrCreateRecipeEndpoint { get; set; } = default!;
    public string GetSingleOrDeleteRecipeEndpoint { get; set; } = default!;
}