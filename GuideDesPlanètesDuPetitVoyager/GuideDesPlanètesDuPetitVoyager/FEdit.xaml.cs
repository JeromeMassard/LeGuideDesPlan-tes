using GuideDesPlanètesDuPetitVoyager.ViewModels;
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

namespace GuideDesPlanètesDuPetitVoyager
{
    /// <summary>
    /// Logique d'interaction pour FEdit.xaml
    /// </summary>
    public partial class FEdit : Window
    {
        public AjoutPlanete ViewModelEdit;
        public FEdit(Planete _planete)
        {
            InitializeComponent();
            ViewModelEdit = new AjoutPlanete(_planete);
            DataContext = ViewModelEdit;
        }
    }
}
