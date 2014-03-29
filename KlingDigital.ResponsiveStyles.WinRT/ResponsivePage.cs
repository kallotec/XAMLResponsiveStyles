/*
XAMLResponsiveStyles created by James H. at http://www.klingdigital.net
Source code from http://github.com/klingdigital/XAMLResponsiveStyles
*/
using KlingDigital.ResponsiveStyles.WinRT.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace KlingDigital.ResponsiveStyles.WinRT
{
    public class ResponsivePage : Page
    {
        public ResponsivePage()
        {
            this.SizeChanged += page_SizeChanged;
        }

        #region ResponsiveMethods (DependencyProperty)

        public MethodCollection ResponsiveMethods
        {
            get { return (MethodCollection)GetValue(ResponsiveMethodProperty); }
            set { SetValue(ResponsiveMethodProperty, value); }
        }

        public static readonly DependencyProperty ResponsiveMethodProperty =
            DependencyProperty.Register("ResponsiveMethods", typeof(MethodCollection), typeof(ResponsivePage), new PropertyMetadata(null));
        
        #endregion


        void page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var orientation = ApplicationView.Value;

            if (ResponsiveMethods != null)
            {
                foreach(var method in ResponsiveMethods)
                {
                    method.HandleChange(e.NewSize,
                                        orientation,
                                        false,
                                        this.Resources.MergedDictionaries);
                }
            }

        }


    }
}
