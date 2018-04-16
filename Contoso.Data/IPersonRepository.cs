using Contoso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Data
{
    interface IPersonRepository: IDisposable
    {
        IEnumerable<Person> GetPeople();
        Person GetPersonByID(int PersonId);
        void InsertPerson(Person Person);
        void DeletePerson(int PersonID);
        void UpdatePerson(Person Person);
        void Save();
    }
}
