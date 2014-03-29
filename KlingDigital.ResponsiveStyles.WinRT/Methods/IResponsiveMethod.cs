/*
XAMLResponsiveStyles created by James H. at http://www.klingdigital.net
Source code from http://github.com/klingdigital/XAMLResponsiveStyles
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace KlingDigital.ResponsiveStyles.WinRT.Methods
{
    public interface IResponsiveMethod
    {
        void HandleChange(Size size, ApplicationViewState orientation, bool snapped, IList<ResourceDictionary> resources);
    }
}
