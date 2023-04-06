using MatrixAlgebra.Client.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace MatrixAlgebra.Client.Views
{
    public partial class MatrixViewer : UserControl
    {
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(MatrixViewer), new PropertyMetadata(""));

        public static readonly DependencyProperty MatrixProperty =
            DependencyProperty.Register(
                "Matrix", 
                typeof(float[,]), 
                typeof(MatrixViewer), 
                new PropertyMetadata(new float[,] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } }));

        public string Title
        {
            get 
            { 
                return (string)GetValue(TitleProperty); 
            }
            set 
            { 
                SetValue(TitleProperty, value);
            }
        }

        public MatrixViewer()
        {
            InitializeComponent();
        }
    }
}
