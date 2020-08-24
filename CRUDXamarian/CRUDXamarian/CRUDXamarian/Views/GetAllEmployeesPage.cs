using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace CRUDXamarian.Views
{
    public class GetAllEmployeesPage : ContentPage
    {
        RestService _restService;
        private ListView _listView;
        public  GetAllEmployeesPage()
        {
            _restService = new RestService();   
            this.Title = "Employees";
            _listView = new ListView();
            StackLayout stackLayout = new StackLayout();

            _listView.ItemsSource = (System.Collections.IEnumerable)_restService.GetAllEmployeeAsync();
            stackLayout.Children.Add(_listView);
            Content = stackLayout;
        }
    }
}