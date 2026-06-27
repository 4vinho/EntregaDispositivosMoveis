using EntregaDispositivosMoveis.Models;

namespace EntregaDispositivosMoveis.ViewModels;

public class DashboardViewModel
{
    public string StudentName { get; set; } = string.Empty;
    public int TotalQuestions { get; set; }
    public int TotalCorrectAnswers { get; set; }
    public int TotalSubjects { get; set; }
    public decimal OverallAccuracy { get; set; }
    public IReadOnlyList<QuestSession> RecentSessions { get; set; } = [];
}
