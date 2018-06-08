using BOL.Data;
using BOL.DBContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;

namespace DAL
{
    public partial class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly SetServiceDbContext _context;
        private IDbSet<T> entities;

        public EfRepository()
        {
            _context = new SetServiceDbContext();
        }


        public virtual T GetById(int id)
        {
            return this.Entities.Find(id);
        }


        public void Insert(IEnumerable<T> entities)
        {

            try
            {
                if (entities == null)
                    throw new ArgumentNullException("entities");

                foreach (var e in entities)
                {
                    this.Entities.Add(e);
                }

                _context.SaveChanges();

            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }


        public void Insert(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                this.Entities.Add(entity);

                _context.SaveChanges();

            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }



        public void Update(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException("entity");

                foreach (var e in entities)
                    _context.Entry(e).State = EntityState.Modified;

                _context.SaveChanges();

            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public void Update(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                _context.Entry(entity).State = EntityState.Modified;

                _context.SaveChanges();

            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }


        public void Delete(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException("entity");

                foreach (var e in entities)
                    this.Entities.Remove(e);

                _context.SaveChanges();

            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        public void Delete(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                this.Entities.Remove(entity);

                _context.SaveChanges();

            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }


        public IQueryable<T> Table
        {
            get
            {
                return this.Entities;
            }
        }

        public IQueryable<T> TableNoTracking
        {
            get
            {
                return this.Entities.AsNoTracking();
            }
        }


        protected virtual IDbSet<T> Entities
        {
            get
            {
                if (entities == null)
                    entities = _context.Set<T>();
                return entities;
            }
        }
    }
}
