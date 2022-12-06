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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PR12.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageHotel.xaml
    /// </summary>
    public partial class PageHotel : Page
    {
        Classes.PageChange pc = new Classes.PageChange();
        List<Hotel> hotelList = new List<Hotel>();
        public PageHotel()
        {
            InitializeComponent();
            datagridHotels.ItemsSource = Classes.BaseClass.tBE.Hotel.ToList();
          

            pc.CountPages = Classes.BaseClass.tBE.Hotel.ToList().Count;
            DataContext = pc;
        }

        private void buttonTour_Click(object sender, RoutedEventArgs e)
        {
            Classes.Framec.MainFrame.Navigate(new PageTours());
        }

        private void textboxCount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            try
            {
                if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так с выводом символов");
            }
        }

        private void textboxCount_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                pc.CountPage = Convert.ToInt32(textboxCount.Text);
            }
            catch
            {
                pc.CountPage = hotelList.Count;
            }
            pc.Countlist = hotelList.Count;
            datagridHotels.ItemsSource = hotelList.Skip(0).Take(pc.CountPage).ToList();
            pc.Currentpage = 1;


        }

        private void txtNextt_MouseDown(object sender, MouseButtonEventArgs e)
        {
            pc.Currentpage = pc.CountPages;
            datagridHotels.ItemsSource = hotelList.Skip(pc.Currentpage * pc.CountPage - pc.CountPage).Take(pc.CountPage).ToList();
        }

        private void GoPage_MouseDown(object sender, MouseButtonEventArgs e)  // обработка нажатия на один из Textblock в меню с номерами страниц
        {
            TextBlock tb = (TextBlock)sender;

            switch (tb.Uid)  // определяем, куда конкретно было сделано нажатие
            {
                case "prev":
                    pc.Currentpage--;
                    break;
                case "next":
                    pc.Currentpage++;
                    break;
                default:
                    pc.Currentpage = Convert.ToInt32(tb.Text);
                    break;
            }
            datagridHotels.ItemsSource = hotelList.Skip(pc.Currentpage * pc.CountPage - pc.CountPage).Take(pc.CountPage).ToList();  // оображение записей постранично с определенным количеством на каждой странице

        }
    }
}
