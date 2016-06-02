using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniverseBuilder;
using UniverseBuilder.Entites;

namespace UniverseBuilder
{
    public class PlaneteDAO
    {
        public static List<PlaneteEntite> GetAllPlanete()
        {
            return new List<PlaneteEntite>()
            {
                new PlaneteEntite
                {
                    Nom = "Saturne",
                    Volume = 145,
                    Masse = 2357,
                    Anneaux = 8.ToString(),
                    AnnéeDecouverte = 1975,
                    NbreSatellite = 3,
                    PeriodeRevo = 26,
                    PlanIm = @"PlanIm\sat.jpe"
                },
                new PlaneteEntite
                {
                    Nom = "Terre",
                    Volume = 31321,
                    Masse = 46455,
                    Anneaux = 0.ToString(),
                    AnnéeDecouverte = -650000000,
                    NbreSatellite = 1,
                    PeriodeRevo = 365,
                    PlanIm = @"PlanIm\Ter.jpg"

                },
                new PlaneteEntite
                {
                    Nom = "Neptune",
                    Volume = 354686,
                    Masse = 100,
                    Anneaux = 0.ToString(),
                    AnnéeDecouverte = 1980,
                    NbreSatellite = 5,
                    PeriodeRevo = 560,
                    PlanIm = @"PlanIm\nep.jpe"
                }
            };
        }
    }
}
