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

namespace HomeWork9._5
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

        bool textBox1Changed = false; // определяют был ли текст изменен хоть раз с открытия приложения. 
        bool textBox2Changed = false; // меняются по первому клику в соответствующий текстбокс

        #region Первая вкладка
        /// <summary>
        /// Очищаю поле перед первым вводом, меняю цвет шрифта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox1_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!textBox1Changed) // добавил булевую переменную, чтобы поле обнулялось при первом клике, а не при каждом переключении между вкладками
            {
                TextBox1.Clear();
                TextBox1.Foreground = Brushes.Black;
                textBox1Changed = true;
            }

        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            BreakText(TextBox1.Text);
        }
        
        /// <summary>
        /// Метод разбиения текста на слова по символу пробел
        /// </summary>
        /// <param name="text"></param>
        private void BreakText(string text) 
        {
            ListBox1.Items.Clear();
            string tempString = "";

            foreach(char i in text)
            {
                if (Char.IsWhiteSpace(i))
                {
                    if (tempString.Length > 0)
                    {
                        ListBox1.Items.Add(tempString);
                        tempString = "";
                    }
                    continue;
                }
                tempString += i;
            }
            ListBox1.Items.Add(tempString);
        }

        #endregion

        #region Вторая вкладка

        private void TextBox2_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!textBox2Changed) // добавил булевую переменную, чтобы поле обнулялось при первом клике, а не при каждом переключении между вкладками
            {
                TextBox2.Clear();
                TextBox2.Foreground = Brushes.Black;
                textBox2Changed = true;
            }
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            ReverseText(TextBox2.Text);
        }

        /// <summary>
        /// Переворачиваем строку по словам, отделенным пробелами
        /// </summary>
        /// <param name="text"></param>
        private void ReverseText(string text)
        {
            string[] words = text.Split(' '); // записываем строку по словам в массив слов
            
            string reversedText = ""; //переменная для перевернутого текста
            for(int word = words.Length; word > 0; word--)
            {
                reversedText = reversedText + words[word - 1] + ' ';
            }
            Label1.Content = reversedText.Remove(reversedText.Length - 1);
        }


        #endregion

    }
}
