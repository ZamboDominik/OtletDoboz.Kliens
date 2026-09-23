using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OtletDoboz.Models;

namespace OtletDoboz.Kliens
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly HttpClient _http = new HttpClient { BaseAddress = new Uri("http://localhost:5203/") };

        private List<Idea> _allIdeas = new List<Idea>();

        public MainWindow()
        {
            InitializeComponent();
        }
        private async void Window_Loaded(object sender,RoutedEventArgs e) 
        {
            await LoadCategoriesAsync();
            await LoadIdeasAsync();
        }
        public async Task LoadCategoriesAsync() 
        {
            try
            {
                var categories = await _http.GetFromJsonAsync<List<Category>>("api/categories");
                if (categories != null)
                {
                    cb_Kategoriak.ItemsSource = categories;
                    cb_Kategoriak_Filter.ItemsSource = categories;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private async Task LoadIdeasAsync() 
        {
            try
            {
                var ideas = await _http.GetFromJsonAsync<List<Idea>>("api/ideas");
                _allIdeas = ideas ?? new List<Idea>();
                ApplyFilter();
            } 
            catch (Exception e) 
            {
                MessageBox.Show(e.Message, "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void ApplyFilter() 
        {
            if (cb_Kategoriak_Filter.SelectedItem is Category selectedCategory)
            {
                lb_Ideas.ItemsSource = _allIdeas.Where(i => i.Category?.Id == selectedCategory.Id).ToList();
            }
            else 
            {
                lb_Ideas.ItemsSource = _allIdeas.ToList();
            }
        }

        private void cb_Kategoriak_Filter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyFilter();
        }

        private async void btn_Bekuld_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_Title.Text) || string.IsNullOrWhiteSpace(tb_Content.Text)) 
            {
                MessageBox.Show("Üres textbox");
            }
            if (cb_Kategoriak.SelectedItem is not Category selectedCategory) 
            {
                MessageBox.Show("Válassz kategóriát");
            }
            bool isPrivate = rb_Igaz.IsChecked == true;
            //Idea newIdea = new Idea(5, tb_Title.Text.Trim(), tb_Content.Text.Trim(),new Category(cb_Kategoriak.SelectedItem), 0,isPrivate,DateTime.Now);
        }

        
    }
}