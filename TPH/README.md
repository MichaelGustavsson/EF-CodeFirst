# Table per Hierarchy (TPH)

## Vad är Table per Hierarchy
**TPH** eller *Table per Hierarchy* är standard strategin som Entity Framework använder sig av för att skapa tabeller när Entity Framework
upptäcker en arvshierarki mellan klasser. Ta till exempel nedanstående klassdiagram som består av en klass *Person* som ärvs av klasserna *Student* och *Instructor*.

[![coursemodel.png](https://i.postimg.cc/ZqZrchHx/coursemodel.png)](https://postimg.cc/5X7Y4TZX)

### Tabell design

[![tabledesign-TPH.png](https://i.postimg.cc/zGQsb0kN/tabledesign-TPH.png)](https://postimg.cc/v4WqC7j2)

### Tabell resultat

[![tableresult-TPH.png](https://i.postimg.cc/QdvzxVXx/tableresult-TPH.png)](https://postimg.cc/21FG0kbP)
