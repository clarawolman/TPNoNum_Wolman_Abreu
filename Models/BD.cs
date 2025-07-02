using Microsoft.Data.SqlClient;
using Dapper;

namespace try_catch_poc.Models;

class BD
{
    public string 
    public List<Integrante> LevantarIntegrante() {
        List <Integrante> integrantes = new List<Integrante>();
        using(SqlConnection connection = new SqlConnection(_connectionString)) {
            string query  "SELECT * FROM Patentes";
            patentes = connection.Query<Patente>(query).ToList();
        }
        return patentes;
    }
    public class Patente 
    {
        public string Matricula {get; set;}
        public DateTime FechaCompra{get;set;}
    }
}