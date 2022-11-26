using System.ComponentModel.DataAnnotations;

namespace API.Context
{
    public class Alert
    {
        [Key]
        public string AlertId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }
        public string RiskId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CountryId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Notes { get; set; }
    }
}
