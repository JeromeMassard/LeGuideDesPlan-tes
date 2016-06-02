using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuideDesPlanètesDuPetitVoyager.ViewModels;
using GuideDesPlanètesDuPetitVoyager;
using UniverseBuilder.Entites;
using Library;

namespace GuideDesPlanètesDuPetitVoyager.Maker
{
    public static class PlaneteMaker
    {
        public static Planete PlaneteEntiteToPlaneteModele(PlaneteEntite planete)
        {
            return new Planete
            {
                Nom = planete.Nom,
                Volume = planete.Volume,
                Masse = planete.Masse,
                Anneaux = planete.Anneaux,
                AnnéeDecouverte = planete.AnnéeDecouverte,
                NbreSatellite = planete.NbreSatellite,
                PeriodeRevo = planete.PeriodeRevo,
                PlanIm = planete.PlanIm
            };
        }

        public static List<Planete> AllPlaneteEntiteToPlanete(List<PlaneteEntite> list)
        {
            return list.Select(PlaneteEntiteToPlaneteModele).ToList();
        }


    }
}
