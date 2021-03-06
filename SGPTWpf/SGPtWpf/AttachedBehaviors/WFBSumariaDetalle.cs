﻿using MahApps.Metro.Controls;
using System;
using System.Windows;
using SGPTWpf.Views.Compartidas;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Supervision.Agenda;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Supervision.Agenda;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Planificacion.Indice;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Planificacion.Indices;

namespace SGPTWpf.AttachedBehaviors
{
    public static class WFBSumariaDetalle
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

        #region WFBSumariaDetalle Constructor

        static WFBSumariaDetalle()
        {
            NameProperty = DependencyProperty.RegisterAttached("Name",
                                                               typeof(string),
                                                               typeof(WFBSumariaDetalle),
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
                    string encabezado = "";
                    double ancho = PrincipalAlterna.ancho;
                    double largo = PrincipalAlterna.largo;
                    switch (e.NewValue.ToString())
                    {
                        /*Casos de Encargos planificacion programas */

                        case "CedulaAgendaCrearview":
                            encabezado = "Creación de Agenda";
                            crearVentana = new AgendaCrudView();
                            crearVentana.DataContext = new AgendaControllerViewModel("DocumentacionCedulaAgenda");
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;
                        case "CedulaAgendaEditarView":
                            encabezado = "Actualización de Agenda";
                            crearVentana = new AgendaCrudView();
                            crearVentana.DataContext = new AgendaControllerViewModel("DocumentacionCedulaAgenda");
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;
                        case "CedulaAgendaConsultarView":
                            encabezado = "Consulta de Agenda";
                            crearVentana = new AgendaCrudView();
                            crearVentana.DataContext = new AgendaControllerViewModel("DocumentacionCedulaAgenda");
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;
                        case "CedulaAgendaImportarView":
                            encabezado = "Consulta de Agenda";
                            crearVentana = new AgendaCrudView();
                            crearVentana.DataContext = new AgendaControllerViewModel("DocumentacionCedulaAgenda");
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;
                        case "CedulaAgendaVerView":
                            encabezado = "Vista de Agenda";
                            crearVentana = new AgendaPresentacionView();
                            crearVentana.DataContext = new AgendaPresentacionViewModel("CedulaAgenda");
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;
                        case "CedulaModeloReferenciarView":
                            encabezado = "Referenciación de cédula de auditoría";
                            crearVentana = new ReferenciarView();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new AgendaControllerViewModel("DocumentacionCedulaAgenda");
                            break;
                        case "CedulaAgendaCerrarView":
                            encabezado = "Cierre del documento";
                            crearVentana = new ReferenciarView();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new AgendaControllerViewModel("DocumentacionCedulaAgenda");
                            break;
                        case "CedulaAgendaSupervisarView":
                            encabezado = "Supervisa y aprueba el documento";
                            crearVentana = new ReferenciarView();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new AgendaControllerViewModel("DocumentacionCedulaAgenda");
                            break;
                        case "CedulaAgendaAprobarView":
                            encabezado = "Terminación del papel de trabajo";
                            crearVentana = new ReferenciarView();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new AgendaControllerViewModel("DocumentacionCedulaAgenda");
                            break;

                        default:
                            //Controller y vista solo para mientras
                            encabezado = "Error"; break;
                    }
                    crearVentana.WindowStartupLocation = WindowStartupLocation.Manual;
                    crearVentana.Title = encabezado;
                    crearVentana.Owner = Application.Current.MainWindow;
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