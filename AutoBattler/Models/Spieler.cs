namespace AutoBattler.Models;

/// <summary>
/// Die Klasse Spieler ist der Bauplan für einen Kämpfer im AutoBattler.
/// Sie beschreibt, welche Eigenschaften ein Spieler hat (Name, Leben, Schaden)
/// und was er tun kann (Angreifen, Heilen).
/// </summary>
public class Spieler
{
    public string Name { get; set; }
    public int Leben { get; private set; }
    public int MaxLeben { get; set; }
    public int Schaden { get; set; }

    /// <summary>
    /// Gibt zurück, ob der Spieler noch am Leben ist.
    /// </summary>
    public bool IstAmLeben => Leben > 0;

    public Spieler(string name, int maxLeben, int schaden)
    {
        Name = name;
        MaxLeben = maxLeben;
        Leben = MaxLeben;
        Schaden = schaden;
    }

    /// <summary>
    /// Greift einen Gegner an und zieht ihm Schaden ab.
    /// </summary>
    public void Angreifen(Spieler gegner)
    {
        Console.WriteLine($"{Name} greift {gegner.Name} an und macht {Schaden} Schaden!");

        gegner.Leben -= Schaden;

        if (gegner.Leben < 0)
        {
            gegner.Leben = 0;
        }
    }


    /// <summary>
    /// Heilt den Spieler um einen bestimmten Betrag, maximal bis MaxLeben.
    /// </summary>
    public void Heilen(int heilmenge)
    {
        int geheilt = heilmenge;

        if (Leben + heilmenge > MaxLeben)
        {
            geheilt = MaxLeben - Leben;
        }

        Leben += geheilt;
        Console.WriteLine($"{Name} heilt sich um {geheilt} HP.");
    }

    /// <summary>
    /// Zeigt den aktuellen Status des Spielers inklusive Lebensbalken an.
    /// </summary>
    public void StatusAnzeigen()
    {
        string balken = LebensbalkenErstellen();
        Console.WriteLine($"{Name,-10} {Leben,3}/{MaxLeben,-3} HP {balken}");
    }


    private string LebensbalkenErstellen()
    {
        int balkenLaenge = 10;
        int gefuellt = (int)Math.Round((double)Leben / MaxLeben * balkenLaenge);
        if (gefuellt < 0)
        {
            gefuellt = 0;
        }

        return "[" + new string('#', gefuellt) + new string('-', balkenLaenge - gefuellt) + "]";
    }
}
