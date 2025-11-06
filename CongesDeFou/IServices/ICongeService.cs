using GestionConges.Entities;
using System.Collections.Generic;

namespace GestionConges.IServices
{
    public interface ICongeService
    {
        List<Conge> GetCongesByPraticien(int praticienId);
        List<Conge> GetAllConges();
        bool AjouterConge(Conge conge);
        bool AccepterConge(int congeId);
        bool RefuserConge(int congeId);
        bool AnnulerConge(int congeId);
    }
}