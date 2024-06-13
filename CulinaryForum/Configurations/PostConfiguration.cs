using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CulinaryForum.Models;

namespace CulinaryForum.Configurations;

public class PostEntityConfiguration : IEntityTypeConfiguration<PostEntity>
{
    public void Configure(EntityTypeBuilder<PostEntity> builder)
    {
        builder
            .HasKey(p => p.Id);

        builder
            .Property(p => p.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder
            .Property(p => p.Content)
            .IsRequired();

        builder.Property(p => p.PostedDate)
            .IsRequired();

        builder
            .HasOne(p => p.Author)
            .WithMany()
            .HasForeignKey(p => p.AuthorId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}