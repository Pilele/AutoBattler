# AutoBattler – OOP Lernprojekt

Ein kleines Kampfspiel, um die Grundlagen der objektorientierten
Programmierung in C# zu üben: Klassen, Objekte, Properties,
Methoden und Konstruktoren.

## Projekt starten

**Im Terminal** (im Ordner `AutoBattler/AutoBattler/`):
```bash
dotnet run
```

## AutoBattler – Aufgaben

### Übersicht

| Aufgabe | Titel | Datei |
|---|---|---|
| A | Kritischer Treffer | `Models/Spieler.cs` |
| B | Heilen in der Arena | `Models/Arena.cs` |
| C | Leaderboard | `Models/Leaderboard.cs` (neu) + `Program.cs` |
| B1 | Vererbung | `Models/Krieger.cs` + `Models/Magier.cs` (neu) |
| B2 | Kapselung | `Models/Spieler.cs` |

---

### Aufgabe A – Kritischer Treffer

**Datei:** `Models/Spieler.cs` → Methode `Angreifen()`

Ein Angriff soll mit **20% Wahrscheinlichkeit** doppelten Schaden verursachen.
Gebt in der Konsole aus, ob es ein kritischer Treffer war.

**Tipp – Zufallszahl für Wahrscheinlichkeit:**
```csharp
zufall.Next(100) < 20  // ergibt true in 20% der Fälle
zufall.Next(100) < 10  // ergibt true in 10% der Fälle
```

**Erwartetes Verhalten:**
```
Ritter greift Magier an und macht 18 Schaden!
Ritter trifft KRITISCH und macht 36 Schaden!
```

---

### Aufgabe B – Heilen in der Arena

**Datei:** `Models/Arena.cs` → Methode `Kampf()`

Ein Spieler soll in seinem Zug mit **30% Wahrscheinlichkeit** sich selbst heilen,
statt den Gegner anzugreifen. Heilmenge: 15 HP.

**Tipp – Zufallszahl für Wahrscheinlichkeit:**
```csharp
zufall.Next(100) < 30  // ergibt true in 30% der Fälle
```

---

### Aufgabe C – Leaderboard

#### Schritt 1: Neue Klasse erstellen

Erstellt eine neue Datei `Models/Leaderboard.cs` mit folgenden Methoden:

```csharp
public void SiegRegistrieren(string spielerName)  // zählt einen Sieg
public void Anzeigen()                             // gibt die Rangliste aus
```

**Tipp – Dictionary für Siege:**
```csharp
private Dictionary<string, int> siege = new Dictionary<string, int>();
```

#### Schritt 2: Rückgabewert in Arena anpassen

Damit ihr wisst, wer gewonnen hat, muss `Kampf()` den Namen des Gewinners zurückgeben.
Ändert den Rückgabewert von `void` auf `string`:

```csharp
public string Kampf(Spieler spieler1, Spieler spieler2)
{
   ...
}
```

#### Schritt 3: Loop in Program.cs

Ersetzt die einzelne `arena.Kampf()`-Zeile durch einen Loop über 10 Runden.

---

### Aufgabe B1 – Vererbung

#### Schritt 1: Neue Klassen erstellen

Erstellt `Models/Krieger.cs` und `Models/Magier.cs`.
Jede Klasse erbt von `Spieler` und setzt im Konstruktor die Startwerte via `base()`:

#### Schritt 2: Program.cs anpassen

```csharp
Spieler spieler1 = new Krieger("Arthus");
Spieler spieler2 = new Magier("Gandalf");
```

Beachtet: Der Typ der Variable ist `Spieler`, das Objekt selbst ist ein `Krieger` bzw. `Magier`.
`Arena.Kampf()` muss nicht angepasst werden. Es nimmt `Spieler`-Parameter und funktioniert
automatisch mit jedem Typ, der von `Spieler` erbt. Das ist Polymorphismus.

---

### Aufgabe B2 – Kapselung 

#### Das Problem

In `Angreifen()` wird direkt auf `gegner.Leben` zugegriffen:

```csharp
public void Angreifen(Spieler gegner)
{
    gegner.Leben -= Schaden;  // ← direkter Zugriff auf fremde Daten
}
```

Das verletzt Kapselung: `Spieler` verändert die internen Daten eines anderen Objekts.

#### Schritt 1: Leben kapseln

Ändert den Setter von `Leben` auf `private`:

```csharp
public int Leben { get; private set; }
```

#### Schritt 2: Neue Methode SchadenNehmen()

Fügt in `Spieler.cs` eine neue Methode SchadenNehmen(int schaden) hinzu. Die das Leben des Spielers reduziert.

#### Schritt 3: Angreifen() anpassen

Nutze die SchadenNehmen-Methode um das Leben des Gegners zu veringern.

Jetzt entscheidet jeder Spieler selbst, was beim Schaden nehmen passiert.
Von aussen kann `Leben` nur noch gelesen, aber nie direkt gesetzt werden.