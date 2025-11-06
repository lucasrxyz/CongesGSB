namespace GestionConges.Entities
{
    public class Utilisateur
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Mdp { get; set; }
        public int IdAdmin { get; set; }
        public string Commentaire { get; set; }
    }
}