using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Dice_Testing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            userErrorNotification.Visibility = Visibility.Hidden;
            numOfDiceTextBox.ClearValue(Border.BorderBrushProperty);
            numOfSidesTextBox.ClearValue(Border.BorderBrushProperty);
            successValueTextBox.ClearValue(Border.BorderBrushProperty);
            resultsViewer.Content = "";

            int numOfDice = 0;
            int numOfSides = 0;
            int successValue = 0;
            bool diceExplode = (bool)explodingDice.IsChecked;
            bool passed = true;

            try
            {
                numOfDice = int.Parse(numOfDiceTextBox.Text);
                if (numOfDice < 1)
                    throw new Exception();
            }
            catch
            {
                userErrorNotification.Visibility = Visibility.Visible;
                numOfDiceTextBox.BorderBrush = Brushes.Red;
                passed = false;
            }
            try
            {
                numOfSides = int.Parse(numOfSidesTextBox.Text);
                if (numOfSides < 2)
                    throw new Exception();
            }
            catch
            {
                userErrorNotification.Visibility = Visibility.Visible;
                numOfSidesTextBox.BorderBrush = Brushes.Red;
                passed = false;
            }
            try
            {
                successValue = int.Parse(successValueTextBox.Text);
                if (successValue <= 1)
                    throw new Exception();
            }
            catch
            {
                userErrorNotification.Visibility = Visibility.Visible;
                successValueTextBox.BorderBrush = Brushes.Red;
                passed = false;
            }

            if (passed)
            {
                Roller roller = new Roller(numOfDice, numOfSides, diceExplode);

                Analyzer analyzer = new Analyzer(roller.RollSet(random), successValue);
                resultsViewer.Content = analyzer.SendResults();
            }
        }
    }
}
