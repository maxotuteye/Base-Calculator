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
using System.Windows.Threading;
using System.Text.RegularExpressions;

namespace Base_Calculator
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private DispatcherTimer timer = new DispatcherTimer();
		public MainWindow()
		{
			InitializeComponent();
		}

		private bool isNumberInvalid(string text)
        {
			Regex regex = new Regex("[^0-9]+");
			return regex.IsMatch(text);
        }

		private void CalcBtn_Click(object sender, RoutedEventArgs e)
		{
			UInt64 buffer;
			string value = inputTextBox.Text;
			Algorithm.Calculate(value, (int)slider.Value, (int)sliderNew.Value, ref outputTextBox);
			/*if (*//*isNumberInvalid(inputTextBox.Text) ||*//* inputTextBox.Text == "")
			{
				timer.Tick += delegate { SnackbarMessage_ActionClick(sender, e); };
				timer.Interval = new TimeSpan(0, 0, 3);
				timer.Start();
				alertMsg.Content = "Invalid Input: Please enter a decimal number";
				alertSnackBar.IsActive = true;
			}
			else if (!UInt64.TryParse(inputTextBox.Text, out buffer))
			{
				timer.Tick += delegate { SnackbarMessage_ActionClick(sender, e); };
				timer.Interval = new TimeSpan(0, 0, 3);
				timer.Start();
				alertMsg.Content = "Number too large";
				alertSnackBar.IsActive = true;
			}
			else
			{
				Algorithm.Calculate(inputTextBox.Text, slider.Value, ref outputTextBox);
			}*/
		}

		public static void UpdateOutput(string s, ref TextBox outputbox)
		{
			outputbox.Text = s;
		}

		private void timer_Tick(object sender, EventArgs e)
		{
			alertSnackBar.IsActive = false;
		}

		private void SnackbarMessage_ActionClick(object sender, RoutedEventArgs e)
		{
			alertSnackBar.IsActive = false;
			timer.Stop();
		}

		private void ToggleButton_Checked(object sender, RoutedEventArgs e)
		{
			AppBar.Background = (SolidColorBrush)Application.Current.Resources["PrimaryDarkNight"];
			MainCard.Background = (SolidColorBrush)Application.Current.Resources["PrimaryCardNight"];
			mainGrid.Background = (SolidColorBrush)Application.Current.Resources["PrimaryLightNight"];
			inputTextBox.BorderBrush = (SolidColorBrush)Application.Current.Resources["PrimaryDarkNight"];
			outputTextBox.BorderBrush = (SolidColorBrush)Application.Current.Resources["PrimaryDarkNight"];
			slider.Foreground = (SolidColorBrush)Application.Current.Resources["PrimaryDarkNight"];
			slidervalbtn.Background = (SolidColorBrush)Application.Current.Resources["PrimaryDarkNight"];
			sliderNew.Foreground = (SolidColorBrush)Application.Current.Resources["PrimaryDarkNight"];
			slidervalbtnNew.Background = (SolidColorBrush)Application.Current.Resources["PrimaryDarkNight"];
			CalcBtn.Background = (SolidColorBrush)Application.Current.Resources["PrimaryDarkNight"];
		}

		private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
		{
			AppBar.Background = (SolidColorBrush)Application.Current.Resources["PrimaryDarkDay"];
			MainCard.Background = (SolidColorBrush)Application.Current.Resources["DayBackground"];
			mainGrid.Background = (LinearGradientBrush)Application.Current.Resources["PrimaryLightDay"];
			inputTextBox.BorderBrush = (SolidColorBrush)Application.Current.Resources["PrimaryDarkDay"];
			outputTextBox.BorderBrush = (SolidColorBrush)Application.Current.Resources["SecondaryAccent"];
			slider.Foreground = (SolidColorBrush)Application.Current.Resources["PrimaryDarkDay"];
			slidervalbtn.Background = (SolidColorBrush)Application.Current.Resources["PrimaryDarkDay"];
			sliderNew.Foreground = (SolidColorBrush)Application.Current.Resources["PrimaryDarkDay"];
			slidervalbtnNew.Background = (SolidColorBrush)Application.Current.Resources["PrimaryDarkDay"];
			CalcBtn.Background = (SolidColorBrush)Application.Current.Resources["SecondaryAccent"];
		}

   
    }
}