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
        /// Реализация поиска и фильтрации.
        /// </summary>
        private void FindAgent()
        {
            List<Agent> agent = DB.Entities.Agent.Where(x => x.Title.StartsWith(FindAgentTb.Text)).ToList();

            switch (SortCb.SelectedIndex)
            {
                
                case 0:; break;
                case 1: agent = agent.OrderBy(x => x.Title).ToList(); break;
                case 2: agent = agent.OrderByDescending(x => x.Title).ToList(); break;
            }

            if (FilterCb.SelectedIndex > 0)
            {
                string angentTp = FilterCb.SelectedItem.ToString();
                agent = agent.Where(x => x.AgentType.Title == angentTp).ToList();
            }

            GridAgents.ItemsSource = agent;

        }

        
        /// <summary>
        /// Показ данных при запуске приложения.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            FindAgent();
        }
        /// <summary>
        /// Сортировка данных по алфавиту и в обратную сторону.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SortCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            FindAgent();
        }
        /// <summary>
        /// Сортировка агентов по типу.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FilterCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FindAgent();
        }
        /// <summary>
        /// Поиск по названию агента.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FindAgentTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            FindAgent();
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
