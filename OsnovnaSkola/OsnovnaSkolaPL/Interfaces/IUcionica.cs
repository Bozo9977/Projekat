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
    public interface IUcionica
    {
        [OperationContract]
        bool AddUcionica(UcionicaIM novaUcionica);

        [OperationContract]
        List<UcionicaIM> GetAllUcionica();
        [OperationContract]
        bool ChangeUcionica(UcionicaIM toChange);
        [OperationContract]
        bool DeleteUcionica(int id);
    }
}
