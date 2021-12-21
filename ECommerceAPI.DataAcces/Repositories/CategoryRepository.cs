using ECommerceAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.DataAcces.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ECommerceDbConext _dbConext;
        public CategoryRepository(ECommerceDbConext dbConext)
        {
            _dbConext = dbConext;
        }

        public async Task<string> CreateAsync(Category entity)
        {
             await _dbConext.Set<Category>().AddAsync(entity);
            _dbConext.Entry(entity).State = EntityState.Added;
            await _dbConext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task DeleteAsync(string id)
        {
            var entity = await _dbConext.Set<Category>()
                .SingleOrDefaultAsync(p => p.Id == id);
            if (entity == null) return;

            _dbConext.Set<Category>().Remove(entity);
            _dbConext.Entry(entity).State = EntityState.Deleted;
            await _dbConext.SaveChangesAsync();
        }

        public async Task<Category> GetItemAsync(string id)
        {
            return await _dbConext.Set<Category>()
                .SingleOrDefaultAsync(p => p.Id ==id);
        }

        public async Task<(ICollection<Category> collection, int total)> ListAsync(string filter, int page, int rows)
        {
            var collection = await _dbConext.Set<Category>()
                .Where(p => p.Name.StartsWith(filter) && p.Status)
                .OrderBy(p => p.Name)
                .AsNoTracking()
                .Skip((page - 1) * rows)
                .Take(rows)
                .ToListAsync();

            var totalCount = await _dbConext.Set<Category>()
                .Where(p => p.Name.StartsWith(filter) && p.Status)
                .AsNoTracking()
                .CountAsync();

            return (collection, totalCount);
        }

        public async Task UpdateAsync(Category entity)
        {
            _dbConext.Set<Category>().Attach(entity);
            _dbConext.Entry(entity).State = EntityState.Modified;
            await _dbConext.SaveChangesAsync();
        }
    }
}
