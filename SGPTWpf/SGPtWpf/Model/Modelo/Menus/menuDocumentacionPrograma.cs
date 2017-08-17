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
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Documentacion.Programas;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Documentacion.Programa;

namespace SGPTWpf.SGPtWpf.Model.Modelo.Menus
{
    public class menuDocumentacionPrograma : UIBase
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

        #region Menu Documentacion Programas
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

        public menuDocumentacionPrograma NewMenuHerramienta
        {
            get { return GetValue(() => NewMenuHerramienta); }
            set { SetValue(() => NewMenuHerramienta, value); }
        }


        public menuDocumentacionPrograma()
        {
            _token = "MenuDocumentacion"; ;
            Navegar = new RelayCommand(NavigateExecute);
        }
        public void NavigateExecute()
        {
            switch (ViewDisplay)
            {
                case "Detalle Programa":
                    ViewType = typeof(DetalleProgramaView);
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
                    case "Detalle Programa":
                        ViewModelType = typeof(DetalleProgramaViewModel);
                        Contexto = new DetalleProgramaViewModel("EncargoDocumentacionProgramas");
                        break;
                }
            }
            var msg = new NavegacionSgpt { View = View, ViewModelType = ViewModelType, ViewType = ViewType, Contexto = Contexto };
            Messenger.Default.Send(msg, token);
        }

        public void NavigateExecute(string opcion)
        {
            switch (ViewDisplay)
            {
                case "Detalle Programa":
                    ViewType = typeof(DetalleProgramaView);
                    break;
            }

            if ((View != null) && ViewType != null)
            {
                View = (UserControl)Activator.CreateInstance(ViewType);
            }
            else
            {
                View = (UserControl)Activator.CreateInstance(ViewType);
                //View = (UserControl)Activator.CreateInstance(ViewType);

                switch (ViewDisplay)
                {
                    case "Detalle Programa":
                        ViewModelType = typeof(DetalleProgramaViewModel);
                        Contexto = new DetalleProgramaViewModel("EncargoDocumentacionProgramas");
                        break;
                }
            }
            var msg = new NavegacionSgpt { View = View, ViewModelType = ViewModelType, ViewType = ViewType, Contexto = Contexto };
            Messenger.Default.Send(msg, token);
        }
        #endregion


        #region Public Model Methods

        public static List<menuDocumentacionPrograma> GetAll()
        {
            ObservableCollection<menuDocumentacionPrograma> lista = new ObservableCollection<menuDocumentacionPrograma>
                {
                    new menuDocumentacionPrograma {
                                id=1,
                                tabla="detalleprogramas",
                                ViewType = typeof(DetalleProgramaViewModel),
                                ViewDisplay ="Detalle Programa"
                                },
                    };

            return lista.OrderBy(x => x.id).ToList();
        }

        public menuDocumentacionPrograma(int i)
        {
            _token = "MenuDocumentacion";
        }
        #endregion
    }
}