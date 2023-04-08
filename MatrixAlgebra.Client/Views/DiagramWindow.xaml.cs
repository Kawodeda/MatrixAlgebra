using MatrixAlgebra.Client.ViewModels;
using System.Windows;

namespace MatrixAlgebra.Client.Views
{
    public partial class DiagramWindow : Window
    {
        public DiagramWindow(float[] elements)
        {
            InitializeComponent();
            DataContext = new DiagramViewModel(elements);
        }
    }
}
