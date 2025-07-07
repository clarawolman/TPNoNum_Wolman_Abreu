using Microsoft.Data.SqlClient;
using Dapper;

namespace try_catch_poc.Models;

public static class BD
{
    private static string _connectionString = @"Server=localhost;DataBase=TP;Integrated Security=True;TrustServerCertificate=True;";

    public static List<Integrante> LevantarIntegrante()
    {
        List<Integrante> integrantes = new List<Integrante>();
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM Integrante";
            integrantes = connection.Query<Integrante>(query).ToList();
        }
        return integrantes;
    }
    public static Integrante BuscarIntegrante(string usuario, string password)
    {
        Integrante newIntegrante = null;
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Integrantes WHERE usuario = @usuario AND password = @password";
            newIntegrante = connection.QueryFirstOrDefault<Integrante>(sql, new { usuario, password });
        }
        return newIntegrante;
    }
}