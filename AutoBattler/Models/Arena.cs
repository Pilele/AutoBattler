namespace AutoBattler.Models;

/// <summary>
/// Die Arena steuert den Kampf zwischen zwei Spielern.
/// Sie entscheidet zufällig, wer angreift, und ermittelt am Ende den Gewinner.
/// </summary>
public class Arena
{
    // Wird für die Zufallsentscheidung gebraucht: wer greift als nächstes an?
    private Random zufall = new Random();

    /// <summary>
    /// Lässt zwei Spieler gegeneinander kämpfen, bis einer von beiden besiegt ist.
    /// </summary>
    public void Kampf(Spieler spieler1, Spieler spieler2)
    {
        Console.WriteLine();
        Console.WriteLine($"{spieler1.Name} VS {spieler2.Name}");
        Console.WriteLine("________________________________________");
    }
}
