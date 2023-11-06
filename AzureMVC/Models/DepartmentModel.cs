using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhamNgocDung.Models
{
    [Table("Department_Tbl")]
    public class DepartmentModel
    {
        [Key]
        public int departmentId { get; set; }
        public string departmentName { get; set; }
        public string departmentCode { get; set;}
        public string departmentLocation { get; set;}
        public string departmentNumbPersonals { get; set;}
        public ICollection<EmployeeModel> Employees { get; set; }
    }
}

//Department include (department name, department code, location, number of personals, ....)