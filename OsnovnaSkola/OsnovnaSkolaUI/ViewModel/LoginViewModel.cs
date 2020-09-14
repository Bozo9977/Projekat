using OsnovnaSkola;
using OsnovnaSkolaPL.Helpers;
using OsnovnaSkolaPL.IntermediaryModels;
using OsnovnaSkolaUI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace OsnovnaSkolaUI.ViewModel
{
    public class LoginViewModel: BindableBase
    {
        private string ime;
        private string prezime;
        private string imeError;
        private string prezimeError;



        public Window Window { get; set; }
        public Grid LoginGrid { get; set; }
        public MyICommand LoginCommand { get; set; }
        public string Ime
        {
            get
            {
                return ime;
            }
            set
            {
                ime = value;
                OnPropertyChanged("Ime");
            }
        }
        public string Prezime
        {
            get
            {
                return prezime;
            }
            set
            {
                prezime = value;
                OnPropertyChanged("Prezime");
            }
        }
        public string ImeError
        {
            get
            {
                return imeError;
            }
            set
            {
                imeError = value;
                OnPropertyChanged("ImeError");
            }
        }
        public string PrezimeError {
            get
            {
                return prezimeError;
            }
            set
            {
                prezimeError = value;
                OnPropertyChanged("PrezimeError");
            }
        }

        public LoginViewModel(Grid loginGrid)
        {
            LoginGrid = loginGrid;
            LoginCommand = new MyICommand(OnLogin);
        }

        public void OnLogin()
        {
            ImeError = PrezimeError = "";
            Prezime = (LoginGrid.FindName("PrezimeBox") as PasswordBox).Password;

            if (String.IsNullOrWhiteSpace(Ime))
                ImeError = "Morate uneti Vaš e-mejl.";
            else
                ImeError = "";
            if (string.IsNullOrWhiteSpace(Prezime))
                PrezimeError = "Morate uneti Vašu lozinku.";
            else
                PrezimeError = "";

            if(!String.IsNullOrWhiteSpace(Ime) && !String.IsNullOrWhiteSpace(Prezime))
            {
                try
                {
                    ZaposleniIM zap = Channel.Instance.ZaposleniProxy.Login(Ime, Prezime);
                    LoggedInZaposleni.Instance = zap;
                    if (!String.IsNullOrWhiteSpace(LoggedInZaposleni.Instance.ime))
                    {
                        if (!CheckData(LoggedInZaposleni.Instance.Id_zaposlenog))
                        {

                        }
                        else
                        {
                            if (LoggedInZaposleni.Instance.PrvoLogovanje)
                            {
                                new PasswordChange().Show();
                                Window.Close();
                            }
                            else
                            {
                                new MainWindow().Show();
                                Window.Close();
                            }   
                        }
                    }
                    else
                    {
                        PrezimeError = "Zaposleni nije pronađen.";
                        LoggedInZaposleni.Instance = null;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + "\n\n" + e.StackTrace);
                }
            }
        }

        private  bool CheckData(int loggedinID)
        {
            if(LoggedInZaposleni.Instance.ime == "Admin")
            {
                return true;
            }
            else if (!LoggedInZaposleni.Instance.Ucitelj && Channel.Instance.PredmetiProxy.GetPredmetiForZaposleni(loggedinID).Count == 0)
            {
                MessageBox.Show($"Vaš nalog nije inicijalizovan, sačekajte da Vam se dodele predmeti/odeljenja." +
                    $"\nKontaktirajte Vašeg sistem administratora.", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
                Ime = (LoginGrid.FindName("PrezimeBox") as PasswordBox).Password = "";
                return false;
            }
            else if(LoggedInZaposleni.Instance.Ucitelj && (Channel.Instance.PredmetiProxy.GetPredmetiForZaposleni(loggedinID).Count == 0 ||
                Channel.Instance.OdeljenjaProxy.GetOdeljenjaForZaposleni(loggedinID).Count == 0))
            {
                MessageBox.Show($"Vaš nalog nije inicijalizovan, sačekajte da Vam se dodele predmeti/odeljenja." +
                    $"\nKontaktirajte Vašeg sistem administratora.", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
                Ime = (LoginGrid.FindName("PrezimeBox") as PasswordBox).Password = "";
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
