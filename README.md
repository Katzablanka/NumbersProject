### **Projektziel**
Das Ziel der App ist es, eine vierstellige Zahl darzustellen, ähnlich wie sie auf einem digitalen Display (z. B. einer Uhr) erscheint. Diese Zahlen sollen im zweiten Quadranten eines Koordinatensystems dargestellt werden können und anschließend in die anderen Quadranten gespiegelt werden:
- Spiegelung nach der **x-Achse** (in den dritten Quadranten),
- Spiegelung nach der **y-Achse** (in den vierten Quadranten),
- Spiegelung nach **beiden Achsen** (in den ersten Quadranten).

---

### **Struktur des Projekts**

#### **1. Kleinster Bestandteil der Zahl**
Das kleinste Detail des Projekts basiert auf der Idee, eine Zahl systematisch von ihren einfachsten Bestandteilen aus zu erstellen. Die **kleinste Einheit** ist ein **Digit Display Symbol**. Diese Symbole sind als Enums definiert und können die folgenden Werte annehmen:
- **Pipe**: Ein vertikaler Strich (|),
- **Dash**: Ein horizontaler Strich (–),
- **Space**: Ein leeres Feld.

#### **2. Digit Display**
Jede Zahl wird durch eine **Matrix** aus diesen Symbolen dargestellt, mit einer festen Größe von **5 Zeilen und 4 Spalten**. Ein Dictionary weist den Enums die entsprechenden String-Symbole zu.
Die Datei `DigitDisplay` definiert ein generelles Objekt für alle Ziffern. Es enthält:
- Eine Matrix aus `Digit Display Symbols`, die die Kombinationen aus Dash, Pipe und Space darstellen.
- Methoden wie `SetRightOfPipe`, `SetLeftOfPipe`, `GetBottomDash` und `GetRightPipe`, um die Symbole in der Matrix effizient zu manipulieren.
- Eine Funktion, die es ermöglicht, eine Ziffer zu drucken oder darzustellen.

Beispiel: Die Ziffer **8** ist die am meisten ausgefüllte Ziffer. Sie kann durch Hinzufügen eines Mittelstrichs (Dash) zur Null erstellt werden.

#### **3. Digit-Klassen und -Methoden**
####  Digits**
Zusätzlich wurde ein Enum für alle Ziffern von 0 bis 9 erstellt. Ein Dictionary ordnet diesen Enums die entsprechenden `DigitDisplay`-Objekte zu, die mit den zuvor genannten Methoden erstellt wurden. Dazu werden aber auch Transformations benuzt. Dies ermöglicht die systematische Erstellung aller Ziffern.

---

### **Funktionen und Logik**

#### **Transformationen und Operationen**
Um die digitPartSymbols im Koordinatensystem zu spiegeln und zu manipulieren,(z.b einzehlne Zahl oder ganzes Number) wurden folgende Transformationen implementiert:
- **Inversion nach x:** Spiegelung entlang der x-Achse.
- **Inversion nach y:** Spiegelung entlang der y-Achse.
- **Konkatenation:** Kombination von zwei Matrizen des gleichen Typs.

Diese Transformationen wurden dynamisch typisiert, was bei der Implementierung zusätzliche Recherche erforderte, aber schlussendlich erfolgreich umgesetzt wurde.

Beispiel: Die Ziffer **5** kann durch Spiegelung von **2** dargestellt werden.

#### **Number Operations**
Die Klasse `NumberOperations` dient zur Verwaltung von Zahlen, die aus mehreren Ziffern bestehen. Eine Zahl wird als **Matrix von Digit Part Symbols** dargestellt. Diese Klasse bietet:
- Die Möglichkeit, eine Zahl in der Konsole auszugeben.
- Methoden zur Konvertierung einer Matrix in ein Array von Ziffern.
- Funktionen zur Manipulation und Ersetzung einzelner Ziffern innerhalb einer Zahl.
- Benutzt concatenation

---

### **Zusätzliche Features**
#### **Number Scores Field**
Ein weiteres Objekt wurde hinzugefügt, um zu prüfen, ob bestimmte Quadranten des Koordinatensystems durch die Widerspiegelungen der Zahlen ausgefüllt sind.

---

#### *0 werten ausfühlen*
Wenn man zwischen 1 und 4 Digits eingibt, werden ubrige freie stellen von links nach rechts mit 0 ausgefühlt. Die logic wurde direct in main classe erstellt.

---

### **Zusammenfassung**
Das Projekt basiert auf der flexiblen Darstellung von Ziffern in einer Matrix, wobei jede Zelle entweder leer oder mit einem horizontalen/vertikalen Strich gefüllt ist. Durch die Verwendung von Klassen wie `DigitPartSymbols` und `DigitDisplay` können Ziffern systematisch aufgebaut und für Spiegelungen genutzt werden, um sie in allen Quadranten des Koordinatensystems darzustellen. Ziel ist eine saubere, modulare und wiederverwendbare Struktur.
