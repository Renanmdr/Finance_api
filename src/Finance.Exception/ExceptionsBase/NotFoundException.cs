using System.Net;

namespace Finance.Exception.ExceptionsBase;
public class NotFoundException : FinanceException
{

    public NotFoundException(string message) : base(message)
    {
        
    }

    public override int StatusCode => (int)HttpStatusCode.NotFound;

    public override List<string> GetErrors()
    {
        return [Message];
    }
}
