/*
XAMLResponsiveStyles created by James H. at http://www.klingdigital.net
Source code from http://github.com/klingdigital/XAMLResponsiveStyles
*/
using KlingDigital.ResponsiveStyles.WP8.Methods;
using Microsoft.Phone.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Windows.ApplicationModel;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;

namespace KlingDigital.ResponsiveStyles.WP8
{
    public class ResponsiveApp : Application
    {
        public ResponsiveApp()
        {
            base.Host.Content.Resized += Content_Resized;
        }

        bool listeningToFrameEvents;
        PhoneApplicationFrame frame;

        MethodCollection responsiveMethods;

        MethodCollection ResponsiveMethods
        {
            get
            {
                if (responsiveMethods != null)
                    return responsiveMethods;

                foreach (var res in this.Resources.Values.OfType<MethodCollection>())
                {
                    responsiveMethods = res;
                    break;
                }

                return responsiveMethods;
            }
        }
        

        void Content_Resized(object sender, EventArgs e)
        {
            if (listeningToFrameEvents)
                return;

            frame = (sender as Microsoft.Phone.Controls.PhoneApplicationFrame);

            frame.SizeChanged += frame_SizeChanged;
            frame.OrientationChanged += ResponsiveApp_OrientationChanged;

            listeningToFrameEvents = true;
        }

        void frame_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (frame != null)
            {
                //intial call to setup default styles
                handleChangeEvents(e.NewSize,
                                   frame.Orientation);
            }
        }

        void ResponsiveApp_OrientationChanged(object sender, OrientationChangedEventArgs e)
        {
            if (frame != null)
            {
                //intial call to setup default styles
                handleChangeEvents(new Size(frame.ActualWidth, frame.ActualHeight),
                                   frame.Orientation);
            }
        }


        void handleChangeEvents(Size size, PageOrientation orientation)
        {
            if (ResponsiveMethods == null)
                return;

            foreach (var method in ResponsiveMethods)
            {
                method.HandleChange(size,
                                    orientation,
                                    this.Resources.MergedDictionaries);
            }

        }



    }
}
