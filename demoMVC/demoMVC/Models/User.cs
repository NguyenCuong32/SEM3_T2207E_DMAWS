using System.ComponentModel.DataAnnotations;

namespace demoMVC.Models;

public class User
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Address { get; set; }
}