# rubrica
programma in WPF app che prevede una rubrica modificabile e persistente


## struttura

il programma prevede l'uso di due classi, una per le informazioni aggiuntive di una persona (questa userà degli enum come attributi) e una che prevede le informazini basilari e comuni a tutti (nome,cognome,email)

## metodo window_loaded
~~~C#
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

        ///////////////////////////////////////////////////////////////////////////////////////LEGGO I CONTATTI

        fin = new StreamReader("C:\\Users\\kevin\\source\\repos\\Kevin.Semprini.4i.Rubrica\\Contatti.csv"); //legge i dati dal file "Contatti.csv"
        fin.ReadLine();

        while (!fin.EndOfStream)
        {
            string riga = fin.ReadLine();
            Contatto c = new Contatto(riga);
            contatti.Add(c);
        }
    }
    catch (Exception err)
    {
        MessageBox.Show($" NUH UH\n + {err.Message} \n  alla riga {idx}");
    }
}
~~~

## grafica

la parte grafica prevede due parti, la sinistra e la destra

### sinistra
comprende un footer, un header con bottoni (WIP) e la vera  e propria rubrica con tutti i contatti salvati nel file .csv dedicato

### destra

una mini tabella per salvare tutte le persone con il campo desiretao (ex: tutte le informazioni con numero di identificazione pari a 2), un grande rettangolo verde completamente inutile messo per rendere il programma meno triste :)

## funzioni e metodi

sono compresi diversi metodi collegati e derivanti dal file XAML, questi permettono l'implementazioni di diverse funzioni in base a cambiamenti attuati nella finestra

**cambio di casella:**
~~~C#
private void dgDati_SelectionChanged(object sender, SelectionChangedEventArgs e)
{

    Persona p = e.AddedItems[0] as Persona;

    if (p != null) 
    {
        StatusBar.Text = $"contatto selezionato: {p.Nome} {p.Cognome}";

        List<Contatto> c = new List<Contatto>();

        foreach (var item in contatti)
        {
            if (item.IdPersona == p.Numero)
            {
                c.Add(item);
            }
        }

        dgDettagli.ItemsSource = c;
    }

}
~~~

