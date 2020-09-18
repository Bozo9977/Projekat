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
using AuthTesting.AuthDbAccess;
using System.Net.Mail;
using System.Net;

namespace OsnovnaSkolaPL.Services
{
    public class ZaposleniService : IZaposleni
    {
        ZaposleniciDAO dao = new ZaposleniciDAO();

        public bool AddPredmetToZaposleni(ZaposleniIM zaposleni, PredmetIM predmet)
        {
            return dao.AddPredmetToZaposleni(zaposleni.Id_zaposlenog, predmet.Id_predmeta);
        }

        public bool AddZaposleni(ZaposleniIM zaposleni)
        {
            Zaposleni z = null;

            
            if(!AuthChannel.Instance.UserProxy.CreateUser(zaposleni.ime, zaposleni.prezime, zaposleni.KorisnickoIme, zaposleni.Ucitelj))
            {
                return false;
            }

            if (zaposleni.Ucitelj)
            {
                z = new Ucitelj()
                {
                    korisnicko_ime = zaposleni.KorisnickoIme,
                    zvanje = zaposleni.zvanje
                };
            }
            else
            {
                z = new Nastavnik()
                {
                    korisnicko_ime = zaposleni.KorisnickoIme,
                    zvanje = zaposleni.zvanje
                };
            }
            
            return dao.Insert(z);
        }

        public bool ChangePassword(ZaposleniIM zaposleni, string novaLozinka)
        {
            ApplicationUserIM user = AuthChannel.Instance.UserProxy.GetUser(zaposleni.KorisnickoIme);
            return AuthChannel.Instance.UserProxy.ChangePassword(user, novaLozinka);
        }

        public bool ChangeZaposleni(ZaposleniIM zaposleniToChange)
        {
            ApplicationUserIM appUser = new ApplicationUserIM();

            if ((appUser = AuthChannel.Instance.UserProxy.GetUser(zaposleniToChange.KorisnickoIme)) != null)
            {
                Zaposleni z = dao.FindById(zaposleniToChange.Id_zaposlenog);
                appUser.ime = zaposleniToChange.ime;
                appUser.prezime = zaposleniToChange.prezime;
                appUser.KorisnickoIme = zaposleniToChange.KorisnickoIme;

                if (AuthChannel.Instance.UserProxy.ChangeUser(appUser))
                {
                    z.zvanje = zaposleniToChange.zvanje;
                    z.korisnicko_ime = zaposleniToChange.KorisnickoIme;
                    return dao.Update(z);
                }
                else
                {
                    return false;
                }

                
            }
            else
            {
                return false;
            }

            
        }

        public bool DeleteZaposleni(int idZaposlenog)
        {
            using(var db = new ModelOsnovnaSkolaContainer())
            {
                

                Zaposleni z = db.Zaposlenici.Find(idZaposlenog);

                if (!AuthChannel.Instance.UserProxy.DeleteUser(z.korisnicko_ime))
                {
                    return false;
                }

                
                if (z is Ucitelj)
                {
                    List<Cas> casovi = db.Cas.Where(x => x.ZaposleniId_zaposlenog == idZaposlenog).ToList();
                   
                    foreach(var c in casovi)
                    {
                        db.Entry(c).State = EntityState.Deleted;
                    }
                    db.SaveChanges();

                    List<Predavanje> predavanja = db.Predavanja.Where(x => x.ZaposleniId_zaposlenog == idZaposlenog).ToList();

                    foreach(var p in predavanja)
                    {
                        db.Entry(p).State = EntityState.Deleted;
                    }
                    db.SaveChanges();

                    List<Radi> radovi = db.Rade.Where(x => x.ZaposleniId_zaposlenog == idZaposlenog).ToList();

                    foreach (var item in radovi)
                    {
                        db.Entry(item).State = EntityState.Deleted;
                    }
                    db.SaveChanges();

                    List<Kontrolna_tacka> kts = db.Kontrolna_tacka.Where(x => x.ZaposleniId_zaposlenog == idZaposlenog).ToList();

                    foreach(var kt in kts)
                    {
                        db.Entry(kt).State = EntityState.Deleted;
                    }
                    db.SaveChanges();

                    List<Prisustvo> prisustva = db.Prisustva.Where(x => x.ZaposleniId_zaposlenog == idZaposlenog).ToList();

                    foreach(var item in prisustva)
                    {
                        db.Entry(item).State = EntityState.Deleted;
                    }
                    db.SaveChanges();

                    

                    db.Entry(z).State = EntityState.Deleted;
                    db.SaveChanges();

                    return true;
                }
                else
                {
                    List<NastavnikOdeljenje> no = db.NastavnikOdeljenjes.Where(x => x.NastavnikId_zaposlenog == idZaposlenog).ToList();

                    foreach(var item in no)
                    {
                        db.Entry(item).State = EntityState.Deleted;
                    }
                    db.SaveChanges();

                    List<Cas> casovi = db.Cas.Where(x => x.ZaposleniId_zaposlenog == idZaposlenog).ToList();
                    foreach (var c in casovi)
                    {
                        db.Entry(c).State = EntityState.Deleted;
                    }
                    db.SaveChanges();

                    List<Predavanje> predavanja = db.Predavanja.Where(x => x.ZaposleniId_zaposlenog == idZaposlenog).ToList();

                    foreach (var p in predavanja)
                    {
                        db.Entry(p).State = EntityState.Deleted;
                    }
                    db.SaveChanges();

                    List<Radi> radovi = db.Rade.Where(x => x.ZaposleniId_zaposlenog == idZaposlenog).ToList();
                    foreach (var item in radovi)
                    {
                        db.Entry(item).State = EntityState.Deleted;
                    }
                    db.SaveChanges();

                    List<Kontrolna_tacka> kts = db.Kontrolna_tacka.Where(x => x.ZaposleniId_zaposlenog == idZaposlenog).ToList();
                    foreach (var kt in kts)
                    {
                        db.Entry(kt).State = EntityState.Deleted;
                    }
                    db.SaveChanges();

                    List<Prisustvo> prisustva = db.Prisustva.Where(x => x.ZaposleniId_zaposlenog == idZaposlenog).ToList();

                    foreach (var item in prisustva)
                    {
                        db.Entry(item).State = EntityState.Deleted;
                    }
                    db.SaveChanges();

                   

                    db.Entry(z).State = EntityState.Deleted;
                    db.SaveChanges();
                    return true;
                }
            }
        }

        public bool DodeliKontrolneTackeUcenicima(int idZaposlenog, int idOdeljenja, short ocena)
        {
            using(var db = new ModelOsnovnaSkolaContainer())
            {
                Odeljenje o = db.Odeljenja.Include(s => s.Ucenici).SingleOrDefault(x => x.Id_odeljenja == idOdeljenja);
                Kontrolna_tacka k = db.Kontrolna_tacka.ToList().LastOrDefault();
                int idKontrolneTacke = k.Id_kontrolne_tacke;

                if (o != null)
                {
                    foreach(var item in o.Ucenici)
                    {
                        dao.DodajKontrolnuTackuUcenicima(item.Id_ucenika, idZaposlenog, idKontrolneTacke, ocena);
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public List<ZaposleniIM> GetZaposleni()
        {
            try
            {
                List<Zaposleni> zaposleni = dao.GetAll();
                List<ApplicationUserIM> users = AuthChannel.Instance.UserProxy.GetUsers();

                List<ZaposleniIM> retVal = new List<ZaposleniIM>();



                foreach(var item in zaposleni)
                {
                    //if(use)
                    retVal.Add(new ZaposleniIM()
                    {
                        ime = users.SingleOrDefault(x=>x.KorisnickoIme == item.korisnicko_ime).ime,
                        zvanje = users.SingleOrDefault(x => x.KorisnickoIme == item.korisnicko_ime).Uloga,
                        prezime = users.SingleOrDefault(x => x.KorisnickoIme == item.korisnicko_ime).prezime,
                        Id_zaposlenog = item.Id_zaposlenog,
                        Ucitelj = (item is Ucitelj),
                        Nastavnik = !(item is Ucitelj)
                    }) ;
                }
                return retVal;
            }catch(Exception e)
            {
                Console.WriteLine("Msssage: "+e.Message + "\n\nTrace:\n"+e.StackTrace);
                return new List<ZaposleniIM>();
            }
            
        }

        public ZaposleniIM Login(string email, string lozinka)
        {
            ApplicationUserIM appUser = AuthChannel.Instance.UserProxy.Login(email, lozinka);

            if (appUser.Uloga != "Administrator")
            {
                List<Zaposleni> zaposleni = dao.GetAll();
                Zaposleni existing = zaposleni.SingleOrDefault(x => x.korisnicko_ime == appUser.KorisnickoIme);
                if (existing != null)
                {
                    if (existing is Ucitelj)
                    {
                        return new ZaposleniIM()
                        {
                            ime = appUser.ime,
                            prezime = appUser.prezime,
                            zvanje = existing.zvanje,
                            Id_zaposlenog = existing.Id_zaposlenog,
                            KorisnickoIme = appUser.KorisnickoIme,
                            Ucitelj = true,
                            PrvoLogovanje = appUser.FirstLogin
                        };
                    }
                    else
                    {
                        return new ZaposleniIM()
                        {
                            ime = appUser.ime,
                            prezime = appUser.prezime,
                            zvanje = existing.zvanje,
                            Id_zaposlenog = existing.Id_zaposlenog,
                            KorisnickoIme = appUser.KorisnickoIme,
                            Ucitelj = false,
                            PrvoLogovanje = appUser.FirstLogin
                        };
                    }
                }
                else
                {
                    return new ZaposleniIM();
                }

            }
            else
            {
                ZaposleniIM admin = new ZaposleniIM()
                {
                    ime = appUser.ime,
                    prezime = appUser.prezime,
                    zvanje = "administratorSistema",
                    Id_zaposlenog = 0
                };
                return admin;
            }

        }

        public bool SendReportsToParents(int zaposleniID)
        {
            using(var db = new ModelOsnovnaSkolaContainer())
            {
                //List<Odeljenje> odeljenja = db.Odeljenja.Include(o => o.Ucenici).Include(o => o.Ucitelj).Include(o => o.NastavnikOdeljenjes).ToList();
                Zaposleni z = db.Zaposlenici.Find(zaposleniID);

                if (z is Ucitelj)
                {
                    List<Odeljenje> odeljenja = db.Odeljenja.Include(o => o.Ucenici.Select(p => p.Prisustva)).Where(x => x.Ucitelj.Id_zaposlenog == zaposleniID).ToList();

                    List<Cas> casovi;

                    List<Radi> radovi;

                    


                    foreach (var odeljenje in odeljenja)
                    {
                        casovi = db.Cas.Include(x => x.Prisustva.Select(u => u.Ucenik)).Include(za => za.ZauzetostUcionice.Odeljenje).Where(zc => zc.ZaposleniId_zaposlenog == zaposleniID && zc.ZauzetostUcionice.OdeljenjeId_odeljenja == odeljenje.Id_odeljenja).ToList();

                        foreach (var ucenik in odeljenje.Ucenici)
                        {
                            int ucenikOdsustvovao = 0;
                            Dictionary<string, Tuple<int, int>> ocenePoPredmetima = new Dictionary<string, Tuple<int, int>>();

                            radovi = db.Rade.Include(kt => kt.Kontrolna_tacka.Oblast.Predmet).Include(u => u.Ucenik).Where(x => x.UcenikId_ucenika == ucenik.Id_ucenika).ToList();

                            foreach (var cas in casovi)
                            {
                                if (cas.Prisustva.SingleOrDefault(x => x.Ucenik == ucenik) == null)
                                    ++ucenikOdsustvovao;
                            }

                            foreach (var rad in radovi)
                            {
                                if (rad.ocena != 0)
                                {
                                    if (!ocenePoPredmetima.ContainsKey(rad.Kontrolna_tacka.Oblast.Predmet.naziv))
                                    {
                                        ocenePoPredmetima.Add(rad.Kontrolna_tacka.Oblast.Predmet.naziv, new Tuple<int, int>(rad.ocena, 1));
                                    }
                                    else
                                    {
                                        ocenePoPredmetima[rad.Kontrolna_tacka.Oblast.Predmet.naziv] = new Tuple<int, int>(ocenePoPredmetima[rad.Kontrolna_tacka.Oblast.Predmet.naziv].Item1 + rad.ocena, ocenePoPredmetima[rad.Kontrolna_tacka.Oblast.Predmet.naziv].Item2 + 1);
                                    }
                                    
                                }
                            }

                            SendEmailToParent(ucenik, ucenikOdsustvovao, ocenePoPredmetima);
                        }
                    }

                }


            }

            return true;
        }

        private bool SendEmailToParent(Ucenik ucenik, int odsustva, Dictionary<string, Tuple<int,int>> predmetiOcene)
        {

            int od = odsustva;
            Dictionary<string, Tuple<int, int>> d = predmetiOcene;

            string to = ucenik.Roditelj;
            string from = "bokimaric97@gmail.com";
            MailMessage message = new MailMessage(from, to);
            message.Subject = "Izveštaj o uspehu učenika";
            message.Body = $"Vaše dete {ucenik.ime} + {ucenik.prezime}"+



                "\nMolimo Vas da je obavezno promenite pri prvoj prijavi na sistem, radi sigurnosti Vašeg naloga."
                + "\nVaše korisničko ime je: " ;
            try
            {
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.EnableSsl = true;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(from, "Geografija9977");
                smtpClient.Send(message);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Message: " + e.Message + "\nInner: " + e.InnerException);
                return false;
            }
        }

        public bool ValidatePredmetAdding(int nastavnikID)
        {
            return dao.ValidatePredmetAdding(nastavnikID);
        }
    }
}
