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
    public interface IKontrolneTacke
    {
        [OperationContract]
        bool AddDomaci(DomaciIM domaci, OblastIM oblast);
        [OperationContract]
        List<KontrolnaTackaIM> GetKTForZaposleni(int idZaposlenog);
        [OperationContract]
        bool ChangeDomaci(DomaciIM domaci);
        [OperationContract]
        DomaciIM GetDomaciById(int domaciID);
        [OperationContract]
        bool DeleteDomaci(int domaciID);

        [OperationContract]
        bool AddKontrolni(KontrolniIM kontrolni, OblastIM oblast);
        [OperationContract]
        KontrolniIM GetKontrolniById(int kontrolniID);
        [OperationContract]
        bool DeleteKontrolni(int kontrolniId);

        [OperationContract]
        bool ChangeKontrolni(KontrolniIM kontrolni);
    }
}
