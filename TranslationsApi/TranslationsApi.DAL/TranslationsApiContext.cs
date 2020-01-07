using Microsoft.EntityFrameworkCore;
using TranslationsApi.Core.Models;

namespace TranslationsApi.DAL
{
    public class TranslationsApiContext: DbContext
    {
        public DbSet<Language> Languages { get; set; }

        public DbSet<Key> Keys { get; set; }

        public TranslationsApiContext(DbContextOptions options): base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost; Database=TranslationsDB; Integrated Security=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Key>(entity =>
            {
                entity.HasOne(entity => entity.Language)
                .WithMany(entity => entity.Keys)
                .HasForeignKey(entity => entity.LanguageId)
                .HasConstraintName("Key_Language");

                entity.Property(entity => entity.KeyName)
                .IsRequired();

                entity.HasKey(entity => new { entity.LanguageId, entity.KeyName });
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.Property(entity => entity.Id).ValueGeneratedOnAdd();

                entity.Property(entity => entity.LangCode).IsRequired();

                entity.HasIndex(entity => entity.LangCode).IsUnique();
            });
        }
    }
}
