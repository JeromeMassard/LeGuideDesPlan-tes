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
using System.Windows.Navigation;
using System.Windows.Shapes;
using GuideDesPlanètesDuPetitVoyager.ViewModels;

namespace GuideDesPlanètesDuPetitVoyager
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ListPlanete _viewModelUnivers;


        public List<Planete> lPlanete { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            _viewModelUnivers = new ListPlanete();
            DataContext = _viewModelUnivers;
        }

    }
}
