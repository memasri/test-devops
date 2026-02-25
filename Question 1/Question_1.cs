using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        List<Item> items = new List<Item>();

        items.Add(new Table(150, 100));
        items.Add(new Paddle(35, 0.45));
        items.Add(new Paddle(50, 0.38));
        items.Add(new Balls(5, 0.006, 3));
	
        foreach(var item in items)
        {
            string template = "Item: {{name}} | Price: {{fullPrice}}";
            
            template = template.Replace("{{name}}", item.GetType().Name);
            template = template.Replace("{{fullPrice}}", item.getFullPrice().ToString());
            
            Console.WriteLine(template);
        }
	
        Console.ReadLine();
    }
}

public abstract class Item
{
    protected int price;
    protected float weight;
    abstract public float getFullPrice();
    public float Weight { get {return weight;} }
}

public class Table : Item
{
    public Table(int price, float weight)
    {
        this.price = price;
        this.weight = weight;
    }

    public override float getFullPrice()
    {
        return price * 1.2;
    }
}

public class Paddle : Item
{
    public Paddle(int price, float wieght)
    {
        this.price = price;
        this.weight = weight;
    }

    public override float getFullPrice()
    {
        return price * 1.2;
    }
}

public class Balls : Item
{
    protected int quantity;
    public Balls(int price, float weight, int quantity)
    {

        this.price = price;
        this.weight = weight;
        this.quantity = quantity;
    }

    public override float getFullPrice()
    {
        return price * 1.2;
    }
}
