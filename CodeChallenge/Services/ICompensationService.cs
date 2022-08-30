using CodeChallenge.Models;
using System;

namespace CodeChallenge.Services
{
    /// <summary>
    /// The compensation service to modify the repository
    /// </summary>
    public interface ICompensationService
    {
        /// <summary>
        /// Gets the compensation based on employee Id
        /// </summary>
        /// <param name="id">Employee Id to search by</param>
        /// <returns></returns>
        Compensation GetByEmployeeId(string id);

        /// <summary>
        /// Adds a compensation record
        /// </summary>
        /// <param name="compensation">Compensation object to add</param>
        /// <returns></returns>
        Compensation Create(Compensation compensation);
    }
}
