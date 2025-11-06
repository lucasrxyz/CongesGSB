namespace GestionConges.Entities
{
    public class Praticien
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Adresse { get; set; }
        public string CodePostal { get; set; }
        public string CodeVille { get; set; }
        public double? Salaire { get; set; }
        public string CodeTypePraticien { get; set; }
        public int? IdVille { get; set; }
    }
}