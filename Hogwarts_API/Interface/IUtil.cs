using Hogwarts_API.Models;

namespace Hogwarts_API.Interface
{
    public interface IUtil
    {
        Task<List<Personagem>> searchCharacters(string uri, string domain); 
    }
}
