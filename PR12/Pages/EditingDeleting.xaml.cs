using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PR12.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditingDeleting.xaml
    /// </summary>
    public partial class EditingDeleting : Window
    {
        Hotel h;
        bool flagUpdate = false;
        public EditingDeleting(Hotel h)
        {
            InitializeComponent();
            this.h = h;
            flagUpdate = true;

            textNameHotel.Text = h.Name;
            textStars.Text = Convert.ToString(h.CountOfStars);
            textDescription.Text = h.Description;

            comboboxCount.ItemsSource = Classes.BaseClass.tBE.Country.ToList();
            comboboxCount.SelectedValuePath = "Code";
            comboboxCount.DisplayMemberPath = "Name";
            comboboxCount.SelectedValue = h.CountryCode;
        }
        //запрет ввода чисел
        private void textNameHotel_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            try
            {
                Regex x = new Regex("^[0-9]+");
                e.Handled = x.IsMatch(e.Text);
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так с запретов ввода чисел");
            }
        }


        private void textDescription_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            try
            {
                Regex x = new Regex("^[0-9]+");
                e.Handled = x.IsMatch(e.Text);
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так с запретов ввода чисел");
            }
        }

        private void textStars_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            try
            {
                if (!Char.IsDigit(e.Text, 0))
                { e.Handled = true; }
                else
                {
                    Regex x = new Regex("^[6-9]+");
                    e.Handled = x.IsMatch(e.Text);
                }
                
              
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так с запретом ввода символов");
            }

        }
        public EditingDeleting()
        {
            try
            {

                InitializeComponent();
                buttonAdd.Content = "Сохранить";
                // блокировка полей для редактирования клиента
                if (flagUpdate == false)
                {
                    comboboxCount.ItemsSource = Classes.BaseClass.tBE.Country.ToList();
                    comboboxCount.SelectedValuePath = "Code";
                    comboboxCount.DisplayMemberPath = "Name";

                }
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так с добавлением записи");
            }

        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            if(textDescription.Text != "" && textNameHotel.Text != "" && textStars.Text != "" &&comboboxCount.SelectedItem != null)
            {
                if(flagUpdate == false)
                {
                    h = new Hotel();
                }

                h.Name = textNameHotel.Text;
                h.Description = textDescription.Text;
                h.CountOfStars = Convert.ToInt32( textStars.Text);
                h.CountryCode = comboboxCount.SelectedItem.ToString();
                if(flagUpdate == false)
                {
                    Classes.BaseClass.tBE.Hotel.Add(h);
                }


                Classes.BaseClass.tBE.SaveChanges();
                MessageBox.Show("Данные изменены"); // сообщение об успешном изменение данных
                this.Close();// закрываем это окно
            }
            else
            {
                MessageBox.Show($"Не все поля заполнены");
            }
        }

        
        // назад
    }
}
