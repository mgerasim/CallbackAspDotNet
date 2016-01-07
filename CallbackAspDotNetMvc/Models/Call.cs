using CallbackAspDotNetMvc.Common;
using CallbackAspDotNetMvc.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallbackAspDotNetMvc.Models
{
    public class Call
    {
        public virtual int ID { get; set; }
        public virtual DateTime created_at { get; set; }
        public virtual DateTime updated_at { get; set; }
        public virtual string Name { get; set; }
        public virtual string phoneBgn { get; set; }
        public virtual string phoneEnd { get; set; }
        public virtual int CallsCount { get; set; }        
        public Call()
        {
            this.CallsCount = 0;
        }
        

        public static CallbackAspDotNetMvc.Models.Call GetByCall(string phoneBgn, string phoneEnd)
        {
            Repositories.CallRepository repo = new Repositories.CallRepository();
            return repo.GetByCall(phoneBgn, phoneEnd);
        }

        public static CallbackAspDotNetMvc.Models.Call GetById(int id)
        {
            IRepository<Call> repo = new Repositories.CallRepository();
            return repo.GetById(id);
        }

        
        public virtual void Save()
        {
            IRepository<Call> repo = new CallRepository();
            this.created_at = DateTime.Now;
            this.updated_at = DateTime.Now;
            repo.Save(this);
        }

        public virtual void Update()
        {
            IRepository<Call> repo = new CallRepository();
            this.updated_at = DateTime.Now;
            repo.Update(this);
        }

        public static List<Call> GetAll()
        {
            IRepository<Call> repo = new CallRepository();
            return (List<Call>)(repo.GetAll());
        }

        public virtual void Delete()
        {
            IRepository<Call> repo = new CallRepository();

            repo.Delete(this);
        }
    }
}
