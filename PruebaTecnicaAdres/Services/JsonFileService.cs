using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Newtonsoft.Json;
using PruebaTecnicaAdres.Models;
using System.Xml;
using System.Text.Json;

namespace PruebaTecnicaAdres.Services
{
    public class JsonFileService
    {
        private readonly string _filePath;
        private int _nextId;

        public JsonFileService()
        {
            _filePath = Path.Combine(Directory.GetCurrentDirectory(), "clientes.json");
            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, "[]");
            }
        }

        public List<Cliente> GetClientes()
        {
            var json = File.ReadAllText(_filePath);
            return JsonConvert.DeserializeObject<List<Cliente>>(json);
        }

        public void SaveClientes(List<Cliente> clientes)
        {
            var json = JsonConvert.SerializeObject(clientes, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(_filePath, json);
        }

        public void CreateCliente(Cliente cliente)
        {
            var clientes = GetClientes();
            clientes.Add(cliente);
            SaveClientes(clientes);
        }

    }
}
