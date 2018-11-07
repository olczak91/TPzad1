using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public Client(int id, string name, string surname, string email, string address)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Email = email;
            Address = address;
        }

        public override string ToString()
        {
            return string.Format("[{0}] {1} {2} ({3} ; {4})", Id, Name, Surname, Email, Address);
        }

        public override bool Equals(object obj)
        {
            if (obj != null && obj is Client)
            {
                Client clt = obj as Client;
                if (Id == clt.Id)
                    return true;
            }
            return false;
        }
    }
}
