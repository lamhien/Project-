namespace Idea.ViewModels
{
    public class HomeVM
    {
        public List<string> ChartLabels { get; set; } = new List<string>();

        public List<int> ChartReactionCounting { get; set; } = new List<int>();

        public int TotalUsers { get; set; }

        public int TotalSubmissions { get; set; }

        public int TotalDepartments { get; set; }
    }
}
