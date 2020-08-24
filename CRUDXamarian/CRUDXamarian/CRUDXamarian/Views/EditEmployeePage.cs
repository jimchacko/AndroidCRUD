using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace CRUDXamarian.Views
{
    public class EditEmployeePage : ContentPage
    {
        RestService _restService;
        private ListView _listView;
        private Entry idEntry = new Entry();
        private Entry _nameEntry = new Entry();
        private Entry _address = new Entry();
        private Entry _email = new Entry();
        private Entry _company = new Entry();
        private Entry _designation = new Entry();
        private Button _updateButton;
        Employee employee = new Employee();
        public EditEmployeePage()
        {
            StackLayout stackLayout = new StackLayout();
            _restService = new RestService();
            this.Title = "Edit Employee";
            _listView = new ListView();
            _listView.ItemsSource = (System.Collections.IEnumerable)_restService.GetAllEmployeeAsync();

            _listView.ItemSelected += _listView_ItemSelected;
            stackLayout.Children.Add(_listView);

            idEntry = new Entry();
            idEntry.Placeholder = "ID";
            idEntry.IsVisible = false;
            stackLayout.Children.Add(idEntry);

            _nameEntry = new Entry();
            _nameEntry.Keyboard = Keyboard.Text;
            _nameEntry.Placeholder = "Employee Name";
            stackLayout.Children.Add(_nameEntry);

            _address = new Entry();
            _address.Keyboard = Keyboard.Text;
            _address.Placeholder = "Address";
            stackLayout.Children.Add(_address);

            _email = new Entry();
            _email.Keyboard = Keyboard.Text;
            _email.Placeholder = "Email Id";
            stackLayout.Children.Add(_email);

            _company = new Entry();
            _company.Keyboard = Keyboard.Text;
            _company.Placeholder = "Company Name";
            stackLayout.Children.Add(_company);

            _designation = new Entry();
            _designation.Keyboard = Keyboard.Text;
            _designation.Placeholder = "Designation";
            stackLayout.Children.Add(_designation);

            _updateButton = new Button();
            _updateButton.Text = "Update";
            _updateButton.Clicked += _updateButton_Clicked;
            stackLayout.Children.Add(_updateButton);
            Content = stackLayout;
        }

        private async void _updateButton_Clicked(object sender, EventArgs e)
        {

            Employee employee = new Employee()
            {
                Id = Convert.ToInt32(idEntry.Text),
                Name = _nameEntry.Text,
                Address = _address.Text,
                Company = _company.Text,
                Email = _email.Text,
                Designation = _designation.Text
            };

            await _restService.EditEmployee(employee);
            await DisplayAlert(null, employee.Name + " Updated", "OK");
            await Navigation.PopAsync();
        }

        private void _listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            employee = (Employee)e.SelectedItem;
            idEntry.Text = employee.Id.ToString();
            _nameEntry.Text = employee.Name;
            _address.Text = employee.Address;
            _email.Text = employee.Email;
            _company.Text = employee.Company;
            _designation.Text = employee.Designation;

        }
    }
}