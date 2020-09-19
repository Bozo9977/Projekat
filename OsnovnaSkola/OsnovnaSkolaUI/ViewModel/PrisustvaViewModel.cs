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
    public class PrisustvaViewModel : BindableBase
    {
        public Window Window { get; set; }
        public MyICommand EvidentirajPrisustvoCommand { get; set; }
        public MyICommand UcenikPrisustvoCommand { get; set; }

        private List<UcenikIM> ucenici;
        public List<UcenikIM> Ucenici 
        {
            get { return ucenici; }
            set
            {
                ucenici = value;
                OnPropertyChanged("Ucenici");
            }
        }
        private UcenikIM selectedUcenik;
        public UcenikIM SelectedUcenik
        {
            get { return selectedUcenik; }
            set
            {
                selectedUcenik = value;
                OnPropertyChanged("SelectedUcenik");
            }
        }
        private CasIM Cas;
        private List<UcenikIM> prisustvovali = new List<UcenikIM>();
        public PrisustvaViewModel(CasIM cas)
        {
            Ucenici = Channel.Instance.UceniciProxy.GetUcenikeForCas(cas);
            Cas = cas;

            EvidentirajPrisustvoCommand = new MyICommand(OnEvidentirajPrisustvo);
            UcenikPrisustvoCommand = new MyICommand(OnUcenikPrisustvovao);
        }

        public void OnEvidentirajPrisustvo()
        {
            if (Channel.Instance.CasovyProxy.EvidentirajPrisustvo(prisustvovali, Cas))
            {
                
            }
            else
            {
                MessageBox.Show("Greška u bazi, kontaktirajte sitem administratora.", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Window.Close();
        }

        public void OnUcenikPrisustvovao()
        {
            if (!prisustvovali.Contains(SelectedUcenik))
                prisustvovali.Add(SelectedUcenik);
            else
            {
                if(MessageBox.Show("Učenik je već označen kao prisutan, da li želite da ga uklonite iz liste prisutnih?", "Upozorenje!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    prisustvovali.Remove(SelectedUcenik);
                }
            }
        }

    }
}
