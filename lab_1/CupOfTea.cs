using System;

namespace lab_1
{
    public class CupOfTea : HotDrink
    {
        protected string leafType = "черный";
        
        public string LeafType
        {
            get { return leafType; }
            set
            {
                if (value.Equals("зеленый"))
                    leafType = value;
            }
        }

        public override void Drink()
        {
            Console.WriteLine("Какой вкусный чай!");
        }

        public override void Refill()
        {
            Console.WriteLine("Повторить чай {4} объемом {0}\n" +
                              "Молоко: {1}\n" +
                              "Сахар: {2}\n" +
                              "Тип стакана: {3}\n", Capacity, Milk, Sugar, Type, leafType);
        }

        public override void Wash()
        {
            Console.WriteLine("Вымыть {0} чашку с чаем\n", Type);
        }
    }
}