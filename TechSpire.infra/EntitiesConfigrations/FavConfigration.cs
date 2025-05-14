using TechSpire.Domain.Consts;

namespace TechSpire.infra.EntitiesConfigrations;

public class FavConfigration : IEntityTypeConfiguration<Fav>
{
    public void Configure(EntityTypeBuilder<Fav> builder)
    {
        builder
            .HasKey(ua => new {ua.UserId, ua.ItemId, ua.Type});
    }
}

