using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace GuideDesPlanètesDuPetitVoyager
{
    internal class Utility
    {
        //recupère le chemin de connection du du fichier de configuration App
        internal static string GetConnectionString()
        {
            string returnValue = null;

            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["UniversDATABase.Properties.Settings.connString"];

            if (settings != null)
                returnValue = settings.ConnectionString;
            return returnValue;
        }

    }
}
