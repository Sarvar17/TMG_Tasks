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

namespace Task1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Method to calculate number of words and vowels when button clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            calculateAllInputedIDs();
        }

        /// <summary>
        /// Method to count words and vowels of first text when text in first text box inputted.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void firstTextBox_TextInput(object sender, TextCompositionEventArgs e)
        {
            calculateFirst();
        }

        /// <summary>
        /// Method to count words and vowels of second text when text in second text box inputted.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void secondTextBox_TextInput(object sender, TextCompositionEventArgs e)
        {
            calculateSecond();
        }

        /// <summary>
        /// Method to count words and vowels of third text when text in third text box inputted.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void thirdTextBox_TextInput(object sender, TextCompositionEventArgs e)
        {
            calculateThird();
        }

        // Method to count words and vowels of second text when text in second text box inputted.
        private void calculateFirst()
        {
            firstWordsNum.Content = Functions.countWords(firstTextBox.Text);
            firstVowelsNum.Content = Functions.countVowel(firstTextBox.Text);
        }

        // Method to count words and vowels of second text when text in second text box inputted.
        private void calculateSecond()
        {
            secondWordsNum.Content = Functions.countWords(secondTextBox.Text);
            secondVowelsNum.Content = Functions.countVowel(secondTextBox.Text);
        }

        // Method to count words and vowels of third text when text in third text box inputted.
        private void calculateThird()
        {
            thirdWordsNum.Content = Functions.countWords(thirdTextBox.Text);
            thirdVowelsNum.Content = Functions.countVowel(thirdTextBox.Text);
        }

        // Changing values method;
        private void Change(int i, Data data)
        {
            switch (i)
            {
                case 0:
                    firstTextBox.Text = Functions.makeMultiline(data.text);
                    calculateFirst();
                    break;
                case 1:
                    secondTextBox.Text = Functions.makeMultiline(data.text);
                    calculateSecond();
                    break;
                case 2:
                    thirdTextBox.Text = Functions.makeMultiline(data.text);
                    calculateThird();
                    break;
            }
        }

        // Method to calculate inputted IDs
        private void calculateAllInputedIDs()
        {
            string[] ids = idTextBox.Text.Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
            if (ids.Length < 0 || ids.Length > 3)
            {
                MessageBox.Show("Number of IDs have to be from 0 to 3 and splitted with ',' or ';'", "Error");
                return;
            }
            else if (ids.Length == 0)
            {
                calculateFirst();
                calculateSecond();
                calculateThird();
            }
            else
            {
                for (int i = 0; i < ids.Length; i++)
                {
                    if (int.TryParse(ids[i], out int temp))
                    {
                        Data data;
                        try
                        {
                            data = Functions.getResponse<Data>(temp);
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show(exception.Message, "Error");
                            return;
                        }
                        Change(i, data);
                    }
                    else
                    {
                        MessageBox.Show("IDs must be a number and from 1 to 20", "Error");
                    }
                }
            }
        }
    }
}
