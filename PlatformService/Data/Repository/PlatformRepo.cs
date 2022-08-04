using PlatformService.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlatformService.Data.Repository
{
    public class PlatformRepo : IPlatformRepo
    {
        private readonly AppDbContext _dbContext;
        public PlatformRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreatePlatform(Platform platform)
        {
            if (platform == null)
            {
                throw new ArgumentNullException(nameof(platform));
            }
            _dbContext.Platforms.Add(platform);
        }

        public IEnumerable<Platform> GetAllPlatform()
        {
            return _dbContext.Platforms.ToList();
        }

        public Platform GetPlatformById(int Id)
        {
            return _dbContext.Platforms.FirstOrDefault(x=>x.Id==Id);
        }

        public bool SaveChange()
        {
            return (_dbContext.SaveChanges()>0);
        }
    }
}
