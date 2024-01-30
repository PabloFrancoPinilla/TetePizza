using System.Data.SqlClient;
using System.Collections.Generic;
using TetePizza.Models;

namespace TetePizza.Data;

public class PizzaSqlRepository : IPizzaRepository
{
    private readonly string _connectionString;

    public PizzaSqlRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public List<Pizza> GetAll()
    {
        List<Pizza> pizzas = new List<Pizza>();

        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            var sqlString = "SELECT Id, Name, IsGlutenFree FROM Pizza";
            var command = new SqlCommand(sqlString, connection);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var pizza = new Pizza
                    {

                        Id = Convert.ToInt16(reader["Id"].ToString()),
                        Name = reader["Name"].ToString(),
                        IsGlutenFree = (bool)reader["IsGlutenFree"]
                    };


                    pizzas.Add(pizza);
                }
            }
        }

        return pizzas;
    }

    public Pizza? Get(int id)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            var sqlString = "SELECT Id, Name, IsGlutenFree FROM Pizza WHERE Id=@Id";
            var command = new SqlCommand(sqlString, connection);
            command.Parameters.AddWithValue("@Id", id);

            using (var reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    var pizza = new Pizza
                    {
                        Id = Convert.ToInt16(reader["Id"].ToString()),
                        Name = reader["Name"].ToString(),
                        IsGlutenFree = (bool)reader["IsGlutenFree"]
                    };



                    return pizza;
                }
                else
                {
                    return null;
                }
            }
        }
    }

    public void Add(Pizza pizza)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            var sqlString = "INSERT INTO Pizza (Name, IsGlutenFree) VALUES (@Name, @IsGlutenFree); SELECT SCOPE_IDENTITY();";
            var command = new SqlCommand(sqlString, connection);
            command.Parameters.AddWithValue("@Name", pizza.Name);
            command.Parameters.AddWithValue("@IsGlutenFree", pizza.IsGlutenFree);


            var generatedId = command.ExecuteScalar();


            if (generatedId != null && generatedId != DBNull.Value)
            {
                pizza.Id = Convert.ToInt32(generatedId);
            }
        }
    }

    public void Delete(int id)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            var sqlString = "DELETE FROM Pizza WHERE Id=@Id";
            var command = new SqlCommand(sqlString, connection);
            command.Parameters.AddWithValue("@Id", id);

            command.ExecuteNonQuery();
        }
    }

    public void Update(Pizza pizza)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            var sqlString = "UPDATE Pizza SET Name=@Name, IsGlutenFree=@IsGlutenFree WHERE Id=@Id";
            var command = new SqlCommand(sqlString, connection);
            command.Parameters.AddWithValue("@Id", pizza.Id);
            command.Parameters.AddWithValue("@Name", pizza.Name);
            command.Parameters.AddWithValue("@IsGlutenFree", pizza.IsGlutenFree);

            command.ExecuteNonQuery();
        }
    }

    public void AddIngredient(int pizzaId, int ingredienteId)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            var sqlString = "INSERT INTO PizzaIngrediente (PizzaId, IngredienteId) VALUES (@PizzaId, @IngredienteId)";
            var command = new SqlCommand(sqlString, connection);
            command.Parameters.AddWithValue("@PizzaId", pizzaId);
            command.Parameters.AddWithValue("@IngredienteId", ingredienteId);

            command.ExecuteNonQuery();
        }
    }

    public void DeleteIngredient(int pizzaId, int ingredienteId)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            var sqlString = "DELETE FROM PizzaIngrediente WHERE PizzaId = @PizzaId AND IngredienteId = @IngredienteId";
            var command = new SqlCommand(sqlString, connection);
            command.Parameters.AddWithValue("@PizzaId", pizzaId);
            command.Parameters.AddWithValue("@IngredienteId", ingredienteId);

            command.ExecuteNonQuery();
        }
    }
}

