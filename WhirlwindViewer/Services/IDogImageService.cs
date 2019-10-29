using System;
using System.Threading.Tasks;
using Refit;
namespace WhirlwindViewer.Services
{
    public interface IDogImageService
    {
        [Get("/random")]
        Task<RandomDogMessage> GetRandomDog();
    }
}
