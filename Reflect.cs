using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Reflect
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class TextClass1
    {
        void GetText2()
        {
            Type typeClass1 = Type.GetType("Reflect.TextClass2");
            MethodInfo text1 = typeClass1.GetMethod("Text1");
            MethodInfo text2 = typeClass1.GetMethod("Text2");
            text1.Invoke(text1, null);
            Object[] a = new Object[] { 2 };
            string b = text2.Invoke(text2,a) as string;
        }
        
    }


    class TextClass2
    {
        void Text1()
        {
            
            
        }

        string Text2(int a)
        {
            return a.ToString();
        }

    }


}
