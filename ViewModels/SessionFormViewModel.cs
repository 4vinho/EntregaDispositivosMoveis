namespace EntregaDispositivosMoveis.ViewModels;

public class SessionFormViewModel
{
    public int? Id { get; set; }
    public string PageTitle { get; set; } = string.Empty;
    public string Subtitle { get; set; } = string.Empty;
    public string CrudAction { get; set; } = string.Empty;
    public string CrudDescription { get; set; } = string.Empty;
    public string Subject { get; set; } = string.Empty;
    public int QuestionsAnswered { get; set; }
    public int CorrectAnswers { get; set; }
    public DateOnly StudyDate { get; set; }
    public string PrimaryButtonText { get; set; } = string.Empty;
    public string SecondaryButtonText { get; set; } = string.Empty;
    public string PrimaryButtonRoute { get; set; } = string.Empty;
    public string SecondaryButtonRoute { get; set; } = string.Empty;
}
