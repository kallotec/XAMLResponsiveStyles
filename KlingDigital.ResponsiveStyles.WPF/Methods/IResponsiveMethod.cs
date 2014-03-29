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
    public interface IResponsiveMethod
    {
        void HandleChange(Size size, IList<ResourceDictionary> resources);
    }
}
