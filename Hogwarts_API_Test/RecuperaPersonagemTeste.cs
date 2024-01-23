using Hogwarts_API.Models;
using System.Text.Json;

namespace Hogwarts_API_Test
{
    public class RecuperaPersonagemTeste
    {
        [Fact]
        public async void Testar_RecuperaListaPersonagemBuscandoPorNomeCasa()
        {
            HttpClient client = new HttpClient { BaseAddress = new Uri("http://localhost:5162/personagem/") };

            var response = await client.GetStreamAsync("house/Slytherin");

            var personagens = JsonSerializer.Deserialize<List<Personagem>>(response);

            //Assert.True(personagens.Count() > 40 && personagens.Count() < 50);
            Assert.Equal(46, personagens.Count);
        }

        [Fact]
        public async void Testar_RecuperaListaPersonagemBuscandoPorNomePersonagem()
        {
            HttpClient client = new HttpClient { BaseAddress = new Uri("http://localhost:5162/personagem/") };

            var response = await client.GetStreamAsync("name/Draco Malfoy");

            var personagens = JsonSerializer.Deserialize<List<Personagem>>(response);

            Assert.Equal("Draco Malfoy", personagens.First().name);
        }
    }
}