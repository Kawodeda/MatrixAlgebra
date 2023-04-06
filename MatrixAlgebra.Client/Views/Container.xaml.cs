using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace MatrixAlgebra.Client.Views
{
    [ContentProperty("InnerContent")]
    public partial class Container : UserControl
    {
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(Container), new PropertyMetadata(""));

        public static readonly DependencyProperty InnerContentProperty =
            DependencyProperty.Register("InnerContent", typeof(object), typeof(Container));

        public Container()
        {
            InitializeComponent();
        }

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

        public object InnerContent
        {
            get 
            { 
                return GetValue(InnerContentProperty); 
            }
            set 
            { 
                SetValue(InnerContentProperty, value); 
            }
        }
    }
}
