using Hogwarts_API.Interface;
using Hogwarts_API.Models;

namespace Hogwarts_API.DataBase;

public class PersonagemDb : IPersonagemDb
{
    private string uri = "https://hp-api.onrender.com/api/";
    private string domain = "characters";

    private readonly IUtil _getSterializedHttp;
    public PersonagemDb(IUtil getSterializedHttpResponse)
    {
        _getSterializedHttp = getSterializedHttpResponse;
    }

    public async Task<List<Personagem>> PersonagensDb()
    {
        var personagens = await _getSterializedHttp.searchCharacters(uri, domain);

        return personagens;
    }
}
