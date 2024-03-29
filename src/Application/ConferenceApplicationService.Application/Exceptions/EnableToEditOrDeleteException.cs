namespace ConferenceApplicationService.Application.Exceptions;

public class EnableToEditOrDeleteException : Exception
{
    public EnableToEditOrDeleteException(string message)
        : base(message)
    {
    }

    public EnableToEditOrDeleteException()
    {
    }

    public EnableToEditOrDeleteException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}