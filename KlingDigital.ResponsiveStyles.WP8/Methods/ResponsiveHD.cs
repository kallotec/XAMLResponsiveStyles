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
    public class ResponsiveHD : DependencyObject, IResponsiveMethod
    {
        public ResponsiveHD()
        {
        }

        double nonHDHeight = 800d;
        bool? isHD;
        
        public ResourceDictionaryCollection NonHDStyles
        {
            get { return (ResourceDictionaryCollection)GetValue(NonHDStylesProperty); }
            set { SetValue(NonHDStylesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CompactStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NonHDStylesProperty =
            DependencyProperty.Register("NonHDStyles", typeof(ResourceDictionaryCollection), typeof(ResponsiveHD), new PropertyMetadata(null));


        public ResourceDictionaryCollection HDStyles
        {
            get { return (ResourceDictionaryCollection)GetValue(HDStylesProperty); }
            set { SetValue(HDStylesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RegularStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HDStylesProperty =
            DependencyProperty.Register("HDStyles", typeof(ResourceDictionaryCollection), typeof(ResponsiveHD), new PropertyMetadata(null));



        public void HandleChange(Size size, PageOrientation orientation, IList<ResourceDictionary> resources)
        {
            determineStyle(size, resources);
        }

        void determineStyle(Size size, IList<ResourceDictionary> resources)
        {
            //detect HD
            if (isHD == null)
            {
                removeExistingStyles(resources);

                //if one dimension is larger than 800 then it is a HD phone
                //this only needs to be processed once
                if (size.Height > nonHDHeight || size.Width > nonHDHeight)
                {
                    isHD = true;

                    //add regular style xaml to resources
                    if (this.HDStyles != null)
                    {
                        foreach (var style in this.HDStyles)
                            resources.Add(style);
                    }
                }
                else
                {
                    isHD = true;

                    //add compact style xaml to resources
                    if (this.NonHDStyles != null)
                    {
                        foreach (var style in this.NonHDStyles)
                            resources.Add(style);
                    }
                }
            }

        }

        void removeExistingStyles(IList<ResourceDictionary> resources)
        {
            var allStyles = new List<ResourceDictionary>();

            if (this.HDStyles != null)
                allStyles.AddRange(this.HDStyles);

            if (this.NonHDStyles != null)
                allStyles.AddRange(this.NonHDStyles);

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
