using System.Windows;
using System.Windows.Controls;

namespace ListAutoSelectTest
{
    public static class TextBoxAttach
    {
        public static readonly DependencyProperty TextBoxControllerProperty = DependencyProperty.RegisterAttached("TextBoxController", typeof(bool), typeof(TextBoxAttach),
            new UIPropertyMetadata(false, OnTextBoxControllerChanged));

        public static void SetTextBoxController(DataGridCell element, bool value)
        {
            element.SetValue(TextBoxControllerProperty, value);
        }

        public static bool GetTextBoxController(DataGridCell element)
        {
            return (bool)element.GetValue(TextBoxControllerProperty);
        }

        static void OnTextBoxControllerChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = d as DataGridCell;
            if (element == null)
            {
                return;
            }

            if (e.NewValue is bool == false)
                return;

            if ((bool)e.NewValue)
                element.Selected += SelectAll;
            else
                element.Selected -= SelectAll;
        }

        private static void SelectAll(object o, RoutedEventArgs routedEventArgs)
        {
            DataGridCell element = o as DataGridCell;

            element.Focus();
            var child = WPFTools.FindChild<TextBox>(element, null);
            if (child != null)
            {
                child.SelectAll();
            }
        }
    }
}
