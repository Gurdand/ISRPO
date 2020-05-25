using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2
{
    class Coffee
    {
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
        }
        private int price;
        public int Price
        {
            get
            {
                return price;
            }
        }

        public Coffee(string name, int price)
        {
            this.name = name;
            this.price = price;
        }
    }
}
