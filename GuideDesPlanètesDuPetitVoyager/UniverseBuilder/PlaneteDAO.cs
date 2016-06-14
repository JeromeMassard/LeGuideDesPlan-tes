using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniverseBuilder;
using System.Data.SqlClient;
using System.Data;
using UniverseBuilder.Entites;


namespace UniverseBuilder
{
    public class PlaneteDAO
    {
        public static List<PlaneteEntite> GetAllPlanete()
        {
            List<PlaneteEntite> lP = new List<PlaneteEntite>();
            string connstr = GuideDesPlanètesDuPetitVoyager.Utility.GetConnectionString();

            string strRecup = "SELECT PlaneteNOM, PlaneteVolume, PlaneteMasse, PlaneteAnneaux, PlaneteDecouverte, PlaneteNBSat, PlanetePeriodeRevo, PlanetePathIm from UniversDATABase.Planete";

            using (SqlConnection connection = new SqlConnection(connstr))
            {
                try
                {

                    SqlCommand cmdRecup = new SqlCommand("UniversDATABase.uspPlanete", connection);

                    connection.Open();
                    SqlDataReader read = cmdRecup.ExecuteReader();

                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
          
             }
            return lP;
        }
    }
}
