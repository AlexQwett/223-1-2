namespace DAL.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() 
            : base("Was not found")
        {
        }
    }
}
