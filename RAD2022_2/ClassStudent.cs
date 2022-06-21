using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAD2022_2
{
  
    public class ClassStudent : IStudent
    {
        public int age { get; set; }
        public string name { get; set; }
        public string id { get; set; }
        public string email { get; set; }
        public ClassStudent(int age, string name, string email, string id)
        {
            this.age = age;
            this.name = name;
            this.id = id;
            this.email = email;
        }
    }
}
