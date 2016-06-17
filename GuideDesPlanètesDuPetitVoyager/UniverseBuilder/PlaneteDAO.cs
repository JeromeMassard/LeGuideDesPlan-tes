using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniverseBuilder;
using System.Data.SqlClient;
using System.Data;
using UniverseBuilder.Entites;
using System.Data.OleDb;

namespace UniverseBuilder
{
    public class PlaneteDAO
    {
        public static List<PlaneteEntite> GetAllPlanete()
        {

            string connectionString = GuideDesPlanètesDuPetitVoyager.Utility.GetConnectionString();

            List<PlaneteEntite> listOfPlanete = new List<PlaneteEntite>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM [UniversDATABase].[Planete]";
                using (var command = new SqlCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var planeteE = new PlaneteEntite();
                            planeteE.Nom = reader["PlaneteNom"].ToString();
                            planeteE.Volume = reader["PlaneteVolume"].ToString();
                            planeteE.Masse = reader["PlaneteMasse"].ToString();
                            planeteE.Anneaux = reader["PlaneteAnneaux"].ToString();
                            planeteE.AnnéeDecouverte = reader["PlaneteDecouverte"].ToString();
                            planeteE.NbreSatellite = reader["PlaneteNBSat"].ToString();
                            planeteE.PeriodeRevo = reader["PlanetePeriodeRevo"].ToString();
                            planeteE.PlanIm = reader["PlanetePathIm"].ToString();

                            listOfPlanete.Add(planeteE);
                        }
                    }
                }
                

                connection.Close();
                
                return listOfPlanete;
            }
        }
    }

}