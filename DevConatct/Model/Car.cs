using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevConatct.Model
{
    public class Car:BaseEntity
    {
        public string Ownername { get; set; } = string.Empty;
        public string Registration { get; set; } = string.Empty;
        public int Type { get; set; } =0;//Car=1; Truck=2
    }
}
