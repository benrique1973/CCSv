using SGPTWpf.Model;
using SGPTWpf.SGPtmvvm.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
//https://social.technet.microsoft.com/wiki/contents/articles/31422.wpf-passing-a-data-bound-value-to-a-validation-rule.aspx

namespace SGPTWpf.SGPtWpf.Support.Validaciones.Reglas
{
    public class WrapperElementoContable : DependencyObject
    {
        public static readonly DependencyProperty listaElementoContableProperty =
             DependencyProperty.Register("listaElementoContable", typeof(ObservableCollection<ElementoModelo>),
             typeof(WrapperElementoContable), new FrameworkPropertyMetadata());

        public ObservableCollection<ElementoModelo> listaElementoContable
        {
            get { return (ObservableCollection<ElementoModelo>)GetValue(listaElementoContableProperty); }
            set { SetValue(listaElementoContableProperty, value); }
        }

        //Modificado por eliezer para reutilizarlo 08/03/2017
        public static readonly DependencyProperty listaElementoContablexProperty =
             DependencyProperty.Register(
             "listaElementoContablex",
             typeof(List<ElementosContablesModelo>),
             typeof(WrapperElementoContable),
             new FrameworkPropertyMetadata(null)
                {
                    BindsTwoWayByDefault = true,
                    DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
                });
             //new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public List<ElementosContablesModelo> listaElementoContablex
        {
            get { return (List<ElementosContablesModelo>)GetValue(listaElementoContablexProperty); }
            set { SetValue(listaElementoContablexProperty, value); }
        }
        //**************************

        //public object SelectedItem
        //{
        //    get { return GetValue(SelectedItemProperty); }
        //    set { SetValue(SelectedItemProperty, value); }
        //}

        //public static readonly DependencyProperty SelectedItemProperty = 
        //DependencyProperty.Register(
        //"SelectedItem", 
        //typeof(object),
        //typeof(WrapperElementoContable), 
        //new FrameworkPropertyMetadata(null)
        //{
        //    BindsTwoWayByDefault = true,
        //    DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
        //});

        public object SelectedItem
        {
            get { return (object)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        public static readonly DependencyProperty SelectedItemProperty =
        DependencyProperty.Register(
        "SelectedItem",
        typeof(object),
        typeof(WrapperElementoContable),
        new FrameworkPropertyMetadata(null)
        {
            BindsTwoWayByDefault = true,
            DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
        });

        public static readonly DependencyProperty CodiguitoxProperty =
             DependencyProperty.Register(
             "Codiguitox",
             typeof(string),
             typeof(WrapperElementoContable),
             new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public string Codiguitox
        {
            get { return (string)GetValue(CodiguitoxProperty); }
            set { SetValue(CodiguitoxProperty, value); }
        }

    }

    public class UnicoCodigoContableRule : ValidationRule
    {
        private int _min;
        private int _max;

        public UnicoCodigoContableRule()
        {
            _min = 1;
            _max = 9;
        }

        public int Min
        {
            get { return _min; }
            set { _min = value; }
        }

        public int Max
        {
            get { return _max; }
            set { _max = value; }
        }

        

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                if (this.Wrapper.listaElementoContable!=null)
                {
                    #region +
                    int elemento = int.Parse(value.ToString());
                    ObservableCollection<ElementoModelo> castedCollection = this.Wrapper.listaElementoContable;
                    if (castedCollection.Count > 0)
                    {
                        //int contains = castedCollection.Where(x => x.codigoelemento == elemento).Count();
                        //var contains = castedCollection.Where(x => x.codigoelemento == elemento).ToList();
                        var contains = castedCollection.Select(x => x.digitosElementoModelo.idDigitosModelo.ToString()).Contains(elemento.ToString());

                        int contar = 0;
                        foreach (ElementoModelo item in castedCollection)
                        {
                            if (item.digitosElementoModelo.idDigitosModelo == elemento)
                            {
                                contar++;
                            }
                        }


                        if (contar > 1)
                        {
                            return new ValidationResult(false,
                              "El código de los elementos contables debe ser únicos no pueden repetirse " + contar);
                        }
                        else
                        {
                            if ((elemento < Min) || (elemento > Max))
                            {
                                return new ValidationResult(false,
                                  "Por favor ingrese valores  en el siguiente rango: " + Min + " - " + Max + ".");
                            }
                            else
                            {
                                return new ValidationResult(true, null);
                            }
                        }
                    }
                    else
                    {
                        return new ValidationResult(true, null);
                    }

                    #endregion 
                }
                else if (this.Wrapper.listaElementoContablex != null)
                {
                    #region +
                    int elemento = int.Parse(value.ToString());
                    List<ElementosContablesModelo> castedCollection = this.Wrapper.listaElementoContablex;

                    if (castedCollection.Count > 0)
                    {
                        //int contains = castedCollection.Where(x => x.codigoelemento == elemento).Count();
                        //var contains = castedCollection.Where(x => x.codigoelemento == elemento).ToList();
                        var contains = castedCollection.Select(x => x.codigoelemento.ToString()).Contains(elemento.ToString());

                      
                        //int i = castedCollection.Count(x => x.codigoelemento == elemento);
                        //if (i == 0)
                        //{
                        //    if ((elemento < Min) || (elemento > Max))
                        //    {
                        //        return new ValidationResult(false,
                        //          "Por favor ingrese valores  en el siguiente rango: " + Min + " - " + Max + ".");
                        //    }
                        //    else
                        //        return new ValidationResult(true, null);
                        //}


                        int contar = 0;
                        foreach (var item in castedCollection)
                        {
                            if (item.codigoelemento == elemento)
                            {
                                contar++;
                            }
                        }

                        if (contar > 1)
                        {
                            return new ValidationResult(false,
                              "El código de los elementos contables debe ser únicos no pueden repetirse " + contar);
                        }
                        else
                        {
                            if ((elemento < Min) || (elemento > Max))
                            {
                                return new ValidationResult(false,
                                  "Por favor ingrese valores  en el siguiente rango: " + Min + " - " + Max + ".");
                            }
                            else
                            {
                                return new ValidationResult(true, null);
                            }
                        }
                    }
                    else
                    {
                        return new ValidationResult(true, null);
                    }

                    #endregion 
                }
                else
                    return new ValidationResult(false, "No ha ingresado el dato solicitado");
            }
            catch (Exception)
            {
                return new ValidationResult(false, "No ha ingresado el dato solicitado");
            }
        }
        public WrapperElementoContable Wrapper { get; set; }
    }

}