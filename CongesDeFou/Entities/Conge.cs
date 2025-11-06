using System;

namespace GestionConges.Entities
{
    public class Conge
    {
        public int Id { get; set; }
        public int IdUtilisateur { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public string EtatConge { get; set; } // Attente, Accepté, Refusé, Annulé
        public string Motif { get; set; }
    }
}