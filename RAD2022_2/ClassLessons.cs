﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAD2022_2
{
    public class ClassLessons : ILessons
    {
        public string[] lessons { get; set; }
        public ClassLessons(string[] lessons)
        {
            this.lessons = lessons;
        }
    }
}
