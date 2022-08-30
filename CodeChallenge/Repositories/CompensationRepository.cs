using CodeChallenge.Data;
using CodeChallenge.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CodeChallenge.Repositories
{
    /// <summary>
    /// Concrete Compensation repository
    /// </summary>
    public class CompensationRepository : ICompensationRepository
    {
        private readonly EmployeeContext _employeeContext;
        private readonly ILogger<ICompensationRepository> _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="employeeContext"></param>
        public CompensationRepository(ILogger<ICompensationRepository> logger, EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
            _logger = logger;
        }

        /// <summary>
        /// Adds a compensation record to the repository
        /// </summary>
        /// <param name="compensation">Compensation object to add</param>
        /// <returns></returns>
        public Compensation Add(Compensation compensation)
        {
            _employeeContext.Compensations.Add(compensation);
            return compensation;
        }

        /// <summary>
        /// Gets the compensation from the repository based on employeeId
        /// </summary>
        /// <param name="id">Employee id to search by</param>
        /// <returns></returns>
        public Compensation GetByEmployeeId(string id)
        {
            // Retrieve the compensation and include the related employee
            return _employeeContext.Compensations
                                   .Include(x => x.Employee)
                                   .FirstOrDefault(e => e.Employee != null && 
                                                        e.Employee.EmployeeId == id);
        }

        /// <summary>
        /// Saves the current db context of any changes
        /// </summary>
        /// <returns></returns>
        public Task SaveAsync()
        {
            return _employeeContext.SaveChangesAsync();
        }
    }
}
