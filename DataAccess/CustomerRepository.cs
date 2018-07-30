using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class CustomerRepository : GenericRepository<Customer>
    {
        private ShoppingMeEntities entities = null;
        public CustomerRepository()
        {
            entities = new ShoppingMeEntities();
        }

        public bool Add(Customer obj)
        {
            var result = entities.Customers.Add(obj);
            entities.SaveChanges();
            return result != null ? true : false;
        }

        public bool Update(Customer obj)
        {
            var result = entities.Customers.Where(x => x.CustomerId == obj.CustomerId).FirstOrDefault();
            result.FirstName = obj.FirstName;
            result.LastName = obj.LastName;
            result.Mobile = obj.Mobile;
            result.Password = obj.Password;
            entities.SaveChanges();
            return true;
            //result.ModifiedDate = obj.ModifiedDate;
        }

        public bool Delete(int id)
        {
            var result = entities.Customers.Where(x => x.CustomerId == id).FirstOrDefault();

            if (result != null)
            {
                entities.Customers.Remove(result);
                entities.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public Customer Get(int id)
        {
            var result = entities.Customers.Where(x => x.CustomerId == id).FirstOrDefault();
            if (result != null)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public Customer GetByEmail(string email)
        {
            var result = entities.Customers.Where(x => x.Email == email).FirstOrDefault();
            if (result != null)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public Customer ValidateCredentialByEmailAndPassword(string email, string password)
        {
            var result = entities.Customers.Where(x => x.Email == email && x.Password == password).FirstOrDefault();
            if (result != null)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public List<Customer> GetAll()
        {
            return entities.Customers.ToList();
        }
    }
}