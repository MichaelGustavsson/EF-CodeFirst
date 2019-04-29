# Table per Hierarchy (TPH)

## Vad är Table per Hierarchy?
**TPH** eller *Table per Hierarchy* är standard strategin som Entity Framework använder sig av för att skapa tabeller när Entity Framework
upptäcker en arvshierarki mellan klasser. Ta till exempel nedanstående klassdiagram som består av en klass *Person* som ärvs av klasserna *Student* och *Instructor*.

[![coursemodel.png](https://i.postimg.cc/ZqZrchHx/coursemodel.png)](https://postimg.cc/5X7Y4TZX)

Arv är ett vanligt scenario i objektorienterad programmering för att definiera att en klass är en *typ* av en annan klass, men något specialiserad. En *Instructor* är en typ av *Person*, vilket även en *Student* är. Båda två har egenskaperna *FirstName*, *LastName* och *Email*, men *Instructor* har behov av några fler egenskaper som är *speciellt* för en instruktör. *Student* klassen har också behov av en egenskap *CompanyName* som endast behövs i *Student* klassen.
Istället för att upprepa egenskaperna *FirstName*, *LastName* och *Email* i respektive klass. Så bryts dessa ur och placeras i en separat klass, i detta fall klassen *Person*. Vilken både *Student* och *Instructor* klasserna ärver ifrån.

```javascript
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string  LastName { get; set; }
        public string Email { get; set; }

    }
    
    public class Student: Person
    {
        public string CompanyName { get; set; }
    }
    
    public class Instructor: Person
    {
        public string MobilePhone { get; set; }
        public int TaughtCourses { get; set; }
        public bool IsActive { get; set; }

    }
    
```

### Database Context
För att generera databasstrukturen med Entity Framework *Code First* behöver vi skapa en klass som ärver ifrån *DbContext* klassen som finns i *System.Data.Entity* namnutrymmet.

```javascript
    public class CourseContext: DbContext
    {
        public DbSet<Person> Person { get; set; }

        public CourseContext(): base("DefaultConnection")
        {

        }
    }
```

### Tabell design

Ovanstående kod kommer att generera följande tabellstruktur, se bild nedan.
Tabellen består av fält som är kombinerade ifrån alla tre klasserna. Dessutom skapar Entity Framework ett extra fält för att definiera  vilken klass som informationen härrör ifrån. Se bilden tabell resultat.

[![tabledesign-TPH.png](https://i.postimg.cc/zGQsb0kN/tabledesign-TPH.png)](https://postimg.cc/v4WqC7j2)

#### Tabell resultat

[![tableresult-TPH.png](https://i.postimg.cc/QdvzxVXx/tableresult-TPH.png)](https://postimg.cc/21FG0kbP)

#### Hantera result av frågor
[![base-Query-Result.png](https://i.postimg.cc/pr1W1Dqz/base-Query-Result.png)](https://postimg.cc/H8X1r7Gk)

### Fördelar och nackdelar
#### Fördelar
Fördelen med denna strategi är dess enkelhet och prestanda. Det behövs inga komplexa *joins* mellan tabeller för att hämta data. Databasen är i princip denormaliserad.
#### Nackdelar
Den största nackdelen är att strategin inte följer databas normaliseringskraven. Vilket leder till och innebär mycket dubbletter och många fält som kommer att innehålla *null* värden. Förmodligen är detta ingen strategi som någon databas administratör kommer att godkänna.
