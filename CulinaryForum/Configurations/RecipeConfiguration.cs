using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CulinaryForum.Models;

namespace CulinaryForum.Configurations;

public class RecipeEntityConfiguration : IEntityTypeConfiguration<RecipeEntity>
{
    public void Configure(EntityTypeBuilder<RecipeEntity> builder)
    {
        builder
            .HasKey(r => r.Id);

        builder
            .Property(r => r.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder
            .Property(r => r.Content)
            .IsRequired();

        builder
            .HasOne(r => r.Author)
            .WithMany()
            .HasForeignKey(r => r.AuthorId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}