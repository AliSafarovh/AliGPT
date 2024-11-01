namespace TraversalProject.CQRS.Results.DestinationResults
{
    public class GetDestinationByIdQueryResult
    {
        public int DestinationId { get; set; }
        public string City { get; set; }
        public string dayNight { get; set; }
        public double Price { get; set; }
    }
}
