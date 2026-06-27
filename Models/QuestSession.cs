namespace EntregaDispositivosMoveis.Models;

public class QuestSession
{
    public int Id { get; set; }
    public string Subject { get; set; } = string.Empty;
    public int QuestionsAnswered { get; set; }
    public int CorrectAnswers { get; set; }
    public DateOnly StudyDate { get; set; }

    public int AccuracyPercentage =>
        QuestionsAnswered == 0 ? 0 : (int)Math.Round((double)CorrectAnswers / QuestionsAnswered * 100);
}
