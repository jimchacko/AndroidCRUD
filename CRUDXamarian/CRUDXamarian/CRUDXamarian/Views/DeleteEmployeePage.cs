using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace CRUDXamarian.Views
{
    public class DeleteEmployeePage : ContentPage
    {
        RestService _restService;
        private Button _button;
        private ListView _listView;
        Employee employee = new Employee();
        public DeleteEmployeePage()
        {
            StackLayout stackLayout = new StackLayout();
            _restService = new RestService();
            this.Title = "Delete Employee";
            _listView = new ListView();
            _listView.ItemsSource = (System.Collections.IEnumerable)_restService.GetAllEmployeeAsync();

            _listView.ItemSelected += _listView_ItemSelected;
            stackLayout.Children.Add(_listView);

            _button = new Button();
            _button.Text = "Delete";
            _button.Clicked += _deleteButton_Clicked;
            stackLayout.Children.Add(_button);

            Content = stackLayout;
        }
        private void _listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            employee = (Employee)e.SelectedItem;

        }
        private async void _deleteButton_Clicked(object sender, EventArgs e)
        {
            await _restService.DeleteConfirmed(employee.Id.ToString());

            await Navigation.PopAsync();
        }

    }
}