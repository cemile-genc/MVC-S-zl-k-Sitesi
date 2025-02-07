﻿using DataAccsessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsessLayer.Concrete.Repositories
{
    public class GenericRepository <T> : IRepository <T> where T : class
    {
        Context context = new Context();

        DbSet<T> _object;
        public GenericRepository() //Constructor Method
        {
            _object = context.Set<T>();
        }

        public void Delete(T p)
        {
            var deletedEntity = context.Entry(p);
            deletedEntity.State = EntityState.Deleted;
            //_object.Remove(p);
            context.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter); //Bir dizide veya listede sadece bir değer döndürmek için kullanılır
        }

        public List<T> List() //Normal listeleme
        {
            return _object.ToList();    
        }

        public List<T> List(Expression<Func<T, bool>> filter) //Parametreli listeleme
        {
            return _object.Where(filter).ToList();  
        }

        public void Update(T p)
        {
            var updatedEntity = context.Entry(p);
            updatedEntity.State = EntityState.Modified;
            context.SaveChanges();

        }

        public void İnsert(T p)
        {
            var addedEntity = context.Entry(p);
            addedEntity.State= EntityState.Added;
           // _object.Add(p);
            context.SaveChanges ();   
        }
    }
}
