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
            UriTemplate = "/EgyCustomerAdata"
            )]
        Customer EgyCustomerGet();

        [OperationContract]

        Customer EgyCustomerGetCS();

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "/EgyCustomerHozzaAdas"
            )]
        Customer EgyCustomerPost();

        [OperationContract]

        Customer EgyCustomerPostCS();

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "/Customers"
            )]
        List<Customer> CustomersListaja();

        [OperationContract]

        List<Customer> CustomersListajaCS();

        [OperationContract]

        string EgyCustomerAddCS(Customer customer);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "/EgyCustomerAdd"
            )]

        string EgyCustomerAdd(Customer customer);

        [OperationContract]

        string EgyCustomerPutCS(Customer customer);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "/EgyCustomerModosit"
            )]

        string EgyCustomerPut(Customer customer);

        [OperationContract]

        string EgyCustomerPatchCS(Customer customer);

        [OperationContract]
        [WebInvoke(Method = "PATCH",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "/EgyCustomerModosit2"
            )]

        string EgyCustomerPatch(Customer customer);

        [OperationContract]

        string EgyCustomerDeleteCS(int ID);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "/EgyCustomerTorol"
            )]

        string EgyCustomerDelete(int ID);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.WrappedRequest,
           UriTemplate = "/EgyCustomerTorol?ID={ID}"
           )]

        string EgyCustomerDeleteID(int ID);

        [OperationContract]
        Customer EgyCustomerGetIDCS(int ID);

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "/EgyCustomerGetID?ID={ID}"
            )]
        Customer EgyCustomerGetID(int ID);



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
