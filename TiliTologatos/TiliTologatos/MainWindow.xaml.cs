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

namespace TiliTologatos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        int[] helyzet = { 1, 2, 3, 4, 5, 6, 7, 8, 0 };
        int[] kesz = { 1, 2, 3, 4, 5, 6, 7, 8, 0 };

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            Button ezGomb = sender as Button;
            Button nullaGomb = (Button)FindName("Button0");

            var fTav = Math.Abs(ezGomb.Margin.Top - nullaGomb.Margin.Top);
            var vTav = Math.Abs(ezGomb.Margin.Left - nullaGomb.Margin.Left);

            int ezGombFelirat = int.Parse(ezGomb.Content.ToString());
            int ezGombIndex = Array.IndexOf(helyzet, ezGombFelirat);
            int nullaGombIndex = Array.IndexOf(helyzet, 0);
        }
    }
}
