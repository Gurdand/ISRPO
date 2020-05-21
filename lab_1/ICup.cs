namespace lab_1
{
    public interface ICup
    {
        void Refill();
        void Wash();

        string Type { get; set; }
        double Capacity { get; set; }
    }
}