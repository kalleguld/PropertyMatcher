using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace dk.kalleguld.PropertyMatcher.View
{
    public static class DragDropHelper
    {

        public static readonly DependencyProperty VerticalScrollOnDraggingProperty =
            DependencyProperty.RegisterAttached(
                "VerticalScrollOnDragging", 
                typeof(bool), 
                typeof(DragDropHelper), 
                new PropertyMetadata(false, HandleScrollOnDragDropChanged));

        public static bool GetVerticalScrollOnDragging(DependencyObject element)
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));

            return (bool)element.GetValue(VerticalScrollOnDraggingProperty);
        }

        public static void SetVerticalScrollOnDragging(DependencyObject element, bool value)
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));

            element.SetValue(VerticalScrollOnDraggingProperty, value);
        }

        private static void HandleScrollOnDragDropChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement container = d as FrameworkElement;

            if (d == null)
            {
                Debug.Fail("Invalid type!");
                return;
            }

            Unsubscribe(container);

            if (true.Equals(e.NewValue))
            {
                Subscribe(container);
            }
        }

        private static void Subscribe(FrameworkElement container)
        {
            container.PreviewDragOver += OnContainerPreviewDragOver;
        }


        private static void Unsubscribe(FrameworkElement container)
        {
            container.PreviewDragOver -= OnContainerPreviewDragOver;
        }

        private static void OnContainerPreviewDragOver(object sender, DragEventArgs e)
        {
            ScrollViewer scrollViewer = sender as ScrollViewer;
            if (scrollViewer == null)
            {
                var container = sender as FrameworkElement;
                if (container == null)
                    return;
                scrollViewer = GetFirstVisualChild<ScrollViewer>(container);
            }

            if (scrollViewer == null)
                return;

            double tolerance = 60;
            double verticalPos = e.GetPosition(scrollViewer).Y;
            double offset = 20;

            if (verticalPos < tolerance) // Top of visible list? 
            {
                scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset - offset); //Scroll up. 
            }
            else if (verticalPos > scrollViewer.ActualHeight - tolerance) //Bottom of visible list? 
            {
                scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset + offset); //Scroll down.     
            }
        }

        private static T GetFirstVisualChild<T>(DependencyObject depObject) where T : DependencyObject
        {
            if (depObject != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObject); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObject, i);
                    if (child != null && child is T)
                    {
                        return (T)child;
                    }

                    T childItem = GetFirstVisualChild<T>(child);
                    if (childItem != null)
                    {
                        return childItem;
                    }
                }
            }

            return null;
        }
    }
}
