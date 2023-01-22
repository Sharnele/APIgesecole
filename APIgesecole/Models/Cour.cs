using System;
using System.Collections.Generic;

namespace APIgesecole.Models
{
    public partial class Cour
    {
        public Cour()
        {
            Participants = new HashSet<Participant>();
        }

        public int Id { get; set; }
        public string? Nom { get; set; }

        public virtual ICollection<Participant> Participants { get; set; }
    }
}
