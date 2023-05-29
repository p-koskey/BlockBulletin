using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfiguration;

public class UserNeighbourhoodConfiguration : IEntityTypeConfiguration<UserNeighbourhood>
{
    public void Configure(EntityTypeBuilder<UserNeighbourhood> builder)
    {
        builder.HasKey(un => un.Id);
    }
}
