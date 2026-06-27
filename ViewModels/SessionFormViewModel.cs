using System.ComponentModel.DataAnnotations;

namespace EntregaDispositivosMoveis.ViewModels;

public class SessionFormViewModel
{
    public int? Id { get; set; }
    public string PageTitle { get; set; } = string.Empty;
    public string Subtitle { get; set; } = string.Empty;
    public string CrudAction { get; set; } = string.Empty;
    public string CrudDescription { get; set; } = string.Empty;
    public string FormAction { get; set; } = string.Empty;
    [Required(ErrorMessage = "Informe a materia.")]
    public string Subject { get; set; } = string.Empty;
    [Range(1, int.MaxValue, ErrorMessage = "Informe pelo menos 1 questao.")]
    public int QuestionsAnswered { get; set; }
    [Range(0, int.MaxValue, ErrorMessage = "Acertos nao pode ser negativo.")]
    public int CorrectAnswers { get; set; }
    [DataType(DataType.Date)]
    public DateOnly StudyDate { get; set; }
    public string PrimaryButtonText { get; set; } = string.Empty;
    public string SecondaryButtonText { get; set; } = string.Empty;
    public string SecondaryButtonRoute { get; set; } = string.Empty;
}
