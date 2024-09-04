using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EISG20240902.Models;

namespace EISG20240902.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnosController : ControllerBase
    {
        // Declaración de una lista estática de objetos
        // "Alumno" para almacenar alumnos.
        static List<Alumno> alumnos = new List<Alumno>();

        // Definición de un método HTTP GET
        // que devuelve una colección de alumnos.
        [HttpGet]
        public IEnumerable<Alumno> Get()
        {
            return alumnos;
        }

        // Definición de un método HTTP GET
        // que recibe un ID como parámetro y devuelve un alumno específico.
        [HttpGet("{id}")]
        public Alumno Get(int id)
        {
            var alumno = alumnos.FirstOrDefault(c => c.Id == id);
            return alumno;
        }

        // Definición de un método HTTP POST
        // para agregar un nuevo alumno a la lista.
        [HttpPost]
        public IActionResult Post([FromBody] Alumno alumno)
        {
            alumnos.Add(alumno);
            return Ok();
        }

        // Definición de un método HTTP PUT
        // para actualizar un alumno existente en la lista por su ID.
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Alumno alumno)
        {
            var existingAlumno = alumnos.FirstOrDefault(c => c.Id == id);
            if (existingAlumno != null)
            {
                existingAlumno.Nombre = alumno.Nombre;
                existingAlumno.Apellido = alumno.Apellido;
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        // Definición de un método HTTP DELETE
        // para eliminar un alumno por su ID.
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingAlumno = alumnos.FirstOrDefault(c => c.Id == id);
            if (existingAlumno != null)
            {
                alumnos.Remove(existingAlumno);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
