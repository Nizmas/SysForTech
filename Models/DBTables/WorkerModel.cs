using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SysTech
{
    public class Worker
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public DateTime Employment { get; set; }
        public string Position { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
    }
}