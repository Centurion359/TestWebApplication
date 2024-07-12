namespace TestWebApplication.Models
{
    public class Task
    {
        public Task(string title, string summary, DateTime started, DateTime finished)
        {
            Title = title;
            Summary = summary;
            Started = started;
            Finished = finished;
            Created = DateTime.UtcNow;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public DateTime Created{ get; set; }
        public DateTime Started{ get; set; }
        public DateTime Finished{ get; set; }
        public bool IsSucces{ get; set; }
    }
}
