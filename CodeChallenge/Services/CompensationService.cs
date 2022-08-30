using CodeChallenge.Models;
using CodeChallenge.Repositories;
using Microsoft.Extensions.Logging;
using System;

namespace CodeChallenge.Services
{
    /// <summary>
    /// Concrete Compensation service
    /// </summary>
    public class CompensationService : ICompensationService
    {

        private readonly ICompensationRepository _compensationRepository;
        private readonly ILogger<CompensationService> _logger;

        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="compensationRepo"></param>
        public CompensationService(ILogger<CompensationService> logger, ICompensationRepository compensationRepo)
        {
            _compensationRepository = compensationRepo;
            _logger = logger;
        }

        /// <summary>
        /// Adds a compensation record
        /// </summary>
        /// <param name="compensation">Compensation object to add</param>
        /// <returns></returns>
        /// 
        public Compensation Create(Compensation compensation)
        {
            if (compensation != null)
            {
                _compensationRepository.Add(compensation);
                _compensationRepository.SaveAsync().Wait();
            }

            return compensation;
        }

        /// <summary>
        /// Gets the compensation based on employee Id
        /// </summary>
        /// <param name="id">Employee Id to search by</param>
        /// <returns></returns>
        public Compensation GetByEmployeeId(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                return _compensationRepository.GetByEmployeeId(id);
            }

            return null;
        }
    }
}
