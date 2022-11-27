using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCF_Service
{
    [ServiceContract]
    public interface IService1
    {
        // Get //

        [OperationContract]

        User EgyUserGetCS();

        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "/EgyUserGet/")]

        User EgyUserGet();


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

        [DataMember(IsRequired =true)]
        public DateTime Log_Time { get; set; }

    }
}
