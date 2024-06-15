namespace JobbyJobb.Models
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string AnonName { get; set; } = "null";
        public string Text { get; set; } = "null";

        public Vacancy Vacancy { get; set; } = new Vacancy();    

        
    }
}
