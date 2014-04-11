/*
XAMLResponsiveStyles created by James H. at http://www.klingdigital.net
Source code from http://github.com/klingdigital/XAMLResponsiveStyles
*/
using KlingDigital.ResponsiveStyles.WPF.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace KlingDigital.ResponsiveStyles.WPF
{
    public class ResponsiveWindow : Window
    {
        public ResponsiveWindow()
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
            DependencyProperty.Register("ResponsiveMethods", typeof(MethodCollection), typeof(ResponsiveWindow), new PropertyMetadata(null));
        
        #endregion


        void page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (ResponsiveMethods != null)
            {
                foreach(var method in ResponsiveMethods)
                {
                    method.HandleChange(e.NewSize,
                                        this.Resources.MergedDictionaries);
                }
            }

        }


    }
}
