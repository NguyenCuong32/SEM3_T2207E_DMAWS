using System.ComponentModel.DataAnnotations;

namespace demoApiweb.Models;

public class User
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Address  { get; set; }
}