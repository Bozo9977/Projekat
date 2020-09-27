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
    public class OblastiPredmetaViewModel:BindableBase
    {
        public Window Window { get; set; }
        public MyICommand ChangeOblastCommand { get; set; }
        public MyICommand DeleteOblastCommand { get; set; }
        public MyICommand CreatePredavanjeCommand { get; set; }
        List<OblastIM> oblasti;
        public List<OblastIM> Oblasti
        {
            get
            {
                return oblasti;
            }
            set
            {
                oblasti = value;
                OnPropertyChanged("Oblasti");
            }
        }
        public OblastIM SelectedOblast { get; set; }
        public PredmetIM SelectedPredmet { get; set; }
        public string CreatingPredavanje { get; set; }
        public string IzmenaOblasti { get; set; }
        bool CreatingKT { get; set; } = false;
        private KontrolnaTackaIM kontrolna_tacka;
        private int odeljenjeID;
        public OblastiPredmetaViewModel(PredmetIM predmet, bool creatingPredavanje, bool creatingKt, KontrolnaTackaIM kt, int odeljenjeID)
        {
            
            ChangeOblastCommand = new MyICommand(OnChangeOblast);
            DeleteOblastCommand = new MyICommand(OnDeleteOblast);
            SelectedPredmet = predmet;

           
            if (creatingKt)
            {
                CreatingPredavanje = "Visible";
                IzmenaOblasti = "Hidden";
                kontrolna_tacka = kt;
                this.odeljenjeID = odeljenjeID;
                Oblasti = Channel.Instance.PredmetiProxy.GetOblastiForPredmetForKT(predmet.Id_predmeta);
            }
            else if (creatingPredavanje)
            {
                CreatingPredavanje = "Visible";
                IzmenaOblasti = "Hidden";
                kontrolna_tacka = kt;
                this.odeljenjeID = odeljenjeID;
                Oblasti = Channel.Instance.PredmetiProxy.GetOblastiForPRedmet(predmet.Id_predmeta);

            }
            else
            {
                kontrolna_tacka = kt;
                CreatingPredavanje = "Hidden";
                IzmenaOblasti = "Visible";
            }

            CreatingKT = creatingKt;
            CreatePredavanjeCommand = new MyICommand(OnCreatePredavanje);
        }

        public void OnChangeOblast()
        {
            if (SelectedOblast != null)
            {
                new AddOblastWindow(SelectedPredmet, SelectedOblast).ShowDialog();
                Window.Close();
            }
            else
            {
                MessageBox.Show("Prvo izaberite oblast.", "Upozorenje!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        public void OnCreatePredavanje()
        {
            
            if (SelectedOblast != null)
            {
                if (CreatingKT)
                {
                    //new UcenikOdeljenjeWindow(Se)
                    //new AddCasWindow(SelectedOblast, null, null).ShowDialog();
                    if(kontrolna_tacka is KontrolniIM)
                    {
                        if (Channel.Instance.KTProxy.AddKontrolni(kontrolna_tacka as KontrolniIM, SelectedOblast))
                        {
                            if (Channel.Instance.ZaposleniProxy.DodeliKontrolneTackeUcenicima(LoggedInZaposleni.Instance.Id_zaposlenog, odeljenjeID, 0))
                            {

                            }
                            else
                            {
                                MessageBox.Show("Greška pri dodeljivanju KT ucenicima.", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Greška prilikom dodavanja.", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }else if(kontrolna_tacka is DomaciIM)
                    {
                        if(Channel.Instance.KTProxy.AddDomaci(kontrolna_tacka as DomaciIM, SelectedOblast))
                        {
                            if (Channel.Instance.ZaposleniProxy.DodeliKontrolneTackeUcenicima(LoggedInZaposleni.Instance.Id_zaposlenog, odeljenjeID, 0))
                            {

                            }
                            else
                            {
                                MessageBox.Show("Greška pri dodeljivanju KT ucenicima.", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                    }

                }
                else
                {
                    //new AddPRedavanjeWindow(SelectedOblast, null).ShowDialog();
                }
                Window.Close();
            }
            else
            {
                MessageBox.Show("Prvo izaberite oblast.", "Upozorenje!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        public void OnDeleteOblast()
        {
            if (SelectedOblast != null)
            {
                if (Channel.Instance.OblastiProxy.DeleteOblast(SelectedOblast))
                {
                    MessageBox.Show("Oblast obrisana", "Uspeh!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Greška pri brisanju,", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                Window.Close();
            }
            else
            {
                MessageBox.Show("Prvo izaberite oblast.", "Upozorenje!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
        }
    }
}
