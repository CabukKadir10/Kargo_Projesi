﻿using Core.Data.Abstract;
using Entity.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.Concrete
{
    public class RepositoryBase<T, Context> : IRepository<T>
        where T : class, IEntity, new()
        where Context : IdentityDbContext<User, Role, int>, new()
    {
        public bool Any(Expression<Func<T, bool>> filter)
        {
            using(var _context = new Context())
            {
                return _context.Set<T>().Any(filter);
            }
        }

        public int Count(Expression<Func<T, bool>> filter)
        {
            using(var _context = new Context())
            {
                return _context.Set<T>().Count(filter);
            }
        }

        public void Create(T entity)
        {
            using (var _context = new Context())
            {
                var addedEntity = _context.Entry(entity);
                addedEntity.State = EntityState.Added;
                _context.SaveChanges();
            }
        }

        public void Delete(T entity)
        {
            using (var _context = new Context())
            {
                var deletedEntity = _context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                _context.SaveChanges();
            }
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            using (var _context = new Context())
            {
                return _context.Set<T>().SingleOrDefault(filter);
            }
        }

        public List<T> GetList(Expression<Func<T, bool>> filter = null)
        {
            using (var _context = new Context())
            {
                return filter == null
                ? _context.Set<T>().ToList()
                : _context.Set<T>().Where(filter).ToList();
            }
        }

        public void Update(T entity)
        {
            using (var _context = new Context())
            {
                _context.Update(entity);
                _context.SaveChanges();
               // _context.ChangeTracker.Clear();
               // _context.Entry(entity).State = EntityState.Modified;
               //// _context.Update(entity);
               // _context.SaveChanges();
            }
        }

        //public void Create(T entity)
        //{
        //    var addedEntity = _context.Entry(entity);
        //    addedEntity.State = EntityState.Added;
        //    _context.SaveChanges();
        //}

        //public void Delete(T entity)
        //{
        //    var deletedEntity = _context.Entry(entity);
        //    deletedEntity.State = EntityState.Deleted;
        //    _context.SaveChanges();
        //}

        //public T Get(Expression<Func<T, bool>> filter)
        //{
        //    return _context.Set<T>().FirstOrDefault(filter);
        //}

        //public List<T> GetList(Expression<Func<T, bool>> filter = null)
        //{
        //    return filter == null
        //       ? _context.Set<T>().ToList()
        //       : _context.Set<T>().Where(filter).ToList();
        //}

        //public void Update(T entity)
        //{
        //    var updatedEntity = _context.Entry(entity);
        //    updatedEntity.State = EntityState.Modified;
        //    _context.SaveChanges();
        //}
    }
}
