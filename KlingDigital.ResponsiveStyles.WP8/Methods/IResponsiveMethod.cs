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
    public interface IResponsiveMethod
    {
        void HandleChange(Size size, PageOrientation orientation, IList<ResourceDictionary> resources);
    }
}
