using System;

class Restaurant
{
    public virtual void ShowMenu()
    {
        Console.WriteLine("Restaurant Menu:");
    }

    public virtual int CalculateBill(int choice, int quantity)
    {
        return 0;          
    }
}

class VegRestaurant : Restaurant
{
    public override void ShowMenu()
    {
        Console.WriteLine("Welcome to Annapoorna Veg Restaurant");
        Console.WriteLine("1. Idli  – ₹20");
        Console.WriteLine("2. Dosa  – ₹40");
        Console.WriteLine("3. Meals – ₹80");
        Console.WriteLine("4. Finish order");
    }

    public override int CalculateBill(int choice, int quantity)
    {
        int price = 0;

        switch (choice)
        {
            case 1: price = 20; break;
            case 2: price = 40; break;
            case 3: price = 80; break;
            default: Console.WriteLine("Invalid item."); 
            break; // If user enters invalid item number
        }

        // Total cost = price × quantity
        return price * quantity;
    }
}

class NonVegRestaurant : Restaurant
{
    public override void ShowMenu()
    {
        Console.WriteLine("Welcome to Empire Non‑Veg Restaurant");
        Console.WriteLine("1. Chicken Biryani – ₹120");
        Console.WriteLine("2. Mutton Curry    – ₹180");
        Console.WriteLine("3. Fish Fry        – ₹150");
        Console.WriteLine("4. Finish order");
    }

    public override int CalculateBill(int choice, int quantity)
    {
        int price = 0;

        switch (choice)
        {
            case 1: price = 120; break;
            case 2: price = 180; break;
            case 3: price = 150; break;
            default: Console.WriteLine("Invalid item."); break;
        }

        return price * quantity;
    }
}

class IndoChineseRestaurant : Restaurant
{
    public override void ShowMenu()
    {
        Console.WriteLine("Welcome to Dragon Spice Indo‑Chinese Restaurant");
        Console.WriteLine("1. Veg Noodles       – ₹90");
        Console.WriteLine("2. Chicken Manchurian – ₹140");
        Console.WriteLine("3. Fried Rice        – ₹100");
        Console.WriteLine("4. Finish order");
    }

    public override int CalculateBill(int choice, int quantity)
    {
        int price = 0;

        switch (choice)
        {
            case 1: price = 90; break;
            case 2: price = 140; break;
            case 3: price = 100; break;
            default: Console.WriteLine("Invalid item."); break;
        }

        return price * quantity;
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        Console.WriteLine(" 🍲 Soup");

        Console.WriteLine("Select Restaurant:");
        Console.WriteLine("1.🟢 Veg Restaurant");
        Console.WriteLine("2.🔴 Non‑Veg Restaurant");
        Console.WriteLine("3.🥢 Indo‑Chinese Restaurant");

        // Read user's choice (1, 2 or 3)
        int Choice = Convert.ToInt32(Console.ReadLine());


        // Restaurant Restaurant1=new VegRestaurant();
        //Restaurant Restaurant2=new VegRestaurant();
        // Declare a variable of base class type that will point to any derived restaurant object
        Restaurant selectedRestaurant;

        switch (Choice)
        {
            case 1: selectedRestaurant = new VegRestaurant(); break;
            case 2: selectedRestaurant = new NonVegRestaurant(); break;
            case 3: selectedRestaurant = new IndoChineseRestaurant(); break;
            default:
                Console.WriteLine("Invalid restaurant selection.");
                return; // Exit the program if user entered anything other than 1, 2, or 3
        }

        int grandTotal = 0;

        // Start an infinite loop to take multiple orders
        while (true)
        {
            selectedRestaurant.ShowMenu();

            Console.WriteLine("\nChoose an item (4 to finish): ");
            int itemChoice = Convert.ToInt32(Console.ReadLine());

           
            if (itemChoice == 4) break;     // If user enters 4, finish ordering and break the loop

            Console.WriteLine("Quantity: ");
            int qty = Convert.ToInt32(Console.ReadLine());

            int itemTotal = selectedRestaurant.CalculateBill(itemChoice, qty);

            grandTotal = grandTotal + itemTotal;

            Console.WriteLine($"Item total: ₹{itemTotal}\n");
        }

        Console.WriteLine($"\nGRAND TOTAL: ₹{grandTotal}");
    }
}
