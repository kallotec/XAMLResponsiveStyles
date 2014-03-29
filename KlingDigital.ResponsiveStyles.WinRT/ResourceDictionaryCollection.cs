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
using Windows.UI.Xaml;
using Windows.UI.Xaml.Markup;

namespace KlingDigital.ResponsiveStyles.WinRT
{
    [ContentProperty(Name="List")]
    public class ResourceDictionaryCollection : DependencyObject, IList<ResourceDictionary>
    {
        public ResourceDictionaryCollection()
        {
            list = new List<ResourceDictionary>();
        }


        List<ResourceDictionary> list;

        public List<ResourceDictionary> List
        {
            get { return list; }
            set { list = value; }
        }


        public int IndexOf(ResourceDictionary item)
        {
            return list.IndexOf(item);
        }

        public void Insert(int index, ResourceDictionary item)
        {
            list.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            list.RemoveAt(index);
        }

        public ResourceDictionary this[int index]
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

        public void Add(ResourceDictionary item)
        {
            list.Add(item);
        }

        public void Clear()
        {
            list.Clear();
        }

        public bool Contains(ResourceDictionary item)
        {
            return list.Contains(item);
        }

        public void CopyTo(ResourceDictionary[] array, int arrayIndex)
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

        public bool Remove(ResourceDictionary item)
        {
            return list.Remove(item);
        }

        public IEnumerator<ResourceDictionary> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }
    }
}
