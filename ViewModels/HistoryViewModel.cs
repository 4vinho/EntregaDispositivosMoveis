using EntregaDispositivosMoveis.Models;

namespace EntregaDispositivosMoveis.ViewModels;

public class HistoryViewModel
{
    public string SearchPlaceholder { get; set; } = string.Empty;
    public IReadOnlyList<QuestSession> Sessions { get; set; } = [];
}
