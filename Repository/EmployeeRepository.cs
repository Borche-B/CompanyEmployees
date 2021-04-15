using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            
        }

        public void CreateEmployeeForCompany(Guid companyId, Employee employee)
        {
            employee.CompanyId = companyId;
            Create(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            Delete(employee);
        }

        public Employee GetEmployee(Guid companyId, Guid id, bool trackChanges) =>
            FindByCondition(x => x.CompanyId == companyId && x.Id == id, trackChanges)
                .SingleOrDefault();

        public IEnumerable<Employee> GetEmployees(Guid companyId, bool trackChanges) =>
                FindByCondition(e => e.CompanyId == companyId, trackChanges).OrderBy(x => x.Name);


                
    }
}
