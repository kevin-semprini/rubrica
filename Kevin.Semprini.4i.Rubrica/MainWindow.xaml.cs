using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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


namespace Kevin.Semprini._4i.Rubrica
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

        List<Contatto> contatti = new List<Contatto>();
        List<Persona> Persone = new List<Persona>();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            int idx = 0;
            try
            {
                StreamReader fin = new StreamReader("Persone.csv"); //legge i dati dal file "Dati.csv"
                fin.ReadLine();

                while (!fin.EndOfStream)
                {
                   
                    string riga = fin.ReadLine();
                    Persona c = new Persona(riga);
                    Persone.Add(c);
                }
                dgDati.ItemsSource = Persone;

                StatusBar.Text = $"sei nunegro, ho letto {Persone.Count} contatti";

                //LEGGO I CONTATTI
                fin = new StreamReader("C:\\Users\\kevin\\source\\repos\\Kevin.Semprini.4i.Rubrica\\Contatti.csv"); //legge i dati dal file "Contatti.csv"
                fin.ReadLine();

                while (!fin.EndOfStream)
                {
                    string riga = fin.ReadLine();
                    Contatto c = new Contatto(riga);
                    contatti.Add(c);
                }

                dgDettagli.ItemsSource = contatti;

            }
            catch (Exception err)
            {
                MessageBox.Show($" NUH UH\n + {err.Message} \n  alla riga {idx}");
            }



        }




        private void DgDati_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            Persona c = e.Row.Item as Persona;
            if (c != null)
            {
                if (c.Numero == 0)
                {
                    //e.Row.Foreground = Brushes.White;
                    //e.Row.Background = Brushes.Red;
                }
            }
        }

        

        private void dgDati_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Persona p = e.AddedItems[0] as Persona;

            List<Contatto> c = new List<Contatto>();

            foreach (var item in contatti)
            {
                if (item.IdPersona == p.Numero)
                {
                    c.Add(item);
                }
            }

            dgDettagli.ItemsSource = c;

            StatusBar.Text = $"contatto selezionato: {p.Nome} {p.Cognome}";

        }

        
    }
}