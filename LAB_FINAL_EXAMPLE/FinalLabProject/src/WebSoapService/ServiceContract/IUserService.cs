using SoapService.DataContract;
using System.ServiceModel;
using System.Xml.Linq;

namespace SoapService.ServiceContract
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        public string RegisterUser(User user);
    }
}
