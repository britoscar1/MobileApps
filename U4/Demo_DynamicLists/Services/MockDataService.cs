using Demo_DynamicLists.Models;

namespace Demo_DynamicLists.Services;

public sealed class MockDataService : IMateriaDataService
{
    private static readonly List<Materia> _materias =
    [
        new() { Id = 1, Nombre = "Aplicaciones Moviles", Docente = "Dr. Carlos Ramirez", Creditos = 6, HorarioTexto = "Lun-Mie 10:00-12:00" },
        new() { Id = 2, Nombre = "Bases de Datos Avanzadas", Docente = "Dra. Laura Mendez", Creditos = 6, HorarioTexto = "Mar-Jue 08:00-10:00" },
        new() { Id = 3, Nombre = "Ingenieria de Software", Docente = "M.C. Roberto Flores", Creditos = 8, HorarioTexto = "Lun-Mie 14:00-16:00" },
        new() { Id = 4, Nombre = "Redes de Computadoras", Docente = "Dr. Fernando Castillo", Creditos = 6, HorarioTexto = "Mar-Jue 10:00-12:00" },
        new() { Id = 5, Nombre = "Inteligencia Artificial", Docente = "Dra. Ana Torres", Creditos = 8, HorarioTexto = "Lun-Mie 08:00-10:00" },
        new() { Id = 6, Nombre = "Sistemas Operativos", Docente = "M.C. Jorge Navarro", Creditos = 6, HorarioTexto = "Mar-Jue 14:00-16:00" },
        new() { Id = 7, Nombre = "Compiladores", Docente = "Dr. Miguel Herrera", Creditos = 6, HorarioTexto = "Vie 08:00-12:00" },
        new() { Id = 8, Nombre = "Seguridad Informatica", Docente = "M.C. Patricia Rios", Creditos = 6, HorarioTexto = "Lun-Mie 16:00-18:00" },
        new() { Id = 9, Nombre = "Arquitectura de Computadoras", Docente = "Dr. Eduardo Vargas", Creditos = 6, HorarioTexto = "Mar-Jue 16:00-18:00" },
        new() { Id = 10, Nombre = "Programacion Web", Docente = "Dra. Sofia Luna", Creditos = 6, HorarioTexto = "Vie 14:00-18:00" },
    ];

    public async Task<List<Materia>> ObtenerMateriasAsync()
    {
        // Simula latencia de red/carga
        await Task.Delay(500);
        return [.. _materias];
    }
}
