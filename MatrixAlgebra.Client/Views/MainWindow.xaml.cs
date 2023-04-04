using System.Collections.Generic;
using System.Windows;

namespace MatrixAlgebra.Client.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<List<string>> _values = new List<List<string>>()
        {
            new List<string>() { "0", "1", "2" },
            new List<string>() { "3", "4", "5" },
            new List<string>() { "6", "7", "8" }
        };

        public List<string> Ops => new List<string>()
        {
            "Add",
            "Subtract",
            "Multiply"
        };

        public List<List<string>> Values => _values;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
