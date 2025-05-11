using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;


namespace SurvayBasket.Infrastructure.Dbcontext;
public class AppDbcontext(DbContextOptions<AppDbcontext> options) : IdentityDbContext<AppUser>(options)
{
    public required DbSet<Poll> Polls { get; set; }
    public required DbSet<Question> Questions { get; set; }
    public required DbSet<Answer> Answers { get; set; }
    public required DbSet<Vote> Votes { get; set; }
    public required DbSet<VoteAnswer> VoteAnswers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        var cascadeFKs = modelBuilder.Model.GetEntityTypes()
            .SelectMany(t => t.GetForeignKeys())
            .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

        foreach (var fk in cascadeFKs)
            fk.DeleteBehavior = DeleteBehavior.Restrict;


        base.OnModelCreating(modelBuilder);

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.ConfigureWarnings(warnings =>
            warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
    }
}

