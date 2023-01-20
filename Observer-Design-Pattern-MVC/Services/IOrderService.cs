using System;
using Observer_Design_Pattern_MVC.Models;

namespace Observer_Design_Pattern_MVC.Services
{
	public interface IOrderService : IOrderNotifier
    {
        void UpdateOrder(Order order);
    }
}

