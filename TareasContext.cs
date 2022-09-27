using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace WebAPI;

public class TareasContext: DbContext
{
    public DbSet<Categoria> Categorias {get;set;}
    public DbSet<Tarea> Tareas {get;set;}

    public TareasContext(DbContextOptions<TareasContext>options) :base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Categoria> categoriasInit = new List<Categoria>();
        categoriasInit.Add(new Categoria(){CategoriaId = Guid.Parse("91c48411-08ed-4964-aa46-35af87aa8a3d"), Nombre = "Actividades Pendientes", Peso = 20});
        categoriasInit.Add(new Categoria(){CategoriaId = Guid.Parse("91c48411-08ed-4964-aa46-35af87aa8a01"), Nombre = "Actividades Personales", Peso = 50});
        
        modelBuilder.Entity<Categoria>(categoria =>
        {
            categoria.ToTable("Categoria");
            categoria.HasKey(p=> p.CategoriaId);
            categoria.Property(p=> p.Nombre).IsRequired().HasMaxLength(150);
            categoria.Property(p=> p.Peso);
            categoria.Property(p=> p.Descripcion).IsRequired(false);
            categoria.HasData(categoriasInit);
        });

        List<Tarea> tareasInit = new List<Tarea>();
        tareasInit.Add(new Tarea(){TareaId = Guid.Parse("91c48411-08ed-4964-aa46-35af87aa8a10"), CategoriaId= Guid.Parse("91c48411-08ed-4964-aa46-35af87aa8a3d"), PrioridadTarea = Prioridad.Media, Titulo = "Pago de servicios publicos", FechaCreacion = DateTime.Now});
        tareasInit.Add(new Tarea(){TareaId = Guid.Parse("91c48411-08ed-4964-aa46-35af87aa8a11"), CategoriaId= Guid.Parse("91c48411-08ed-4964-aa46-35af87aa8a01"), PrioridadTarea = Prioridad.Baja, Titulo = "Terminar de ver pelicula en Netflix", FechaCreacion = DateTime.Now});

        modelBuilder.Entity<Tarea>(tarea =>
        {
            tarea.ToTable("Tarea");
            tarea.HasKey(p=> p.TareaId);
            tarea.HasOne(p=> p.Categoria).WithMany(p=> p.Tareas).HasForeignKey(p=> p.CategoriaId);
            tarea.Property(p=> p.Titulo).IsRequired().HasMaxLength(200);
            tarea.Property(p=> p.Descripcion).IsRequired(false);
            tarea.Property(p=> p.PrioridadTarea);
            tarea.Property(p=> p.FechaCreacion);
            tarea.Ignore(p=> p.Resumen);
            tarea.HasData(tareasInit);

        });
    }
}
