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
    private Personagem novoPersonagem = new Personagem();

    public PersonagemController(IPersonagemDb personagemDb)
    {
        _personagens = personagemDb.PersonagensDb().Result;
    }

    

    [HttpGet("house/{house}")]
    public async Task<String> finbAListByHouse(string house)
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
    public async Task<String> finbAListByGender(string gender)
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
    public async Task<String> finbAListByExactAge(string age)
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
    public async Task<String> finbAListByName(string name)
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



    //[HttpPost]
    //public async Task<ActionResult<Personagem>>insertNewCharacter([FromBody]Personagem personagem)
    //{
    //    if (string.IsNullOrEmpty(personagem.name)) return BadRequest(new { Code = "400", Message = "Parâmetro vazio." });

    //    try
    //    {
    //        if (_personagens == null) return NotFound(new { Code = "404", Message = "Nenhum dado encontrado." });

    //       novoPersonagem = SearchBy.InsertCharacter(_personagens, personagem);

    //        return novoPersonagem;
    //    }
    //    catch (HttpRequestException ex)
    //    {
    //        return StatusCode(500, new { Code = "500", Message = $"Erro interno: {ex.Message}" });
    //    }
    //}


}
