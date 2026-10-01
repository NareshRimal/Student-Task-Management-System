using static System.Console;

public class TestSoccerPlayer
{
    public static void Main()
    {
        SoccerPlayer player = new SoccerPlayer();

        player.Name = "Lionel Messi";
        player.JerseyNumber = 10;
        player.GoalsScored = 20;
        player.Assists = 15;

        WriteLine("Soccer Player Information");
        WriteLine("-------------------------");
        WriteLine("Name: " + player.Name);
        WriteLine("Jersey Number: " + player.JerseyNumber);
        WriteLine("Goals Scored: " + player.GoalsScored);
        WriteLine("Assists: " + player.Assists);
    }
} 