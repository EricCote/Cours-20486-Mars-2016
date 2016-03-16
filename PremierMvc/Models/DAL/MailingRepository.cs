using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PremierMvc.Models.DAL
{
    public class MailingRepository
    {
        public List<Personne> GetPersonnes()
        {
            List<Personne> personnes = new List<Personne>();

            using (SqlConnection conn = new SqlConnection(
                ConfigurationManager.ConnectionStrings["Mailing"].ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Personnes", conn);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        personnes.Add(new Personne()
                        {
                            PersonneID = (int)dr["PersonneID"],
                            Nom = (string)dr["Nom"],
                            Courriel = (string)dr["Courriel"],
                            DateNaissance = (DateTime)dr["DateNaissance"]
                        });
                    }
                }
            }
            return personnes;
        }
    }
}