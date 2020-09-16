using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace OsnovnaSkola.DataAccess
{
    public class CasDAO: RepoAccess<Cas>
    {
        public List<Cas> FindByZaposleniId(int idZaposlenog)
        {
            using(var db = new ModelOsnovnaSkolaContainer())
            {
                Zaposleni zaposleni = db.Zaposlenici.Include(x=>x.Casovi.Select(z=>z.ZauzetostUcionice).Select(u=>u.Ucionica)).SingleOrDefault(p=>p.Id_zaposlenog == idZaposlenog);
                if(zaposleni != null)
                {
                    return zaposleni.Casovi.ToList();
                }
                return new List<Cas>();
            }
        }
    }
}
