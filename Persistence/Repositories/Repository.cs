﻿using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
 
using System.Threading.Tasks;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class , IBaseEntity
    {
        protected readonly MigrationContext _context;

        public Repository(MigrationContext context)
        {
            _context = context;
        }

        public EntityEntry<TEntity> Add(TEntity entity) 
        {
            return _context.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities) => _context.Set<TEntity>().AddRange(entities);


        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate) => _context.Set<TEntity>().Where(predicate);


        public async Task<TEntity> Get(int id) => await _context.Set<TEntity>().FindAsync(id);

        public IQueryable<TEntity> GetAll() => _context.Set<TEntity>();

        public void Remove(TEntity entity)
        {
            if(entity is null)   throw new Exception("Entity Is Null");
            entity.IsDeleted = true;
            _context.Set<TEntity>().Update(entity);
        }

        public void Update(TEntity entity)
        {
            if (entity is null) throw new Exception("Entity Is Null");
         //   entity.IsDeleted = true;
            _context.Set<TEntity>().Update(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities) => _context.Set<TEntity>().RemoveRange(entities);

    }
}
