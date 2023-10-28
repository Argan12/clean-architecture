namespace CleanArchitecture.Application.Common.Exceptions
{
    public class NotUniqueRessourceException : Exception
    {
        public NotUniqueRessourceException(string message) : base(message) { }
    }
}
