using CapaDatos;
using SGPTWpf.Model;
using SGPTWpf.Model.Modelo.programas;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Documentacion;
using SGPTWpf.Support;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Cierre
{

    public class UniversalPT : UIBase
    {
        #region Model Attributes

        private static SGPTEntidades _context;

        #endregion

        public int idUpt//correlativo que servirá como id
        {
            get { return GetValue(() => idUpt); }
            set { SetValue(() => idUpt, value); }
        }
        public string descripionUpt //Descripcion de la tabla origen
        {
            get { return GetValue(() => descripionUpt); }
            set { SetValue(() => descripionUpt, value); }
        }
        public int idOrigenUpt //Almacena el id de la tabla origen
        {
            get { return GetValue(() => idOrigenUpt); }
            set { SetValue(() => idOrigenUpt, value); }
        }

        public int codOrigenUpt //Almacena el codigo para las tablas origen
        {
            get { return GetValue(() => codOrigenUpt); }
            set { SetValue(() => codOrigenUpt, value); }
        }
        #region Public Model Methods

        public string tablaUpt //Tabla de la que proviene los datos
        {
            get { return GetValue(() => tablaUpt); }
            set { SetValue(() => tablaUpt, value); }
        }
        public string vistaUpt //vista de la que proviene los datos
        {
            get { return GetValue(() => vistaUpt); }
            set { SetValue(() => vistaUpt, value); }
        }
        public string controladorUpt //controlador de la que proviene los datos
        {
            get { return GetValue(() => controladorUpt); }
            set { SetValue(() => controladorUpt, value); }
        }
        public virtual TablasPTModelo tablasPtModelo //controlador de la que proviene los datos
        {
            get { return GetValue(() => tablasPtModelo); }
            set { SetValue(() => tablasPtModelo, value); }
        }
        public string nombreMostrarTpt //Nombre a presentar al usuario
        {
            get { return GetValue(() => nombreMostrarTpt); }
            set { SetValue(() => nombreMostrarTpt, value); }
        }
        public string comentarioTpt //Nombre a presentar al usuario
        {
            get { return GetValue(() => comentarioTpt); }
            set { SetValue(() => comentarioTpt, value); }
        }
        public string referenciaTpt //Nombre a presentar al usuario
        {
            get { return GetValue(() => referenciaTpt); }
            set { SetValue(() => referenciaTpt, value); }
        }

        public string usuarioaprobo
        {
            get { return GetValue(() => usuarioaprobo); }
            set { SetValue(() => usuarioaprobo, value); }
        }

        public string usuariosuperviso
        {
            get { return GetValue(() => usuariosuperviso); }
            set { SetValue(() => usuariosuperviso, value); }
        }

        public string usuariocerro
        {
            get { return GetValue(() => usuariocerro); }
            set { SetValue(() => usuariocerro, value); }
        }
        public string fechacierre
        {
            get { return GetValue(() => fechacierre); }
            set { SetValue(() => fechacierre, value); }
        }
        public string fechasupervision
        {
            get { return GetValue(() => fechasupervision); }
            set { SetValue(() => fechasupervision, value); }
        }
        public string fechaaprobacion
        {
            get { return GetValue(() => fechaaprobacion); }
            set { SetValue(() => fechaaprobacion, value); }
        }
        public string etapapapel
        {
            get { return GetValue(() => etapapapel); }
            set { SetValue(() => etapapapel, value); }
        }
        public int? idencargo
        {
            get { return GetValue(() => idencargo); }
            set { SetValue(() => idencargo, value); }
        }

        #region usuarioModelo

        public UsuarioModelo _usuarioModelo;
        public UsuarioModelo usuarioModelo
        {
            get { return _usuarioModelo; }
            set { _usuarioModelo = value; }
        }
        public bool IsSelected
        {
            get { return GetValue(() => IsSelected); }
            set { SetValue(() => IsSelected, value); }
        }
        public int idTpt//correlativo que servirá como id
        {
            get { return GetValue(() => idTpt); }
            set { SetValue(() => idTpt, value); }
        }

        #endregion
        public static ObservableCollection<TablasPTModelo> GetAllTablas()
        {
            ObservableCollection<TablasPTModelo> lista = new ObservableCollection<TablasPTModelo>();
            lista = TablasPTModelo.GetAll();
            return lista;
        }

        public static ObservableCollection<UniversalPT> GetAllContenido(int? idEncargo, UsuarioModelo usuario)
        {
            string commandString = string.Empty;
            ObservableCollection<UniversalPT> lista = new ObservableCollection<UniversalPT>();
            //Lista de tablas a recorrerre
            ObservableCollection<TablasPTModelo> listaTablas = TablasPTModelo.GetAll();
            UniversalPT temporalItem = new UniversalPT();
            temporalItem.idencargo = idEncargo;
            temporalItem.usuarioModelo = usuario;
            temporalItem.IsSelected = false;
            int i = 1;
            if (idEncargo != null && idEncargo != 0)
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {

                        foreach (TablasPTModelo item in listaTablas)
                        {
                            //Recorrer y obtener los valores  del encargo
                            switch (item.idTpt)
                            {
                                case 0:
                                    break;
                                case 1:
                                    //Por no estar la matriz de  riesgo
                                    commandString = String.Format("SELECT * FROM sgpt.matrizriesgos WHERE idencargo={0} AND estadomr = 'A' ORDER BY idmr;", idEncargo);
                                    var listaMr = _context.matrizriesgos.SqlQuery(commandString);
                                    //var lista = _context.catalogocuentas.Where(entidad => (entidad.idsc == idSc && entidad.estadocc == "A"));
                                    ObservableCollection<matrizriesgo> temporal = new ObservableCollection<matrizriesgo>(listaMr);
                                    if (temporal.Count > 0)
                                    {
                                        foreach (matrizriesgo papel in temporal)
                                        {
                                            temporalItem = new UniversalPT();
                                            temporalItem.idUpt = i;
                                            temporalItem.descripionUpt = "Evaluación de riesgo del " + papel.fechaevaluacionmr;
                                            temporalItem.idOrigenUpt = papel.idmr; //Almacena el id de la tabla origen
                                            temporalItem.referenciaTpt = papel.referenciamr;
                                            temporalItem.codOrigenUpt = item.idTpt; //Almacena el codigo para las tablas origen
                                            temporalItem.tablaUpt = item.tablaTpt; //Tabla de la que proviene los datos
                                            temporalItem.vistaUpt = item.vistaTpt; //vista de la que proviene los datos
                                            temporalItem.controladorUpt = item.controladorTpt; //controlador de la que proviene los datos
                                            temporalItem.nombreMostrarTpt = item.nombreMostrarTpt;
                                            temporalItem.idTpt = item.idTpt;

                                            temporalItem.usuarioaprobo = papel.usuarioaprobo;
                                            temporalItem.usuariocerro = papel.usuariocerro;
                                            temporalItem.usuariosuperviso = papel.usuariosuperviso;

                                            temporalItem.fechaaprobacion = papel.fechaaprobacion;
                                            temporalItem.fechacierre = papel.fechacierre;
                                            temporalItem.fechasupervision = papel.fechasupervision;
                                            
                                            temporalItem.etapapapel = papel.etapapapel;
                                            if (temporalItem.etapapapel != null && temporalItem.etapapapel != "")
                                            {
                                                temporalItem.etapapapel = EtapaProgramaModelo.nombreEtapa(temporalItem.etapapapel);
                                            }
                                            lista.Add(temporalItem);
                                            i++;
                                        }
                                    }
                                    break;
                                case 2:
                                    commandString = String.Format("SELECT * FROM sgpt.papeles WHERE idencargopapeles={0} AND estadopapeles = 'A' ORDER BY idpapeles;", idEncargo);
                                    var listaPapeles = _context.papeles.SqlQuery(commandString);
                                    //var lista = _context.catalogocuentas.Where(entidad => (entidad.idsc == idSc && entidad.estadocc == "A"));
                                    ObservableCollection<papele> temporalP = new ObservableCollection<papele>(listaPapeles);
                                    if (temporalP.Count > 0)
                                    {
                                        foreach (papele papel in temporalP)
                                        {
                                            temporalItem = new UniversalPT();
                                            temporalItem.idUpt = i;
                                            temporalItem.descripionUpt = papel.nombrepapeles;
                                            temporalItem.idOrigenUpt = papel.idpapeles; //Almacena el id de la tabla origen
                                            temporalItem.referenciaTpt = papel.referenciapapeles;
                                            temporalItem.codOrigenUpt = item.idTpt; //Almacena el codigo para las tablas origen
                                            temporalItem.tablaUpt = item.tablaTpt; //Tabla de la que proviene los datos
                                            temporalItem.vistaUpt = item.vistaTpt; //vista de la que proviene los datos
                                            temporalItem.controladorUpt = item.controladorTpt; //controlador de la que proviene los datos
                                            temporalItem.nombreMostrarTpt = item.nombreMostrarTpt;
                                            temporalItem.idTpt = item.idTpt;

                                            temporalItem.usuarioaprobo = papel.usuarioaprobo;
                                            temporalItem.usuariocerro = papel.usuariocerro;
                                            temporalItem.usuariosuperviso = papel.usuariosuperviso;

                                            temporalItem.fechaaprobacion = papel.fechaaprobacion;
                                            temporalItem.fechacierre = papel.fechacierre;
                                            temporalItem.fechasupervision = papel.fechasupervision;
                                            temporalItem.etapapapel = papel.etapapapel;
                                            if (temporalItem.etapapapel != null && temporalItem.etapapapel != "")
                                            {
                                                temporalItem.etapapapel = EtapaProgramaModelo.nombreEtapa(temporalItem.etapapapel);
                                            }
                                            lista.Add(temporalItem);
                                            i++;
                                        }
                                    }
                                    break;
                                case 3:
                                    commandString = String.Format("SELECT * FROM sgpt.matrizanalisisfinanciero WHERE idencargo={0} AND estadomaf = 'A' ORDER BY idmaf;", idEncargo);
                                    var listaMaf = _context.matrizanalisisfinancieroes.SqlQuery(commandString);
                                    //var lista = _context.catalogocuentas.Where(entidad => (entidad.idsc == idSc && entidad.estadocc == "A"));
                                    ObservableCollection<matrizanalisisfinanciero> temporalMaf = new ObservableCollection<matrizanalisisfinanciero>(listaMaf);
                                    if (temporalMaf.Count > 0)
                                    {
                                        foreach (matrizanalisisfinanciero papel in temporalMaf)
                                        {
                                            temporalItem = new UniversalPT();
                                            temporalItem.idUpt = i;
                                            temporalItem.descripionUpt = papel.descripcionmaf;
                                            temporalItem.idOrigenUpt = papel.idmaf; //Almacena el id de la tabla origen
                                            temporalItem.referenciaTpt = papel.referenciamaf;
                                            temporalItem.codOrigenUpt = item.idTpt; //Almacena el codigo para las tablas origen
                                            temporalItem.tablaUpt = item.tablaTpt; //Tabla de la que proviene los datos
                                            temporalItem.vistaUpt = item.vistaTpt; //vista de la que proviene los datos
                                            temporalItem.controladorUpt = item.controladorTpt; //controlador de la que proviene los datos
                                            temporalItem.nombreMostrarTpt = item.nombreMostrarTpt;
                                            temporalItem.idTpt = item.idTpt;

                                            temporalItem.usuarioaprobo = papel.usuarioaprobo;
                                            temporalItem.usuariocerro = papel.usuariocerro;
                                            temporalItem.usuariosuperviso = papel.usuariosuperviso;

                                            temporalItem.fechaaprobacion = papel.fechaaprobacion;
                                            temporalItem.fechacierre = papel.fechacierre;
                                            temporalItem.fechasupervision = papel.fechasupervision;
                                            temporalItem.etapapapel = papel.etapapapel;
                                            if (temporalItem.etapapapel != null && temporalItem.etapapapel != "")
                                            {
                                                temporalItem.etapapapel = EtapaProgramaModelo.nombreEtapa(temporalItem.etapapapel);
                                            }
                                            lista.Add(temporalItem);
                                            i++;
                                        }
                                    }
                                    break;
                                case 4://Programas
                                    commandString = String.Format("SELECT * FROM sgpt.programas WHERE idencargoprograma={0} AND estadoprograma = 'A' ORDER BY idprograma;", idEncargo);
                                    var listaProgramas = _context.programas.SqlQuery(commandString);
                                    //var lista = _context.catalogocuentas.Where(entidad => (entidad.idsc == idSc && entidad.estadocc == "A"));
                                    ObservableCollection<programa> temporalProg = new ObservableCollection<programa>(listaProgramas);
                                    if (temporalProg.Count > 0)
                                    {
                                        foreach (programa papel in temporalProg)
                                        {
                                            temporalItem = new UniversalPT();
                                            temporalItem.idUpt = i;
                                            temporalItem.descripionUpt = papel.nombreprograma;
                                            temporalItem.idOrigenUpt = papel.idprograma; //Almacena el id de la tabla origen
                                            temporalItem.referenciaTpt = papel.referenciaprograma;
                                            temporalItem.codOrigenUpt = item.idTpt; //Almacena el codigo para las tablas origen
                                            temporalItem.tablaUpt = item.tablaTpt; //Tabla de la que proviene los datos
                                            temporalItem.vistaUpt = item.vistaTpt; //vista de la que proviene los datos
                                            temporalItem.controladorUpt = item.controladorTpt; //controlador de la que proviene los datos
                                            if (papel.idthprograma == 1)
                                            {
                                                temporalItem.nombreMostrarTpt = "Programa";
                                            }
                                            else
                                            {
                                                temporalItem.nombreMostrarTpt = "Cuestionario";
                                            };

                                            temporalItem.idTpt = item.idTpt;

                                            temporalItem.usuarioaprobo = papel.usuarioaprobo;
                                            temporalItem.usuariocerro = papel.usuariocerro;
                                            temporalItem.usuariosuperviso = papel.usuariosuperviso;

                                            temporalItem.fechaaprobacion = papel.fechaaprobacion;
                                            temporalItem.fechacierre = papel.fechacierre;
                                            temporalItem.fechasupervision = papel.fechasupervision;
                                            temporalItem.etapapapel = papel.etapaprograma;
                                            if (temporalItem.etapapapel != null && temporalItem.etapapapel != "")
                                            {
                                                temporalItem.etapapapel = EtapaProgramaModelo.nombreEtapa(temporalItem.etapapapel);
                                            }
                                            lista.Add(temporalItem);
                                            i++;
                                        }
                                    }
                                    break;
                                case 5://Repositorio
                                    ObservableCollection<RepositorioModelo> listaRepositorio = RepositorioModelo.GetAllReferenciacion(idEncargo);

                                    //ObservableCollection<RepositorioModelo> listaRepositorio =new ObservableCollection<RepositorioModelo>(RepositorioModelo.GetAllEncabezado(idEncargo));
                                    if (listaRepositorio.Count > 0)
                                    {

                                        for (int p = 0; p < listaRepositorio.Count(); p++)
                                        {
                                            temporalItem = new UniversalPT();
                                            temporalItem.idUpt = i;
                                            temporalItem.descripionUpt = listaRepositorio[p].nombrerepositorio;
                                            temporalItem.idOrigenUpt = listaRepositorio[p].idrepositorio; //Almacena el id de la tabla origen
                                            temporalItem.referenciaTpt = listaRepositorio[p].referenciarepositorio;
                                            temporalItem.codOrigenUpt = item.idTpt; //Almacena el codigo para las tablas origen
                                            temporalItem.tablaUpt = item.tablaTpt; //Tabla de la que proviene los datos
                                            temporalItem.vistaUpt = item.vistaTpt; //vista de la que proviene los datos
                                            temporalItem.controladorUpt = item.controladorTpt; //controlador de la que proviene los datos
                                            //temporalItem.nombreMostrarTpt = "Documentos";
                                            temporalItem.nombreMostrarTpt = listaRepositorio[p].descripciondocumento;
                                            temporalItem.idTpt = item.idTpt;

                                            temporalItem.usuarioaprobo = listaRepositorio[p].usuarioaprobo;
                                            temporalItem.usuariocerro = listaRepositorio[p].usuariocerro;
                                            temporalItem.usuariosuperviso = listaRepositorio[p].usuariosuperviso;

                                            temporalItem.fechaaprobacion = listaRepositorio[p].fechaaprobacion;
                                            temporalItem.fechacierre = listaRepositorio[p].fechacierre;
                                            temporalItem.fechasupervision = listaRepositorio[p].fechasupervision;
                                            temporalItem.etapapapel = listaRepositorio[p].etapapapel;
                                            if (temporalItem.etapapapel != null && temporalItem.etapapapel != "")
                                            {
                                                temporalItem.etapapapel = EtapaProgramaModelo.nombreEtapa(temporalItem.etapapapel);
                                            }
                                            lista.Add(temporalItem);
                                            i++;
                                        }
                                    }
                                    break;
                                case 6:
                                    commandString = String.Format("SELECT * FROM sgpt.cedulas WHERE idencargo={0} AND estadocedula = 'A' ORDER BY idcedula;", idEncargo);
                                    var listaCedulas = _context.cedulas.SqlQuery(commandString);
                                    //var lista = _context.catalogocuentas.Where(entidad => (entidad.idsc == idSc && entidad.estadocc == "A"));
                                    ObservableCollection<cedula> temporalCed = new ObservableCollection<cedula>(listaCedulas);
                                    if (temporalCed.Count > 0)
                                    {

                                        for (int p = 0; p < temporalCed.Count(); p++)
                                        {
                                            temporalItem = new UniversalPT();
                                            temporalItem.idUpt = i;
                                            temporalItem.descripionUpt = temporalCed[p].titulocedula;
                                            temporalItem.idOrigenUpt = temporalCed[p].idcedula; //Almacena el id de la tabla origen
                                            temporalItem.referenciaTpt = temporalCed[p].referenciacedula;
                                            temporalItem.codOrigenUpt = item.idTpt; //Almacena el codigo para las tablas origen
                                            temporalItem.tablaUpt = item.tablaTpt; //Tabla de la que proviene los datos
                                            temporalItem.vistaUpt = item.vistaTpt; //vista de la que proviene los datos
                                            temporalItem.controladorUpt = item.controladorTpt; //controlador de la que proviene los datos
                                            temporalItem.nombreMostrarTpt = "Cédula";

                                            temporalItem.idTpt = item.idTpt;

                                            temporalItem.usuarioaprobo = temporalCed[p].usuarioaprobo;
                                            temporalItem.usuariocerro = temporalCed[p].usuariocerro;
                                            temporalItem.usuariosuperviso = temporalCed[p].usuariosuperviso;

                                            temporalItem.fechaaprobacion = temporalCed[p].fechaaprobacion;
                                            temporalItem.fechacierre = temporalCed[p].fechacierre;
                                            temporalItem.fechasupervision = temporalCed[p].fechasupervision;
                                            temporalItem.etapapapel = temporalCed[p].etapapapel;
                                            if (temporalItem.etapapapel != null && temporalItem.etapapapel != "")
                                            {
                                                temporalItem.etapapapel = EtapaProgramaModelo.nombreEtapa(temporalItem.etapapapel);
                                            }
                                            lista.Add(temporalItem);
                                            i++;
                                        }
                                    }
                                    break;
                                case 7:
                                    commandString = String.Format("SELECT * FROM sgpt.tipocarpeta WHERE idencargotc={0} AND estadotc = 'A' ORDER BY idencargotc;", idEncargo);
                                    var listaCarpetas = _context.tipocarpetas.SqlQuery(commandString);
                                    //var lista = _context.catalogocuentas.Where(entidad => (entidad.idsc == idSc && entidad.estadocc == "A"));
                                    ObservableCollection<tipocarpeta> temporaTC = new ObservableCollection<tipocarpeta>(listaCarpetas);
                                    if (temporaTC.Count > 0)
                                    {
                                        foreach (tipocarpeta papel in temporaTC)
                                        {
                                            temporalItem = new UniversalPT();
                                            temporalItem.idUpt = i;
                                            temporalItem.descripionUpt = papel.descripciontc;
                                            temporalItem.idOrigenUpt = papel.idtc; //Almacena el id de la tabla origen
                                            temporalItem.referenciaTpt = papel.descripciontc;
                                            temporalItem.codOrigenUpt = item.idTpt; //Almacena el codigo para las tablas origen
                                            temporalItem.tablaUpt = item.tablaTpt; //Tabla de la que proviene los datos
                                            temporalItem.vistaUpt = item.vistaTpt; //vista de la que proviene los datos
                                            temporalItem.controladorUpt = item.controladorTpt; //controlador de la que proviene los datos
                                            temporalItem.nombreMostrarTpt = item.nombreMostrarTpt;

                                            temporalItem.idTpt = item.idTpt;

                                            temporalItem.usuarioaprobo = papel.usuarioaprobo;
                                            temporalItem.usuariocerro = papel.usuariocerro;
                                            temporalItem.usuariosuperviso = papel.usuariosuperviso;

                                            temporalItem.fechaaprobacion = papel.fechaaprobacion;
                                            temporalItem.fechacierre = papel.fechacierre;
                                            temporalItem.fechasupervision = papel.fechasupervision;
                                            temporalItem.etapapapel = papel.etapapapel;
                                            if (temporalItem.etapapapel != null && temporalItem.etapapapel != "")
                                            {
                                                temporalItem.etapapapel = EtapaProgramaModelo.nombreEtapa(temporalItem.etapapapel);
                                            }
                                            lista.Add(temporalItem);
                                            i++;
                                        }
                                    }
                                    break;
                            }
                        }
                        return lista;
                    }

                }
                catch (Exception e)
                {
                    //Captura de fallo en la insercion
                    if (e.Source != null)
                        MessageBox.Show("No fue posible la elaboracion del detalle\n" + e);
                    return new ObservableCollection<UniversalPT>();
                }
            }
            else
            {
                return new ObservableCollection<UniversalPT>();
            }
        }

        #endregion

        #region Filtro
        public UniversalPT()
        {
            idUpt = 0;
            descripionUpt = string.Empty;
            idOrigenUpt = 0;//Almacena el id de la tabla origen
            codOrigenUpt = 0; //Almacena el codigo para las tablas origen
            tablaUpt = string.Empty; //Tabla de la que proviene los datos
            vistaUpt = string.Empty; //vista de la que proviene los datos
            controladorUpt = string.Empty; //controlador de la que proviene los datos
            nombreMostrarTpt = string.Empty;
            referenciaTpt = string.Empty;
            usuarioaprobo = string.Empty;
            usuariocerro = string.Empty;
            usuariosuperviso = string.Empty;

            fechaaprobacion = string.Empty;
            fechacierre = string.Empty;
            fechasupervision = string.Empty;
            etapapapel = string.Empty;
        }

        #endregion
    }
}
