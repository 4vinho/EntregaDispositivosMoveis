using EntregaDispositivosMoveis.Models;
using Microsoft.EntityFrameworkCore;

namespace EntregaDispositivosMoveis.Data;

public static class DbInitializer
{
    public static void Seed(AppDbContext dbContext)
    {
        dbContext.Database.ExecuteSqlRaw(
            """
            CREATE TABLE IF NOT EXISTS QuestSessions (
                Id INTEGER NOT NULL CONSTRAINT PK_QuestSessions PRIMARY KEY AUTOINCREMENT,
                Subject TEXT NOT NULL,
                QuestionsAnswered INTEGER NOT NULL,
                CorrectAnswers INTEGER NOT NULL,
                StudyDate TEXT NOT NULL
            );
            """);

        if (dbContext.QuestSessions.Any())
        {
            return;
        }

        dbContext.QuestSessions.AddRange(
            new QuestSession
            {
                Subject = "Direito Constitucional",
                QuestionsAnswered = 100,
                CorrectAnswers = 87,
                StudyDate = new DateOnly(2026, 6, 27)
            },
            new QuestSession
            {
                Subject = "Portugues",
                QuestionsAnswered = 50,
                CorrectAnswers = 42,
                StudyDate = new DateOnly(2026, 6, 26)
            },
            new QuestSession
            {
                Subject = "Informatica",
                QuestionsAnswered = 80,
                CorrectAnswers = 71,
                StudyDate = new DateOnly(2026, 6, 25)
            },
            new QuestSession
            {
                Subject = "Raciocinio Logico",
                QuestionsAnswered = 60,
                CorrectAnswers = 45,
                StudyDate = new DateOnly(2026, 6, 24)
            },
            new QuestSession
            {
                Subject = "Direito Penal",
                QuestionsAnswered = 70,
                CorrectAnswers = 56,
                StudyDate = new DateOnly(2026, 6, 23)
            });

        dbContext.SaveChanges();
    }
}
