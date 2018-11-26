using System;

namespace No2
{
    public delegate void BankStateHandler(object sender, BankStateEventArgs e);

    public class Bank : IObserver
    {
        private IObservable stock;

        public string Name { get; set; }

        private event BankStateHandler sells;
        private event BankStateHandler buying;

        public Bank(string name, IObservable observable)
        {
            this.Name = name;
            stock = observable;
            stock.Register(this);
        }

        public void Update(object info)
        {
            var stockInfo = (StockInfo)info;

            if (stockInfo.Euro > 40)
            {
                sells?.Invoke(this, new BankStateEventArgs(stockInfo.Euro, "Bank sels euros"));
            }
            else
            {
                buying?.Invoke(this, new BankStateEventArgs(stockInfo.Euro, "Bank buying euros"));
            }
        }
    }
}
