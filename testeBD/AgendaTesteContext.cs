using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Teste_com_Banco_de_Dados_Agenda.testeBD;

public partial class AgendaTesteContext : DbContext
{
    public AgendaTesteContext()
    {
    }

    public AgendaTesteContext(DbContextOptions<AgendaTesteContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Contato> Contato { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=admin;database=agendaTeste", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Contato>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("contato");

            entity.HasIndex(e => e.Email, "email").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(128)
                .HasColumnName("email");
            entity.Property(e => e.FotoUrl)
                .HasMaxLength(10000)
                .HasColumnName("foto_url");
            entity.Property(e => e.Nome)
                .HasMaxLength(64)
                .HasColumnName("nome");
            entity.Property(e => e.Telefone)
                .HasPrecision(11)
                .HasColumnName("telefone");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}