using Hogwarts_API.Interface;
using Hogwarts_API.Models;
using System.Text.Json;

namespace Hogwarts_API.Util;

public class GetUtil : IUtil
{
  
    public async Task<List<Personagem>> searchCharacters(string uri, string domain)
    {

        HttpClient client = new HttpClient { BaseAddress = new Uri(uri) };

        var response = await client.GetStreamAsync(domain);

        var personagens = JsonSerializer.Deserialize<List<Personagem>>(response);

        return personagens;

    }
}
