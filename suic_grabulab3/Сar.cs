using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suic_grabulab3
{
    public class Car
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int DataRelease { get; set; }
        public int Cost { get; set; }
        public string Remark { get; set; }
        public bool IsStock { get; set; }
        public Stock Stock { get; set; }
    }
}
