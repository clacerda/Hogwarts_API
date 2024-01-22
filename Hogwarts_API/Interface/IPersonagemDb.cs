using Hogwarts_API.Models;

namespace Hogwarts_API.Interface;

public interface IPersonagemDb
{
    public Task<List<Personagem>> PersonagensDb();
}


