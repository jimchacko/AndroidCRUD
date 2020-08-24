using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CRUDXamarian
{
    public class RestService
    {
        HttpClient _client;

        public RestService()
        {
            _client = new HttpClient();
        }

        public async Task<Employee> GetEmployeeDataAsync(string uri)
        {
            Employee empData = null;
            try
            {

                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    empData = JsonConvert.DeserializeObject<Employee>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return empData;
        }

        public async Task<List<Employee>> GetAllEmployeeAsync()
        {
            List<Employee> employees = null;
            try
            {

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Constants.OpenEmployeeMapEndpoint);
                    client.DefaultRequestHeaders.Accept.Clear();
                    var result = client.GetAsync("employees/Get").Result;

                    if (result.IsSuccessStatusCode)
                    {
                        employees = await result.Content.ReadAsAsync<List<Employee>>();
                        return employees != null ? (employees).ToList() : employees;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            return employees;
        }

        public async Task CreateEmployeeAsyn(Employee employee)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Constants.OpenEmployeeMapEndpoint);

                var response = await client.PostAsJsonAsync("employees/Create", employee);


                if (response != null)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        Debug.WriteLine("Create Sucess");
                    }
                }

            }
        }
        /// <summary>
        /// Remove an employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteConfirmed(string id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Constants.OpenEmployeeMapEndpoint);

                var response = await client.DeleteAsync($"employees/delete/{id}");

            }
            //   return View();
        }
        public async Task EditEmployee(Employee employee)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Constants.OpenEmployeeMapEndpoint);
                var response = await client.PutAsJsonAsync("employees/edit", employee);

            }
        }
    }
}
