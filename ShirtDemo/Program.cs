using static System.Console;

public class ShirtDemo
{
    public static void Main()
    {
        Shirt shirt1 = new Shirt();
        shirt1.Material = "Cotton";
        shirt1.Color = "Blue";
        shirt1.Size = "M";

        Shirt shirt2 = new Shirt();
        shirt2.Material = "Polyester";
        shirt2.Color = "Black";
        shirt2.Size = "L";

        Shirt shirt3 = new Shirt();
        shirt3.Material = "Wool";
        shirt3.Color = "White";
        shirt3.Size = "S";

        Display(shirt1);
        Display(shirt1, shirt2);
        Display(shirt1, shirt2, shirt3);
    }

    public static void Display(params Shirt[] shirts)
    {
        foreach (Shirt shirt in shirts)
        {
            WriteLine("Material: " + shirt.Material);
            WriteLine("Color: " + shirt.Color);
            WriteLine("Size: " + shirt.Size);
            WriteLine();
        }

        WriteLine("----------------------");
    }
} 