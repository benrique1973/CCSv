using MahApps.Metro.Controls;
using SGPTWpf.ViewModel;
using SGPTWpf.Views;
using System;
using System.Windows;

namespace SGPTWpf.AttachedBehaviors
{
    public static class WFBInicial
        {
            #region Private Section
            private static string vista = string.Empty;
            private static string vistaAnterior = string.Empty;
            private static bool controlStrin = true;

            #endregion

            #region Name Dependency Property

            public static readonly DependencyProperty NameProperty;

            public static void SetName(DependencyObject DepObject, string value)
            {
                DepObject.SetValue(NameProperty, value);
            }

            public static string GetName(DependencyObject DepObject)
            {
                return (string)DepObject.GetValue(NameProperty);
            }

            #endregion

            #region WFBInicial Constructor

            static WFBInicial()
            {
                NameProperty = DependencyProperty.RegisterAttached("Name",
                                                                   typeof(string),
                                                                   typeof(WFBInicial),
                                                                   new UIPropertyMetadata(String.Empty, IsFactoryStart));
            }

            #endregion

            #region IsFactoryStart

            private static void IsFactoryStart(DependencyObject sender, DependencyPropertyChangedEventArgs e)
            {

                if (e.NewValue is String && String.IsNullOrEmpty((string)e.NewValue) == false)
                {
                    if (controlStrin)
                    {
                        vista = e.NewValue.ToString();
                        controlStrin = false;
                    }
                    else
                    {
                        vistaAnterior = e.NewValue.ToString();
                        controlStrin = true;
                    }
                    if (vistaAnterior == vista)
                    {
                        //Repetido
                    }
                    else
                    {
                        var crearVentana = new MetroWindow();
                        crearVentana = new LoguinView();
                        crearVentana.DataContext = new LoguinViewModel();
                        crearVentana.Show();
                    }
                }
                else
                {
                    vista = string.Empty;
                    vistaAnterior = string.Empty;
                    controlStrin = true;
                }
            }
            #endregion
        }
    }