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

namespace WpfApp5
{
    /// <summary>
    /// Логика взаимодействия для AgentPage.xaml
    /// </summary>
    public partial class AgentPage : Page
    {
        public AgentPage()
        {
            InitializeComponent();
        }

        

        

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            GridAgents.ItemsSource = DB.Entities.Agent.ToList();
        }

        private void SortCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void FilterCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void FindAgentTb_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void FindAgentTb_GotFocus(object sender, RoutedEventArgs e)
        {
            
        }

        private void FindAgentTb_LostFocus(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(FindAgentTb.Text))
            {
                FindAgentTb.Visibility = Visibility.Collapsed;
                FindAgentTbPlaceHolder.Visibility = Visibility.Visible;
            }
        }

        private void FindAgentTbPlaceHolder_GotFocus(object sender, RoutedEventArgs e)
        {
            FindAgentTbPlaceHolder.Visibility = Visibility.Collapsed;
            FindAgentTb.Visibility = Visibility.Visible;
            FindAgentTb.Focus();
        }
    }
}
