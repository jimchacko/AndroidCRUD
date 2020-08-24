using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace CRUDXamarian.Views
{
    public class HomePage : ContentPage
    {
        public HomePage()
        {
            this.Title = "Select an option";
            StackLayout stackLayout = new StackLayout();
            Button button = new Button();
            button.Text = "Add Employe";
            button.Clicked += ButtonAdd_Clicked;
            stackLayout.Children.Add(button);

            button = new Button();
            button.Text = "Get Employee";
            button.Clicked += ButtonGet_Clicked;
            stackLayout.Children.Add(button);


            button = new Button();
            button.Text = "Edit Employee";
            button.Clicked += ButtonEdit_Clicked;
            stackLayout.Children.Add(button);

            button = new Button();
            button.Text = "Delete Employee";
            button.Clicked += ButtonDelete_Clicked;
            stackLayout.Children.Add(button);
            Content = stackLayout;

        }

        private async void ButtonAdd_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddEmployeePage());
        }

        private async void ButtonGet_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GetAllEmployeesPage());
        }
        private async void ButtonEdit_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditEmployeePage());
        }
        private async void ButtonDelete_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeleteEmployeePage());
        }
    }
}