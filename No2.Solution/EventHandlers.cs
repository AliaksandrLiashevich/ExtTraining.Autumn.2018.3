using System;

namespace No2
{
    public static class EventHandlers
    {
        public static void BankSells(object sender, BankStateEventArgs e)
        {
            Console.WriteLine(e.Type + ":" + e.Money);
        }

        public static void BankBuying(object sender, BankStateEventArgs e)
        {
            Console.WriteLine(e.Type + ":" + e.Money);
        }

        public static void BrokerSells(object sender, BankStateEventArgs e)
        {
            Console.WriteLine(e.Type + ":" + e.Money);
        }

        public static void BrokerBuying(object sender, BankStateEventArgs e)
        {
            Console.WriteLine(e.Type + ":" + e.Money);
        }

    }
}
