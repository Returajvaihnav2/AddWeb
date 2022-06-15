namespace Api.School.Models
{
    public class SearchModel
    {
        public int? Page { get; set; }
        public int? Size { get; set; }

        public string? SearchValue { get; set; }
    }
}
