using Newtonsoft.Json;

namespace FoodApplication.Extensions;

public static class HttpClientExtensions
{
    //public static async Task<T> ReadContentAs<T>(this HttpResponseMessage response)
    //{
    //    var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

    //    return JsonSerializer.Deserialize<T>(dataAsString,
    //                                         new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    //}

    public static async Task<T> ReadContentAs<T>(this HttpResponseMessage response)
    {
        var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

        return JsonConvert.DeserializeObject<T>(dataAsString)!;
    }
}