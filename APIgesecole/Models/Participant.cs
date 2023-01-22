using System;
using System.Collections.Generic;

namespace APIgesecole.Models
{
    public partial class Participant
    {
        public int Id { get; set; }
        public int? Idcour { get; set; }
        public int? Idetudiant { get; set; }
        public DateTime? Datep { get; set; }

        public virtual Cour? IdcourNavigation { get; set; }
        public virtual Etudiant? IdetudiantNavigation { get; set; }
    }
}
