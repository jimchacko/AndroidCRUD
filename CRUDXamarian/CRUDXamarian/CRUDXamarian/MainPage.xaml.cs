using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CRUDXamarian
{
    public partial class MainPage : ContentPage
    {
        RestService _restService;
        public MainPage()
        {
            InitializeComponent();
            _restService = new RestService();
        }

        int count = 0;
        void Button_Clicked(object sender, System.EventArgs e)
        {
            count++;
            ((Button)sender).Text = $"You clicked {count} times.";
        }
        async void OnButtonClicked(object sender, EventArgs e)
        {

            var employeeData = await _restService.GetEmployeeDataAsync(GenerateRequestUri(Constants.OpenEmployeeMapEndpoint));

            BindingContext = employeeData;
        }

        string GenerateRequestUri(string endpoint)
        {
            string requestUri = endpoint;

            requestUri += "employees/get";
            return requestUri;
        }
    }
}
