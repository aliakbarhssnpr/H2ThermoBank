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


namespace H2ThermoBank
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

        private void getDataClick(object sender, RoutedEventArgs e)
        {
           
           
            try
            {

                int  p = 0;
                int t = 0;

                p = (int) Math.Floor(double.Parse(P.Text));
                t = (int) double.Parse(T.Text);

                int comp = compUnit.SelectedIndex;
                int fraction = fracUnit.SelectedIndex;


                int lineN = comp*8080+(fraction * 1616) + p*16 + (int) (15- (500-t)/20) ;

                string test = AppDomain.CurrentDomain.BaseDirectory + "Data.txt";
                string[] lines = System.IO.File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "Data.txt");
                string [] words = lines[lineN].Split('\t');

                bool flaq = false;

                if (lineN < 8080 * 2)
                    flaq = true;
                if (words.Length > 8)
                    if (words[8] == "1")
                        flaq = true;


                if (flaq)
                {
                    gDensity.Text = words[2];
                    gViscosity.Text = words[3];
                    gCondcutivity.Text = words[4];
                    gThermalCap.Text = words[5];
                    gEnthalpy.Text = words[6];
                    gEnthropy.Text = words[7];
                    gMFraction.Text = "1";
                    lDensity.Text = "-";
                    lViscosity.Text = "-";
                    lCondcutivity.Text = "-";
                    lThermalCap.Text = "-";
                    lEnthalpy.Text = "-";
                    lEnthropy.Text = "-";
                }
                else
                {
                    if (words[8] == "0")
                    {
                       

                        gDensity.Text = "-";
                        gViscosity.Text = "-";
                        gCondcutivity.Text = "-";
                        gThermalCap.Text = "-";
                        gEnthalpy.Text = "-";
                        gEnthropy.Text = "-";
                        gMFraction.Text = "0";
                        lDensity.Text = words[9];
                        lViscosity.Text = words[10];
                        lCondcutivity.Text = words[11];
                        lThermalCap.Text = words[12];
                        lEnthalpy.Text = words[13];
                        lEnthropy.Text = words[14];

                    }
                    else 
                    {
                        gDensity.Text = words[2];
                        gViscosity.Text = words[3];
                        gCondcutivity.Text = words[4];
                        gThermalCap.Text = words[5];
                        gEnthalpy.Text = words[6];
                        gEnthropy.Text = words[7];
                        gMFraction.Text = words[8];
                        lDensity.Text = words[9];
                        lViscosity.Text = words[10];
                        lCondcutivity.Text = words[11];
                        lThermalCap.Text = words[12];
                        lEnthalpy.Text = words[13];
                        lEnthropy.Text = words[14];

                    }
                  

                }


            }
            catch
            {

            }
        }
    }
}
