using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsnovnaSkola.DataAccess
{
    public class KontrolniDAO: RepoAccess<Kontrolni>
    {
        public List<Kontrolni> GetKontrolniForZaposleni(int idZaposlenog)
        {
            using (var db = new ModelOsnovnaSkolaContainer())
            {
                List<Kontrolna_tacka> listKT = db.Kontrolna_tacka.Where(x => x.ZaposleniId_zaposlenog == idZaposlenog).ToList();
                List<Kontrolni> retVal = new List<Kontrolni>();

                foreach (var item in listKT)
                {
                    if (item is Kontrolni)
                    {
                        retVal.Add(item as Kontrolni);
                    }
                }

                return retVal;
            }
        }
    }
}
