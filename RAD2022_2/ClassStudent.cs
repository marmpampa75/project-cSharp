using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAD2022_2
{
  
    public class ClassStudent : IStudent
    {
        public string age { get; set; }
        public string name { get; set; }
        public string id { get; set; }
        public int index { get; set; }
        public string email { get; set; }
        public ClassStudent(string age, string name, string email, string id, int index)
        {
            this.age = age;
            this.name = name;
            this.id = id;
            this.email = email;
            this.index = index;
        }
    }
}
