/*
XAMLResponsiveStyles created by James H. at http://www.klingdigital.net
Source code from http://github.com/klingdigital/XAMLResponsiveStyles
*/
using Microsoft.Phone.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;

namespace KlingDigital.ResponsiveStyles.WP8.Methods
{
    public class ResponsiveOrientation : DependencyObject, IResponsiveMethod
    {
        public ResponsiveOrientation()
        {
        }

        PageOrientation? state;
        
        
        public ResourceDictionaryCollection PortraitStyles
        {
            get { return (ResourceDictionaryCollection)GetValue(PortraitStylesProperty); }
            set { SetValue(PortraitStylesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CompactStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PortraitStylesProperty =
            DependencyProperty.Register("PortraitStyles", typeof(ResourceDictionaryCollection), typeof(ResponsiveOrientation), new PropertyMetadata(null));


        public ResourceDictionaryCollection LandscapeStyles
        {
            get { return (ResourceDictionaryCollection)GetValue(LandscapeStylesProperty); }
            set { SetValue(LandscapeStylesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RegularStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LandscapeStylesProperty =
            DependencyProperty.Register("LandscapeStyles", typeof(ResourceDictionaryCollection), typeof(ResponsiveOrientation), new PropertyMetadata(null));



        public void HandleChange(Size size, PageOrientation orientation, IList<ResourceDictionary> resources)
        {
            determineStyle(orientation, resources);
        }

        void determineStyle(PageOrientation newOrientation, IList<ResourceDictionary> resources)
        {
            var lastOrientation = state;
            state = newOrientation;

            //some flags to simplify detecting an orientation change
            var wasBlank = (lastOrientation == null ||
                            lastOrientation == PageOrientation.None);
            var wasPortrait = (lastOrientation == PageOrientation.Portrait ||
                               lastOrientation == PageOrientation.PortraitDown ||
                               lastOrientation == PageOrientation.PortraitUp);
            var wasLandscape = (lastOrientation == PageOrientation.Landscape ||
                                lastOrientation == PageOrientation.LandscapeLeft ||
                                lastOrientation == PageOrientation.LandscapeRight);
            var isPortrait = (newOrientation == PageOrientation.Portrait ||
                              newOrientation == PageOrientation.PortraitDown ||
                              newOrientation == PageOrientation.PortraitUp);
            var isLandscape = (newOrientation == PageOrientation.Landscape ||
                               newOrientation == PageOrientation.LandscapeLeft ||
                               newOrientation == PageOrientation.LandscapeRight);


            //STYLE SWITCHING

            //only switch on orientation change
            if (isLandscape && (wasBlank || wasPortrait))
            {
                //clear existing responsive styles if any
                removeExistingStyles(resources);

                //add compact style xaml to resources
                if (this.LandscapeStyles != null)
                {
                    foreach (var style in this.LandscapeStyles)
                        resources.Add(style);
                }

            }
            else if (isPortrait && (wasBlank || wasLandscape))
            {
                //clear existing responsive styles if any
                removeExistingStyles(resources);

                //add regular style xaml to resources
                if (this.PortraitStyles != null)
                {
                    foreach (var style in this.PortraitStyles)
                        resources.Add(style);
                }

            }
        }

        void removeExistingStyles(IList<ResourceDictionary> resources)
        {
            var allStyles = new List<ResourceDictionary>();

            if (this.LandscapeStyles != null)
                allStyles.AddRange(this.LandscapeStyles);

            if (this.PortraitStyles != null)
                allStyles.AddRange(this.PortraitStyles);

            for (int i = 0; i < resources.Count; i++)
            {
                var res = resources[i] as ResourceDictionary;
                if (res == null)
                    continue;

                var match = allStyles.FirstOrDefault(s => s.Source == res.Source);
                if (match != null)
                {
                    resources.Remove(res);
                }
            }

        }

    }
}
