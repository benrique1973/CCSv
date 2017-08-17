using MahApps.Metro.Controls.Dialogs;
using SGPTWpf.Model;
using System.Collections.ObjectModel;
//Libreria indispensable para realizar la validacion de can executa.
using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Messages;
using GalaSoft.MvvmLight.CommandWpf;
using SGPTWpf.Messages.Municipio;
using System;
using System.Linq;
using SGPTWpf.SGPtWpf.Support.Validaciones.Metodos;

namespace SGPTWpf.ViewModel.Crud.Municipio
{
    public sealed class MunicipioControllerViewModel : ViewModeloBase
    {
        #region Propiedades privadas

        private MetroDialogSettings configuracionDialogo;

        private readonly IDialogCoordinator _dialogCoordinator;

        public static int Errors { get; set; }//Para controllar los errores de edición


        private int maxDescripcion = 50;
        private DialogCoordinator dlg;
        private static int controlVentana = 0;
        #endregion

        #region ViewModel Properties

        #region ViewModel Properties : ListaEntidad

        public const string listaEntidadPropertyName = "ListaEntidad";

        private ObservableCollection<MunicipioModelo> _ListaEntidad;

        public ObservableCollection<MunicipioModelo> ListaEntidad
        {
            get
            {
                return _ListaEntidad;
            }
            set
            {
                if (_ListaEntidad == value) return;

                _ListaEntidad = value;

                RaisePropertyChanged(listaEntidadPropertyName);
            }
        }
        #endregion

        #region listaPais

        public const string listaPaisPropertyName = "listaPais";


        private ObservableCollection<PaisModelo> _listaPais;

        public ObservableCollection<PaisModelo> listaPais
        {
            get
            {
                return _listaPais;
            }
            set
            {
                if (_listaPais == value) return;

                _listaPais = value;

                RaisePropertyChanged(listaPaisPropertyName);
            }
        }

        #endregion

        #region listaDepartamento

        public const string listaDepartamentoPropertyName = "listaDepartamento";


        private ObservableCollection<DepartamentoModelo> _listaDepartamento;

        public ObservableCollection<DepartamentoModelo> listaDepartamento
        {
            get
            {
                return _listaDepartamento;
            }
            set
            {
                if (_listaDepartamento == value) return;

                _listaDepartamento = value;

                RaisePropertyChanged(listaDepartamentoPropertyName);
            }
        }

        #endregion

        #region Propiedades : Descripcion

        public const string descripcionPropertyName = "descripcion";

        private string _descripcion = string.Empty;

        public string descripcion
        {
            get
            {
                return _descripcion;
            }
            set
            {
                if (_descripcion == value)
                {
                    return;
                }
                _descripcion = value;
                RaisePropertyChanged(descripcionPropertyName);
            }
        }

        #endregion

        #region Primary key

        public const string idPropertyName = "id";

        private int _id = 0;

        public int id
        {
            get
            {
                return _id;
            }

            set
            {
                if (_id == value)
                {
                    return;
                }

                _id = value;
                RaisePropertyChanged(idPropertyName);
            }
        }

        #endregion

        #region Sistema

        public const string sistemaPropertyName = "sistema";

        private bool _sistema = false;

        public bool sistema
        {
            get
            {
                return _sistema;
            }

            set
            {
                if (_sistema == value)
                {
                    return;
                }

                _sistema = value;
                RaisePropertyChanged(sistemaPropertyName);
            }
        }

        #endregion

        #region Estado

        public const string estadoPropertyName = "estado";

        private string _estado = string.Empty;

        public string estado
        {
            get
            {
                return _estado;
            }

            set
            {
                if (_estado == value)
                {
                    return;
                }

                _estado = value;
                RaisePropertyChanged(estadoPropertyName);
            }
        }

        #endregion


        #region ViewModel Property : SelectedPais

        public const string SelectedPaisPropertyName = "SelectedPais";

        private PaisModelo _SelectedPais;

        public PaisModelo SelectedPais
        {
            get
            {
                return _SelectedPais;
            }

            set
            {
                if (_SelectedPais == value) return;

                _SelectedPais = value;
                RaisePropertyChanged("HabilitarMunicipio");
                RaisePropertyChanged("HabilitarSelectionDepartamento");
                RaisePropertyChanged(SelectedPaisPropertyName);
            }
        }

        #endregion

        #region IdPais

        public const string idpaisPropertyName = "idpais";

        private int _idpais = 0;

        public int idpais
        {
            get
            {
                return _idpais;
            }

            set
            {
                if (_idpais == value)
                {
                    return;
                }

                _idpais = value;
                RaisePropertyChanged(idpaisPropertyName);
            }
        }

        #endregion
        #region Descripcion de nombrePais

        public const string nombrePaisPropertyName = "nombrePais";

        private string _nombrePais = string.Empty;

        public string nombrePais
        {
            get
            {
                return _nombrePais;
            }

            set
            {
                if (_nombrePais == value)
                {
                    return;
                }

                _nombrePais = value;
                RaisePropertyChanged(nombrePaisPropertyName);
            }
        }

        #endregion

        #region ViewModel Property : SelectedDepartamento

        public const string SelectedDepartamentoPropertyName = "SelectedDepartamento";

        private DepartamentoModelo _SelectedDepartamento;

        public DepartamentoModelo SelectedDepartamento
        {
            get
            {
                return _SelectedDepartamento;
            }

            set
            {
                if (_SelectedDepartamento == value) return;

                _SelectedDepartamento = value;

                RaisePropertyChanged("HabilitarMunicipio");
                RaisePropertyChanged(SelectedDepartamentoPropertyName);
            }
        }
         
        #endregion

        #region IdDepartamento

        public const string idDepartamentoPropertyName = "idDepartamento";

        private int _idDepartamento = 0;

        public int idDepartamento
        {
            get
            {
                return _idDepartamento;
            }

            set
            {
                if (_idDepartamento == value)
                {
                    return;
                }

                _idDepartamento = value;
                RaisePropertyChanged(idDepartamentoPropertyName);
            }
        }

        #endregion
        #region Descripcion de nombreDepartamento

        public const string nombreDepartamentoPropertyName = "nombreDepartamento";

        private string _nombreDepartamento = string.Empty;

        public string nombreDepartamento
        {
            get
            {
                return _nombreDepartamento;
            }

            set
            {
                if (_nombreDepartamento == value)
                {
                    return;
                }

                _nombreDepartamento = value;
                RaisePropertyChanged(nombreDepartamentoPropertyName);
            }
        }

        #endregion

        #region Entidad en uso

        #region ViewModel Property : CurrentEntidad

        public const string currentEntidadPropertyName = "currentEntidad";

        private MunicipioModelo _currentEntidad;

        public MunicipioModelo currentEntidad
        {
            get
            {
                return _currentEntidad;
            }

            set
            {
                if (_currentEntidad == value) return;

                _currentEntidad = value;

                RaisePropertyChanged(currentEntidadPropertyName);
            }
        }

        #endregion

        #endregion

        #endregion

        #region ViewModel Commands

        public RelayCommand GuardarCommand { get; set; }
        public RelayCommand CancelarCommand { get; set; }
        public RelayCommand OkCommand { get; set; }
        public RelayCommand SalirCommand { get; set; }
        public RelayCommand<MunicipioModelo> SelectionChangedCommand { get; set; }

        #endregion

        #region Implementacion comandos

        #region ViewModel Public Methods

        #region Constructores

        public MunicipioControllerViewModel()
        {
            configuracionDialogo = new MetroDialogSettings()
            {
                AnimateShow = false,
                AnimateHide = false
            };
            _dialogCoordinator = new DialogCoordinator();

            //Suscribiendo el mensaje
            listaPais = new ObservableCollection<PaisModelo>(PaisModelo.GetAll());
            listaDepartamento = new ObservableCollection<DepartamentoModelo>(DepartamentoModelo.GetAll());
            Messenger.Default.Register<CatalogoMensaje>(this, (controlVentanaMensaje) => ControlVentanaMensaje(controlVentanaMensaje));
            Messenger.Default.Register<MunicipioElementoMensaje>(this, (controlElementoMensaje) => ControlElementoMensaje(controlElementoMensaje));
            Messenger.Default.Register<MunicipioListaMensaje>(this, (controlListaMensaje) => ControlListaMensaje(controlListaMensaje));
            RegisterCommands();
            dlg = new DialogCoordinator();
            controlVentana = controlVentana + 1;
            if (controlVentana > 1)
            {
                Ok();//Hay una abierta se cierra la ventana creada

            }

        }

        private void ControlElementoMensaje(MunicipioElementoMensaje controlElementoMensaje)
        {
            currentEntidad = controlElementoMensaje.elementoMensaje; ;
            if (!((currentEntidad.iddepartamento == 0) || (currentEntidad.iddepartamento == null)))
            {
                    SelectedDepartamento = listaDepartamento.Single(i => i.id == currentEntidad.iddepartamento);
                    SelectedPais = listaPais.Single(i => i.id == SelectedDepartamento.idpais);

             }
            else
            {
                SelectedPais = null;
                SelectedDepartamento = null;
            }
        }

        private void ControlListaMensaje(MunicipioListaMensaje controlListaMensaje)
        {
            ListaEntidad = controlListaMensaje.listaMensaje;
        }
        #endregion

        private async void Cancelar()
        {
            // Basado en : https://social.msdn.microsoft.com/Forums/en-US/fece5464-1863-4d76-b595-b16fb98ce626/messages-dialog-fired-the-viewmodel-through-the-dialogcoordinator-using-mahappsmetro-and-mvvm-light?forum=wpf
            //Debe cerrar el sistema
            await dlg.ShowMessageAsync(this, "Operación cancelada", "");
            enviarMensaje();
            controlVentana = controlVentana - 1;
            CloseWindow();
        }

        private void Ok()
        {
            enviarMensaje();
            controlVentana = controlVentana - 1;
            CloseWindow();
        }

        private void Salir()
        {
            if (!((controlVentana == 0)))
            {
                if (controlVentana < 0)
                {
                    controlVentana = 0;
                }
                else
                {
                    enviarMensaje();
                    controlVentana = controlVentana - 1;
                    CloseWindow();
                }
            }

        }


        public async void Guardar()
        {
            currentEntidad.iddepartamento = SelectedDepartamento.id;
            currentEntidad.nombreDepartamento = SelectedDepartamento.descripcion;
            currentEntidad.nombrePais = SelectedPais.descripcion;
            if (!(MunicipioModelo.FindTexto(currentEntidad)))
        {
            if (!string.IsNullOrEmpty(currentEntidad.descripcion))
            {
                if (currentEntidad.descripcion.Length <= maxDescripcion)
                {

                    if ((currentEntidad.id == 0))
                    {
                        //currentEntidad.id = DepartamentoModelo.IdAsignar();
                        if (MunicipioModelo.Insert(currentEntidad, true))
                        {
                                var controller = await dlg.ShowProgressAsync(this, "Registro insertado con éxito", "Este mensaje desaparecerá en 2 segundos", settings: configuracionDialogo);
                                controller.SetIndeterminate();
                                await TaskEx.Delay(1000);
                                await controller.CloseAsync();
                                ListaEntidad.Add(currentEntidad);
                            enviarMensaje();
                            controlVentana = controlVentana - 1;
                            CloseWindow();
                        }
                        else
                        {
                            await dlg.ShowMessageAsync(this, "No ha sido posible insertar el registro", "");
                        }
                        //}
                    }
                    //ListaEntidad.Add(CurrentEntidad);
                    else
                    {
                        //Caso de actualizacion
                        {
                            {
                                if (MunicipioModelo.UpdateModelo(currentEntidad, true))
                                {
                                        var controller = await dlg.ShowProgressAsync(this, "Registro actualizado con éxito", "Este mensaje desaparecerá en 1 segundo", settings: configuracionDialogo);
                                        controller.SetIndeterminate();
                                        await TaskEx.Delay(1000);
                                        await controller.CloseAsync();
                                        enviarMensaje();
                                    controlVentana = controlVentana - 1;
                                    CloseWindow();
                                }
                                else
                                {
                                    await dlg.ShowMessageAsync(this, "No ha sido posible actualizar el registro", "");
                                }
                            }
                        }
                    }
                }
                else
                {
                    //Maximo de 20
                    //Mensaje en caso de indice mayor
                    await dlg.ShowMessageAsync(this, "La descripcion excede el maximo permitido", "");
                }

            }
            else
            {
                await dlg.ShowMessageAsync(this, "Faltan datos requeridos verifique", "");
            }
                //Nuevo();
            }
            else
            {
                await dlg.ShowMessageAsync(this, "El registro ya existe con esa nombre en el mismo departamento", "");
            }
        }

        #endregion

        #region Mensajes

        //Procesando el mensaje recibido
        private bool ControlVentanaMensaje(CatalogoMensaje controlVentanaMensaje)
        {
            if (controlVentanaMensaje.mensaje == 0)
            {
                //Nuevo();
                return true;
            }
            else
            {
                CloseWindow();
                return false;
            }
        }

        public void enviarMensaje()
        {
            //Creando el mensaje de cierre
            VentanaViewMensaje cierre = new VentanaViewMensaje();
            cierre.mensaje = -1;
            Messenger.Default.Send<VentanaViewMensaje>(cierre);

        }
        #endregion

        #region Metodos de apoyo
        public bool HabilitarSelectionDepartamento
        {
            get
            {
                if (!(this.SelectedPais == null))
                {
                    listaDepartamento = new ObservableCollection<DepartamentoModelo>(DepartamentoModelo.GetAllByPais(SelectedPais.id)); ;
                    return (!(this.SelectedPais == null));
                }
                else
                    return false;
               
            }
        }
        public bool HabilitarMunicipio
        {
            get { return (!((this.SelectedPais == null)&& (this.SelectedDepartamento == null))); }
        }
        public bool CanSave()
        {
            bool evaluar = false;

            if (currentEntidad == null || SelectedDepartamento == null|| SelectedPais == null)
            {
                return evaluar;
            }
            else
            {
                evaluar = !string.IsNullOrEmpty(currentEntidad.descripcion) &&
                           (currentEntidad.descripcion.Length <= maxDescripcion) &&
                           ((SelectedPais != null)) &&
                           ((SelectedDepartamento != null));
                return evaluar;
            }
        }

        #endregion

        #endregion
        #region ViewModel Private Methods

        private void RegisterCommands()
        {
            GuardarCommand = new RelayCommand(Guardar, CanSave);
            CancelarCommand = new RelayCommand(Cancelar);
            OkCommand = new RelayCommand(Ok);
            SalirCommand = new RelayCommand(Salir);
            SelectionChangedCommand = new RelayCommand<MunicipioModelo>(entidad =>
            {
                if (entidad == null) return;
                currentEntidad = entidad;
            });
        }

        #endregion
    }
}
