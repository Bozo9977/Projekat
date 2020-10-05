using OsnovnaSkolaPL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace OsnovnaSkolaUI.ViewModel
{
    public class ChangePasswordViewModel: BindableBase
    {
        public Window Window { get; set; }
        private PasswordBox Lozinka;
        private PasswordBox PotvrdaLozinke;
        //private Grid PasswordGrid;
        public MyICommand ChangePasswordCommand { get; set; }


        public ChangePasswordViewModel(Grid passwordGrid)
        {
            Lozinka = (passwordGrid.FindName("Lozinka") as PasswordBox);
            PotvrdaLozinke = (passwordGrid.FindName("PotvrdaLozinke") as PasswordBox);

            ChangePasswordCommand = new MyICommand(OnPasswordChange);
        }

        private bool PasswordMatching()
        {
            if (Lozinka.Password == PotvrdaLozinke.Password)
                return true;
            else
                return false;
        }

        public void OnPasswordChange()
        {
            if (PasswordMatching())
            {
                if(Channel.Instance.ZaposleniProxy.ChangePassword(LoggedInZaposleni.Instance, Lozinka.Password.ToString()))
                {
                    //new MainWindow().Show();
                    Lozinka.Password = PotvrdaLozinke.Password = "";
                    Window.Close();
                }
                else
                {
                    MessageBox.Show("Greška pri promeni lozinke, server nedostupan.", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Unete lozinke se ne poklapaju, unesite ih ponovo.","Greška!",MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }

    }
}
