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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PR12.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageTours.xaml
    /// </summary>
    public partial class PageTours : Page
    {
        List<Tour> listFilter = new List<Tour>();
        public PageTours()
        {
            InitializeComponent();
            listTours.ItemsSource = Classes.BaseClass.tBE.Tour.ToList();

            List<Type> types = Classes.BaseClass.tBE.Type.ToList();

            comboboxType.Items.Add("Все типы");
            for(int i =0; i< types.Count; i++)
            {
                comboboxType.Items.Add(types[i].Name);
            }
            comboboxType.SelectedIndex = 0;
            comboboxSort.SelectedIndex = 0;

            textMoney.Text = SumMoney(Classes.BaseClass.tBE.Tour.ToList()).ToString()+".000 РУБ";

        }

        double SumMoney( List<Tour> tours)
        {
            double sum = 0;
            foreach(Tour tour in listFilter)
            {
                sum = sum + (double)tour.Price * (double)tour.TicketCount;
            }
            return sum;
        }

        //фильтры и сортировка
        void Filter()
        {
            List<Tour> list1 = Classes.BaseClass.tBE.Tour.ToList();
            string name = comboboxType.SelectedValue.ToString();
            int index = comboboxType.SelectedIndex;
            //List<Type> types = Classes.BaseClass.tBE.Type.Where(z => z.Name == name).ToList();
            List<TypeOfTour> typeOfs = Classes.BaseClass.tBE.TypeOfTour.ToList();
            if (index != 0)
            {
                listFilter = new List<Tour>();
                foreach(TypeOfTour tt in typeOfs)
                {
                        if(tt.TypeId == index)
                    {
                        listFilter.Add(tt.Tour);
                    }
     
                }
               //listFilter = Classes.BaseClass.tBE.Type.Where(x => x.Name == name).ToList();
            }
            else
            {
                listFilter = Classes.BaseClass.tBE.Tour.ToList();
            }

            // поиск совпадений по названию
            if (!string.IsNullOrWhiteSpace(textboxSearch.Text))  // если строка не пустая и если она не состоит из пробелов
            {

                listFilter = listFilter.Where(x => x.Name.ToLower().Contains(textboxSearch.Text.ToLower())).ToList();
               
            }
            if (!string.IsNullOrWhiteSpace(textboxSearch2.Text))  // если строка не пустая и если она не состоит из пробелов
            {
                List<Tour> tt = Classes.BaseClass.tBE.Tour.Where(x => x.Description != null).ToList();
                if (tt.Count > 0)
                {
                    foreach (Tour t in list1)
                    {
                        if (t.Description != null)
                        {
                            listFilter = listFilter.Where(x => x.Description.ToLower().Contains(textboxSearch2.Text.ToLower())).ToList();
                        }
                       
                    }
                }
                else
                {
                    MessageBox.Show("Нет записей");
                }
            }

            if(checkboxActual.IsChecked == true)
            {
                listFilter = listFilter.Where(x => x.IsActual == true).ToList();
            }

            switch(comboboxSort.SelectedIndex)
            {
                case 1:
                    {
                        listFilter.Sort((x, y) => x.Price.CompareTo(y.Price));
                    }
                    break;
                case 2:
                    {
                        listFilter.Sort((x, y) => x.Price.CompareTo(y.Price));
                        listFilter.Reverse();
                    }
                    break;
            }

            listTours.ItemsSource = listFilter;
            if (listFilter.Count == 0)
            {
                MessageBox.Show("Нет записей");
            }
            textMoney.Text = SumMoney(listFilter).ToString() + ".000 РУБ";
        }

        private void textboxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        //запрет ввода чисел
        private void textboxSearch_PreviewTextInput(object sender, TextCompositionEventArgs e)
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

        private void comboboxType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void checkboxActual_Checked(object sender, RoutedEventArgs e)
        {
            Filter();
        }

        private void textboxMoney_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void buttonHotel_Click(object sender, RoutedEventArgs e)
        {
            Classes.Framec.MainFrame.Navigate(new PageHotel());

        }
    }
}
