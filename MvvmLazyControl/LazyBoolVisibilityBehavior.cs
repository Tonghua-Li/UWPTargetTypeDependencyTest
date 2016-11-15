
using System;
using System.Diagnostics;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Microsoft.Xaml.Interactivity;

namespace MvvmLazyControl
{

    public interface IWorkVm
    {
        
    }
    public class LazyIWorkVmBehavior : DependencyObject, IBehavior
    {
        public DependencyObject AssociatedObject { get; private set; }
        public void Attach(DependencyObject associatedObject)
        {
            var control = associatedObject as Control;
            if (control == null)
                throw new ArgumentException(
                    "EnumStateBehavior can be attached only to Control");

            AssociatedObject = associatedObject;
        }

        public void Detach()
        {
            AssociatedObject = null;
        }

        public static readonly DependencyProperty TargetTypeProperty = DependencyProperty.Register(
            nameof(TargetType), typeof(Type), typeof(LazyIWorkVmBehavior), new PropertyMetadata(null));

        public Type TargetType
        {
            get { return (Type) GetValue(TargetTypeProperty); }
            set { SetValue(TargetTypeProperty, value);}
        }
//        public Type TargetType
//        {
//            get { return _targetType; }
//            set { _targetType = value; }
//        }

        public static readonly DependencyProperty LazyControlNameProperty = DependencyProperty.Register(
            nameof(LazyControlName), typeof(string), typeof(LazyIWorkVmBehavior), new PropertyMetadata(default(string)));

        public string LazyControlName
        {
            get { return (string)GetValue(LazyControlNameProperty); }
            set { SetValue(LazyControlNameProperty, value); }
        }

        public static readonly DependencyProperty WorkVmProperty = DependencyProperty.Register(
            nameof(WorkVm), typeof(IWorkVm), typeof(LazyIWorkVmBehavior), new PropertyMetadata(default(IWorkVm),
                (d, e) =>
                {
                    var behavior = d as LazyIWorkVmBehavior;
                    if (behavior?.AssociatedObject == null || e.NewValue == null) return;
                    var control = behavior.AssociatedObject as Control;
                    var lazyView = control.FindName(behavior.LazyControlName) as Control;
                    lazyView.Visibility = Visibility.Visible;
                }));

        private Type _targetType;

        public IWorkVm WorkVm
        {
            get { return (IWorkVm)GetValue(WorkVmProperty); }
            set { SetValue(WorkVmProperty, value); }
        }

    }
}