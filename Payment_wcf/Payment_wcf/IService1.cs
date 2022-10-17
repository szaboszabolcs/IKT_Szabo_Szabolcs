using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;


namespace Payment_wcf
{
    
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "EgyCustomerAdata"
            )]

        Customer EgyCustomerGet();

        [OperationContract]

        Customer EgyCustomerAddCS();

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "EgyCustomerHozzaad"
            )]
        Customer EgyCustomerAdd(Customer customer);

        [OperationContract]

        Customer EgyCustomerPostCS();

        
    }


    [DataContract]
    
    public class Sor
    {
        [DataMember]

        public int? ID { get; set; }
    }

    [DataContract]

    public class Customer : Sor
    {
        [DataMember(IsRequired = true)]
        public string Nev { get; set; }

        [DataMember(IsRequired = true)]

        public string Varos { get; set; }

        [OperationContract]
        public override string ToString()
        {
            return $"ID: {ID}\nNév: {Nev}\nVáros: {Varos}";
        }
    }
}
