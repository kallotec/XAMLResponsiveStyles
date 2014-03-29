/*
XAMLResponsiveStyles created by James H. at http://www.klingdigital.net
Source code from http://github.com/klingdigital/XAMLResponsiveStyles
*/
using KlingDigital.ResponsiveStyles.WinRT.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;

namespace KlingDigital.ResponsiveStyles.WinRT
{
    public class ResponsiveApp : Application
    {
        public ResponsiveApp()
        {
        }

        MethodCollection responsiveMethods;
        bool listeningToEvents;

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
        

        protected override void OnWindowCreated(WindowCreatedEventArgs args)
        {
            if (!listeningToEvents)
            {
                subscribeToFrameEvents(args.Window);
                listeningToEvents = true;
            }
            
            base.OnWindowCreated(args);
        }

        void subscribeToFrameEvents(Window frame)
        {
            if (frame != null && listeningToEvents == false)
            {
                frame.SizeChanged += frame_SizeChanged;

                var windowSize = new Size(frame.Bounds.Width, frame.Bounds.Height);

                //intial call to setup default styles
                handleChangeEvents(windowSize,
                                   ApplicationView.Value,
                                   false);
            }
        }


        private void frame_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {
            handleChangeEvents(e.Size, 
                               ApplicationView.Value, 
                               false);
        }

        void handleChangeEvents(Size size, ApplicationViewState orientation, bool snapped)
        {
            if (ResponsiveMethods == null)
                return;

            foreach (var method in ResponsiveMethods)
            {
                method.HandleChange(size,
                                    orientation,
                                    snapped,
                                    this.Resources.MergedDictionaries);
            }

        }



    }
}
