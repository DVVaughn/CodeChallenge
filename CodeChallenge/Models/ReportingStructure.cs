namespace CodeChallenge.Models
{
    /// <summary>
    /// Represents the reporting structure of an employee
    /// </summary>
    public class ReportingStructure
    {
        #region Properties
        /// <summary>
        /// Employee that this reporting structure represents
        /// </summary>
        public Employee Employee { get; set; }

        /// <summary>
        /// The number of direct reporting employees to the Employee property 
        /// </summary>
        public int NumberOfReports
        {
            get
            {
                int reportNum = 0;

                // IF(Employee and DirectReport is not null)
                if (Employee != null && Employee.DirectReports != null)
                    reportNum = Employee.DirectReports.Count;

                return reportNum;
            }
        }
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pEmployee">The Employee</param>
        public ReportingStructure(Employee pEmployee)
        {
            Employee = pEmployee;
        }
    }
}
