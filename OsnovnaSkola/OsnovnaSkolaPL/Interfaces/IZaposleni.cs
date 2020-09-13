﻿using OsnovnaSkola;
using OsnovnaSkolaPL.IntermediaryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace OsnovnaSkolaPL.Interfaces
{
    [ServiceContract]
    public interface IZaposleni
    {
        [OperationContract]
        ZaposleniIM Login(string email, string lozinka);
        [OperationContract]
        List<ZaposleniIM> GetZaposleni();
        [OperationContract]
        bool AddZaposleni(ZaposleniIM zaposleni);
        [OperationContract]
        bool DeleteZaposleni(int idZaposlenog);
        [OperationContract]
        bool ChangeZaposleni(ZaposleniIM zaposleniToChange);
        [OperationContract]
        bool AddPredmetToZaposleni(ZaposleniIM zaposleni, PredmetIM predmet);
        [OperationContract]
        bool ValidatePredmetAdding(int nastavnikID);

        [OperationContract]
        bool DodeliKontrolneTackeUcenicima(int idZaposlenog, int idOdeljenja, short ocena);
        [OperationContract]
        bool ChangePassword(ZaposleniIM zaposleni, string novaLozinka);
    }
}
