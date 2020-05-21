using System;

namespace lab_1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Выберите напиток: кофе <1> или чай <2>: ");
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    ProcessCup(new CupOfCoffee());
                    break;
                case 2:
                    ProcessCup(new CupOfTea());
                    break;
                default:
                    Console.WriteLine("Такого нет");
                    break;
            }
            Console.ReadLine();
        }

        static void ProcessCup(HotDrink drink)
        {
            if (drink is CupOfCoffee)
            {
                CupOfCoffee cup = drink as CupOfCoffee;
                
                Console.WriteLine("Тип зерна: арабика или робуса <по умолчанию арабика>;\n" +
                                  "Сахар: 0...10 <по умолчанию 2>;\n" +
                                  "Молоко: 0...5 <по умолчанию 2>;\n" +
                                  "Тип стакана: пластик или стекло <по умолчанию пластик>;\n" +
                                  "Объем 0,2 или 0,3 <по умолчанию 0,2>;\n");
        
        
                Console.WriteLine("Тип зерна: ");
                cup.BeanType = Console.ReadLine();
                
                Process(cup);
                
                Console.WriteLine("--------------\n" +
                                  "В кофе добавлен сахар: {0}\n" +
                                  "В кофе добавлено молоко: {1}\n" +
                                  "Получите кофе: {2}\n", cup.Sugar, cup.Milk, cup.BeanType);
            }

            if (drink is CupOfTea)
            {
                CupOfTea cup = drink as CupOfTea;
                
                Console.WriteLine("Тип чая: зеленый или черный <по умолчанию черный>;\n" +
                                  "Сахар: 0...10 <по умолчанию 2>\n" +
                                  "Молоко: 0...5 <по умолчанию 2>\n" +
                                  "Тип стакана: пластик или стекло <по умолчанию пластик>\n" +
                                  "Объем 0,2 или 0,3 <по умолчанию 0,2>\n");
                
                Console.WriteLine("Тип чая: ");
                cup.LeafType = Console.ReadLine();
                
                Process(cup);
                
                Console.WriteLine("--------------\n" +
                                  "В чай добавлен сахар: {0}\n" +
                                  "В чай добавлено молоко: {1}\n" +
                                  "Получите чай: {2}\n", cup.Sugar, cup.Milk, cup.LeafType);
            }

            drink.Drink();
            drink.Wash();
            drink.Refill();
        }

        static void Process(HotDrink cup)
        {
            Console.WriteLine("Молоко: ");
            cup.Milk = int.Parse(Console.ReadLine());
            Console.WriteLine("Сахар: ");
            cup.Sugar = int.Parse(Console.ReadLine());
            Console.WriteLine("Тип стакана: ");
            cup.Type = Console.ReadLine();
            Console.WriteLine("Объем <мл>: ");
            cup.Capacity = double.Parse(Console.ReadLine());
        }
    }
}