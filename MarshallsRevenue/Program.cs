using static System.Console;

public class MarshallsRevenue
{
    public static void Main()
    {
        int month = 0;
        int interior = 0;
        int exterior = 0;

        // Get month
        while (month < 1 || month > 12)
        {
            try
            {
                Write("Enter month (1-12): ");
                month = Convert.ToInt32(ReadLine());

                if (month < 1 || month > 12)
                    WriteLine("Invalid month.");
            }
            catch
            {
                WriteLine("Please enter a number.");
            }
        }

        // Get interior murals
        while (interior < 0)
        {
            try
            {
                Write("Enter number of interior murals: ");
                interior = Convert.ToInt32(ReadLine());

                if (interior < 0)
                    WriteLine("Cannot be negative.");
            }
            catch
            {
                WriteLine("Please enter a number.");
            }
        }

        // Get exterior murals
        while (exterior < 0)
        {
            try
            {
                Write("Enter number of exterior murals: ");
                exterior = Convert.ToInt32(ReadLine());

                if (exterior < 0)
                    WriteLine("Cannot be negative.");
            }
            catch
            {
                WriteLine("Please enter a number.");
            }
        }

        // Exterior murals are not allowed in Dec, Jan and Feb
        if (month == 12 || month == 1 || month == 2)
        {
            exterior = 0;
            WriteLine("Exterior murals are not available in this month.");
        }

        // Calculate prices
        int interiorPrice = 500;
        int exteriorPrice = 750;

        if (month == 7 || month == 8)
            interiorPrice = 450;

        if (month == 4 || month == 5 ||
            month == 9 || month == 10)
            exteriorPrice = 699;

        int total = (interior * interiorPrice) +
                    (exterior * exteriorPrice);

        WriteLine();
        WriteLine("Expected revenue: $" + total);

        // Create mural objects
        Mural[] murals = new Mural[interior + exterior];

        // Enter customer information
        for (int i = 0; i < murals.Length; i++)
        {
            murals[i] = new Mural();

            Write("Enter customer name: ");
            murals[i].CustomerName = ReadLine();

            WriteLine("L = Landscape");
            WriteLine("S = Seascape");
            WriteLine("A = Abstract");
            WriteLine("C = Children's");
            WriteLine("O = Other");

            bool valid = false;

            while (!valid)
            {
                try
                {
                    Write("Enter mural code: ");
                    string input = ReadLine();

                    if (input.Length != 1)
                        throw new Exception();

                    murals[i].Code = input;

                    if (murals[i].Code == "I")
                        throw new Exception();

                    valid = true;
                }
                catch
                {
                    WriteLine("Invalid mural code. Try again.");
                }
            }
        }

        // Search for customers
        while (true)
        {
            WriteLine();
            WriteLine("L = Landscape");
            WriteLine("S = Seascape");
            WriteLine("A = Abstract");
            WriteLine("C = Children's");
            WriteLine("O = Other");

            Write("Enter code to search or Q to quit: ");
            string search = ReadLine().ToUpper();

            if (search == "Q")
                break;

            try
            {
                if (search.Length != 1)
                    throw new Exception();

                bool validCode = false;

                for (int i = 0; i < Mural.Codes.Length; i++)
                {
                    if (search == Mural.Codes[i])
                        validCode = true;
                }

                if (!validCode)
                    throw new Exception();

                bool found = false;

                for (int i = 0; i < murals.Length; i++)
                {
                    if (murals[i].Code == search)
                    {
                        WriteLine(murals[i].CustomerName);
                        found = true;
                    }
                }

                if (!found)
                    WriteLine("No customers found.");
            }
            catch
            {
                WriteLine("Invalid code.");
            }
        }

        WriteLine("Program ending...");
    }
} 