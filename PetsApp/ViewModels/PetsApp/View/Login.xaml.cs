using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;
using PetsApp.Domain;
using PetsApp.Persistance;

namespace PetsApp.View
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private DataContext data;
        public Login(DataContext data)
        {
            this.data = data;
            InitializeComponent();
        }

		private void Button_Click(object sender, RoutedEventArgs e)
		{
            this.Close();
        }

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
            var mainAdmin = data.Admins.FirstOrDefault(a => a.Username == "admin" && a.Password == "admin");
            if (mainAdmin == null)
            {
				data.Admins.Add(new Domain.Admin { Username = "admin", Password = "admin", AccessType = "1"});
                data.SaveChanges();
			}

            if (data.Admins.FirstOrDefault(x => x.Username == login.Text & x.Password == password.Text) == null)
            {
				MessageBox.Show("Неправильний логін чи пароль");
				
			}
            else
            {
                sp1.Children.Clear();
                sp2.Children.Clear();

				
                var nameLabel = new Label { Content = "Name:" };
                var nameTextBox = new TextBox();
                sp1.Children.Add(nameLabel);
                sp1.Children.Add(nameTextBox);

                var typeLabel = new Label { Content = "Type:" };
                var typeTextBox = new TextBox();
                sp1.Children.Add(typeLabel);
                sp1.Children.Add(typeTextBox);

                var descriptionLabel = new Label { Content = "Description:" };
                var descriptionTextBox = new TextBox();
                sp1.Children.Add(descriptionLabel);
                sp1.Children.Add(descriptionTextBox);

                var petImageLabel = new Label { Content = "Image:" };
                var petImageTextBox = new TextBox();
                petImageTextBox.Margin = new Thickness(0, 10, 0, 10);
                sp1.Children.Add(petImageLabel);
                sp1.Children.Add(petImageTextBox);
                var addImageButton = new Button { Content = "Add Image" };
                addImageButton.Margin = new Thickness(0, 10, 0, 10);
                List<string> images = new List<string>();
                addImageButton.Click += (s, args) =>
                {
					images.Add(petImageTextBox.Text);
					MessageBox.Show("Image added successfully!");
					petImageTextBox.Clear();
				};
                sp1.Children.Add(addImageButton);
                var saveButton = new Button { Content = "Save" };
                saveButton.Click += (s, args) =>
                {
	                
	                var newPet = new Pet
	                {
		                Name = nameTextBox.Text,
		                Type = typeTextBox.Text,
		                Description = descriptionTextBox.Text
		               
	                };

	                data.Pets.Add(newPet);
                    data.SaveChanges();
                    var petId = data.Pets.FirstOrDefault(p => p.Name == newPet.Name && p.Type == newPet.Type && p.Description == newPet.Description).Id;
                    foreach (var image in images)
                    {
	                    data.PetImages.Add(new PetImage { PetId = petId, ImagePath = image });
					}
                    data.SaveChanges();
	                MessageBox.Show("Дані успішно збережено");
	                
	                nameTextBox.Clear();
	                typeTextBox.Clear();
	                descriptionTextBox.Clear();
                };
                sp1.Children.Add(saveButton);
            }
			//this.Close();
		}
            

		}
	}

