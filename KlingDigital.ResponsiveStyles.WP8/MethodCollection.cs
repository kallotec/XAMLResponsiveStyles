/*
XAMLResponsiveStyles created by James H. at http://www.klingdigital.net
Source code from http://github.com/klingdigital/XAMLResponsiveStyles
*/
using KlingDigital.ResponsiveStyles.WP8.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace KlingDigital.ResponsiveStyles.WP8
{
    [ContentProperty("List")]
    public class MethodCollection : DependencyObject, IList<IResponsiveMethod>
    {
        public MethodCollection()
        {
            list = new List<IResponsiveMethod>();
        }


        List<IResponsiveMethod> list;

        public List<IResponsiveMethod> List
        {
            get { return list; }
            set { list = value; }
        }


        public int IndexOf(IResponsiveMethod item)
        {
            return list.IndexOf(item);
        }

        public void Insert(int index, IResponsiveMethod item)
        {
            list.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            list.RemoveAt(index);
        }

        public IResponsiveMethod this[int index]
        {
            get
            {
                return list[index];
            }
            set
            {
                list[index] = value;
            }
        }

        public void Add(IResponsiveMethod item)
        {
            list.Add(item);
        }

        public void Clear()
        {
            list.Clear();
        }

        public bool Contains(IResponsiveMethod item)
        {
            return list.Contains(item);
        }

        public void CopyTo(IResponsiveMethod[] array, int arrayIndex)
        {
            list.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return list.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(IResponsiveMethod item)
        {
            return list.Remove(item);
        }

        public IEnumerator<IResponsiveMethod> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }
    }
}
