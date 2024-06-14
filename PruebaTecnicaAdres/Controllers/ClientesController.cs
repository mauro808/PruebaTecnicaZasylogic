using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaAdres.Services;
using PruebaTecnicaAdres.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Data;

namespace PruebaTecnicaAdres.Controllers
{
    public class ClientesController : Controller
    {
        private readonly JsonFileService _jsonFileService;

        public ClientesController(JsonFileService jsonFileService)
        {
            _jsonFileService = jsonFileService;
        }

        [HttpGet]
        public IActionResult Lista()
        {
            //string selectQuery = "SELECT * FROM Clientes;";
            var Clientes = _jsonFileService.GetClientes();
            return View(Clientes);
        }

        [HttpGet]
        public ActionResult<List<Cliente>> GetClientes()
        {
            return _jsonFileService.GetClientes();
        }

        [HttpGet]
        public IActionResult Nuevo()
        {
            return View("Nuevo");
        }

        [HttpPost]
        public ActionResult Nuevo(Cliente cliente)
        {
            /**Ingreso de data SQL - AdoNet
             * string insertQuery = @"
                INSERT INTO Clientes (Nombres, Apellidos, Telefono, Email, Sexo, Motivo, FechaAlta)
                VALUES (@Nombres, @Apellidos, @Telefono, @Email, @Sexo, @Motivo, @FechaAlta);
            ";
            SqlParameter[] parameters = new SqlParameter[]
            {
                    new SqlParameter("@Nombres", SqlDbType.NVarChar) { Value = "Juan" },
                    new SqlParameter("@Apellidos", SqlDbType.NVarChar) { Value = "Pérez" },
                    new SqlParameter("@Telefono", SqlDbType.NVarChar) { Value = "123456789" },
                    new SqlParameter("@Email", SqlDbType.NVarChar) { Value = "juan@example.com" },
                    new SqlParameter("@Sexo", SqlDbType.NVarChar) { Value = "Masculino" },
                    new SqlParameter("@Motivo", SqlDbType.NVarChar) { Value = "Registro inicial" },
                    new SqlParameter("@FechaAlta", SqlDbType.DateTime) { Value = DateTime.Now }
            };**/
            cliente.FechaAlta = DateTime.Now.ToString("yyyy-MM-dd");
            _jsonFileService.CreateCliente(cliente);
            return RedirectToAction(nameof(Lista));
        }
    }
}
