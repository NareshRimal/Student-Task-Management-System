public class Mural
{
    public static string[] Codes = { "L", "S", "A", "C", "O" };

    public static string[] Descriptions =
    {
        "Landscape",
        "Seascape",
        "Abstract",
        "Children's",
        "Other"
    };

    public string CustomerName { get; set; }

    private string code;

    public string Code
    {
        get
        {
            return code;
        }
        set
        {
            code = "I";

            for (int i = 0; i < Codes.Length; i++)
            {
                if (value.ToUpper() == Codes[i])
                {
                    code = Codes[i];
                }
            }
        }
    }

    public string Description
    {
        get
        {
            for (int i = 0; i < Codes.Length; i++)
            {
                if (code == Codes[i])
                {
                    return Descriptions[i];
                }
            }

            return "Invalid";
        }
    }
} 