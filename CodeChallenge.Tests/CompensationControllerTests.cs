using CodeChallenge.Models;
using CodeCodeChallenge.Tests.Integration.Extensions;
using CodeCodeChallenge.Tests.Integration.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge.Tests.Integration
{
    [TestClass]
    public class CompensationControllerTests
    {
        private static HttpClient _httpClient; // The Http client to send requests to compensation controller
        private static TestServer _testServer; // Helper method to imitate a server for the web application
                                               
        /// <summary>
        /// Attribute ClassInitialize requires this signature.
        /// </summary>
        /// <param name="context"></param>
        [ClassInitialize]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "<Pending>")]
        public static void InitializeClass(TestContext context)
        {
            _testServer = new TestServer();
            _httpClient = _testServer.NewClient();
        }

        /// <summary>
        /// Method that acts as a deconstructor for this unit test.
        /// </summary>
        [ClassCleanup]
        public static void CleanUpTest()
        {
            _httpClient.Dispose();
            _testServer.Dispose();
        }

        /// <summary>
        /// Tests the compensation create post request by ensuring a Created status code is returned &
        /// the compensation object was created correctly. Post request URL: api/employee/compensation
        /// </summary>
        [TestMethod]
        public void CreateCompensation_Returns_Created()
        {
            // Create an example compensation object
            var comp = new Compensation()
            {
                Employee = new Employee()
                {
                    EmployeeId = "b7839309 - 3348 - 463b - a7e3 - 5de1c168beb3",
                    Department = "Secret Department",
                    FirstName = "Jane",
                    LastName = "Doe",
                    Position = "Anonymous Position",
                },
                Salary = 50000,
                EffectiveDate = DateTime.Now
            };

            // Serialize compensation object to json formatted string
            string requestContent = new JsonSerialization().ToJson(comp);

            // Send post request to create a compensation entry
            var postRequestTask = _httpClient.PostAsync("api/employee/compensation",
                                                        new StringContent(requestContent, Encoding.UTF8, "application/json"));

            // Retrieve the response message 
            var response = postRequestTask.Result;

            // Assert that the created response was returned successfully
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);

            var respComp = response.DeserializeContent<Compensation>();

            // Assert that the compensation object was created and returned fine
            Assert.IsNotNull(respComp.Employee);
            Assert.AreEqual(comp.Salary, respComp.Salary);
            Assert.AreEqual(comp.EffectiveDate, respComp.EffectiveDate);
            Assert.AreEqual(comp.Employee.FirstName, respComp.Employee.FirstName);
            Assert.AreEqual(comp.Employee.LastName, respComp.Employee.LastName);
            Assert.AreEqual(comp.Employee.Department, respComp.Employee.Department);
            Assert.AreEqual(comp.Employee.Position, respComp.Employee.Position);
        }

        /// <summary>
        /// Test creates a Compensation and retrieves it based on the employeeId from get request to URL: 
        /// api/employee/compensation/{id}
        /// </summary>
        [TestMethod]
        public async Task GetCompensation_Returns_Ok()
        {
            // Create an example compensation object
            var comp = new Compensation()
            {
                Employee = new Employee()
                {
                    EmployeeId = "Test",
                    Department = "Secret Department",
                    FirstName = "Jane",
                    LastName = "Doe",
                    Position = "Anonymous Position",
                },
                Salary = 50000,
                EffectiveDate = DateTime.Now
            };

            // Serialize compensation object to json formatted string
            string requestContent = new JsonSerialization().ToJson(comp);

            // Send post request to create a compensation entry
            await _httpClient.PostAsync("api/employee/compensation",
                                        new StringContent(requestContent, Encoding.UTF8, "application/json"));

            // Send get request to get a compensation entry
            var response = await _httpClient.GetAsync($"api/employee/compensation/{comp.Employee.EmployeeId}");


            // Assert that the created response was returned successfully
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            // Deserialize the compensation json to an object
            var respComp = response.DeserializeContent<Compensation>();

            // Assert that the compensation object was created and returned fine
            Assert.IsNotNull(respComp.Employee);
            Assert.AreEqual(comp.Salary, respComp.Salary);
            Assert.AreEqual(comp.EffectiveDate, respComp.EffectiveDate);
            Assert.AreEqual(comp.Employee.FirstName, respComp.Employee.FirstName);
            Assert.AreEqual(comp.Employee.LastName, respComp.Employee.LastName);
            Assert.AreEqual(comp.Employee.Department, respComp.Employee.Department);
            Assert.AreEqual(comp.Employee.Position, respComp.Employee.Position);
        }
    }
}
