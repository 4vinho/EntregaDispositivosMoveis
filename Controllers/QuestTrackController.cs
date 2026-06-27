using EntregaDispositivosMoveis.Data;
using EntregaDispositivosMoveis.Models;
using EntregaDispositivosMoveis.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace EntregaDispositivosMoveis.Controllers;

public class QuestTrackController : Controller
{
    private readonly AppDbContext _dbContext;

    public QuestTrackController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult Dashboard()
    {
        var sessions = GetSessions();
        var totalQuestions = sessions.Sum(session => session.QuestionsAnswered);
        var totalCorrectAnswers = sessions.Sum(session => session.CorrectAnswers);

        var model = new DashboardViewModel
        {
            StudentName = "Eduardo",
            TotalQuestions = totalQuestions,
            TotalCorrectAnswers = totalCorrectAnswers,
            TotalSubjects = sessions.Select(session => session.Subject).Distinct().Count(),
            OverallAccuracy = CalculateAccuracy(totalCorrectAnswers, totalQuestions),
            RecentSessions = sessions.Take(3).ToList()
        };

        return View(model);
    }

    public IActionResult Create()
    {
        return View("SessionForm", BuildCreateFormModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(SessionFormViewModel model)
    {
        ValidateSession(model);

        if (!ModelState.IsValid)
        {
            ApplyCreateFormMetadata(model);
            return View("SessionForm", model);
        }

        _dbContext.QuestSessions.Add(new QuestSession
        {
            Subject = model.Subject.Trim(),
            QuestionsAnswered = model.QuestionsAnswered,
            CorrectAnswers = model.CorrectAnswers,
            StudyDate = model.StudyDate
        });
        _dbContext.SaveChanges();

        return RedirectToAction(nameof(History));
    }

    public IActionResult History()
    {
        var model = new HistoryViewModel
        {
            SearchPlaceholder = "Buscar por materia",
            Sessions = GetSessions()
        };

        return View(model);
    }

    public IActionResult Edit(int id = 1)
    {
        var session = _dbContext.QuestSessions.AsNoTracking().First(session => session.Id == id);

        return View("SessionForm", BuildEditFormModel(session));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(SessionFormViewModel model)
    {
        ValidateSession(model);

        if (!ModelState.IsValid)
        {
            ApplyEditFormMetadata(model);
            return View("SessionForm", model);
        }

        var session = _dbContext.QuestSessions.First(item => item.Id == model.Id);
        session.Subject = model.Subject.Trim();
        session.QuestionsAnswered = model.QuestionsAnswered;
        session.CorrectAnswers = model.CorrectAnswers;
        session.StudyDate = model.StudyDate;
        _dbContext.SaveChanges();

        return RedirectToAction(nameof(History));
    }

    public IActionResult Stats()
    {
        var sessions = GetSessions();
        var totalQuestions = sessions.Sum(session => session.QuestionsAnswered);
        var totalCorrectAnswers = sessions.Sum(session => session.CorrectAnswers);
        var today = DateOnly.FromDateTime(DateTime.Today);
        var last7Days = Enumerable.Range(0, 7)
            .Select(offset => today.AddDays(offset - 6))
            .ToList();

        var model = new StatsViewModel
        {
            TotalQuestions = totalQuestions,
            TotalCorrectAnswers = totalCorrectAnswers,
            TotalIncorrectAnswers = totalQuestions - totalCorrectAnswers,
            OverallAccuracy = CalculateAccuracy(totalCorrectAnswers, totalQuestions),
            WeeklyVariationLabel = "+6% na semana",
            WeeklyPerformance = last7Days
                .Select(day =>
                {
                    var daySessions = sessions.Where(session => session.StudyDate == day).ToList();
                    var dayQuestions = daySessions.Sum(session => session.QuestionsAnswered);
                    var dayCorrect = daySessions.Sum(session => session.CorrectAnswers);
                    return dayQuestions == 0 ? 0 : (int)Math.Round((double)dayCorrect / dayQuestions * 100);
                })
                .ToList(),
            SubjectPerformances = sessions
                .GroupBy(session => session.Subject)
                .Select(group =>
                {
                    var subjectQuestions = group.Sum(session => session.QuestionsAnswered);
                    var subjectCorrect = group.Sum(session => session.CorrectAnswers);

                    return new SubjectPerformance
                    {
                        Subject = group.Key,
                        AccuracyPercentage = subjectQuestions == 0
                            ? 0
                            : (int)Math.Round((double)subjectCorrect / subjectQuestions * 100)
                    };
                })
                .OrderByDescending(item => item.AccuracyPercentage)
                .ThenBy(item => item.Subject)
                .ToList()
        };

        return View(model);
    }

    public IActionResult Delete(int id = 1)
    {
        var session = _dbContext.QuestSessions.AsNoTracking().First(session => session.Id == id);
        var model = new DeleteSessionViewModel
        {
            Id = session.Id,
            Session = session
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var session = _dbContext.QuestSessions.First(item => item.Id == id);
        _dbContext.QuestSessions.Remove(session);
        _dbContext.SaveChanges();

        return RedirectToAction(nameof(History));
    }

    private List<QuestSession> GetSessions()
    {
        return _dbContext.QuestSessions
            .AsNoTracking()
            .OrderByDescending(session => session.StudyDate)
            .ThenByDescending(session => session.Id)
            .ToList();
    }

    private static decimal CalculateAccuracy(int totalCorrectAnswers, int totalQuestions)
    {
        return totalQuestions == 0
            ? 0
            : Math.Round((decimal)totalCorrectAnswers / totalQuestions * 100, 1);
    }

    private static SessionFormViewModel BuildCreateFormModel()
    {
        var model = new SessionFormViewModel
        {
            StudyDate = DateOnly.FromDateTime(DateTime.Today)
        };

        ApplyCreateFormMetadata(model);
        return model;
    }

    private static SessionFormViewModel BuildEditFormModel(QuestSession session)
    {
        var model = new SessionFormViewModel
        {
            Id = session.Id,
            Subject = session.Subject,
            QuestionsAnswered = session.QuestionsAnswered,
            CorrectAnswers = session.CorrectAnswers,
            StudyDate = session.StudyDate
        };

        ApplyEditFormMetadata(model);
        return model;
    }

    private static void ApplyCreateFormMetadata(SessionFormViewModel model)
    {
        model.PageTitle = "Nova sessao";
        model.Subtitle = "Registre uma rodada de questoes.";
        model.CrudAction = "CREATE";
        model.CrudDescription = "Cria uma nova sessao no banco SQLite.";
        model.FormAction = "Create";
        model.PrimaryButtonText = "Salvar Sessao";
        model.SecondaryButtonText = "Cancelar";
        model.SecondaryButtonRoute = "Dashboard";
    }

    private static void ApplyEditFormMetadata(SessionFormViewModel model)
    {
        model.PageTitle = "Editar sessao";
        model.Subtitle = "Atualize os dados cadastrados.";
        model.CrudAction = "UPDATE";
        model.CrudDescription = "Atualiza a sessao salva no banco SQLite.";
        model.FormAction = "Edit";
        model.PrimaryButtonText = "Salvar Alteracoes";
        model.SecondaryButtonText = "Voltar ao historico";
        model.SecondaryButtonRoute = "History";
    }

    private void ValidateSession(SessionFormViewModel model)
    {
        if (model.CorrectAnswers > model.QuestionsAnswered)
        {
            ModelState.AddModelError(nameof(model.CorrectAnswers), "Acertos nao pode ser maior que questoes feitas.");
        }
    }
}
