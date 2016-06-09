using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using GuideDesPlanètesDuPetitVoyager.Event;
using GuideDesPlanètesDuPetitVoyager.ViewModels;


namespace GuideDesPlanètesDuPetitVoyager
{
    /// <summary>
    /// Logique d'interaction pour BoiteDeDialogue.xaml
    /// </summary>
    public partial class BoiteDeDialogue : Window
    {

        public InfoBD ViewModelInfo;

        public BoiteDeDialogue(String dem)
        {
            InitializeComponent();
            this.demande.Text = dem;
            ViewModelInfo = new InfoBD();
            DataContext = ViewModelInfo;
        }
    }
}
