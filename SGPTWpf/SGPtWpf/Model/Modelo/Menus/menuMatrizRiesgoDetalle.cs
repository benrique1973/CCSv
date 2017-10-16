using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Command;
using System;
using System.Collections.ObjectModel;
using SGPTWpf.Support;
using System.ComponentModel.DataAnnotations.Schema;
using SGPTWpf.ViewModel;
using System.Linq;
using System.Windows.Controls;
using SGPTWpf.Messages.Navegacion;
using System.Collections.Generic;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Documentacion.Balances;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Documentacion.Balances;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Documentacion.Balances.DetalleBalance;
using SGPTWpf.Views.Principales.Encargos.Planificacion;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Planificacion.Riesgo;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Planificacion.Riesgo;

namespace SGPTWpf.SGPtWpf.Model.Modelo.Menus
{
    public class menuMatrizRiesgoDetalle : UIBase
{
    #region Model Attributes

    #endregion

    #region Model Properties

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id
    {
        get { return GetValue(() => id); }
        set { SetValue(() => id, value); }
    }

    public string tabla
    {
        get { return GetValue(() => tabla); }
        set { SetValue(() => tabla, value); }
    }
    public Type ViewType
    {
        get { return GetValue(() => ViewType); }
        set { SetValue(() => ViewType, value); }
    }
    public string ViewDisplay
    {
        get { return GetValue(() => ViewDisplay); }
        set { SetValue(() => ViewDisplay, value); }
    }
        //public virtual ICollection<cedulas> cedulas { get; set; }
        public bool IsSelected
        {
            get { return GetValue(() => IsSelected); }
            set { SetValue(() => IsSelected, value); }
        }
        public bool opcionSeleccionada
        {
            get { return GetValue(() => opcionSeleccionada); }
            set { SetValue(() => opcionSeleccionada, value); }
        }
        #endregion

        #region Menu Encargos Planificacion
        public Type ViewModelType { get; set; }
    public UserControl View { get; set; }
    public RelayCommand Navegar { get; set; }

    public ViewModeloBase Contexto { get; set; }

    #region token

    private string _token;
    private string token
    {
        get { return _token; }
        set { _token = value; }
    }

    #endregion

    public menuMatrizRiesgoDetalle NewMenuMatrizRiesgoDetalle
        {
        get { return GetValue(() => NewMenuMatrizRiesgoDetalle); }
        set { SetValue(() => NewMenuMatrizRiesgoDetalle, value); }
    }


    public menuMatrizRiesgoDetalle()
    {
            _token = "MenuPlanificacion";//Se usa el mismo token que planificacion porque es al mismo frame que se manda la informacion
            //_token = "MenuDocumentacion";//Se usa el mismo token que documentacion porque es al mismo frame que se manda la informacion
            Navegar = new RelayCommand(NavigateExecute);
    }
        public void NavigateExecute()
    {
        switch (ViewDisplay)
        {
                case "Riesgo":
                    ViewType = typeof(RiesgoView);
                    break;
                case "Matriz de riesgos":
                ViewType = typeof(DetalleMatrizRiesgosEdicionView);
                break;
        }

        if ((View != null) && ViewType != null)
        {
            View = (UserControl)Activator.CreateInstance(ViewType);
        }
        else
        {
            View = (UserControl)Activator.CreateInstance(ViewType);
            //View = (UserControl)Activator.CreateInstance(ViewType);ç

            switch (ViewDisplay)
            {
                    case "Riesgo":
                        ViewModelType = typeof(MatrizRiesgoViewModel);
                        Contexto = new MatrizRiesgoViewModel("Riesgo");
                        break;
                    case "Matriz de riesgos":
                    ViewModelType = typeof(DetalleMatrizRiesgoViewModel);
                    Contexto = new DetalleMatrizRiesgoViewModel("Matriz de riesgos");
                    break;
                default:
                    //MessageDialog("Error en el switch");
                    break;
            }
        }
        var msg = new NavegacionSgpt { View = View, ViewModelType = ViewModelType, ViewType = ViewType, Contexto = Contexto };
        Messenger.Default.Send(msg, token);
    }

    #endregion


    #region Public Model Methods

    public static List<menuMatrizRiesgoDetalle> GetAll()
    {
        ObservableCollection<menuMatrizRiesgoDetalle> lista = new ObservableCollection<menuMatrizRiesgoDetalle>
                {
               new menuMatrizRiesgoDetalle {
                                id=1,
                                tabla="Riesgo",
                                ViewType = typeof(RiesgoView),
                                ViewDisplay ="Riesgo"
                                },
                new menuMatrizRiesgoDetalle {
                                id=2,
                                tabla="DETALLEMATRIZRIESGOS",
                                ViewType = typeof(DetalleMatrizRiesgoViewModel),
                                ViewDisplay ="Matriz de riesgos"
                                },
                    };

        return lista.OrderBy(x => x.id).ToList();
    }

    public menuMatrizRiesgoDetalle(int i)
    {
            _token = "MenuPlanificacion";
        }
    #endregion
}
}