//using Core.DataAccess.Abstract;
//using Core.Entities.Abstract;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Text;
//using System.Threading.Tasks;

//namespace Core.DataAccess.Concrete.NHibernate
//{
//    public class NHEntityRepositoryBase<TEntity> : IEntityRepository<TEntity>
//        where TEntity : class, IEntity, new()
//    {
//        private NHibernateHelper _nhibernateHelper;

//        public NHEntityRepositoryBase(NHibernateHelper nhibernateHelper)
//        {
//            _nhibernateHelper = nhibernateHelper;
//        }

//        public async Task AddAsync(TEntity entity)
//        {
//            using (var session = _nhibernateHelper.OpenSession())
//            {
//                await session.SaveAsync(entity);
//            }
//        }

//        public async Task DeleteAsync(TEntity entity)
//        {
//            using (var session = _nhibernateHelper.OpenSession())
//            {
//                await session.DeleteAsync(entity);
//            }
//        }

//        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
//        {
//            using (var session = _nhibernateHelper.OpenSession())
//            {
//                return await session.Query<TEntity>().SingleOrDefaultAsync(filter);
//            }
//        }

//        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null)
//        {
//            using (var session = _nhibernateHelper.OpenSession())
//            {
//                return await (filter == null ? session.Query<TEntity>().ToListAsync() : session.Query<TEntity>().Where(filter).ToListAsync());
//            }
//        }

//        public async Task UpdateAsync(TEntity entity)
//        {
//            using(var session = _nhibernateHelper.OpenSession())
//            {
//               await session.UpdateAsync(entity);
//            }
//        }
//    }
//}
