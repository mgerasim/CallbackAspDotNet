using CallbackAspDotNetMvc.Common;
using CallbackAspDotNetMvc.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallbackAspDotNetMvc.Models
{
    public class User
    {
        public virtual int ID { get; set; }
        public virtual DateTime created_at { get; set; }
        public virtual DateTime updated_at { get; set; }
        public virtual string telephone { get; set; }
        public virtual string code { get; set; }
        public virtual string lastname { get; set; }
        public virtual string secondname { get; set; }
        public virtual string firstname { get; set; }
        public virtual string result { get; set; }
        public User()
        {
        }
        

        public static CallbackAspDotNetMvc.Models.User GetByPhone(string telephone)
        {
            Repositories.UserRepository repo = new Repositories.UserRepository();
            return repo.GetByPhone(telephone);
        }

        public static CallbackAspDotNetMvc.Models.User GetById(int id)
        {
            IRepository<User> repo = new Repositories.UserRepository();
            return repo.GetById(id);
        }

        
        public virtual void Save()
        {
            IRepository<User> repo = new UserRepository();
            this.created_at = DateTime.Now;
            this.updated_at = DateTime.Now;
            repo.Save(this);
        }

        public virtual void Update()
        {
            IRepository<User> repo = new UserRepository();
            this.updated_at = DateTime.Now;
            repo.Update(this);
        }

        public static List<User> GetAll()
        {
            IRepository<User> repo = new UserRepository();
            return (List<User>)(repo.GetAll());
        }

        public virtual void Delete()
        {
            IRepository<User> repo = new UserRepository();

            repo.Delete(this);
        }
    }
}
