//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SGPTWpf.SGPtmvvm.Vistas
//{
//    class DialogoRecuperacionCuentaLoginViewModel
//    {
//    }
//}


using CapaDatos;
using MahApps.Metro.Controls.Dialogs;
using SGPTmvvm.Model;
using SGPTmvvm.Soporte;
using SGPTmvvm.ViewModel.FilaVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Input;
//using MetroDemo.Annotations;

namespace SGPTWpf.SGPtmvvm.Vistas
{
    public class DialogoRecuperacionCuentaLoginViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<UsuariosVM> UsuariosListado { get; set; }

        public SGPTEntidades db = new SGPTEntidades();
        DialogCoordinator dlg;

        private readonly ICommand _closeCommand;

        private string _firstName;
        private string _lastName;

        public DialogoRecuperacionCuentaLoginViewModel(Action<DialogoRecuperacionCuentaLoginViewModel> closeHandler)
        {
            dlg = new DialogCoordinator();
            _closeCommand = new SimpleCommand
            {
                ExecuteDelegate = o => closeHandler(this)
            };
        }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                //OnPropertyChanged();
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                //OnPropertyChanged();
            }
        }

        public ICommand CloseCommand
        {
            get { return _closeCommand; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }



        /*********************************/

        #region Olvido Contraseña
        CustomDialog customDialog;
        #region Campos
        private string _correoT;
        private string _idduipersona;
        private string _nombrespersona;
        private string _apellidospersona;
        public string CorreoT { get { return _correoT; } set { _correoT = value; RaisePropertyChanged("CorreoT"); } }
        public string Idduipersonay { get { return _idduipersona; } set { _idduipersona = value; RaisePropertyChanged("Idduipersonay"); } }

        public string Nombrespersona { get { return _nombrespersona; } set { _nombrespersona = value; RaisePropertyChanged("Nombrespersona"); } }

        public string Apellidospersona { get { return _apellidospersona; } set { _apellidospersona = value; RaisePropertyChanged("Apellidospersona"); } }
        #endregion

        #region Comandos
        private bool _canExecute = true;
        private ICommand _cmdCancelar_Click;
        public ICommand cmdCancelar_Click
        {
            get
            {
                return _cmdCancelar_Click ?? (_cmdCancelar_Click = new CommandHandler(() => cmdCancelar(), _canExecute));
            }
        }

        private async void cmdCancelar()
        {
            //await dlg.ShowMessageAsync(this, "Dio click en Cancelar", "");


            //customDialog.Content = "Tenga un buen dia";
            await dlg.ShowMessageAsync(this, "Tenga un buen día", "");
            //return _closeCommand;
            //await dlg.HideMetroDialogAsync(this, customDialog);
            //CloseWindow();
        }

        private ICommand _cmdAceptar_Click;
        public ICommand cmdAceptar_Click
        {
            get
            {
                return _cmdAceptar_Click ?? (_cmdAceptar_Click = new CommandHandler(() => cmdAceptar(), _canExecute));
            }
        }

        private async void cmdAceptar()
        {
            await dlg.ShowMessageAsync(this, "Dio click en Aceptar", "");
        }
        #endregion

        private void ObtenerDatos()
        {
            ObservableCollection<UsuariosVM> _usuarios = new ObservableCollection<UsuariosVM>();

            try
            {
                List<usuariospersonas> usuariosy;
                using (db = new SGPTEntidades())
                {
                    //db.Configuration.AutoDetectChangesEnabled = false;
                    //db.Configuration.ValidateOnSaveEnabled = false;
                    #region +
                    usuariosy = (from u in db.usuarios
                                 join p in db.personas
                                 on u.idduipersona equals p.idduipersona
                                 orderby p.nombrespersona
                                 select new usuariospersonas
                                 {
                                     #region
                                     idusuario = u.idusuario,
                                     idpista = (int)u.idpista,
                                     usuidusuario = (int)(u.usuidusuario),
                                     idrol = (int)(u.idrol),
                                     //idfirma = (int)u.idfirma,
                                     fecharegistrousuario = u.fecharegistrousuario,
                                     fechadebaja = (u.fechadebaja),
                                     fechacontratacion = (u.fechacontratacion),
                                     nickusuariousuario = u.nickusuariousuario,
                                     contraseniausuario = u.contraseniausuario,
                                     inicialesusuario = u.inicialesusuario,
                                     respuestapistausuario = u.respuestapistausuario,
                                     numerocvpausuario = u.numerocvpausuario,
                                     fechacvpausuario = (u.fechacvpausuario),
                                     estadousuario = u.estadousuario,
                                     idduipersona = p.idduipersona,
                                     nombrespersona = p.nombrespersona,
                                     apellidospersona = p.apellidospersona,
                                     sexopersona = p.sexopersona,
                                     direccionpersona = p.direccionpersona,
                                     noafppersona = p.noafppersona,
                                     noissspersona = p.noissspersona,
                                     nitpersona = p.nitpersona,
                                     estadopersona = p.estadopersona,
                                     correos = (from c in db.correos where c.idduipersona == p.idduipersona && c.estadocorreo == "A" orderby c.idcorreo select c).ToList(),
                                     telefonos = (from t in db.telefonos where t.idduipersona == p.idduipersona && t.estadotelefono == "A" orderby t.idtt select t).ToList()
                                     #endregion
                                 }).ToList(); 
                    #endregion
                }
                //from t in db.telefonos on p.idduipersona equals t.idduipersona 
                foreach (usuariospersonas usua in usuariosy)
                {
                    using (db = new SGPTEntidades())
                    {
                        try
                        {
                            if (usua.idrol > 0)
                            {
                                String nombreRolz = (from r in db.roles where r.idrol.Equals(usua.idrol) select r.nombrerol).FirstOrDefault();
                                usua.nombrerol = nombreRolz;
                            }
                            if (usua.usuidusuario > 0)
                            {
                                var zyx = db.personas.Join(db.usuarios, p => p.idduipersona, u => u.idduipersona, (p, u) => new { personas = p, usuarios = u }).Where(uu => uu.usuarios.idusuario == usua.usuidusuario).Select(uu => uu.personas).SingleOrDefault();
                                String nombreJefez = zyx.nombrespersona + ", " + zyx.apellidospersona;
                                usua.nombreusuidusuario = nombreJefez;
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("No se pudo recuperar el nombre del rol, ni el nombre del jefe");
                        }
                    }
                    _usuarios.Add(new UsuariosVM { IsNew = false, TheUsuariosPersonas = usua });
                }
                UsuariosListado = _usuarios;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error critico al recuperar los datos de los usuarios. Notifique a soporte tecnico acerca de este error. " + ex, "Error critico.", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            RaisePropertyChanged("UsuariosListado");
        }

        #endregion

        private void DatosOlvidoContrasenia()
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (object sender, DoWorkEventArgs e) =>
            {
                this.ObtenerDatos();
            };
            worker.RunWorkerCompleted += (object sender, RunWorkerCompletedEventArgs e) =>
            {
            };
            worker.RunWorkerAsync();
        }



        /**********************************/
        
    }
}

public class SimpleCommand : ICommand
{
    public Predicate<object> CanExecuteDelegate { get; set; }
    public Action<object> ExecuteDelegate { get; set; }

    public bool CanExecute(object parameter)
    {
        if (CanExecuteDelegate != null)
            return CanExecuteDelegate(parameter);
        return true; // if there is no can execute default to true
    }

    public event EventHandler CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }

    public void Execute(object parameter)
    {
        if (ExecuteDelegate != null)
            ExecuteDelegate(parameter);
    }
}
