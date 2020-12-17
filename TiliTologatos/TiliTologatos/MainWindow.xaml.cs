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
        int lepesekszam = 0;
        byte[,] Tilehelyzet;
        UIElementCollection Tilitolielemek;

        public MainWindow()
        {
            InitializeComponent();
            Tilitolielemek = elemTartó.Children;
            Ujjatek();
        }

        public void Ujjatek()
        {
            lepesekszam = 0;

            Tilehelyzet = new byte[,]
            {
                {0,1,2},{3,4,5},{6,7,8}
            };
            Shuffle();
            UpdateUI();


        }
        void Shuffle()
        {
            Random r = new Random();

            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    int[] shuffleTarget = { r.Next(0, 3), r.Next(0, 3) };

                    byte a = Tilehelyzet[x, y];
                    byte b = Tilehelyzet[shuffleTarget[0], shuffleTarget[1]];

                    Tilehelyzet[shuffleTarget[0], shuffleTarget[1]] = a;
                    Tilehelyzet[x, y] = b;
                }
            }
        }

        void UpdateUI()
        {
            byte[] flatArray = Tilehelyzet.Cast<byte>().ToArray();
            for(int i = 0; i < 9; i++)
            {
                if (flatArray[i] == 0)
                    (Tilitolielemek[i] as Button).Visibility = Visibility.Hidden;
                else
                {
                    (Tilitolielemek[i] as Button).Visibility = Visibility.Visible;
                    (Tilitolielemek[i] as Button).Content = flatArray[i].ToString();
                }
            }

            lepesek.Text = lepesekszam.ToString();
        }

        bool CheckWin()
        {

            List<byte> tempsorted = Tilehelyzet.Cast<byte>().ToList();
            tempsorted.Sort();
            tempsorted.RemoveAt(0);
            List<byte> tempbase = Tilehelyzet.Cast<byte>().ToList();

            tempbase.RemoveAt(8);

            for (int i = 0; i < 8; i++)
            {
                if (tempsorted[i] != tempbase[i]) return false;
            }

            return true;
        }

        void ButtonClick(int index)
        {

            int[] i = { index / 3, index % 3 };



            if (i[0] != 0 && Tilehelyzet[i[0] - 1, i[1]] == 0)
            {
                byte a = Tilehelyzet[i[0], i[1]];
                byte b = Tilehelyzet[i[0] - 1, i[1]];

                Tilehelyzet[i[0] - 1, i[1]] = a;
                Tilehelyzet[i[0], i[1]] = b;
            }

            else if (i[0] != 2 && Tilehelyzet[i[0] + 1, i[1]] == 0)
            {
                byte a = Tilehelyzet[i[0], i[1]];
                byte b = Tilehelyzet[i[0] + 1, i[1]];

                Tilehelyzet[i[0] + 1, i[1]] = a;
                Tilehelyzet[i[0], i[1]] = b;
            }

            else if (i[1] != 0 && Tilehelyzet[i[0], i[1] - 1] == 0)
            {
                byte a = Tilehelyzet[i[0], i[1]];
                byte b = Tilehelyzet[i[0], i[1] - 1];

                Tilehelyzet[i[0], i[1] - 1] = a;
                Tilehelyzet[i[0], i[1]] = b;
            }

            else if (i[1] != 2 && Tilehelyzet[i[0], i[1] + 1] == 0)
            {
                byte a = Tilehelyzet[i[0], i[1]];
                byte b = Tilehelyzet[i[0], i[1] + 1];

                Tilehelyzet[i[0], i[1] + 1] = a;
                Tilehelyzet[i[0], i[1]] = b;
            }
            else
            {

                lepesekszam--;
            }

            lepesekszam++;
            UpdateUI();

            if (CheckWin())
            {
                foreach (var button in Tilitolielemek)
                {
                    (button as Button).IsEnabled = false;
                    Winner.Visibility = Visibility.Visible;
                }
            }
        }
        private void newgame_Click(object sender, RoutedEventArgs e)
        {
            Ujjatek();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ButtonClick(0);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ButtonClick(1);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ButtonClick(2);

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            ButtonClick(3);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            ButtonClick(4);
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            ButtonClick(5);
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            ButtonClick(6);
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            ButtonClick(7);
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            ButtonClick(8);
        }
    }
}
