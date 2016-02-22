using DevExpress.Mvvm.UI.Interactivity;
using DevExpress.Xpf.Editors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DevExpress.Control
{
     [TemplatePart(Name = "TabHeader", Type = typeof(TextEdit))]
    public class TextEditBehavior : Behavior<TextEdit>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.EditMode = EditMode.InplaceInactive;
            AssociatedObject.PreviewMouseDoubleClick += AssociatedObject_PreviewMouseDoubleClick;
            AssociatedObject.IsKeyboardFocusWithinChanged += AssociatedObject_IsKeyboardFocusWithinChanged;
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.PreviewMouseDoubleClick -= AssociatedObject_PreviewMouseDoubleClick;
            AssociatedObject.IsKeyboardFocusWithinChanged -= AssociatedObject_IsKeyboardFocusWithinChanged;
        }

        void AssociatedObject_IsKeyboardFocusWithinChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            TextEdit editor = ((TextEdit)sender);
            if (!(bool)e.NewValue)
                editor.EditMode = EditMode.InplaceInactive;
        }

        void AssociatedObject_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TextEdit editor = ((TextEdit)sender);
            editor.EditMode = EditMode.Standalone;
            editor.Focus();
        }
    }
}
