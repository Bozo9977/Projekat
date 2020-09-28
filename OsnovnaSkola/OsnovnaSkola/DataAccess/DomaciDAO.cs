using System;
using System.Collections.Generic;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsnovnaSkola.DataAccess
{
    public class DomaciDAO: RepoAccess<Domaci>
    {
        public List<Domaci> GetDomaciForZaposleni(int idZaposlenog)
        {
            using(var db = new ModelOsnovnaSkolaContainer())
            {
                List<Kontrolna_tacka> listKT = db.Kontrolna_tacka.Where(x => x.ZaposleniId_zaposlenog == idZaposlenog).ToList();
                List<Domaci> retVal = new List<Domaci>();

                foreach(var item in listKT)
                {
                    if(item is Domaci)
                    {
                        retVal.Add(item as Domaci);
                    }
                }

                return retVal;
            }
        }
    }
}
