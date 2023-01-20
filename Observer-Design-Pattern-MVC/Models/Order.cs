using System;
namespace Observer_Design_Pattern_MVC.Models
{
	public class Order
	{
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

        public OrderStatuses OrderStatus { get; set; }


        public List<string> Logs { get; set; } = new List<string>();
    }
}

