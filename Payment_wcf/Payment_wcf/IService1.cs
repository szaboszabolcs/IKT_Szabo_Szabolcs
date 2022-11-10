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
        // Adatok lekérése adatbázisból //
        [OperationContract]
        [WebInvoke(Method = "GET",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.WrappedRequest,
           UriTemplate = "/CustomerListaDB/"
           )]
        List<Customer> CustomerListaDB();

        // Adatok hozzáadása adatbázisból //
        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "/CustomerPostDB/"
            )]
        string CustomerPostDB(Customer customer);

        [OperationContract]
        string CustomerPostDBCS(Customer customer);

        // Adatok módosítása adatbázisból //
        [OperationContract]
        [WebInvoke(Method = "PUT",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.Bare,
           UriTemplate = "/CustomerPutDB/"
           )]
        string CustomerPutDB(Customer customer);

        [OperationContract]

        string CustomerPutDBCS(Customer customer);

        // Adatok törlése adatbázisból //

        [OperationContract]
        [WebInvoke(Method = "DELETE",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.WrappedRequest,
           UriTemplate = "/CustomerDeleteDB?Id={Id}"
           )]
        string CustomerDeleteDB(int id);

        [OperationContract]

        string CustomerDeleteDBCS(int id);


        // GET lekérés //
        [OperationContract]

        Customer EgyCustomerGetCS();

        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "/EgyCustomerGet/")]

        Customer EgyCustomerGet();
        //--------------------------//


        // POST lekérés //
        [OperationContract]

        Customer EgyCustomerPostCS();

        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "/EgyCustomerPost/")]

        Customer EgyCustomerPost();
        // ------------------------- //



        // Customers lista kialakítása //
        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "/Customers/"
            )]
        List<Customer> CustomersListaja();
        // ---------------------------  //


        [OperationContract]
        List<Customer> CustomerListajaCS();

        // Egy vásárló hozzáadása //
        [OperationContract]

        string EgyCustomerAddCS(Customer customer);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "/EgyCustomerAdd/"
            )]
        string EgyCustomerAdd(Customer customer);
        // -------------------------------//


        // Adat módosítása //

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "/EgyCustomerModosit/"
            )]
        string EgyCustomerPut(Customer customer);
        // --------------- //


        // Adat törlése //

        [OperationContract]

        string EgyCustomerDeleteCS(int ID);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "/EgyCustomerTorol/"
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

    }

    [DataContract]
    public class Sor
    {
        [DataMember]

        public int? ID { get; set; }
    }

    public class Customer : Sor
    {
        [DataMember(IsRequired = true)]
        public string Nev { get; set; }

        [DataMember(IsRequired = true)]

        public int Eletkor { get; set; }

        [DataMember(IsRequired = true)]

        public string Varos { get; set; }

        [OperationContract]

        public override string ToString()
        {
            return $"ID: {ID}\nNév: {Nev}\nEletkor: {Eletkor}\n Varos {Varos}";
        }
    }
}