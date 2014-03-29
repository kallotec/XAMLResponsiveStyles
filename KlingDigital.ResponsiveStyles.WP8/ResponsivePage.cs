/*
XAMLResponsiveStyles created by James H. at http://www.klingdigital.net
Source code from http://github.com/klingdigital/XAMLResponsiveStyles
*/
using Microsoft.Phone.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;

namespace KlingDigital.ResponsiveStyles.WP8
{
    public class ResponsivePage : PhoneApplicationPage
    {
        public ResponsivePage()
        {
            this.SizeChanged += page_SizeChanged;
            this.OrientationChanged += ResponsivePage_OrientationChanged;
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


        void ResponsivePage_OrientationChanged(object sender, OrientationChangedEventArgs e)
        {
            if (ResponsiveMethods != null)
            {
                foreach (var method in ResponsiveMethods)
                {
                    method.HandleChange(new Size(this.ActualWidth, this.ActualHeight),
                                        base.Orientation,
                                        this.Resources.MergedDictionaries);
                }
            }
        }

        void page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (ResponsiveMethods != null)
            {
                foreach(var method in ResponsiveMethods)
                {
                    method.HandleChange(e.NewSize,
                                        base.Orientation,
                                        this.Resources.MergedDictionaries);
                }
            }

        }


    }
}
