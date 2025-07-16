using System;
namespace Orders_Online
{
    class OnlineOrder     // Base class
    {
        public int  price = 500; // base product price
        public virtual void TrackStatus()
        {
            Console.WriteLine("Order status: Currently being packed at warehouse.");
        }
        public virtual int CalculateTotal()
        {
            Console.WriteLine("Calculating a standard price of item");
            Console.WriteLine($"Standard Price:{price}");
            return price;  // base price without any extra charge
        }
    }
    class PrepaidOrder : OnlineOrder    // Derived class
    {
        private int shippingCharge = 50;
        public override void TrackStatus()
        {
            Console.WriteLine("[Prepaid Order status]: Your order is shipped,tracking is available.");
        }
        public override int CalculateTotal()
        {
            Console.WriteLine($"Paid Online:{price+shippingCharge}");
            return price + shippingCharge;
        }
    }
    class CodOrder : OnlineOrder
    {
        private int deliveryCharge = 100;
        public override void TrackStatus()
        {
            Console.WriteLine("[COD order status]:Out for delivery.");
        }
        public override int CalculateTotal()
        {
            Console.WriteLine($"Pay on Delivery:{price + deliveryCharge}");
            return price + deliveryCharge;
        }
    }
    class Program
    {
        static void Main()
        {
            Console.WriteLine();

            OnlineOrder order = new OnlineOrder();                      // Base class reference
            order.TrackStatus();
            order.CalculateTotal();

            Console.WriteLine();

            order = new PrepaidOrder();
            order.TrackStatus();
            order.CalculateTotal();                                      // dynamically calls PrepaidOrder

            Console.WriteLine();

            order = new CodOrder();
            order.TrackStatus();
            order.CalculateTotal();                                      // dynamically calls CodOrder

            Console.WriteLine();

        }
    }
}

