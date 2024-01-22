namespace TetePizza.Models;

public class Ingrediente
{
    public int Id;
    public string Name { get; set; }
    public string Origin { get; set; }

    public int? Stock { get; set; }
    public string Description { get; set; }
    public Boolean IsVegan { get; set; }

}