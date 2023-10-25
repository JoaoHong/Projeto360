using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Projeto360.DAO.Models;

public partial class TesteDevContext : DbContext
{
    public TesteDevContext()
    {
    }

    public TesteDevContext(DbContextOptions<TesteDevContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Produto> Produtos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=TesteDev;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Produto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Produto__3214EC0792953BEA");

            entity.ToTable("Produto");

            entity.Property(e => e.DataCriacao).HasColumnType("datetime");
            entity.Property(e => e.Nome).HasMaxLength(255);
            entity.Property(e => e.Preco).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3214EC072311713F");

            entity.ToTable("Usuario");

            entity.Property(e => e.Nome).HasMaxLength(150);
            entity.Property(e => e.Senha).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
