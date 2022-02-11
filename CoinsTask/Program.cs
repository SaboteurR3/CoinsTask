using System;
using System.Collections.Generic;
using System.Linq;

namespace CoinsTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter amount of money (in cents)");
            double inputMoney = double.Parse(Console.ReadLine());
            Coins(inputMoney);
        }
        static void Coins(double input)
        {
            double oneCoin = 1;
            double fiveCoin = 5;
            double tenCoin = 10;
            double twentyCoin = 20;
            double fiftyCoin = 50;
            List<double> coins = new List<double>()
            {
                 fiftyCoin, fiveCoin, oneCoin, tenCoin, twentyCoin
            };
            // sort List by descending order
            var itemMoved = false;
            do
            {
                itemMoved = false;
                for (int i = 0; i < coins.Count() - 1; i++)
                {
                    if (coins[i] < coins[i + 1])
                    {
                        var lowerValue = coins[i + 1];
                        coins[i + 1] = coins[i];
                        coins[i] = lowerValue;
                        itemMoved = true;
                    }
                }
            } while (itemMoved);
            // counts minumum coin quantity
            double savedCoin = 0;
            for (int i = 0; i < coins.Count; i++)
            {

                if (!(input < coins[i]))
                {
                    if (input % coins[i] != 0)
                    {
                        while (coins[i] < input)
                        {
                            savedCoin++;
                            input -= coins[i];
                        }
                    }
                    else if (input % coins[i] == 0)
                    {
                        savedCoin = savedCoin + (input / coins[i]);
                        i = coins.Count;
                    }
                }
            }
            Console.WriteLine($"Minimum amount of coins that you need to exchange is: {savedCoin}");
        }
    }
}