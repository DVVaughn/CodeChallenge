using CodeChallenge.Data;
using CodeChallenge.Models;
using System;
using System.Threading.Tasks;

namespace CodeChallenge.Repositories
{
    /// <summary>
    /// Interface of the compensation repo
    /// </summary>
    public interface ICompensationRepository
    {
        /// <summary>
        /// Gets the compensation from the repository based on employeeId
        /// </summary>
        /// <param name="id">Employee id to search by</param>
        /// <returns></returns>
        Compensation GetByEmployeeId(string id);

        /// <summary>
        /// Adds a compensation record to the repository
        /// </summary>
        /// <param name="compensation">Compensation object to add</param>
        /// <returns></returns>
        Compensation Add(Compensation compensation);

        /// <summary>
        /// Saves all changes to the repository
        /// </summary>
        /// <returns></returns>
        Task SaveAsync();
    }
}
