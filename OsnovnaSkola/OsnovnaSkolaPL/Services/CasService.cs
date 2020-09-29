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
using System.Globalization;

namespace OsnovnaSkolaPL.Services
{
    public class CasService : ICasovi
    {
        private static CasDAO dao = new CasDAO();
        public string AddCas(CasIM cas, UcionicaIM ucionica, OdeljenjeIM odeljenje)
        {
            string retMsg = "";
            if(!ValidateCasExistance(cas,ucionica,odeljenje, out retMsg))
            {
                
                Cas c = new Cas()
                {
                    OblastId_oblasti = cas.OblastId_oblasti,
                    ZaposleniId_zaposlenog = cas.ZaposleniId_zaposlenog,
                    ZauzetostUcionice = new ZauzetostUcionice()
                    {
                        datum = cas.datum,
                        pocetak = cas.pocetak,
                        UcionicaId_ucionice = ucionica.Id_ucionice,
                        OdeljenjeId_odeljenja = odeljenje.Id_odeljenja
                    }
                };
                //c.Imaju.Add(new Ima() { Cas = c, OdeljenjeId_odeljenja = odeljenje.Id_odeljenja });

                if (dao.Insert(c))
                    return "";
                else
                    return "Greška prilikom dodavanja.";
            }
            else
            {
                return retMsg;
            }
            
        }

        public bool ChangeCas(CasIM cas, out string retMsg)
        {
            using(var db = new ModelOsnovnaSkolaContainer())
            {
                Cas c = db.Cas.Include(z => z.ZauzetostUcionice.Ucionica).Include(p=>p.ZauzetostUcionice.Odeljenje).SingleOrDefault(x => x.Id_casa == cas.Id_casa);

                UcionicaIM ucionica = new UcionicaIM()
                {
                    naziv = c.ZauzetostUcionice.Ucionica.naziv,
                    broj_ucenika = c.ZauzetostUcionice.Ucionica.broj_ucenika,
                    Id_ucionice = c.ZauzetostUcionice.Ucionica.Id_ucionice
                };
                OdeljenjeIM odeljenje = new OdeljenjeIM()
                {
                    Id_odeljenja = c.ZauzetostUcionice.Odeljenje.Id_odeljenja,
                    razred = c.ZauzetostUcionice.Odeljenje.razred
                };

                retMsg = "";
                if(!ValidateCasExistance(cas, ucionica,odeljenje, out retMsg))
                {
                    c.ZauzetostUcionice.datum = cas.datum;
                    c.ZauzetostUcionice.pocetak = cas.pocetak;

                    db.Entry(c).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;

                }
                else
                {
                    return false;
                }

                
            }
            //Cas c = dao.FindById(cas.Id_casa);

            //c.pocetak = cas.pocetak;
            
        }

        private bool ValidateCasExistance(CasIM cas, UcionicaIM ucionica, OdeljenjeIM odeljenje, out string errMsg)
        {
            errMsg = "";
            bool zauzeta = false;

            if (!CheckZauzetostPredavaca(cas))
            {
                if(!CheckZauzetostOdeljenja(cas, odeljenje))
                {
                    if(!CheckZauzetostUcionice(cas, ucionica))
                    {

                    }
                    else
                    {
                        zauzeta = true;
                        errMsg = "Učionica je zauzeta.";
                    }
                }
                else
                {
                    zauzeta = true;
                    errMsg = $"Odeljenje ima čas u {cas.pocetak.ToString("h\\:mm", CultureInfo.CurrentCulture)}, dana: {cas.datum}.";
                }
            }
            else
            {
                zauzeta = true;
                errMsg = $"Već imate čas u {cas.pocetak.ToString("h\\:mm", CultureInfo.CurrentCulture)}, dana: {cas.datum}.";
            }

            return zauzeta;
        }

        private bool CheckZauzetostUcionice(CasIM cas, UcionicaIM ucionica)
        {
            using (var db = new ModelOsnovnaSkolaContainer())
            {
                List<ZauzetostUcionice> zauzetosti = db.ZauzetostUcionices.Include(x => x.Ucionica).Where(x => x.UcionicaId_ucionice == ucionica.Id_ucionice).ToList();

                zauzetosti.Remove(zauzetosti.SingleOrDefault(x => x.Cas.Id_casa == cas.Id_casa));

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

        private bool CheckZauzetostOdeljenja(CasIM cas, OdeljenjeIM odeljenje)
        {
            using(var db = new ModelOsnovnaSkolaContainer())
            {
                List<ZauzetostUcionice> zauzetosti = db.ZauzetostUcionices.Include(x=>x.Odeljenje).Where(x => x.Odeljenje.Id_odeljenja == odeljenje.Id_odeljenja).ToList();
               
                zauzetosti.Remove(zauzetosti.SingleOrDefault(x => x.Cas.Id_casa == cas.Id_casa));

                bool zauzeta = false;

                foreach (var z in zauzetosti)
                {
                    if (cas.datum.Date == z.datum.Date)
                    {
                        if ((cas.pocetak - z.pocetak).TotalMinutes < 45 && (cas.pocetak - z.pocetak).TotalMinutes > -45)
                        {
                            zauzeta = true;
                        }
                    }
                }

                return zauzeta;
            }
        }


        private bool CheckZauzetostPredavaca(CasIM cas)
        {
            using(var db = new ModelOsnovnaSkolaContainer())
            {

                List<ZauzetostUcionice> zauzetosti = db.ZauzetostUcionices.Where(x => x.Cas.ZaposleniId_zaposlenog == cas.ZaposleniId_zaposlenog).ToList();

                zauzetosti.Remove(zauzetosti.SingleOrDefault(x => x.Cas.Id_casa == cas.Id_casa));

                bool zauzeta = false;

                foreach (var z in zauzetosti)
                {
                    if (cas.datum.Date == z.datum.Date)
                    {
                        if ((cas.pocetak - z.pocetak).TotalMinutes < 45 && (cas.pocetak - z.pocetak).TotalMinutes > -45)
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
                try
                {
                    ZauzetostUcionice z = db.ZauzetostUcionices.SingleOrDefault(x => x.Cas.Id_casa == idCasa);

                    List<Odeljenje> odeljenja = db.Odeljenja.Include(o => o.ZauzetostUcionices).ToList();
                    Odeljenje odeljenje = odeljenja.SingleOrDefault(x => x.ZauzetostUcionices.Contains(z));
                    odeljenje.ZauzetostUcionices.Remove(z);

                    List<Ucionica> ucionice = db.Ucionicas.Include(x => x.ZauzetostUcionices).ToList();
                    Ucionica ucionica = ucionice.SingleOrDefault(x => x.ZauzetostUcionices.Contains(z));
                    ucionica.ZauzetostUcionices.Remove(z);

                    db.Entry(z).State = EntityState.Deleted;

                    Cas cas = db.Cas.Find(idCasa);
                    db.Entry(cas).State = EntityState.Deleted;

                    db.SaveChanges();

                    return true;
                }catch(Exception e)
                {
                    Console.WriteLine("Message: " + e.Message + "\nInner: " + e.InnerException.Message);
                    return false;
                }
                
            }

        }

        public List<CasIM> GetCasoviForZaposleni(int idZaposlenog)
        {
            List<Cas> lista = dao.FindByZaposleniId(idZaposlenog);
            List<CasIM> retVal = new List<CasIM>();

            foreach(var item in lista)
            {
                retVal.Add(new CasIM() { datum = item.ZauzetostUcionice.datum, Id_casa = item.Id_casa, pocetak = item.ZauzetostUcionice.pocetak, naziv_oblasti=item.Oblast.naziv, ucionica = item.ZauzetostUcionice.Ucionica.naziv, OblastId_oblasti = item.OblastId_oblasti, ZaposleniId_zaposlenog = item.ZaposleniId_zaposlenog, odeljenje = item.ZauzetostUcionice.Odeljenje.razred.ToString() + "-" + item.ZauzetostUcionice.Odeljenje.Id_odeljenja.ToString() });
            }

            return retVal;
        }

        public List<CasIM> GetCasoviForZaposleniByDate(int idZaposlenog, DateTime date)
        {
            List<Cas> lista = dao.FindByZaposleniId(idZaposlenog);

            lista.RemoveAll(x => x.ZauzetostUcionice.datum != date.Date);

            List<CasIM> retVal = new List<CasIM>();

            foreach (var item in lista)
            {
                retVal.Add(new CasIM() { datum = item.ZauzetostUcionice.datum, Id_casa = item.Id_casa, pocetak = item.ZauzetostUcionice.pocetak, naziv_oblasti = item.Oblast.naziv, ucionica = item.ZauzetostUcionice.Ucionica.naziv, OblastId_oblasti = item.OblastId_oblasti, ZaposleniId_zaposlenog = item.ZaposleniId_zaposlenog, odeljenje = item.ZauzetostUcionice.Odeljenje.razred.ToString() + "-" + item.ZauzetostUcionice.Odeljenje.Id_odeljenja.ToString() });
            }

            return retVal;
        }

        public bool EvidentirajPrisustvo(List<UcenikIM> prisutni, CasIM cas)
        {
            try
            {
                using(var db = new ModelOsnovnaSkolaContainer())
                {
                    Cas c = db.Cas.Include(x => x.Prisustva).SingleOrDefault(p => p.Id_casa == cas.Id_casa);

                    foreach(var ucenik in prisutni)
                    {
                        c.Prisustva.Add(new Prisustvo() { CasId_casa = c.Id_casa, UcenikId_ucenika = ucenik.Id_ucenika, ZaposleniId_zaposlenog = cas.ZaposleniId_zaposlenog });

                    }

                    db.Entry(c).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return true;
            }catch(Exception e)
            {
                Console.WriteLine("MEssage: "+ e.Message+"\nInner: " + e.InnerException.Message);
                return false;
            }
        }
    }
}
