using System.Net.Http.Headers;
using MoxfieldToMCMWants.Entities;

namespace MoxfieldToMCMWants;

public class MCMService
{
    private readonly HttpClient _client;
    private const string BaseUrl = "https://api.cardmarket.com/ws/v2.0";

    public MCMService()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri(BaseUrl);
    }

    public void FindProducts(string searchString)
    {
        string urlParameters = $"find?search={searchString}&exact=true&idGame=1&idLanguage=1";

        // Add an Accept header for JSON format.
        _client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

        HttpResponseMessage response = _client.GetAsync(urlParameters).Result;  // Blocking call!
        if (response.IsSuccessStatusCode)
        {
            // Parse the response body.
            IEnumerable<Product> dataObjects = response.Content.ReadAsAsync<IEnumerable<Product>>().Result;
            foreach (var product in dataObjects)
            {
                Console.WriteLine("{0}", product.EnName);
            }
        }
        else
        {
            Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
        }
    }
}
