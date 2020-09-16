using OsnovnaSkola;
using OsnovnaSkola.DataAccess;
using OsnovnaSkolaPL.Interfaces;
using OsnovnaSkolaPL.IntermediaryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsnovnaSkolaPL.Services
{
    public class UcionicaService : IUcionica
    {
        private static UcionicaDAO dao = new UcionicaDAO();

        public bool AddUcionica(UcionicaIM novaUcionica)
        {
            Ucionica ucionica = new Ucionica()
            {
                broj_ucenika = novaUcionica.broj_ucenika,
                naziv = novaUcionica.naziv
            };

            return dao.Insert(ucionica);
        }

        public bool ChangeUcionica(UcionicaIM toChange)
        {
            Ucionica u = dao.FindById(toChange.Id_ucionice);
            
            u.naziv = toChange.naziv;
            u.broj_ucenika = toChange.broj_ucenika;

            return dao.Update(u);
        }

        public bool DeleteUcionica(int id)
        {
            return dao.Delete(id);
        }

        public List<UcionicaIM> GetAllUcionica()
        {
            List<Ucionica> list = dao.GetAll();
            List<UcionicaIM> retVal = new List<UcionicaIM>();

            foreach(var ucionica in list)
            {
                retVal.Add(new UcionicaIM()
                {
                    broj_ucenika = (int)ucionica.broj_ucenika,
                    naziv = ucionica.naziv,
                    Id_ucionice = ucionica.Id_ucionice
                });
            }

            return retVal;
        }
    }
}
