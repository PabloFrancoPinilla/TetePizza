using System.Data.SqlClient;
using System.Collections.Generic;
using TetePizza.Models;

namespace TetePizza.Data
{
    public class IngredienteSqlRepository : IIngredienteRepository
    {
        private readonly string _connectionString;

        public IngredienteSqlRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Ingrediente> GetAll()
        {
            List<Ingrediente> Ingredientes = new List<Ingrediente>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sqlString = "SELECT Id, Name, Origin, Stock, Description, IsVegan FROM Ingrediente";
                var command = new SqlCommand(sqlString, connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var Ingrediente = new Ingrediente
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            Origin = reader["Origin"].ToString(),
                            Stock = reader["Stock"] as int?,  
                            Description = reader["Description"].ToString(),
                            IsVegan = (bool)reader["IsVegan"]
                        };

                        Ingredientes.Add(Ingrediente);
                    }
                }
            }

            return Ingredientes;
        }

        public Ingrediente Get(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sqlString = "SELECT Id, Name, Origin, Stock, Description, IsVegan FROM Ingrediente WHERE Id=@Id";
                var command = new SqlCommand(sqlString, connection);
                command.Parameters.AddWithValue("@Id", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var Ingrediente = new Ingrediente
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            Origin = reader["Origin"].ToString(),
                            Stock = reader["Stock"] as int?,  
                            Description = reader["Description"].ToString(),
                            IsVegan = (bool)reader["IsVegan"]
                        };

                        return Ingrediente;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public void Add(Ingrediente Ingrediente)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sqlString = "INSERT INTO Ingrediente (Name, Origin, Stock, Description, IsVegan) VALUES (@Name, @Origin, @Stock, @Description, @IsVegan); SELECT SCOPE_IDENTITY();";
                var command = new SqlCommand(sqlString, connection);
                command.Parameters.AddWithValue("@Name", Ingrediente.Name);
                command.Parameters.AddWithValue("@Origin", Ingrediente.Origin);
                command.Parameters.AddWithValue("@Stock", Ingrediente.Stock ?? (object)DBNull.Value); 
                command.Parameters.AddWithValue("@Description", Ingrediente.Description);
                command.Parameters.AddWithValue("@IsVegan", Ingrediente.IsVegan);

                var generatedId = command.ExecuteScalar();

                if (generatedId != null && generatedId != DBNull.Value)
                {
                    Ingrediente.Id = Convert.ToInt32(generatedId);
                }
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sqlString = "DELETE FROM Ingrediente WHERE Id=@Id";
                var command = new SqlCommand(sqlString, connection);
                command.Parameters.AddWithValue("@Id", id);

                command.ExecuteNonQuery();
            }
        }

        public void Update(Ingrediente Ingrediente)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sqlString = "UPDATE Ingrediente SET Name=@Name, Origin=@Origin, Stock=@Stock, Description=@Description, IsVegan=@IsVegan WHERE Id=@Id";
                var command = new SqlCommand(sqlString, connection);
                command.Parameters.AddWithValue("@Id", Ingrediente.Id);
                command.Parameters.AddWithValue("@Name", Ingrediente.Name);
                command.Parameters.AddWithValue("@Origin", Ingrediente.Origin);
                command.Parameters.AddWithValue("@Stock", Ingrediente.Stock ?? (object)DBNull.Value); 
                command.Parameters.AddWithValue("@Description", Ingrediente.Description);
                command.Parameters.AddWithValue("@IsVegan", Ingrediente.IsVegan);

                command.ExecuteNonQuery();
            }
        }

        public void AddIngredient(int IngredienteId, int ingredientId)
        {
          
        }

        public void DeleteIngredient(int IngredienteId, int ingredientId)
        {
            
        }
    }
}
