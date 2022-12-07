using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;


namespace Service_WCF
{
    [ServiceContract]
    public interface IService1
    {

        // Login végpont //
        [OperationContract]
        [WebInvoke(Method = "*",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.Bare,
           UriTemplate = "getUsers/{uname}/{pwd}")
           ]
        User getUsers(string uname, string pwd);

        // Adatok lekérése adatbázisból működik //
        [OperationContract]
        [WebInvoke(Method = "*",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.Bare,
           UriTemplate = "UserListaDB"
           )]
        List<User> UserListaDB();

        // Adatok hozzáadása adatbázisból működik //
        [OperationContract]
        [WebInvoke(Method = "*",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "UserPostDB"
            )]
        string UserPostDB(User user);

        [OperationContract]
        string UserPostDBCS(User user);


        // Adatok módosítása adatbázisból működik //
        [OperationContract]
        [WebInvoke(Method = "*",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.Bare,
           UriTemplate = "UserPutDB"
           )]
        string UserPutDB(User user);

        [OperationContract]

        string UserPutDBCS(User user);


        // Adatok törlése adatbázisból működik //

        [OperationContract]
        [WebInvoke(Method = "*",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.Bare,
           UriTemplate = "/UserDeleteDB?Id={Id}"
           )]
        string UserDeleteDB(int id);

        [OperationContract]

        string UserDeleteDBCS(int id);



        // POST lekérés //
        [OperationContract]

        User EgyUserPostCS();

        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "EgyUserPost"
            )]

        User EgyUserPost();
        // ------------------------- //


        // Users lista kialakítása //
        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "Users"
            )]
        List<User> UsersListaja();
        // ---------------------------  //


        [OperationContract]
        List<User> UserListajaCS();

        // Egy vásárló hozzáadása //
        [OperationContract]

        string EgyUserAddCS(User user);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "EgyUserAdd"
            )]
        string EgyUserAdd(User user);
        // -------------------------------//


        // Adat módosítása //

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "EgyUserModosit"
            )]
        string EgyUserPut(User user);
        // --------------- //


        // Adat törlése //

        [OperationContract]

        string EgyUserDeleteCS(int ID);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "EgyUserTorol"
            )]
        string EgyUserDelete(int ID);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "EgyUserTorol?ID={ID}"
            )]

        string EgyUserDeleteID(int ID);

    }

}

    [DataContract]

public class Rekord
{
    [DataMember]

    public int? ID { get; set; }
}

public class User : Rekord
{
    [DataMember(IsRequired = true)]
    public string Uname { get; set; }

    [DataMember(IsRequired = true)]
    public string Email { get; set; }

    [DataMember(IsRequired = true)]
    public string Password { get; set; }

    [DataMember(IsRequired = true)]
    public string Fullname { get; set; }

    [DataMember(IsRequired = true)]
    public byte Active { get; set; }

    [DataMember(IsRequired = true)]
    public int Rank { get; set; }

    [DataMember(IsRequired = true)]
    public bool Banned { get; set; }

    [DataMember(IsRequired = true)]
    public DateTime Reg_Time { get; set; }

    [DataMember(IsRequired = true)]
    public DateTime Log_Time { get; set; }

}