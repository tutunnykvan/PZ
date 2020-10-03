using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public Byte[] Password { get; set; }
        public int PersonId { get; set; }
    }
}
