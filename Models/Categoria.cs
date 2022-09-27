using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entity_Framework.Models;

public class Categoria
{
    public Guid CategoriaId {get;set;}
    public string Nombre {get;set;}
    public string Descripcion {get;set;}
    public int Peso {get;set;}
    [JsonIgnore]
    public virtual ICollection<Tarea> Tareas {get;set;}
}
