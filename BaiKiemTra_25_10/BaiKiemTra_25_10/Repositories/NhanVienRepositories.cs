using Microsoft.Identity.Client;
using BaiKiemTra_25_10.Context;
using BaiKiemTra_25_10.DomainClass;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiKiemTra_25_10.Repositories
{
    internal class NhanVienRepositories
    {
        private DBContext dbContext;
        private Employees employees;
        public NhanVienRepositories()
        {
            dbContext = new DBContext();
        }
        public List<Employees> GetEmployees()
        {
            List<Employees> data = dbContext.Employees.ToList();
            return data;
        }
        public bool AddEmployee(Employees employees)
        {
            if (employees == null)
            {
                return false;
            }
            else
            {
                dbContext.Employees.Add(employees);
                dbContext.SaveChanges();
                return true;
            }
        }
        public bool DeleteEmployee(Employees employees)
        {
            if (employees == null)
            {
                return false;
            }
            else
            {
                dbContext.Employees.Remove(employees);
                dbContext.SaveChanges();
                return true;
            }
        }
    }
}
