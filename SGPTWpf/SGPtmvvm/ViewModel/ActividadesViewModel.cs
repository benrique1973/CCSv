using CapaDatos;
using GalaSoft.MvvmLight.Messaging;
using SGPTmvvm.Mensajes;
using SGPTmvvm.Soporte;
using SGPTmvvm.ViewModel.FilaVM;
using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Input;
//using ModeloSGPT.Modelo;

namespace SGPTmvvm.ViewModel
{
    public class Actividades2ViewModel : CrudVMBase
    {
        public ActividadesVM SelectedActividades { get; set; }
        public ObservableCollection<ActividadesVM> Actividades { get; set; }
        public Actividades2ViewModel()
        {
            ThrobberVisible = Visibility.Collapsed;
            _canExecute = true;
        }
        private bool _canExecute;

        //Acepte
        private ICommand _Acepte;
        public ICommand Acepte
        {
            get
            {
                return _Acepte ?? (_Acepte = new CommandHandler(() => cmdAcepte(), _canExecute));
            }
        }

        private void cmdAcepte()
        {
            DejarseVer = Visibility.Visible;
            RaisePropertyChanged();
            RaisePropertyChanged("ThrobberVisible");
            ThrobberVisible = Visibility.Visible;
            RaisePropertyChanged("ThrobberVisible");
        }



        private ICommand _NoAcepte;
        public ICommand NoAcepte
        {
            get
            {
                return _NoAcepte ?? (_NoAcepte = new CommandHandler(() => cmdNoAcepte(), _canExecute));
            }
        }

        private void cmdNoAcepte()
        {
            DejarseVer = Visibility.Collapsed;
            RaisePropertyChanged();
            RaisePropertyChanged("ThrobberVisible");
            ThrobberVisible = Visibility.Hidden;
            RaisePropertyChanged("ThrobberVisible");
        }

        //DejarseVer
        private Visibility _DejarseVer;
        public Visibility DejarseVer
        {
            get { return _DejarseVer; }
            set
            {
                _DejarseVer = value;
                RaisePropertyChanged();
            }
        }

        private Visibility throbberVisible;
        public Visibility ThrobberVisible
        {
            get { return throbberVisible; }
            set
            {
                throbberVisible = value;
                RaisePropertyChanged();
            }
        }


        protected override void ObtenerDatos()
        {
            //ThrobberVisible = Visibility.Visible;
            ObservableCollection<ActividadesVM> _actividades = new ObservableCollection<ActividadesVM>();



                var actividadesx = (from a in db.actividades
                            where a.idcodigoactividad != null
                            orderby a.idcodigoactividad
                            select a).ToList();

                //var actividadesx = await (from a in db.actividades
                //                          where a.idcodigoactividad != null
                //                          orderby a.idcodigoactividad
                //                          select a).ToListAsync();

                foreach (actividade acti in actividadesx)
                {
                    _actividades.Add(new ActividadesVM { IsNew = false, TheActividades = acti });
                }
                Actividades = _actividades;
            RaisePropertyChanged("Actividades");
            //ThrobberVisible = Visibility.Collapsed;
        }
        protected override void ConfirmarActualizaciones()
        {
            UsuarioMensaje msg = new UsuarioMensaje();
            var inserted = (from c in Actividades
                            where c.IsNew
                            select c).ToList();
            if (db.ChangeTracker.HasChanges() || inserted.Count > 0)
            {
                foreach (ActividadesVM c in inserted)
                {
                    db.actividades.Add(c.TheActividades);
                }
                try
                {
                    db.SaveChanges();
                    msg.Mensaje = "Base de Datos Actualizada";
                }
                catch (Exception e)
                {
                    if (System.Diagnostics.Debugger.IsAttached)
                    {
                        ErrorMessage = e.InnerException.GetBaseException().ToString();
                    }
                    msg.Mensaje = "Han ocurrido problemas para actualizar la Base de Datos";
                }
            }
            else
            {
                msg.Mensaje = "No se han guardado cambios";
            }
            Messenger.Default.Send<UsuarioMensaje>(msg);
        }
        protected override void EliminarActual()
        {
            UsuarioMensaje msg = new UsuarioMensaje();
            if (SelectedActividades != null)
            {
                db.actividades.Remove(SelectedActividades.TheActividades);
                Actividades.Remove(SelectedActividades);
                RaisePropertyChanged("Actividades");
                msg.Mensaje = "Eliminado";
            }
            else
            {
                msg.Mensaje = "Ningun producto seleccionado para Eliminar";
            }
            Messenger.Default.Send<UsuarioMensaje>(msg);
        }
    }
}