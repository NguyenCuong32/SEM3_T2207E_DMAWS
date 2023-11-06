using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhamNgocDung.Models
{
    [Table("Employee_Tbl")]
    public class EmployeeModel
    {
        [Key]
        public int employeeId { get; set; }
        [ForeignKey("Department_Tbl")]
        public int departmentId { get; set; }
        public string employeeName { get; set; }
        public int employeeCode { get; set; }
            
        public string employeeDepartment { get; set; }
            
        public string employeeRank { get; set; }
        public string employeeEmail { get; set; }
        public string employeePassword { get; set; }
        public DepartmentModel Department { get; set; }

    }
}

//Employee include(employee name, employee code, department, rank)
