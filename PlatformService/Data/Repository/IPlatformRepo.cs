using PlatformService.Model;
using System.Collections.Generic;

namespace PlatformService.Data.Repository
{
    public interface IPlatformRepo
    {
        bool SaveChange();
        IEnumerable<Platform> GetAllPlatform();
        Platform GetPlatformById(int Id);
        void CreatePlatform(Platform platform);
    }
}
