using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniverseBuilder.Entites
{
    public class PlaneteEntite
    {
        public string Nom { get; set; }

        public int Volume { get; set; }

        public int Masse { get; set; }

        public string Anneaux { get; set; }

        public int AnnéeDecouverte { get; set; }

        public int NbreSatellite { get; set; }

        public int PeriodeRevo { get; set; }

        public string PlanIm { get; set; }
    }
}
