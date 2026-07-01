using AutoBattler.Models;

Console.WriteLine("========================================");
Console.WriteLine("AUTO BATTLER");
Console.WriteLine("========================================");
Console.WriteLine();

Arena arena = new Arena();

Spieler spieler1 = new Spieler("Krieger", 100, 20);
Spieler spieler2 = new Spieler("Magier", 80, 25);

arena.Kampf(spieler1, spieler2);

