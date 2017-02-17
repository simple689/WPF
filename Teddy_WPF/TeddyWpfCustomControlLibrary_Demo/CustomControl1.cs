using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TeddyWpfCustomControlLibrary_Demo
{
    ///     xmlns:MyNamespace="clr-namespace:TeddyWpfCustomControlLibrary_Demo"
    ///     xmlns:MyNamespace="clr-namespace:TeddyWpfCustomControlLibrary_Demo;assembly=TeddyWpfCustomControlLibrary_Demo"
    ///     “添加引用”->“项目”->[选择此项目]
    ///     <MyNamespace:CustomControl1/>

    public class CustomControl1 : Control
    {
        static CustomControl1()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomControl1), new FrameworkPropertyMetadata(typeof(CustomControl1)));
        }
    }
}
