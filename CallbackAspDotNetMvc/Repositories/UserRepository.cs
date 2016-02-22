using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CallbackAspDotNetMvc.Common;
using NHibernate;
using NHibernate.Criterion;

namespace CallbackAspDotNetMvc.Repositories
{
    public class UserRepository : IRepository<CallbackAspDotNetMvc.Models.User>
    {
        #region IRepository<Call> Members

        void IRepository<CallbackAspDotNetMvc.Models.User>.Save(CallbackAspDotNetMvc.Models.User entity)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(entity);
                    transaction.Commit();
                }
            }
        }

        void IRepository<CallbackAspDotNetMvc.Models.User>.Update(CallbackAspDotNetMvc.Models.User entity)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(entity);
                    transaction.Commit();
                }
            }
        }

        void IRepository<CallbackAspDotNetMvc.Models.User>.Delete(CallbackAspDotNetMvc.Models.User entity)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(entity);
                    transaction.Commit();
                }
            }
        }

        CallbackAspDotNetMvc.Models.User IRepository<CallbackAspDotNetMvc.Models.User>.GetById(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.CreateCriteria<CallbackAspDotNetMvc.Models.User>().Add(Restrictions.Eq("ID", id)).UniqueResult<CallbackAspDotNetMvc.Models.User>();
        }

        public CallbackAspDotNetMvc.Models.User GetByPhone(string telephone)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.CreateCriteria<CallbackAspDotNetMvc.Models.User>().Add(Restrictions.Eq("telephone", telephone))
                    .UniqueResult<CallbackAspDotNetMvc.Models.User>();
        }

        IList<CallbackAspDotNetMvc.Models.User> IRepository<CallbackAspDotNetMvc.Models.User>.GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria(typeof(CallbackAspDotNetMvc.Models.User));
                criteria.AddOrder(Order.Desc("updated_at"));
                return criteria.List<CallbackAspDotNetMvc.Models.User>();
            }
        }

        #endregion
    }
}
