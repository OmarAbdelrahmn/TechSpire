using TechSpire.Domain.Consts;

namespace TechSpire.infra.EntitiesConfigrations;

public class UserAnswerConfigration : IEntityTypeConfiguration<UserAnswer>
{
    public void Configure(EntityTypeBuilder<UserAnswer> builder)
    {
        //builder
        //    .HasKey(ua => new {ua.UserId, ua.QuestionId, ua.AnswerId });
    }
}

