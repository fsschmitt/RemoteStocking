using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Server
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServerOps" in both code and config file together.
    [ServiceContract]
    public interface IServerOps
    {
        [OperationContract]
        int DoWork(int num);

        [OperationContract]
        string GetEmail(int id);

        [OperationContract]
        string AddStock(Stock stock);
    }
}
