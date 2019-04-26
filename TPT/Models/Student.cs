using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TPT.Models
{
    [Table("Students")]
    public class Student: Person
    {
        public string CompanyName { get; set; }
    }
}