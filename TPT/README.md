# TPT Table per Type
## Varför?
Syftet med *Table per Type* strategin är att stödja databas  normalisering, vilket enkelt utryckt bland annat skall minimera dubbletter och kolumner med onödiga *null* värden.

### Domän modell

Att ändra ifrån standard beteendet i Entity Framework, det vill säga *Table per Hierarchy* till att få en tabell per klass *Table per Type* är väldigt enkelt. Göra bara nedanstående ändringar på klassdefinitionerna.

```
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
