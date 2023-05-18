namespace BackendAssignment.Models
{
    public class Assignment
    {
        public Guid Id { get; set; }
        public string name { get; set; }

        public string subject { get; set; }

        public string startDate { get; set; }

        public string endDate { get; set; }
    }
}
