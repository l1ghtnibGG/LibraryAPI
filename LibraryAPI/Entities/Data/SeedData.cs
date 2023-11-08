using Entities.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Entities.Data;

public static class SeedData
{
    public static void EnsureData(IApplicationBuilder app)
    {
        LibraryDbContext context = app.ApplicationServices
            .CreateScope().ServiceProvider.GetRequiredService<LibraryDbContext>();

        if (context.Database.GetPendingMigrations().Any())
        {
            context.Database.Migrate();
        }

        if (!context.Users.Any())
        {
            context.AddRange(
                new User
                {
                    Email = "vlad123@mail.ru",
                    Name = "Vlad",
                    Password = "1234",
                    Books =
                    {
                        new Book
                        {
                            ISBN = "9783127323207",
                            Name = "War And Peace",
                            Genre = "Novel",
                            Description = "The work chronicles the Napoleonic era within Russia, " +
                                          "notably detailing the French invasion of Russia and its aftermath. " +
                                          "The book highlights the impact of Napoleon on Tsarist society through " +
                                          "five interlocking narratives following different " +
                                          "Russian aristocratic families.",
                            Author = "Leo Tolstoy",
                            DateOfTake = DateTime.Now.AddDays(-5)
                        },
                        new Book
                        {
                            ISBN = "9783127323607",
                            Name = "The Art of War",
                            Genre = "Military art",
                            Description = "The book contains a detailed explanation and analysis " +
                                          "of the 5th-century BC Chinese military, from weapons, " +
                                          "environmental conditions, and strategy to rank and discipline. " +
                                          "Sun also stressed the importance of intelligence operatives and " +
                                          "espionage to the war effort. Considered one of history's finest " +
                                          "military tacticians and analysts, his teachings and strategies " +
                                          "formed the basis of advanced military training for millennia to come.",
                            Author = "Sun Tzu",
                            DateOfTake = DateTime.Now.AddDays(-20),
                            DateOfReturn = DateTime.Now.AddDays(-5)
                        }
                    }
                },
                new User
                {
                    Email = "vika123@mail.ru",
                    Name = "Vika",
                    Password = "1234",
                    Books =
                    {
                        new Book
                        {
                            ISBN = "9783427323201",
                            Name = "The Prince",
                            Genre = "Political science",
                            Description = "The Prince was written as if it were a traditional work " +
                                          "in the mirrors for princes style, it was generally agreed " +
                                          "as being especially innovative. This is partly because it " +
                                          "was written in the vernacular Italian rather than Latin, a " +
                                          "practice that had become increasingly popular since the " +
                                          "publication of Dante's Divine Comedy and other works of " +
                                          "Renaissance literature.",
                            Author = "Niccolo Machiavelli",
                            DateOfTake = DateTime.Now.AddDays(-1)
                        }
                    }
                },
                new User
                {
                    Email = "petya123@mail.ru",
                    Name = "Petya",
                    Password = "1234",
                    Books =
                    {
                        new Book
                        {
                            ISBN = "9783427328301",
                            Name = "Anna Karenina",
                            Genre = "Realist novel",
                            Description = "The novel deals with themes of betrayal, faith, " +
                                          "family, marriage, Imperial Russian society, desire, " +
                                          "and the differences between rural and urban life. The " +
                                          "story centers on an extramarital affair between Anna and " +
                                          "dashing cavalry officer Count Alexei Kirillovich Vronsky that " +
                                          "scandalizes the social circles of Saint Petersburg and forces " +
                                          "the young lovers to flee to Italy in a search for happiness, " +
                                          "but after they return to Russia, their lives further unravel.",
                            Author = "Leo Tolstoy",
                            DateOfTake = DateTime.Now
                        }
                    }
                });
            
            context.SaveChanges();
        }
    }
}