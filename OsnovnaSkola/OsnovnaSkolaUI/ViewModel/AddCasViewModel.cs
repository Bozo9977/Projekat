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
        UcionicaIM SelectedUcionica { get; set; }

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

        private List<OdeljenjeIM> odeljenja;
        public List<OdeljenjeIM> Odeljenja
        {
            get { return odeljenja; }
            set
            {
                odeljenja = value;
                OnPropertyChanged("Odeljenja");
            }
        }
        public string ButtonContent { get; set; }
        public OdeljenjeIM SelectedOdeljenje { get; set; }
        public string DeletionEnabled { get; set; }
        public string Modification { get; set; }
        public AddCasViewModel(OblastIM oblast, UcionicaIM ucionica, CasIM cas)
        {
            if (cas != null)
            {
                Izmena = true;
                SelectedCas = cas;
                ButtonContent = "Izmeni";
                //SelectedDatum = DateTime.Today;
                SelectedDatum = cas.datum;
                
                Pocetak = cas.pocetak.ToString("h\\:mm",CultureInfo.CurrentCulture);
                DeletionEnabled = "Visible";
                Modification = "Hidden";
            }
            else
            {
                Oblast = oblast;
                ButtonContent = "Dodaj";
                SelectedUcionica = ucionica;
                SelectedDatum = DateTime.Today.AddDays(1);
                DeletionEnabled = "Hidden";
                Modification = "Visible";
            }
            //Pocetak = TimeSpan.N

            Odeljenja = Channel.Instance.OdeljenjaProxy.GetOdeljenjaForZaposleni(LoggedInZaposleni.Instance.Id_zaposlenog);
            AddCasCommand = new MyICommand(OnAddCas);
            DeleteCasCommand = new MyICommand(OnDeleteCas);
        }

        public void OnAddCas()
        {
            DateError = KrajError = PocetakError = "";

            TimeSpan ts = new TimeSpan();

            TimeSpan.TryParseExact(Pocetak, "h\\:mm", CultureInfo.CurrentUICulture, out ts);


            if (ts == TimeSpan.Zero)
            {
                PocetakError = "Vreme morate uneti u obliku: sat:minut.";
            } else if (ts.Hours > 20)
            {
                PocetakError = "Časovi se ne mogu održavati posle 20:00h.";
            }
            else if (ts.Hours < 7)
            {
                PocetakError = "Časovi se ne mogu održavati pre 07:00h.";
            }
            else if(SelectedOdeljenje == null && !Izmena)
            {
                PocetakError = "Morate izabrati odeljenje.";
            }
            else
            {
                if (Izmena)
                {
                    SelectedCas.datum = SelectedDatum.Date;
                    SelectedCas.pocetak = ts;

                    string retMsg = "";
                    if (Channel.Instance.CasovyProxy.ChangeCas(SelectedCas, out retMsg))
                    {
                        MessageBox.Show("Čas uspešno izmenjen.", "Uspeh!", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show(retMsg, "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    CasIM noviCas = new CasIM()
                    {
                        datum = SelectedDatum.Date,
                        pocetak = ts,
                        
                        OblastId_oblasti = Oblast.Id_oblasti,
                        ZaposleniId_zaposlenog = LoggedInZaposleni.Instance.Id_zaposlenog
                    };
                    string res;
                    if (( res = Channel.Instance.CasovyProxy.AddCas(noviCas, SelectedUcionica, SelectedOdeljenje)) == "")
                    //if(!Channel.Instance.CasovyProxy.CheckZauzetostUcionice(SelectedCas, SelectedUcionica))
                    {
                        MessageBox.Show("Čas uspešno dodat.", "Uspeh!", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show(res, "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
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
