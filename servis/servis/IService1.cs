using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;


namespace servis
{
    //Deklaracija svih metoda koje se 
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        int checkConnection();

        [OperationContract]
        int uploadFilesToService(string Name, string IP, 
                                 string fileName, string filePath, 
                                 long fileSize, string fileHash, string udpPort);
        
        [OperationContract]
        string Welcome(string Name);

        [OperationContract]
        int connect(string Name, string IP);

        [OperationContract]
        DataTable getData(string Name);

        [OperationContract]
        int clearUserFiles(string name);

        [OperationContract]
        int checkUsername(string name);

        [OperationContract]
        DataTable searchFiles(string text, string name);

    }


    // nepotrebno, moze delete
    /*
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
     * */
}
