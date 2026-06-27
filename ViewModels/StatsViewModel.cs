using EntregaDispositivosMoveis.Models;

namespace EntregaDispositivosMoveis.ViewModels;

public class StatsViewModel
{
    public int TotalQuestions { get; set; }
    public int TotalCorrectAnswers { get; set; }
    public int TotalIncorrectAnswers { get; set; }
    public decimal OverallAccuracy { get; set; }
    public string WeeklyVariationLabel { get; set; } = string.Empty;
    public IReadOnlyList<int> WeeklyPerformance { get; set; } = [];
    public IReadOnlyList<SubjectPerformance> SubjectPerformances { get; set; } = [];
}
