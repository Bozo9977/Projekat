using OsnovnaSkola;
using OsnovnaSkolaPL.Helpers;
using OsnovnaSkolaPL.IntermediaryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OsnovnaSkolaUI.ViewModel
{
    public class RasporedCasovaViewModel: BindableBase
    {
        public Window  Window { get; set; }

        public MyICommand CheckRasporedCommand { get; set; }


        private List<CasIM> casovi;
        private DateTime datum;
        private string rasporedError;
        public string RasporedError 
        {
            get { return rasporedError; }
            set
            {
                rasporedError = value;
                OnPropertyChanged("RasporedError");
            }
        }
        public DateTime SelectedDatum 
        {
            get { return datum; }
            set
            {
                datum = value;
                OnPropertyChanged("SelectedDatum");
            }
        }
        public List<CasIM> Casovi 
        {
            get { return casovi; }
            set
            {
                casovi = value;
                OnPropertyChanged("Casovi");
            }
        }
        
        public RasporedCasovaViewModel()
        {
            CheckRasporedCommand = new MyICommand(OnCheckRaspored);
            SelectedDatum = DateTime.Today;
            Casovi = Channel.Instance.CasovyProxy.GetCasoviForZaposleniByDate(LoggedInZaposleni.Instance.Id_zaposlenog, SelectedDatum);
            if (Casovi.Count == 0)
            {
                RasporedError = "Nemate nijedan čas isplaniran za danas.";
            }
        }

        public void OnCheckRaspored()
        {
            RasporedError = "";

            if (SelectedDatum != null)
            {
                Casovi = Channel.Instance.CasovyProxy.GetCasoviForZaposleniByDate(LoggedInZaposleni.Instance.Id_zaposlenog, SelectedDatum);
                if(Casovi.Count == 0)
                {
                    RasporedError = "Nemate nijedan čas isplaniran za izabrani datum.";
                }
            }
            else
            {
                RasporedError = "Morate izabrati datum.";
            }
        }
    }
}
