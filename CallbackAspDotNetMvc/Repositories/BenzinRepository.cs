using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CallbackAspDotNetMvc.Common;
using NHibernate;
using NHibernate.Criterion;

namespace CallbackAspDotNetMvc.Repositories
{
    public class BenzinRepository : IRepository<CallbackAspDotNetMvc.Models.Benzin>
    {
        #region IRepository<Benzin> Members

        void IRepository<CallbackAspDotNetMvc.Models.Benzin>.Save(CallbackAspDotNetMvc.Models.Benzin entity)
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

        void IRepository<CallbackAspDotNetMvc.Models.Benzin>.Update(CallbackAspDotNetMvc.Models.Benzin entity)
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

        void IRepository<CallbackAspDotNetMvc.Models.Benzin>.Delete(CallbackAspDotNetMvc.Models.Benzin entity)
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

        CallbackAspDotNetMvc.Models.Benzin IRepository<CallbackAspDotNetMvc.Models.Benzin>.GetById(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.CreateCriteria<CallbackAspDotNetMvc.Models.Benzin>().Add(Restrictions.Eq("ID", id)).UniqueResult<CallbackAspDotNetMvc.Models.Benzin>();
        }
        public CallbackAspDotNetMvc.Models.Benzin GetByPayed(DateTime payed)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.CreateCriteria<CallbackAspDotNetMvc.Models.Benzin>().Add(Restrictions.Eq("payed_at", payed)).UniqueResult<CallbackAspDotNetMvc.Models.Benzin>();
        }

        IList<CallbackAspDotNetMvc.Models.Benzin> IRepository<CallbackAspDotNetMvc.Models.Benzin>.GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria(typeof(CallbackAspDotNetMvc.Models.Benzin));
                criteria.AddOrder(Order.Desc("payed_at")).AddOrder(Order.Desc("ID"));
                return criteria.List<CallbackAspDotNetMvc.Models.Benzin>();
            }
        }

        #endregion
    }
}
