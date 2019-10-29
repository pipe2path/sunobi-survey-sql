using Microsoft.Extensions.Options;
using MongoDB.Driver;
using survey.Interfaces;
using survey.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace survey.Data
{
    public class EntityRepository : IEntityRepository
    {
        private readonly DatabaseContext _context = null;

        public EntityRepository(DatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Entity> GetEntities()
        {
            try
            {
                return _context.Entities.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Entity GetEntity(string id)
        {
            try
            {
                return _context.Entities.FirstOrDefault(e => e.entityId == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateEntity(Entity item)
        {
            try
            {
                _context.Entities.Update(item);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
