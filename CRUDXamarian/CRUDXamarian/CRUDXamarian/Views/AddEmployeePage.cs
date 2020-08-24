using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

using Xamarin.Forms;

namespace CRUDXamarian.Views
{

    public class AddEmployeePage : ContentPage
    {
        RestService _restService;

        private Entry _nameEntry = new Entry();
        private Entry _address = new Entry();
        private Entry _email = new Entry();
        private Entry _company = new Entry();
        private Entry _designation = new Entry();
        private Button _saveButton;
        public AddEmployeePage()
        {
            _restService = new RestService();
            this.Title = "Add Employee";
            StackLayout stackLayout = new StackLayout();
            _nameEntry.Keyboard = Keyboard.Text;
            _nameEntry.Placeholder = "Employee Name";
            stackLayout.Children.Add(_nameEntry);

            _address.Keyboard = Keyboard.Text;
            _address.Placeholder = "Employee Address";
            stackLayout.Children.Add(_address);


            _email.Keyboard = Keyboard.Text;
            _email.Placeholder = "Email Id";
            stackLayout.Children.Add(_email);

            _company.Keyboard = Keyboard.Text;
            _company.Placeholder = "Company Name";
            stackLayout.Children.Add(_company);

            _designation.Keyboard = Keyboard.Text;
            _designation.Placeholder = "Designation";
            stackLayout.Children.Add(_designation);

            _saveButton = new Button();
            _saveButton.Text = "Add ";
            _saveButton.Clicked += _saveButton_Clicked;
            stackLayout.Children.Add(_saveButton);

            Content = stackLayout;
        }

        private async void _saveButton_Clicked(object sender, EventArgs e)
        {
            Employee employee = new Employee()
            {
                Name = _nameEntry.Text,
                Address = _address.Text,
                Company = _company.Text,
                Email = _email.Text,
                Designation = _designation.Text
            };


            await _restService.CreateEmployeeAsyn(employee);
            await DisplayAlert(null, employee.Name + " saved", "OK");
            await Navigation.PopAsync();

        }
       
    }
}