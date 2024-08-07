using RESTConnection.Authentication;
using RESTConnection.Connection.RequestBuilder;
using RESTConnection.Connection.RequestBuilder.Url;

namespace MotorRegister.Web.RESTConnection;

public class MotorRegisterRequestBuilder : AbstractRequestBuilder
{
    public MotorRegisterRequestBuilder(RequestUrl requestUrl, IAuthentication authentication) : base(requestUrl, authentication)
    {
    }

    protected override void AddRequiredHeaders(HttpRequestMessage request)
    {
    }
}