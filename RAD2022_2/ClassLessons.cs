using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAD2022_2
{
    public class ClassLessons : ILessons
    {
        public System.Collections.Generic.List<string> lessons { get; set; }
        public ClassLessons(System.Collections.Generic.List<string> lessons)
        {
            this.lessons = lessons;
        }
    }
}
