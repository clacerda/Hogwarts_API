using Hogwarts_API.DataBase;
using Hogwarts_API.Filters;
using Hogwarts_API.Interface;
using Hogwarts_API.Models;
using Microsoft.AspNetCore.Mvc; 

namespace Hogwarts_API.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonagemController : ControllerBase
{
    private List<Personagem> _personagens;

    public PersonagemController(IPersonagemDb personagemDb)
    {
        _personagens = personagemDb.PersonagensDb().Result;
    }

    

    [HttpGet("house/{house}")]
    public async Task<String> findByListByHouseAsync(string house)
    {
        if (house == null || house == "") return "Parâmetro vazio."; 

        try
        { 
            if (_personagens == null) return "Nenhum dado encontrado.";

            var personagensSelecionados = SearchBy.SearchByHouse(_personagens, house);

            return personagensSelecionados;
        }
        catch (HttpRequestException ex)
        {
            return ex.Message + "/n Algo deu errado.";
        }
    }


    [HttpGet("gender/{gender}")]
    public async Task<String> findByListByGenderAsync(string gender)
    {
        if (gender == null || gender == "") return "Parâmetro vazio.";

        try
        {
            if (_personagens == null) return "Nenhum dado encontrado.";

            var personagensSelecionados = SearchBy.SearchByGender(_personagens, gender);

            return personagensSelecionados;
        }
        catch (HttpRequestException ex)
        {
            return ex.Message + "/n Algo deu errado.";
        }
    }


    [HttpGet("age/{age}")]
    public async Task<String> findByListByExactAgeAsync(string age)
    {
        if (age == null || age == "") return "Parâmetro vazio.";

        try
        {
            if (_personagens == null) return "Nenhum dado encontrado.";

            var personagensSelecionados = SearchBy.SearchByAge(_personagens, age);

            return personagensSelecionados;
        }
        catch (HttpRequestException ex)
        {
            return ex.Message + "/n Algo deu errado.";
        }
    }


    [HttpGet("name/{name}")]
    public async Task<String> findByListByNameAsync(string name)
    {
        if (name == null || name == "") return "Parâmetro vazio.";

        try
        {
            if (_personagens == null) return "Nenhum dado encontrado.";

            var personagensSelecionados = SearchBy.SearchByName(_personagens, name);

            return personagensSelecionados;
        }
        catch (HttpRequestException ex)
        {
            return ex.Message + "/n Algo deu errado.";
        }
    }
}
