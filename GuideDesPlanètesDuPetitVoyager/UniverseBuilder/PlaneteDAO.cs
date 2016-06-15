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
           /* string connstr = GuideDesPlanètesDuPetitVoyager.Utility.GetConnectionString();

            string strRecup = "SELECT PlaneteNOM, PlaneteVolume, PlaneteMasse, PlaneteAnneaux, PlaneteDecouverte, PlaneteNBSat, PlanetePeriodeRevo, PlanetePathIm from UniversDATABase.Planete";

            using (SqlConnection connection = new SqlConnection(connstr))
            {
                try
                {
                    /*
                    connection.Open(); // ouverture de la connection
                    MyAdapter = new SqlCommand("SELECT puis reste de la requete", connection);
                    MyAdapter.Fill(MyDataSet, "NomTable");// dataset rempli avec le resultat du dessus
                    MyDataGrid.DataSource = MyDataSet;// Ici MyDataGrid = le nom du private System.Windows.Forms.DataGrid utilisé
                    MyDataGrid.DataMember = "NomTable";// Ici MyDataGrid = le nom du private System.Windows.Forms.DataGrid utilisé
                    Connection.Close();// fermeture de la connection
                    
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
          
             }*/
            return lP;
        }
    }
}
