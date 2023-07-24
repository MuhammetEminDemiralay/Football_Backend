using Core.DataAccess.Abstract;
using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Concrete.NHibernate
{
    public class NHEntityRepositoryBase<TEntity> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
    {
        private NHibernateHelper _nhibernateHelper;

        public NHEntityRepositoryBase(NHibernateHelper nhibernateHelper)
        {
            _nhibernateHelper = nhibernateHelper;
        }

        public void Add(TEntity entity)
        {
            using (var session = _nhibernateHelper.OpenSession())
            {
                session.Save(entity);
            }
        }

        public void Delete(TEntity entity)
        {
            using (var session = _nhibernateHelper.OpenSession())
            {
                session.Delete(entity);
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var session = _nhibernateHelper.OpenSession())
            {
                return session.Query<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var session = _nhibernateHelper.OpenSession())
            {
                return filter == null ? session.Query<TEntity>().ToList() : session.Query<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using(var session = _nhibernateHelper.OpenSession())
            {
                session.Update(entity);
            }
        }
    }
}
