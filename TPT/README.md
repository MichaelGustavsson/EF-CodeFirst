# TPT Table per Type
## Vad är Table per Type?
Syftet med *Table per Type* strategin är att stödja databas  normalisering, vilket enkelt utryckt bland annat skall minimera dubbletter och kolumner med onödiga *null* värden.

### Domän modell

Att ändra ifrån standard beteendet i Entity Framework, det vill säga *Table per Hierarchy* till att få en tabell per klass *Table per Type* är väldigt enkelt. Göra bara nedanstående ändringar på klassdefinitionerna.

```javascript
    [Table("Persons")]
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string  LastName { get; set; }
        public string Email { get; set; }

    }
    
    [Table("Instructors")]
    public class Instructor: Person
    {
        public string MobilePhone { get; set; }
        public int TaughtCourses { get; set; }
        public bool IsActive { get; set; }

    }
    
    [Table("Students")]
    public class Student: Person
    {
        public string CompanyName { get; set; }
    }
    
    public class CourseContext: DbContext
    {
        public DbSet<Person> Person { get; set; }

        public CourseContext(): base("DefaultConnection")
        {

        }
    }
```
[![coursemodel.png](https://i.postimg.cc/ZqZrchHx/coursemodel.png)](https://postimg.cc/5X7Y4TZX)

### Tabell design

När sedan databasen skapas kommer en tabell per klass att definieras se bilden nedan.

[![tabledesign-TPT.png](https://i.postimg.cc/rmYd46zj/tabledesign-TPT.png)](https://postimg.cc/CBkLyQGn)

Varje tabell kommer nu endast att innehålla information om sin egen entitet.

[![tableresult-TPT.png](https://i.postimg.cc/v8rFDrjg/tableresult-TPT.png)](https://postimg.cc/QVdnyTjh)

#### Hantera result av frågor
Att tänka på när vi använder LINQ och ställer frågor via vårt *Object Context* är att vi använder vår basklass för att hämta data ifrån vår database. Vid användandet av TPH så ligger allt data i en och samma tabell med en *discriminator* kolumn som håller reda på vilken härledd klass datat tillhör. Det gör att om vi ställer följande fråga:
 ```
 var result = db.Person.ToList();
 ```
 Så kommer *Entity Framework* automatiskt att mappa datat till korrekta klasser, se bilden nedan.
 
[![base-Query-Result.png](https://i.postimg.cc/pr1W1Dqz/base-Query-Result.png)](https://postimg.cc/H8X1r7Gk)

Detta i sin tur gör att vi måste ange vilken klass vi egentligen vill mappa datat till vid frågetillfället.

```javascript
    var db = new CourseContext();
    var result = db.Person.OfType<Instructor>().ToList();
    var instructors = result.ToList();

    return View(instructors);
```
## Summering
### Fördelar och nackdelar
#### Fördelar
Fördelen med denna strategi är att databasen är normaliserad.
#### Nackdelar
Nackdelen med TPT är att prestandan kan bli lidande om komplexa arvshierarkier används. På grund av att alla frågor kräver *joins* mellan flera tabeller.
