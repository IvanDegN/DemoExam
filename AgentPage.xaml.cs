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
            SortCb.Items.Add("Сортировка");
            SortCb.Items.Add("От А до Я");
            SortCb.Items.Add("От Я до А");
            FilterCb.Items.Add("Фильтрация");
            
            foreach ( var agentTypes in DB.Entities.AgentType.ToList())
            {
                FilterCb.Items.Add(agentTypes).ToString();
            }
            


        }
        
        

        
        /// <summary>
        /// Показ данных при запуске приложения.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            GridAgents.ItemsSource = DB.Entities.Agent.ToList();
        }
        /// <summary>
        /// Сортировка данных по алфавиту и в обратную сторону.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SortCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            switch(SortCb.SelectedIndex)
            {
                default: GridAgents.ItemsSource = DB.Entities.Agent.ToList(); break;
                case 0: GridAgents.ItemsSource = DB.Entities.Agent.ToList(); break;
                case 1: GridAgents.ItemsSource = DB.Entities.Agent.OrderBy(x => x.Title).ToList(); break;
                case 2: GridAgents.ItemsSource = DB.Entities.Agent.OrderByDescending(x => x.Title).ToList(); break;
            }
        }
        /// <summary>
        /// Сортировка агентов по типу.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FilterCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch(FilterCb.SelectedIndex)
            {
                default: GridAgents.ItemsSource = DB.Entities.Agent.ToList(); break;
                case 0: GridAgents.ItemsSource = DB.Entities.Agent.ToList(); break;
                case 1: GridAgents.ItemsSource = DB.Entities.Agent.Where(x => x.AgentType.Title == "МКК").ToList(); break;
                case 2: GridAgents.ItemsSource = DB.Entities.Agent.Where(x => x.AgentType.Title == "ОАО").ToList(); break;
                case 3: GridAgents.ItemsSource = DB.Entities.Agent.Where(x => x.AgentType.Title == "ООО").ToList(); break;
                case 4: GridAgents.ItemsSource = DB.Entities.Agent.Where(x => x.AgentType.Title == "ЗАО").ToList(); break;
                case 5: GridAgents.ItemsSource = DB.Entities.Agent.Where(x => x.AgentType.Title == "МФО").ToList(); break;
                case 6: GridAgents.ItemsSource = DB.Entities.Agent.Where(x => x.AgentType.Title == "ПАО").ToList(); break;
            }
        }
        /// <summary>
        /// Поиск по названию агента.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FindAgentTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            GridAgents.ItemsSource = DB.Entities.Agent.Where(x => x.Title.StartsWith(FindAgentTb.Text)).ToList();
            
        }

        private void FindAgentTb_GotFocus(object sender, RoutedEventArgs e)
        {
            
        }
        /// <summary>
        /// Если по полю для ввода не было нажатия, то вместо пустоты там будет заглушка в виде текста.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FindAgentTb_LostFocus(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(FindAgentTb.Text))
            {
                FindAgentTb.Visibility = Visibility.Collapsed;
                FindAgentTbPlaceHolder.Visibility = Visibility.Visible;
            }
        }
        /// <summary>
        /// Если по полю ввода было нажатие, то заглушка пропадает и появляется возможность выполнить поиск.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FindAgentTbPlaceHolder_GotFocus(object sender, RoutedEventArgs e)
        {
            FindAgentTbPlaceHolder.Visibility = Visibility.Collapsed;
            FindAgentTb.Visibility = Visibility.Visible;
            FindAgentTb.Focus();
        }
    }
}
