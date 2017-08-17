//http://stackoverflow.com/questions/20242817/resolving-windows-in-structure-map-or-how-to-manage-multiple-windows-in-wpf-mvvm
using MahApps.Metro.Controls;
using System;
using System.Windows;

namespace SGPTWpf.Factory
{
    public interface IWindowFactory
    {
        Window Make(string TypeWindow);
    }
}