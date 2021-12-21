using AutoMapper;
using ECommerceAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.DataAcces
{
    public static class DbContextExtensions
    {

        public static async Task<TEntityBase> Select<TEntityBase>(this DbContext context, string id)
            where TEntityBase : EntityBase
        {
            return await context.Set<TEntityBase>()
                .SingleOrDefaultAsync(p => p.Id == id
                                           && p.Status);
        }

        public static async Task<string> Insert<TEntityBase>(this DbContext context, TEntityBase entity)
            where TEntityBase : EntityBase
        {
            await context.Set<TEntityBase>().AddAsync(entity);
            context.Entry(entity).State = EntityState.Added;
            await context.SaveChangesAsync();

            return entity.Id;
        }

        public static async Task UpdateEntity<TEntityBase>(this DbContext context, TEntityBase entity,
            IMapper mapper)
            where TEntityBase : EntityBase

        {
            var registro = await context.Set<TEntityBase>()
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == entity.Id);

            if (registro == null) return;

            registro = mapper.Map<TEntityBase>(entity);

            context.Entry(registro).State = EntityState.Modified;

            await context.SaveChangesAsync();
        }

        public static async Task Delete<TEntityBase>(this DbContext context, TEntityBase entity)
            where TEntityBase : EntityBase
        {
            var registro = await context.Set<TEntityBase>()
                .SingleOrDefaultAsync(p => p.Id == entity.Id);

            if (registro == null) return;

            registro.Status = false;

            context.Set<TEntityBase>().Attach(registro);
            context.Entry(registro).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

    }
}
