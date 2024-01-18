using Hogwarts_API.Filters;
using Hogwarts_API.Interface; 
using Microsoft.AspNetCore.Mvc; 

namespace Hogwarts_API.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonagemController : ControllerBase
{
    private readonly IUtil _getSterializedHttp;

    public PersonagemController(IUtil getSterializedHttpResponse)
    {
        _getSterializedHttp = getSterializedHttpResponse;
    }

    [HttpGet("house/{house}")]
    public async Task<String> finbAListByHouse(string house)
    {
        if (house == null || house == "") return "Parâmetro vazio."; 

        var uri = "https://hp-api.onrender.com/api/";
        var domain = "characters";
        
        try
        {
            var personagens = await _getSterializedHttp.searchCharacters(uri, domain);

            if (personagens == null) return "Nenhum dado encontrado.";

            var personagensSelecionados = SearchBy.SearchByHouse(personagens, house);

            return personagensSelecionados;
        }
        catch (HttpRequestException ex)
        {
            return ex.Message + "/n Algo deu errado.";
        }
    }


    [HttpGet("gender/{gender}")]
    public async Task<String> finbAListByGender(string gender)
    {
        if (gender == null || gender == "") return "Parâmetro vazio.";

        var uri = "https://hp-api.onrender.com/api/";
        var domain = "characters";

        try
        {
            var personagens = await _getSterializedHttp.searchCharacters(uri, domain);

            if (personagens == null) return "Nenhum dado encontrado.";

            var personagensSelecionados = SearchBy.SearchByGender(personagens, gender);

            return personagensSelecionados;
        }
        catch (HttpRequestException ex)
        {
            return ex.Message + "/n Algo deu errado.";
        }
    }


    [HttpGet("age/{age}")]
    public async Task<String> finbAListByExactAge(string age)
    {
        if (age == null || age == "") return "Parâmetro vazio.";

        var uri = "https://hp-api.onrender.com/api/";
        var domain = "characters";

        try
        {
            var personagens = await _getSterializedHttp.searchCharacters(uri, domain);

            if (personagens == null) return "Nenhum dado encontrado.";

            var personagensSelecionados = SearchBy.SearchByAge(personagens, age);

            return personagensSelecionados;
        }
        catch (HttpRequestException ex)
        {
            return ex.Message + "/n Algo deu errado.";
        }
    }


}
