using System;

namespace lab_1
{
    public class CupOfCoffee : HotDrink
    {
        protected string beanType = "арабика";
        public string BeanType
        {
            get { return beanType; }
            set
            {
                if (value.Equals("робуса"))
                    beanType = value;
            }
        }

        public override void Drink()
        {
            Console.WriteLine("Какое вкусное кофе!");
        }

        public override void Refill()
        {
            Console.WriteLine("Повторить кофе {4} объемом {0}\n" +
                              "Молоко: {1}\n" +
                              "Сахар: {2}\n" +
                              "Тип стакана: {3}\n", Capacity, Milk, Sugar, Type, BeanType);
        }

        public override void Wash()
        {
            Console.WriteLine("Вымыть {0} чашку с кофе\n", Type);
        }
    }
}