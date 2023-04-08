using System.Collections.ObjectModel;
using System.Linq;

namespace MatrixAlgebra.Client.ViewModels
{
    public class DiagramViewModel : BaseViewModel
    {
        public DiagramViewModel(float[] elements)
        {
            Elements = new ObservableCollection<DiagramElement>(
                Enumerable.Range(0, elements.Length)
                .Select(index => new DiagramElement(elements[index], index)));
        }

        public ObservableCollection<DiagramElement> Elements { get; }
    }

    public class DiagramElement
    {
        public DiagramElement(float value, int index)
        {
            Value = value;
            Index = index;
        }

        public float Value { get; }

        public int Index { get; }
    }
}
