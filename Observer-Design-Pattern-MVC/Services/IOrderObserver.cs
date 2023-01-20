using System;
using Observer_Design_Pattern_MVC.Models;

namespace Observer_Design_Pattern_MVC.Services
{
	public interface IOrderObserver
	{
        void Update(Order order);
    }
}

