﻿using OsnovnaSkolaPL.IntermediaryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace OsnovnaSkolaPL.Interfaces
{
    [ServiceContract]
    public interface ICasovi
    {
        [OperationContract]
        string AddCas(CasIM cas, UcionicaIM ucionica);
        [OperationContract]
        List<CasIM> GetCasoviForZaposleni(int idZaposlenog);
        [OperationContract]
        bool ChangeCas(CasIM cas);
        [OperationContract]
        bool DeleteCas(int idCasa);
        
    }
}
