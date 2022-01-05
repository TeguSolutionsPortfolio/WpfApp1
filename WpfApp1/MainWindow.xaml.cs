using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace WpfApp1
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

        #region Task 1

        private void Task1(object sender, RoutedEventArgs e)
        {
            var text = solution1("Codility We test coders", 14);
        }

        //('aa bb cc', 2)
        //('aa bb cc', 5)
        //('aa bb cc', 6)
        //('aa bb cc', 8)
        //(' aa bb cc ', 8)
        //('aa   bb cc', 9)
        //('aa   bb cc', 10)

        public string solution1(string message, int charLimit)
        {
            // Step 01: Remove whitespaces both of start and end of the text
            // Note: Beginning whitespaces maybe out of the task but it's nicer
            var trimmedMessage = message.TrimEnd();
            trimmedMessage = trimmedMessage.TrimStart();

            // Step 02: Easier variation: when the message is fine just return it
            if (trimmedMessage.Length <= charLimit)
                return trimmedMessage;

            // Step 03: Analyse the message and cut the extra words
            // Lazy solution: use Split() to separate the whitespaces and texts (it may have drawbacks that it can't handle multiple whitespaces between messages)
            var splitMessages = trimmedMessage.Split(' ');
            var finalMessage = string.Empty;

            // Step 04: Iterate and build up the finalMessage from the splitMessages
            for (var i = 0; i < splitMessages.Length; i++)
            {
                var currentMessage = splitMessages[i];

                // If it's the first message part just check and manage the message without whitespace
                if (i == 0)
                {
                    if (finalMessage.Length + currentMessage.Length > charLimit)
                        return finalMessage;
                    
                    finalMessage += currentMessage;
                }
                else
                {
                    if (finalMessage.Length + 1 + currentMessage.Length > charLimit)
                        return finalMessage.TrimEnd();
                    
                    finalMessage += " " + currentMessage;
                }
            }

            return finalMessage.TrimEnd();
        }

        #endregion

        #region Task 2

        private void Task2(object sender, RoutedEventArgs e)
        {
            var result = Solutions.Solutions.solution2(new[] { 2, 4, 1 }, new[] { 3, 4, 7 });
        }

        #endregion

        #region Task 3

        private void Task3(object sender, RoutedEventArgs e)
        {

        }

        #endregion
    }
}
