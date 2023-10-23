using System;
using System.Collections.Generic;

namespace WpfApp1.Models
{
    public partial class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Permission { get; set; } = null!;
        public int? GrouppId { get; set; }

        public virtual Groupp? Groupp { get; set; }
    }
}
