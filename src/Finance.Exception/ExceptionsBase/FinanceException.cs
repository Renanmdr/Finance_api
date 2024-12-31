namespace Finance.Exception.ExceptionsBase;

public abstract class FinanceException : SystemException
{
    protected FinanceException(string message) : base(message)
    {
        
    }

    public abstract int StatusCode { get; }

    public abstract List<string> GetErrors();
}
