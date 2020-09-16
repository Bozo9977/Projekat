using OsnovnaSkolaPL.Helpers;
using OsnovnaSkolaPL.IntermediaryModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OsnovnaSkolaUI.ViewModel
{
    public class AddCasViewModel: BindableBase
    {
        public Window Window { get; set; }
        bool Izmena = false;
        public MyICommand AddCasCommand { get; set; }
        public MyICommand DeleteCasCommand { get; set; }
        CasIM SelectedCas { get; set; }

        DateTime datum;
        public DateTime SelectedDatum 
        {
            get
            {
                return datum;
            }
            set
            {
                datum = value;
                OnPropertyChanged("SelectedDatum");
            }
        }

        string pocetak;
        public string Pocetak 
        {
            get
            {
                return pocetak;
            }
            set
            {
                pocetak = value;
                OnPropertyChanged("Pocetak");
            }
        }

        

        string dateError;
        public string DateError 
        {
            get
            {
                return dateError;
            }
            set
            {
                dateError = value;
                OnPropertyChanged("DateError");
            }
        }
        string pocetakError;
        public string PocetakError 
        {
            get
            {
                return pocetakError;
            }
            set
            {
                pocetakError = value;
                OnPropertyChanged("PocetakError");
            }
        }
        string krajError;
        public string KrajError 
        {
            get
            {
                return krajError;
            }
            set
            {
                krajError = value;
                OnPropertyChanged("KrajError");
            }
        }
        OblastIM Oblast;
        //string button;
        public string ButtonContent { get; set; }
        public string DeletionEnabled { get; set; }
        public AddCasViewModel(OblastIM oblast, CasIM cas)
        {
            if (cas != null)
            {
                Izmena = true;
                SelectedCas = cas;
                ButtonContent = "Izmeni";
                //SelectedDatum = DateTime.Today;
                SelectedDatum = cas.datum;
                
                Pocetak = cas.pocetak;
                DeletionEnabled = "Visible";
            }
            else
            {
                Oblast = oblast;
                ButtonContent = "Dodaj";
                SelectedDatum = DateTime.Today;
                DeletionEnabled = "Hidden";
            }
            //Pocetak = TimeSpan.N
            AddCasCommand = new MyICommand(OnAddCas);
            DeleteCasCommand = new MyICommand(OnDeleteCas);
        }

        public void OnAddCas()
        {
            DateError = KrajError = PocetakError = "";
            if(SelectedDatum == null)
            {
                DateError = "";
            }
            else if (String.IsNullOrWhiteSpace(Pocetak))
            {
                PocetakError = "";
            }
            else
            {
                if (Izmena)
                {
                    SelectedCas.datum = SelectedDatum.Date;
                    SelectedCas.pocetak = Pocetak;
                   

                    if (Channel.Instance.CasovyProxy.ChangeCas(SelectedCas))
                    {
                        MessageBox.Show("Čas uspešno izmenjen.", "Uspeh!", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Greška prilikom menjanja.", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    TimeSpan ts = new TimeSpan();

                    TimeSpan.TryParseExact(Pocetak, "h\\:mm", CultureInfo.CurrentUICulture, out ts);

                    if (ts == TimeSpan.Zero)
                    {

                    }

                    CasIM noviCas = new CasIM()
                    {
                        datum = SelectedDatum.Date,
                        pocetak = Pocetak,
                        
                        OblastId_oblasti = Oblast.Id_oblasti,
                        ZaposleniId_zaposlenog = LoggedInZaposleni.Instance.Id_zaposlenog
                    };
                    if (Channel.Instance.CasovyProxy.AddCas(noviCas))
                    {
                        MessageBox.Show("Čas uspešno dodat.", "Uspeh!", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Greška prilikom dodavanja.", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                }
                Window.Close();
            }
        }
        public void OnDeleteCas()
        {
            if (Channel.Instance.CasovyProxy.DeleteCas(SelectedCas.Id_casa))
            {
                Window.Close();
            }
            else
            {
                MessageBox.Show("Greška prilikom brisanja.", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
