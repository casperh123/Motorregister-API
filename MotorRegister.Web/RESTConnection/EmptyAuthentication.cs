using RESTConnection.Authentication;

namespace MotorRegister.Web.RESTConnection;

public class EmptyAuthentication : IAuthentication
{
    public Dictionary<string, string> AuthenticationHeaders()
    {
        return new Dictionary<string, string>();
    }
}