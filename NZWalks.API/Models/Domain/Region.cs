namespace NZWalks.API.Models.Domain
{
    public class Region
    {
        public Guid id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }

    }
}
