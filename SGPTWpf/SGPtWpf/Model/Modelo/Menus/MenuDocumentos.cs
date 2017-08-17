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
using SGPTWpf.Views.Principales.Documentos.Consulta;
using SGPTWpf.Views.Principales.Documentos.Generacion;
using SGPTWpf.ViewModel.Documentos.Consulta;
using SGPTWpf.ViewModel.Documentos.Generacion;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Planificacion.Indices;

namespace SGPTWpf.SGPtWpf.Model.Modelo.Menus
{
    public class MenuDocumentos : UIBase
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

        public MenuDocumentos NewMenuDocumentos
        {
            get { return GetValue(() => NewMenuDocumentos); }
            set { SetValue(() => NewMenuDocumentos, value); }
        }


        public MenuDocumentos()
        {
            _token = "MenuDocumentos";
            Navegar = new RelayCommand(NavigateExecute);
        }
        public void NavigateExecute()
        {
            switch (ViewDisplay)
            {
                case "Consulta":
                    ViewType = typeof(ConsultaView);
                    break;
                case "Impresión":
                    ViewType = typeof(GeneracionView);
                    break;
            }

            if ((View != null) && ViewType != null)
            {
                View = (UserControl)Activator.CreateInstance(ViewType);
            }
            else
            {
                View = (UserControl)Activator.CreateInstance(ViewType);

                switch (ViewDisplay)
                {
                    case "Consulta":
                        ViewModelType = typeof(IndiceViewModel);
                        //Contexto = new ConsultaViewModel();
                        Contexto = new IndiceViewModel("Documentos");
                        break;
                    case "Impresión":
                        ViewModelType = typeof(GeneracionViewModel);
                        Contexto = new IndiceViewModel("DocumentosImpresion");
                        break;
                }
            }
            var msg = new NavegacionSgpt { View = View, ViewModelType = ViewModelType, ViewType = ViewType, Contexto = Contexto };
            Messenger.Default.Send(msg, token);
        }

        #endregion


        #region Public Model Methods

        public static List<MenuDocumentos> GetAll()
        {
            ObservableCollection<MenuDocumentos> lista = new ObservableCollection<MenuDocumentos>
                {
               new MenuDocumentos {
                                id=1,
                                tabla="Consulta",
                                ViewType = typeof(IndiceViewModel),
                                ViewDisplay ="Consulta"
                                },
                new MenuDocumentos {
                                id=2,
                                tabla="Impresión",
                                ViewType = typeof(IndiceViewModel),
                                ViewDisplay ="Impresión"
                                },
                    };

            return lista.OrderBy(x => x.id).ToList();
        }

        public MenuDocumentos(int i)
        {
            _token = "MenuDocumentos";
        }
        #endregion
    }
}
