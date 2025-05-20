using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Addres
    {
        public string? StreetLine1{ get; set; }

        public string? StreetLine2 { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public string? PostalCode { get; set; }

        public string? Country { get; set; }

        public string? AddresType{ get; set; }

       public bool Validate()
        {
            bool isValid = true;
            isValid =
                (StreetLine1 != null) &&
                (StreetLine2 != null) &&
                (City != null) &&
                (State != null) &&
                (PostalCode != null) &&
                (Country != null);
            return isValid;

        }
  
    }
}
