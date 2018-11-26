using System;

namespace No2
{
    public delegate void BrokerStateHandler(object sender, BankStateEventArgs e);

    public class Broker : IObserver
    {
        private IObservable stock;

        public string Name { get; set; }

        private event BrokerStateHandler sells;
        private event BrokerStateHandler buying;

        public Broker(string name, IObservable observable)
        {
            this.Name = name;
            stock = observable;
            stock.Register(this);
        }

        public void Update(object info)
        {
            StockInfo stockInfo = (StockInfo)info;

            if (stockInfo.USD > 30)
            {
                sells?.Invoke(this, new BankStateEventArgs(stockInfo.USD, "Broker sels euros"));
            }
            else
            {
                buying?.Invoke(this, new BankStateEventArgs(stockInfo.USD, "Broker buying euros");
            }
        }

        public void StopTrade()
        {
            stock.Unregister(this);
            stock = null;
        }
    }
}
