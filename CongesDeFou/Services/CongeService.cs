using GestionConges.Entities;
using GestionConges.IServices;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace GestionConges.Services
{
    public class CongeService : ICongeService
    {
        private readonly string _connectionString;

        public CongeService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Conge> GetAllConges()
        {
            var conges = new List<Conge>();
            string query = @"
                SELECT c.id, c.idUtilisateur, c.dateDebut, c.dateFin, c.etatConge, u.nom 
                FROM gsb_praticien_ouf_congeutilisateur c
                JOIN gsb_praticien_ouf_utilisateur u ON c.idUtilisateur = u.id";

            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        conges.Add(new Conge
                        {
                            Id = reader.GetInt32(0),
                            IdUtilisateur = reader.GetInt32(1),
                            DateDebut = reader.GetDateTime(2),
                            DateFin = reader.GetDateTime(3),
                            EtatConge = reader.GetString(4)
                        });
                    }
                }   
            }
            return conges;
        }

        public List<Conge> GetCongesByPraticien(int praticienId)
        {
            var conges = new List<Conge>();
            string query = @"
                SELECT c.id, c.idUtilisateur, c.dateDebut, c.dateFin, c.etatConge 
                FROM gsb_praticien_ouf_congeutilisateur c
                WHERE c.idUtilisateur = @id";

            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", praticienId);
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        conges.Add(new Conge
                        {
                            Id = reader.GetInt32(0),
                            IdUtilisateur = reader.GetInt32(1),
                            DateDebut = reader.GetDateTime(2),
                            DateFin = reader.GetDateTime(3),
                            EtatConge = reader.GetString(4)
                        });
                    }
                }
            }
            return conges;
        }

        public bool AjouterConge(Conge conge)
        {
            string query = @"
                INSERT INTO gsb_praticien_ouf_congeutilisateur 
                (idUtilisateur, dateDebut, dateFin, etatConge, motif) 
                VALUES (@idUtilisateur, @dateDebut, @dateFin, 'Attente', @motif)";

            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@idUtilisateur", conge.IdUtilisateur);
                cmd.Parameters.AddWithValue("@dateDebut", conge.DateDebut);
                cmd.Parameters.AddWithValue("@dateFin", conge.DateFin);
                cmd.Parameters.AddWithValue("@motif", conge.Motif ?? (object)DBNull.Value);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool AccepterConge(int congeId)
            => UpdateEtatConge(congeId, "Accepté");

        public bool RefuserConge(int congeId)
            => UpdateEtatConge(congeId, "Refusé");

        public bool AnnulerConge(int congeId)
            => UpdateEtatConge(congeId, "Annulé");

        private bool UpdateEtatConge(int congeId, string etat)
        {
            string query = "UPDATE gsb_praticien_ouf_congeutilisateur SET etatConge = @etat WHERE id = @id";
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@etat", etat);
                cmd.Parameters.AddWithValue("@id", congeId);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}