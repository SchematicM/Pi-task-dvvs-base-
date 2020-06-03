using System;
using System.Collections.Generic;

namespace Model
{
    public partial class Dbbc
    {
        public Dbbc()
        {
            Dbbctouser = new HashSet<Dbbctouser>();
        }

        public int? Id { get; set; }
        public string TeacherId { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? NumberOfSeats { get; set; }
        public int NumberSetsUsed { get; set; }

        public virtual AspNetUsers Teacher { get; set; }
        public virtual ICollection<Dbbctouser> Dbbctouser { get; set; }
    }
}
