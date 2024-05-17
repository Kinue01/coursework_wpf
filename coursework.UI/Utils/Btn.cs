using System.Windows;
using System.Windows.Controls;

namespace coursework.UI.Utils
{
    internal class Btn : RadioButton
    {
        static Btn()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Btn), new FrameworkPropertyMetadata(typeof(Btn)));
        }
    }
}
