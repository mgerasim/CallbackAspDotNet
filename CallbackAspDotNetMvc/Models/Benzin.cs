using CallbackAspDotNetMvc.Common;
using CallbackAspDotNetMvc.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallbackAspDotNetMvc.Models
{
    public class Benzin
    {
        public virtual int ID { get; set; }
        public virtual DateTime created_at { get; set; }
        public virtual DateTime updated_at { get; set; }
        public virtual DateTime payed_at { get; set; }
        public virtual int probeg { get; set; }
        public virtual int litrs { get; set; }
        public virtual decimal summa { get; set; }

        public virtual void Save()
        {
            this.created_at = DateTime.Now;
            this.updated_at = DateTime.Now;
            CallbackAspDotNetMvc.Common.IRepository<Benzin> repo = new Repositories.BenzinRepository();

            repo.Save(this);
        }

        public virtual void Update()
        {
            this.updated_at = DateTime.Now;
            CallbackAspDotNetMvc.Common.IRepository<Benzin> repo = new Repositories.BenzinRepository();
            repo.Update(this);
        }

        public static List<Benzin> GetAll()
        {
            CallbackAspDotNetMvc.Common.IRepository<Benzin> repo = new Repositories.BenzinRepository();
            return (List<Benzin>)repo.GetAll();
        }

        public static Benzin GetById(int ID)
        {
            CallbackAspDotNetMvc.Common.IRepository<Benzin> repo = new Repositories.BenzinRepository();
            return repo.GetById(ID);
        }
        public virtual void Delete()
        {
            CallbackAspDotNetMvc.Common.IRepository<Benzin> repo = new Repositories.BenzinRepository();
            repo.Delete(this);
        }

    }
}
