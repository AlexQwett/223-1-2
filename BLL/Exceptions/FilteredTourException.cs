namespace BLL.Exceptions
{
    public sealed class FilteredTourException : Exception
    {
        public FilteredTourException()
            : base("Existing tour or category not found. Please create it before")
        {
        }
    }
}
