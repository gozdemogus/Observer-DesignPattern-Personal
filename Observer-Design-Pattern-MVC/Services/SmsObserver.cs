using System;
using Observer_Design_Pattern_MVC.Models;

namespace Observer_Design_Pattern_MVC.Services
{
    public class SmsObserver : IOrderObserver
    {
        public void Update(Order order)
        {
            Console.WriteLine("Siparis numarası '{0}' olan siparisin statusu '{1}' olarak guncellendi. Musteriye bir SMS gonderildi.",
                order.OrderNumber, order.OrderStatus.ToString());

            order.Logs.Add(string.Format("Siparis numarası '{0}' olan siparisin statusu '{1}' olarak guncellendi. Musteriye bir sms gonderildi.",
               order.OrderNumber, order.OrderStatus.ToString()));
        }
    }
}

