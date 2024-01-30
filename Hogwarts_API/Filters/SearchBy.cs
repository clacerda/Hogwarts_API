using Hogwarts_API.Models;
using System.Text.Json;

namespace Hogwarts_API.Filters;

public static class SearchBy
{
    public static string SearchByHouse(List<Personagem> personagens, string house)
    {
        if (string.IsNullOrEmpty(house)) return "informe a casa.";

        var personagensSelecionados = personagens.Where(p => p.house.ToUpper().Equals(house.ToUpper())).ToList();
         
        var personagensSerialized = JsonSerializer.Serialize(personagensSelecionados);

        return personagensSerialized;
    }

    public static string SearchByGender(List<Personagem> personagens, string gender)
    {
        if (string.IsNullOrEmpty(gender)) return "informe o gênero.";

        var personagensSelecionados = personagens.Where(p => p.gender.ToUpper() == gender.ToUpper()).ToList();

        var personagensSerialized = JsonSerializer.Serialize(personagensSelecionados);

        return personagensSerialized;
    }

    public static string SearchByAge(List<Personagem> personagens, string age)
    { 

        if (!int.TryParse(age, out int result)) return "Informe uma idade"; 

        var personagensSelecionados = personagens.Where(p => !string.IsNullOrEmpty(p.dateOfBirth) &&
                                      Convert.ToInt32((DateTime.Now - DateTime.Parse(p.dateOfBirth)).TotalDays / 365) == result).ToList();

        var personagensSerialized = JsonSerializer.Serialize(personagensSelecionados);

        return personagensSerialized;
    }


    public static string SearchByName(List<Personagem> personagens, string name)
    {
        if (string.IsNullOrEmpty(name)) return "informe o nome.";

        var personagensSelecionados = personagens.Where(p => p.name.ToUpper().Equals(name.ToUpper()));

        var personagensSerialized = JsonSerializer.Serialize(personagensSelecionados);

        return personagensSerialized;
    }


    public static Personagem InsertCharacter(List<Personagem> personagens, Personagem personagem)
    {
        if (string.IsNullOrEmpty(personagem.name)) return null;

        personagem.id = Guid.NewGuid();
        personagens.Add(personagem);

        return personagem;        
    }
}
