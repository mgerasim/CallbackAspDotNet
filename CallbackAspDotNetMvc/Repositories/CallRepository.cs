using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CallbackAspDotNetMvc.Common;
using NHibernate;
using NHibernate.Criterion;

namespace CallbackAspDotNetMvc.Repositories
{
    public class CallRepository : IRepository<CallbackAspDotNetMvc.Models.Call>
    {
        #region IRepository<Call> Members

        void IRepository<CallbackAspDotNetMvc.Models.Call>.Save(CallbackAspDotNetMvc.Models.Call entity)
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

        void IRepository<CallbackAspDotNetMvc.Models.Call>.Update(CallbackAspDotNetMvc.Models.Call entity)
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

        void IRepository<CallbackAspDotNetMvc.Models.Call>.Delete(CallbackAspDotNetMvc.Models.Call entity)
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

        CallbackAspDotNetMvc.Models.Call IRepository<CallbackAspDotNetMvc.Models.Call>.GetById(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.CreateCriteria<CallbackAspDotNetMvc.Models.Call>().Add(Restrictions.Eq("ID", id)).UniqueResult<CallbackAspDotNetMvc.Models.Call>();
        }

        public CallbackAspDotNetMvc.Models.Call GetByCall(string phoneBgn, string phoneEnd)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.CreateCriteria<CallbackAspDotNetMvc.Models.Call>().Add(Restrictions.Eq("phoneBgn", phoneBgn))
                    .Add(Restrictions.Eq("phoneEnd", phoneEnd))
                    .UniqueResult<CallbackAspDotNetMvc.Models.Call>();
        }

        IList<CallbackAspDotNetMvc.Models.Call> IRepository<CallbackAspDotNetMvc.Models.Call>.GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria(typeof(CallbackAspDotNetMvc.Models.Call));
                criteria.AddOrder(Order.Desc("updated_at"));
                return criteria.List<CallbackAspDotNetMvc.Models.Call>();
            }
        }

        #endregion
    }
}
