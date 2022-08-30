using System;

namespace CodeChallenge.Models
{
    /// <summary>
    /// Represents the compensation an employee can have. 
    /// One employee could have many compensations.
    /// </summary>
    public class Compensation
    {
        /// <summary>
        /// The compensation record's Id
        /// </summary>
        public long CompensationId { get; set; }

        /// <summary>
        /// The amount of money earned by the Employee
        /// </summary>
        public decimal Salary { get; set; }

        /// <summary>
        /// The date the compensation begins to be earned by the Employee
        /// </summary>
        public DateTime EffectiveDate { get; set; }

        /// <summary>
        /// The Employee object this compensation is related to
        /// </summary>
        public Employee Employee { get; set; }
    }
}
