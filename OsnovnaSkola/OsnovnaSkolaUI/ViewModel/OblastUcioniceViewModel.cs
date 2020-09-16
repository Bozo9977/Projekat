using OsnovnaSkolaPL.Helpers;
using OsnovnaSkolaPL.IntermediaryModels;
using OsnovnaSkolaUI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OsnovnaSkolaUI.ViewModel
{
    public class OblastUcioniceViewModel: BindableBase
    {
        public Window Window { get; set; }
        public MyICommand NapraviCasCommand { get; set; }
        private string errorLabel;
        public string ErrorLabel 
        {
            get { return errorLabel; }
            set
            {
                errorLabel = value;
                OnPropertyChanged("ErrorLabel");
            }
        }

        private List<UcionicaIM> ucionice;
        public UcionicaIM SelectedUcionica { get; set; }
        public OblastIM SelectedOblast { get; set; }
        public List<UcionicaIM> Ucionice
        {
            get { return ucionice; }
            set
            {
                ucionice = value;
                OnPropertyChanged("Ucionice");
            }
        }

        private List<OblastIM> oblasti;
        public List<OblastIM> Oblasti 
        { 
            get { return oblasti; }
            set
            {
                oblasti = value;
                OnPropertyChanged("Oblasti");
            }
        }


        public OblastUcioniceViewModel(int predmetID)
        {
            Oblasti = Channel.Instance.PredmetiProxy.GetOblastiForPRedmet(predmetID);
            Ucionice = Channel.Instance.UcionicaProxy.GetAllUcionica();
            NapraviCasCommand = new MyICommand(NoviCas);

        }

        public void NoviCas()
        {
            if(SelectedUcionica == null)
            {
                ErrorLabel = "Morate izabrati učionicu.";
            }
            else if(SelectedOblast == null)
            {
                ErrorLabel = "Morate izabrati oblast.";
            }
            else
            {
                new AddCasWindow(SelectedOblast, SelectedUcionica, null).ShowDialog();
                Window.Close();
            }
        }




    }
}
