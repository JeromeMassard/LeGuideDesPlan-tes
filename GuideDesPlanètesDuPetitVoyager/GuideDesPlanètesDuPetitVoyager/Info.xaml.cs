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
    /// Logique d'interaction pour Info.xaml
    /// </summary>
    public partial class Info : Window
    {

        public Info(String infodite)
        {
            InitializeComponent();
            this.info.Text = infodite;
        }

        private void ClickOOK(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
