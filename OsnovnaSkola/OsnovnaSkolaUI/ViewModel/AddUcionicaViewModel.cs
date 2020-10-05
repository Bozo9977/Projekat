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
    public class AddUcionicaViewModel: BindableBase
    {
        #region Fields
        private UcionicaIM novaUcionica;
        private string nazivError;
        private string brojError;
        #endregion

        #region Commands
        public MyICommand AddUcionicaCommand { get; set; }

        #endregion

        #region Properties
        public Window Window { get; set; }
       
        public string ButtonContent { get; set; }
        public UcionicaIM NovaUcionica 
        {
            get { return novaUcionica; }
            set
            {
                novaUcionica = value;
                OnPropertyChanged("NovaUcionica");
            }
        }
        public string NazivError 
        {
            get { return nazivError; }
            set
            {
                nazivError = value;
                OnPropertyChanged("NazivError");
            }
        }
        public string BrojError 
        {
            get { return brojError; }
            set
            {
                brojError = value;
                OnPropertyChanged("BrojError");
            }
        }
        #endregion

        public AddUcionicaViewModel(bool change, UcionicaIM toChange)
        {
            

            if (change)
            {
                AddUcionicaCommand = new MyICommand(IzmeniUcionicu);
                NovaUcionica = toChange;
                ButtonContent = "IZMENI";
            }
            else
            {
                AddUcionicaCommand = new MyICommand(DodajUcionicu);
                NovaUcionica = new UcionicaIM();
                ButtonContent = "DODAJ";
            }

            
        }

        public void IzmeniUcionicu()
        {
            NazivError = BrojError = "";

            if (string.IsNullOrEmpty(NovaUcionica.naziv))
            {
                NazivError = "Naziv ne može biti prazan.";
            }
            else if (NovaUcionica.broj_ucenika == 0)
            {
                BrojError = "Broj učenika mora biti celobrojan.";
            }
            else if (NovaUcionica.broj_ucenika < 0)
            {
                BrojError = "Broj učenika mora biti pozitivan.";
            }
            else
            {
                if (Channel.Instance.UcionicaProxy.ChangeUcionica(NovaUcionica))
                {
                    Window.Close();
                }
                else
                {
                    MessageBox.Show("Greška sa bazom. Kontaktirajte administratora sistema.", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
                    Window.Close();
                }
            }
        }
        public void DodajUcionicu()
        {
            NazivError = BrojError = "";

            if (string.IsNullOrEmpty(NovaUcionica.naziv))
            {
                NazivError = "Naziv ne može biti prazan.";
            }
            else if(NovaUcionica.broj_ucenika == 0)
            {
                BrojError = "Broj učenika mora biti celobrojan.";
            }
            else if(NovaUcionica.broj_ucenika < 0)
            {
                BrojError = "Broj učenika mora biti pozitivan.";
            }
            else
            {
               // UcionicaIM ucionica = NovaUcionica;
                if (Channel.Instance.UcionicaProxy.AddUcionica(NovaUcionica))
                {
                    Window.Close();
                }
                else
                {
                    MessageBox.Show("Greška sa bazom. Kontaktirajte administratora sistema.", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
                    Window.Close();
                }
            }
            
        }


    }
}
