using Microsoft.EntityFrameworkCore;
using TuEmpresa.Model;

namespace TuEmpresa.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        // DbSet para cada entidad
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Distrito> Distritos { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<NombreNegocio> NombresNegocios { get; set; }
        public DbSet<Negocio> Negocios { get; set; }
        public DbSet<Notaria> Notarias { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<Solicitud> Solicitudes { get; set; }
        public DbSet<TipoDocumento> TiposDocumentos { get; set; }
        public DbSet<TipoModalidadEmpresarial> TiposModalidadEmpresarial { get; set; }
        public DbSet<TipoPersona> TiposPersonas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar las tablas (opcional si los nombres coinciden)
            modelBuilder.Entity<Comentario>().ToTable("comentarios");
            modelBuilder.Entity<Departamento>().ToTable("departamentos");
            modelBuilder.Entity<Distrito>().ToTable("distritos");
            modelBuilder.Entity<Estado>().ToTable("estados");
            modelBuilder.Entity<NombreNegocio>().ToTable("names");
            modelBuilder.Entity<Negocio>().ToTable("negocios");
            modelBuilder.Entity<Notaria>().ToTable("notarias");
            modelBuilder.Entity<Persona>().ToTable("personas");
            modelBuilder.Entity<Provincia>().ToTable("provincias");
            modelBuilder.Entity<Solicitud>().ToTable("solicitudes");
            modelBuilder.Entity<TipoDocumento>().ToTable("tipos_documentos");
            modelBuilder.Entity<TipoModalidadEmpresarial>().ToTable("tipos_modalidad_empresarial");
            modelBuilder.Entity<TipoPersona>().ToTable("tipos_persona");

            // Configurar las claves primarias
            modelBuilder.Entity<Comentario>().HasKey(c => c.Id);
            modelBuilder.Entity<Departamento>().HasKey(d => d.Id);
            modelBuilder.Entity<Distrito>().HasKey(d => d.Id);
            modelBuilder.Entity<Estado>().HasKey(e => e.Id);
            modelBuilder.Entity<NombreNegocio>().HasKey(nn => nn.Id);
            modelBuilder.Entity<Negocio>().HasKey(n => n.Id);
            modelBuilder.Entity<Notaria>().HasKey(n => n.Id);
            modelBuilder.Entity<Persona>().HasKey(p => p.Id);
            modelBuilder.Entity<Persona>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Provincia>().HasKey(p => p.Id);
            modelBuilder.Entity<Solicitud>().HasKey(s => s.Id);
            modelBuilder.Entity<TipoDocumento>().HasKey(td => td.Id);
            modelBuilder.Entity<TipoModalidadEmpresarial>().HasKey(tm => tm.Id);
            modelBuilder.Entity<TipoPersona>().HasKey(tp => tp.Id);

            // Configuración de relaciones y claves foráneas

            // Comentario - Solicitud (Muchos a Uno)
            modelBuilder.Entity<Comentario>()
                .HasOne(c => c.Solicitud)
                .WithMany(s => s.Comentarios)
                .HasForeignKey(c => c.IdSolicitud)
                .OnDelete(DeleteBehavior.Cascade);

            // Negocio - TipoModalidadEmpresarial (Muchos a Uno)
            modelBuilder.Entity<Negocio>()
                .HasOne(n => n.TipoModalidadEmpresarial)
                .WithMany(tm => tm.Negocios)
                .HasForeignKey(n => n.IdTipoModalidad)
                .OnDelete(DeleteBehavior.Restrict);

            // Negocio - Departamento, Provincia, Distrito (Muchos a Uno)
            modelBuilder.Entity<Negocio>()
                .HasOne(n => n.Departamento)
                .WithMany(d => d.Negocios)
                .HasForeignKey(n => n.IdDepartamento)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Negocio>()
                .HasOne(n => n.Provincia)
                .WithMany(p => p.Negocios)
                .HasForeignKey(n => n.IdProvincia)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Negocio>()
                .HasOne(n => n.Distrito)
                .WithMany(d => d.Negocios)
                .HasForeignKey(n => n.IdDistrito)
                .OnDelete(DeleteBehavior.Restrict);

            // Persona - TipoDocumento (Muchos a Uno)
            modelBuilder.Entity<Persona>()
                .HasOne(p => p.TipoDocumento)
                .WithMany(td => td.Personas)
                .HasForeignKey(p => p.IdTipoDocumento)
                .OnDelete(DeleteBehavior.Restrict);

            // Persona - TipoPersona (Muchos a Uno)
            modelBuilder.Entity<Persona>()
                .HasOne(p => p.TipoPersona)
                .WithMany(tp => tp.Personas)
                .HasForeignKey(p => p.IdTipoPersona)
                .OnDelete(DeleteBehavior.Restrict);

            // Persona - Departamento, Provincia, Distrito (Muchos a Uno)
            modelBuilder.Entity<Persona>()
                .HasOne(p => p.Departamento)
                .WithMany(d => d.Personas)
                .HasForeignKey(p => p.IdDepartamento)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Persona>()
                .HasOne(p => p.Provincia)
                .WithMany(pv => pv.Personas)
                .HasForeignKey(p => p.IdProvincia)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Persona>()
                .HasOne(p => p.Distrito)
                .WithMany(d => d.Personas)
                .HasForeignKey(p => p.IdDistrito)
                .OnDelete(DeleteBehavior.Restrict);

            // Notaria - Departamento, Provincia, Distrito (Muchos a Uno)
            modelBuilder.Entity<Notaria>()
                .HasOne(n => n.Departamento)
                .WithMany(d => d.Notarias)
                .HasForeignKey(n => n.IdDepartamento)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Notaria>()
                .HasOne(n => n.Provincia)
                .WithMany(p => p.Notarias)
                .HasForeignKey(n => n.IdProvincia)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Notaria>()
                .HasOne(n => n.Distrito)
                .WithMany(d => d.Notarias)
                .HasForeignKey(n => n.IdDistrito)
                .OnDelete(DeleteBehavior.Restrict);

            // Solicitud - Estado (Muchos a Uno)
            modelBuilder.Entity<Solicitud>()
                .HasOne(s => s.Estado)
                .WithMany(e => e.Solicitudes)
                .HasForeignKey(s => s.IdEstado)
                .OnDelete(DeleteBehavior.Restrict);

            // Solicitud - Persona (Muchos a Uno)
            modelBuilder.Entity<Solicitud>()
                .HasOne(s => s.Persona)
                .WithMany(p => p.Solicitudes)
                .HasForeignKey(s => s.IdPersona)
                .OnDelete(DeleteBehavior.Restrict);

            // Solicitud - Negocio (Muchos a Uno, opcional)
            modelBuilder.Entity<Solicitud>()
                .HasOne(s => s.Negocio)
                .WithMany(n => n.Solicitudes)
                .HasForeignKey(s => s.IdNegocio)
                .OnDelete(DeleteBehavior.Restrict);

            // Solicitud - Notaria (Muchos a Uno, opcional)
            modelBuilder.Entity<Solicitud>()
                .HasOne(s => s.Notaria)
                .WithMany(n => n.Solicitudes)
                .HasForeignKey(s => s.IdNotaria)
                .OnDelete(DeleteBehavior.Restrict);

            // NombreNegocio - Negocio (Muchos a Uno)
            modelBuilder.Entity<NombreNegocio>()
                .HasOne(nn => nn.Negocio)
                .WithMany(n => n.NombresNegocios)
                .HasForeignKey(nn => nn.IdNegocio)
                .OnDelete(DeleteBehavior.Restrict);

            // NombreNegocio - Estado (Muchos a Uno)
            modelBuilder.Entity<NombreNegocio>()
                .HasOne(nn => nn.Estado)
                .WithMany(e => e.NombresNegocios)
                .HasForeignKey(nn => nn.IdEstado)
                .OnDelete(DeleteBehavior.Restrict);
        }
        }
}
