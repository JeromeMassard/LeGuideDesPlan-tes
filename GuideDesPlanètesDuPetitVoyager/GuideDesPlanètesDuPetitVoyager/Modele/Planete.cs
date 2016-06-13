using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;

namespace GuideDesPlanètesDuPetitVoyager
{
    public class Planete : NotifyPropertyChangedBase
    {
        private string _image;
        private string _volume;
        private string _masse;
        private string _anneaux;
        private string _annee;
        private string _periode;
        private string _nbSat;

        public string PlanIm
        {
            get
            {
                return _image;
            }
            set
            {
                _image = @value;
            }
        }

        public string Nom { get; set; }

        public string Volume
        {
            get
            {
                return _volume;
            }
            set
            {
                _volume = value;
            }
        }

        public string Masse
        {
            get
            {
                return _masse;
            }
            set
            {
                _masse = value;
            }
        }

        public string Anneaux
        {
            get
            {
                return _anneaux;
            }
            set
            {
                _anneaux = value;
            }
        }

        public string AnnéeDecouverte
        {
            get
            {
                return _annee;
            }
            set
            {
                _annee = value;
            }
        }

        public string NbreSatellite
        {
            get
            {
                return _nbSat;
            }
            set
            {
                _nbSat = value;
            }
        }

        public string PeriodeRevo
        {
            get
            {
                return _periode;
            }
            set
            {
                _periode = value;
            }
        }



        public override string ToString()
        {
            return string.Format("{0}", Nom);
        }

        public string Resume()
        {
            return string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}", Nom, Volume, Masse, Anneaux, AnnéeDecouverte, NbreSatellite, PeriodeRevo, PlanIm);
        }
        public Planete()
        {
                
        }
    }
}

