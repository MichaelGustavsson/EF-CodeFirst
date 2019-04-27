# TPT Table per Type

### Domän modell

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

[![tabledesign-TPT.png](https://i.postimg.cc/rmYd46zj/tabledesign-TPT.png)](https://postimg.cc/CBkLyQGn)

[![tableresult-TPT.png](https://i.postimg.cc/v8rFDrjg/tableresult-TPT.png)](https://postimg.cc/QVdnyTjh)
