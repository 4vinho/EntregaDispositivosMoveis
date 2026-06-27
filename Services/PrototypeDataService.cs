using EntregaDispositivosMoveis.Models;
using EntregaDispositivosMoveis.ViewModels;

namespace EntregaDispositivosMoveis.Services;

public class PrototypeDataService
{
    private readonly IReadOnlyList<QuestSession> _sessions =
    [
        new QuestSession
        {
            Id = 1,
            Subject = "Direito Constitucional",
            QuestionsAnswered = 100,
            CorrectAnswers = 87,
            StudyDate = new DateOnly(2026, 6, 27)
        },
        new QuestSession
        {
            Id = 2,
            Subject = "Portugues",
            QuestionsAnswered = 50,
            CorrectAnswers = 42,
            StudyDate = new DateOnly(2026, 6, 26)
        },
        new QuestSession
        {
            Id = 3,
            Subject = "Informatica",
            QuestionsAnswered = 80,
            CorrectAnswers = 71,
            StudyDate = new DateOnly(2026, 6, 25)
        },
        new QuestSession
        {
            Id = 4,
            Subject = "Raciocinio Logico",
            QuestionsAnswered = 60,
            CorrectAnswers = 45,
            StudyDate = new DateOnly(2026, 6, 24)
        },
        new QuestSession
        {
            Id = 5,
            Subject = "Direito Penal",
            QuestionsAnswered = 70,
            CorrectAnswers = 56,
            StudyDate = new DateOnly(2026, 6, 23)
        }
    ];

    public DashboardViewModel GetDashboard()
    {
        var totalQuestions = _sessions.Sum(session => session.QuestionsAnswered);
        var totalCorrectAnswers = _sessions.Sum(session => session.CorrectAnswers);

        return new DashboardViewModel
        {
            StudentName = "Eduardo",
            TotalQuestions = totalQuestions,
            TotalCorrectAnswers = totalCorrectAnswers,
            TotalSubjects = _sessions.Select(session => session.Subject).Distinct().Count(),
            OverallAccuracy = Math.Round((decimal)totalCorrectAnswers / totalQuestions * 100, 1),
            RecentSessions = _sessions.Take(3).ToList()
        };
    }

    public HistoryViewModel GetHistory()
    {
        return new HistoryViewModel
        {
            SearchPlaceholder = "Buscar por materia",
            Sessions = _sessions.Take(4).ToList()
        };
    }

    public SessionFormViewModel GetCreateForm()
    {
        return new SessionFormViewModel
        {
            PageTitle = "Nova sessao",
            Subtitle = "Registre uma rodada de questoes.",
            CrudAction = "CREATE",
            CrudDescription = "Cria uma nova linha na planilha Google Sheets.",
            Subject = "Direito Penal",
            QuestionsAnswered = 40,
            CorrectAnswers = 32,
            StudyDate = new DateOnly(2026, 6, 27),
            PrimaryButtonText = "Salvar Sessao",
            SecondaryButtonText = "Cancelar",
            PrimaryButtonRoute = "Dashboard",
            SecondaryButtonRoute = "Dashboard"
        };
    }

    public SessionFormViewModel GetEditForm(int id)
    {
        var session = _sessions.First(session => session.Id == id);

        return new SessionFormViewModel
        {
            Id = session.Id,
            PageTitle = "Editar sessao",
            Subtitle = "Atualize os dados cadastrados.",
            CrudAction = "UPDATE",
            CrudDescription = "Edita uma linha existente da planilha.",
            Subject = session.Subject,
            QuestionsAnswered = session.QuestionsAnswered,
            CorrectAnswers = 90,
            StudyDate = session.StudyDate,
            PrimaryButtonText = "Salvar Alteracoes",
            SecondaryButtonText = "Voltar ao historico",
            PrimaryButtonRoute = "History",
            SecondaryButtonRoute = "History"
        };
    }

    public StatsViewModel GetStats()
    {
        var dashboard = GetDashboard();

        return new StatsViewModel
        {
            TotalQuestions = dashboard.TotalQuestions,
            TotalCorrectAnswers = dashboard.TotalCorrectAnswers,
            TotalIncorrectAnswers = dashboard.TotalQuestions - dashboard.TotalCorrectAnswers,
            OverallAccuracy = dashboard.OverallAccuracy,
            WeeklyVariationLabel = "+6% na semana",
            WeeklyPerformance = [54, 66, 58, 79, 91, 72, 100],
            SubjectPerformances =
            [
                new SubjectPerformance { Subject = "Direito Constitucional", AccuracyPercentage = 87 },
                new SubjectPerformance { Subject = "Portugues", AccuracyPercentage = 84 },
                new SubjectPerformance { Subject = "Informatica", AccuracyPercentage = 89 },
                new SubjectPerformance { Subject = "Raciocinio Logico", AccuracyPercentage = 75 }
            ]
        };
    }

    public DeleteSessionViewModel GetDeleteConfirmation(int id)
    {
        var session = _sessions.First(session => session.Id == id);

        return new DeleteSessionViewModel
        {
            Session = session
        };
    }
}
