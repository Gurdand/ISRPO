namespace lab_1
{
    public abstract class HotDrink : ICup
    {
        protected int sugar = 3;

        public int Sugar
        {
            get { return sugar; }
            set
            {
                if (value < 0) sugar = 0;
                if (value > 10) sugar = 10;
                if (value >= 0 && value <= 10) sugar = value;
            }
        }

        protected int milk = 3;
        public int Milk
        {
            get { return milk; }
            set
            {
                if (value < 0) milk = 0;
                if (value > 5) milk = 5;
                if (value >= 0 && value <= 5) milk = value;
            }
        }

        protected string type = "пластик";
        public string Type
        {
            get { return type; }
            set
            {
                if (value == "стекло")
                    type = value;
            }
        }
        
        protected double capacity = 0.2;
        public double Capacity
        {
            get { return capacity; }
            set
            {
                if (value <= 0.2) capacity = 0.2;
                if (value > 0.2) capacity = 0.3;
            }
        }
        
        public abstract void Drink();
        public abstract void Refill();
        public abstract void Wash();

        public void AddMilk(int milk)
        {
            Milk += milk;
        }

        public void AddSugar(int sugar)
        {
            Sugar += sugar;
        }
    }
}