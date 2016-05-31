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
        private int _volume;
        private int _masse;
        private string _anneaux;
        private int _annee;
        private int _periode;
        private int _nbSat;


        public string Image
        {
            get
            {
                return _image;
            }
            set
            {
                _image = value;
            }
        }

        public string Nom { get; set; }

        public int Volume
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

        public int Masse
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

        public int AnnéeDecouverte
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

        public int NbreSatellite
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

        public int PeriodeRevo
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
        public Planete()
        {
                
        }
    }
}

