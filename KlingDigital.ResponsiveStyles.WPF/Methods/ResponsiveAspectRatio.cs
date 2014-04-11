/*
XAMLResponsiveStyles created by James H. at http://www.klingdigital.net
Source code from http://github.com/klingdigital/XAMLResponsiveStyles
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KlingDigital.ResponsiveStyles.WPF.Methods
{
    public enum eCurrentAspectRatio { None, FourByThree, SixteenByNine }

    public class ResponsiveAspectRatio : DependencyObject, IResponsiveMethod
    {
        public ResponsiveAspectRatio()
        {
        }

        eCurrentAspectRatio state;


        public ResourceDictionaryCollection FourByThreeStyles
        {
            get { return (ResourceDictionaryCollection)GetValue(FourByThreeStylesProperty); }
            set { SetValue(FourByThreeStylesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CompactStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FourByThreeStylesProperty =
            DependencyProperty.Register("FourByThreeStyles", typeof(ResourceDictionaryCollection), typeof(ResponsiveAspectRatio), new PropertyMetadata(null));

        public ResourceDictionaryCollection SixteenByNineStyles
        {
            get { return (ResourceDictionaryCollection)GetValue(SixteenByNineStylesProperty); }
            set { SetValue(SixteenByNineStylesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RegularStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SixteenByNineStylesProperty =
            DependencyProperty.Register("SixteenByNineStyles", typeof(ResourceDictionaryCollection), typeof(ResponsiveAspectRatio), new PropertyMetadata(null));



        public void HandleChange(Size size, IList<ResourceDictionary> resources)
        {
            //get aspect ratio
            double value = (double)size.Width / size.Height;

            bool is16b9 = (value > 1.7);
            bool is4b3 = !(value > 1.7);

            //STYLE SWITCHING

            //16:9
            if ((state == eCurrentAspectRatio.None && is16b9) ||
                (state == eCurrentAspectRatio.FourByThree && is16b9))
            {
                state = eCurrentAspectRatio.SixteenByNine;

                //clear existing responsive styles if any
                removeExistingStyles(resources);

                //add compact style xaml to resources
                if (this.SixteenByNineStyles != null)
                {
                    foreach (var style in this.SixteenByNineStyles)
                        resources.Add(style);
                }

            }
            //4:3
            else if ((state == eCurrentAspectRatio.None && is4b3) ||
                     (state == eCurrentAspectRatio.SixteenByNine && is4b3))
            {
                state = eCurrentAspectRatio.FourByThree;

                //clear existing responsive styles if any
                removeExistingStyles(resources);

                //add regular style xaml to resources
                if (this.FourByThreeStyles != null)
                {
                    foreach (var style in this.FourByThreeStyles)
                        resources.Add(style);
                }

            }
        }

        void removeExistingStyles(IList<ResourceDictionary> resources)
        {
            var allStyles = new List<ResourceDictionary>();

            if (this.FourByThreeStyles != null)
                allStyles.AddRange(this.FourByThreeStyles);

            if (this.SixteenByNineStyles != null)
                allStyles.AddRange(this.SixteenByNineStyles);

            for (int i = 0; i < resources.Count; i++)
            {
                var res = resources[i] as ResourceDictionary;
                if (res == null)
                    continue;

                var match = allStyles.FirstOrDefault(s => s.Source == res.Source);
                if (match != null)
                {
                    resources.RemoveAt(i);
                    i--;
                }
            }

        }

    }
}
