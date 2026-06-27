using EntregaDispositivosMoveis.Models;

namespace EntregaDispositivosMoveis.ViewModels;

public class DeleteSessionViewModel
{
    public int Id { get; set; }
    public QuestSession Session { get; set; } = new();
}
