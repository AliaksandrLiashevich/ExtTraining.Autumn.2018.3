namespace No2
{
    public class BankStateEventArgs
    {
        public BankStateEventArgs(int _money, string _type)
        {
            Money = _money;

            Type = _type;
        }

        public int Money { get; private set; }
        public string Type { get; private set; }
    }
}
