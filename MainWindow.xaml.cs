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

namespace Diary
{
    public partial class MainWindow : Window
    {
        LinkedList<Page> diary;
        public MainWindow()
        {
            InitializeComponent();

            diary = new LinkedList<Page>();
            UpdatePageCount();
            UpdatePage();
        }

        private void PrevBt_Click(object sender, RoutedEventArgs e)
        {
            diary.Previous();
            UpdatePage();
        }
        private void NextBt_Click(object sender, RoutedEventArgs e)
        {
            diary.Next();
            UpdatePage();
        }

        private void DeleteBt_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to delete this page?","Delete?",MessageBoxButton.YesNo); 
            if(result == MessageBoxResult.Yes) 
            {
                diary.RemoveCurrent();
               DisplayFirstPage();
            }
        }

        private void AddBt_Click(object sender, RoutedEventArgs e)
        {
            PageCreateGrid.Visibility = Visibility.Visible;
        }
        
        private void AcceptCreateBt_Click(object sender, RoutedEventArgs e)
        {
            if(Calendar.SelectedDate != null && TextForPage.Text != "")
            {
                MessageBoxResult result = MessageBox.Show("Do you want to save this page?", "Save or discard ?", MessageBoxButton.YesNo);
                if(result == MessageBoxResult.Yes)
                {
                    string text = TextForPage.Text;
                    DateOnly date = DateOnly.FromDateTime((DateTime)Calendar.SelectedDate);
                
                    diary.Add(new Page(text,date));
                    UpdatePage();
                    TextForPage.Text = "";
                    Calendar.SelectedDate = DateTime.Today;
                    PageCreateGrid.Visibility = Visibility.Hidden;
                }
                else
                {
                    TextForPage.Text = "";
                    Calendar.SelectedDate = DateTime.Today;
                    PageCreateGrid.Visibility = Visibility.Hidden;
                }

            }
            else if(Calendar.SelectedDate == null)
            {
                MessageBox.Show("Pick a date.");
            }
            else
            {
                MessageBox.Show("No text.");
            }

            
        }

        private void DisplayFirstPage()
        {

            Page page = diary.GetFirst();
            if (diary.Count == 0)
            {
                DateTx.Text = "";
                TextTx.Text = "";
                UpdatePageCount();
                return;
            }
            TextTx.Text = page.Text;
            DateTx.Text = page.Date.ToString();
            UpdatePageCount();
        }
        private void UpdatePage()
        {
            Page page = diary.GetCurrent();
            if(diary.Count == 0) 
            {
                DateTx.Text = "";
                TextTx.Text = "";
                UpdatePageCount();
                return;
            }
            TextTx.Text = page.Text;
            DateTx.Text = page.Date.ToString();
            UpdatePageCount();
        }
        private void UpdatePageCount()
        {
            if (diary.Count == 0)
            {
                PageNumLb.Content = "The Diary is Empty";
            }
            else
            {
                PageNumLb.Content = $"There is {diary.Count} Pages";
            }
        }


    }
}


