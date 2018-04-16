using Contoso.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Data
{
    public class PersonRepository: IPersonRepository, IDisposable
    {
        private ContosoContext context;

        public PersonRepository(ContosoContext context)
        {
            this.context = context;
        }

        public IEnumerable<Person> GetPeople()
        {
            return context.People.ToList();
        }

        public Person GetPersonByID(int id)
        {
            return context.People.Find(id);
        }

        public void InsertPerson(Person Person)
        {
            context.People.Add(Person);
        }

        public void DeletePerson(int PersonID)
        {
            Person Person = context.People.Find(PersonID);
            context.People.Remove(Person);
        }

        public void UpdatePerson(Person Person)
        {

            context.Entry(Person).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
