using Microsoft.EntityFrameworkCore.Diagnostics;


namespace TechSpire.infra.Dbcontext;
public class AppDbcontext(DbContextOptions<AppDbcontext> options) : IdentityDbContext<ApplicataionUser>(options)
{


    public DbSet<RefreshToken> RefreshTokens { get; set; } = default!;
    public DbSet<Stage> Stages { get; set; } = default!;
    public DbSet<Lesson> Lessons { get; set; } = default!;
    public DbSet<Quiz> Quizzes { get; set; } = default!;
    public DbSet<Answer> Answers{ get; set; } = default!;
    public DbSet<UserAnswer> UserAnswers { get; set; } = default!;
    public DbSet<Post> Posts { get; set; } = default!;
    public DbSet<Article> Articles { get; set; } = default!;
    public DbSet<Book> Books { get; set; } = default!;
    public DbSet<Question> Questions { get; set; } = default!;




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

