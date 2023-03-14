namespace SenseWebApi1.domain.Exceptions
{
    public class ExceptionsAdapter:Exception
    {
        public IEnumerable<string> Exceptions { get; set; }
        public ExceptionsAdapter(IEnumerable<string> exceptions)
        {
            Exceptions=exceptions;
        }

    }
}
