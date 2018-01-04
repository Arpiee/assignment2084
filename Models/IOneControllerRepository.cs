using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2.Models
{
    // repository for mock phone data fot unit testing
  public  interface IOneControllerRepository
    {
        IQueryable<phone> phones { get; }
            
        phone Save(phone phone);

        void Delete(phone phone);
    }
}
