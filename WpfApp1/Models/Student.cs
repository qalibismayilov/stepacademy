using System;
using System.Collections.Generic;

namespace WpfApp1.Models
{
    public partial class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public DateTime? Birthday { get; set; }
        public int? Avarage { get; set; }
        public int? GrouppId { get; set; }

        public virtual Groupp? Groupp { get; set; }
    }
}
