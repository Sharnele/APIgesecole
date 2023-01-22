using System;
using System.Collections.Generic;

namespace APIgesecole.Models
{
    public partial class Etudiant
    {
        public Etudiant()
        {
            Participants = new HashSet<Participant>();
        }

        public int Id { get; set; }
        public string? Matricule { get; set; }
        public string? Nom { get; set; }
        public int? Telephone { get; set; }

        public virtual ICollection<Participant> Participants { get; set; }
    }
}
