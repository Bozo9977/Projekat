using OsnovnaSkola;
using OsnovnaSkola.DataAccess;
using OsnovnaSkolaPL.Interfaces;
using OsnovnaSkolaPL.IntermediaryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace OsnovnaSkolaPL.Services
{
    public class CasService : ICasovi
    {
        private static CasDAO dao = new CasDAO();
        public string AddCas(CasIM cas, UcionicaIM ucionica)
        {

            if(!CheckZauzetostUcionice(cas, ucionica))
            {
                Cas c = new Cas()
                {
                    //pocetak=cas.pocetak,
                    //kraj = cas.kraj,
                    OblastId_oblasti = cas.OblastId_oblasti,
                    ZaposleniId_zaposlenog = cas.ZaposleniId_zaposlenog,
                    ZauzetostUcionice = new ZauzetostUcionice()
                    {
                        datum = cas.datum,
                        pocetak = cas.pocetak,
                        UcionicaId_ucionice = ucionica.Id_ucionice
                    }
                };

                if (dao.Insert(c))
                    return "";
                else
                    return "Greška prilikom dodavanja.";
            }
            else
            {
                return "Učionica je tada zauzeta.";
            }
            
            
        }

        public bool ChangeCas(CasIM cas)
        {
            using(var db = new ModelOsnovnaSkolaContainer())
            {
                Cas c = db.Cas.Include(z => z.ZauzetostUcionice.Ucionica).SingleOrDefault(x => x.Id_casa == cas.Id_casa);

                UcionicaIM ucionica = new UcionicaIM()
                {
                    naziv = c.ZauzetostUcionice.Ucionica.naziv,
                    broj_ucenika = c.ZauzetostUcionice.Ucionica.broj_ucenika,
                    Id_ucionice = c.ZauzetostUcionice.Ucionica.Id_ucionice
                };

                if(!CheckZauzetostUcionice(cas, ucionica))
                {
                    c.ZauzetostUcionice.datum = cas.datum;
                    c.ZauzetostUcionice.pocetak = cas.pocetak;

                    return dao.Update(c);
                }
                else
                {
                    return false;
                }

                
            }
            //Cas c = dao.FindById(cas.Id_casa);

            //c.pocetak = cas.pocetak;

            
            
        }

        private bool CheckZauzetostUcionice(CasIM cas, UcionicaIM ucionica)
        {
            using (var db = new ModelOsnovnaSkolaContainer())
            {
                List<ZauzetostUcionice> zauzetosti = db.ZauzetostUcionices.Include(x => x.Ucionica).Where(x => x.UcionicaId_ucionice == ucionica.Id_ucionice).ToList();

                bool zauzeta = false;
                //TimeSpan ts = new TimeSpan();

                foreach (var z in zauzetosti)
                {
                    if (cas.datum.Date == z.datum.Date)
                    {
                        if( (cas.pocetak - z.pocetak).TotalMinutes < 45 && (cas.pocetak - z.pocetak).TotalMinutes > -45)
                        {
                            zauzeta = true;
                        }
                    }
                }

                return zauzeta;
            }
        }

        public bool DeleteCas(int idCasa)
        {
            using(var db = new ModelOsnovnaSkolaContainer())
            {
                ZauzetostUcionice z = db.ZauzetostUcionices.SingleOrDefault(x => x.Cas.Id_casa == idCasa);

                db.Entry(z).State = EntityState.Deleted;
                db.SaveChanges();
            }

            return dao.Delete(idCasa);
        }

        public List<CasIM> GetCasoviForZaposleni(int idZaposlenog)
        {
            List<Cas> lista = dao.FindByZaposleniId(idZaposlenog);
            List<CasIM> retVal = new List<CasIM>();

            foreach(var item in lista)
            {
                retVal.Add(new CasIM() { datum = item.ZauzetostUcionice.datum, Id_casa = item.Id_casa, pocetak = item.ZauzetostUcionice.pocetak, ucionica = item.ZauzetostUcionice.Ucionica.naziv, OblastId_oblasti = item.OblastId_oblasti, ZaposleniId_zaposlenog = item.ZaposleniId_zaposlenog });
            }

            return retVal;
        }
    }
}
