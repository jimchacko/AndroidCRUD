using System;
using System.Collections.Generic;
using System.Text;

namespace CRUDXamarian
{
  public   class Employee
    {
        public int Id { get; set; }
       
        public string Name { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }
        public string Company { get; set; }
        public string Designation { get; set; }

        public override string ToString()
        {
            return this.Name + "(" + this.Email + ")";
        }
    }
}
