using CapaDatos;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Cedulas;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Documentacion;
using SGPTWpf.Support;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace SGPTWpf.Model.Modelo.programas
{

    public class UniversalPTModelo : UIBase
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
        public static ObservableCollection<TablasPTModelo> GetAllTablas()
        {
            ObservableCollection<TablasPTModelo> lista = new ObservableCollection<TablasPTModelo>();
            lista = TablasPTModelo.GetAll();
            return lista;
        }

        public static string GetReferencia(string tabla, int? idGenerico)
        {
            string referencia = string.Empty;
            try
            {
                using (_context = new SGPTEntidades())
                {
                    #region seleccion
                    switch (tabla)
                    {
                        case "ACTIVIDADES":
                            break;
                        case "AGENDAS":
                            break;
                        case "ASIGNACIONES":
                            break;
                        case "BALANCES":
                            break;
                        case "BALANCESSUMARIAS":
                            break;
                        case "BITACORA":
                            break;
                        case "CATALOGOCUENTAS":
                            break;
                        case "CEDULACONTACTOS":
                            {
                               cedulacontacto registro = _context.cedulacontactos.Find(idGenerico);
                                referencia = registro.referenciapapel;
                            }
                            break;
                        case "CEDULACORRESPONDENCIAS":
                            {
                                cedulacorrespondencia registro = _context.cedulacorrespondencias.Find(idGenerico);
                                referencia = registro.referenciapapel;
                            }
                            break;
                        case "CEDULAREQUERIMIENTOS":
                            {
                                cedularequerimiento registro = _context.cedularequerimientos.Find(idGenerico);
                                referencia = registro.referenciapapel;
                            }
                            break;
                        case "CEDULAREUNIONES":
                            {
                                cedulareunione registro = _context.cedulareuniones.Find(idGenerico);
                                referencia = registro.referenciapapel;
                            }
                            break;
                        case "CEDULAS":
                            {
                                cedula registro = _context.cedulas.Find(idGenerico);
                                referencia = registro.referenciacedula;
                            }
                            break;
                        case "CEDULASLEGALES":
                            {
                                cedulaslegale registro = _context.cedulaslegales.Find(idGenerico);
                                referencia = registro.referenciapapel;
                            }
                            break;
                        case "CLASECUENTAS":
                            break;
                        case "CLASESBALANCE":
                            break;
                        case "CLASIFICACIONES":
                            break;
                        case "CLIENTES":
                            break;
                        case "CONEXIONES":
                            break;
                        case "CONFIRMACIONES":
                            break;
                        case "CONTACTOCLIENTE":
                            break;
                        case "CONTACTOS":
                            break;
                        case "CORREOS":
                            break;
                        case "CORRESPONDENCIAS":
                            break;
                        case "CORRESPONDENCIATIPOS":
                            break;
                        case "COSTOHISTORICOHORAS":
                            break;
                        case "CRONOGRAMAS":
                            break;
                        case "DEPARTAMENTOS":
                            break;
                        case "DESIGNACIONES":
                            break;
                        case "DETALLEBALANCES":
                            break;
                        case "DETALLECEDULAS":
                            break;
                        case "DETALLECONFIRMACIONES":
                            break;
                        case "DETALLECRONOGRAMAS":
                            break;
                        case "DETALLECUESTIONARIOS":
                            break;
                        case "DETALLEDOCUMENTOS":
                            break;
                        case "DETALLEHERRAMIENTAS":
                            break;
                        case "DETALLEMATRIZRIESGOS":
                            break;
                        case "DETALLEPLANTILLAINDICE":
                            break;
                        case "DETALLEPROGRAMAS":
                            break;
                        case "DETALLESMAF":
                            break;
                        case "DETALLETIEMPO":
                            break;
                        case "DETALLETITULO":
                            break;
                        case "DOCUMENTOS":
                            break;
                        case "ELEMENTOS":
                            break;
                        case "ENCARGOS":
                            break;
                        case "ESTRUCTURAESTADOFINANCIEROS":
                            break;
                        case "ESTRUCTURASORGANICAS":
                            break;
                        case "FIRMAS":
                            break;
                        case "FORMULAS":
                            break;
                        case "FORMULASAPLICADAS":
                            break;
                        case "HALLAZGOS":
                            {
                                cedula registro = _context.cedulas.Find(idGenerico);
                                referencia = registro.referenciacedula;
                            }
                            break;
                        case "HERRAMIENTAS":
                            break;
                        case "HISTORICOSCONTRASENIAS":
                            break;
                        case "INDICES":
                            break;
                        case "INFORMEACTIVIDADES":
                            break;
                        case "LEGALNORMAS":
                            break;
                        case "MARCASAUDITORIA":
                            break;
                        case "MARCASESTANDARES":
                            break;
                        case "MATERIALIDAD":
                            break;
                        case "MATRIZANALISISFINANCIERO":
                            break;
                        case "MATRIZRIESGOS":
                            {
                                matrizriesgo registro = _context.matrizriesgos.Find(idGenerico);
                                referencia = registro.referenciamr;
                            }
                        break;
                        case "MONEDAS":
                            break;
                        case "MOVIMIENTOS":
                            {
                                cedula registro = _context.cedulas.Find(idGenerico);
                                referencia = registro.referenciacedula;
                            }
                            break;
                        case "MUNICIPIOS":
                            break;
                        case "NORMATIVAS":
                            break;
                        case "NOTASCONFIRMACIONES":
                            break;
                        case "NOTASPT":
                            {
                                cedula registro = _context.cedulas.Find(idGenerico);
                                referencia = registro.referenciacedula;
                            }
                            break;
                        case "OBLIGACIONESLEGALES":
                            break;
                        case "OPCIONESROLES":
                            break;
                        case "PAISES":
                            break;
                        case "PAPELES":
                            break;
                        case "PARTIDAS":
                            break;
                        case "PERIODOS":
                            break;
                        case "PERMISOSROLESUSUARIOS":
                            break;
                        case "PERSONAS":
                            break;
                        case "PISTAS":
                            break;
                        case "PLANTILLAINDICE":
                            break;
                        case "PLANTILLAS":
                            break;
                        case "PROCESOSAUDITORIA":
                            break;
                        case "PROGRAMAS":
                            {
                                programa registro = _context.programas.Find(idGenerico);
                                referencia = registro.referenciaprograma;
                            }
                            break;
                        case "CUESTIONARIOS":
                            {
                                programa registro = _context.programas.Find(idGenerico);
                                referencia = registro.referenciaprograma;
                            }
                            break;
                        case "RATIOS":
                            break;
                        case "RAZONES":
                            break;
                        case "REPOSITORIO":
                            {
                                repositorio registro = _context.repositorios.Find(idGenerico);
                                referencia = registro.referenciarepositorio;
                            }
                            break;
                        case "REQUERIMIENTOS":
                            break;
                        case "REUNIONES":
                            break;
                        case "ROLES":
                            break;
                        case "SIMBOLOS":
                            break;
                        case "SISTEMASCONTABLES":
                            break;
                        case "TELEFONOS":
                            break;
                        case "TIPOCARPETA":
                            break;
                        case "TIPOCONFIRMACIONES":
                            break;
                        case "TIPOELEMENTOINDICE":
                            break;
                        case "TIPOPARTIDAS":
                            break;
                        case "TIPOPROCEDIMIENTO":
                            break;
                        case "TIPORESPUESTACUESTIONARIO":
                            break;
                        case "TIPOSAUDITORIA":
                            break;
                        case "TIPOSCEDULAS":
                            break;
                        case "TIPOSDESCRIPTORES":
                            break;
                        case "TIPOSHERRAMIENTAS":
                            break;
                        case "TIPOSPROGRAMA":
                            break;
                        case "TIPOSTELEFONOS":
                            break;
                        case "TITULOS":
                            break;
                        case "USUARIOAGENDAACCION":
                            break;
                        case "USUARIOHERRAMIENTASACCION":
                            break;
                        case "USUARIOMATANALISFINANCACCION":
                            break;
                        case "USUARIOPROGRAMASACCION":
                            break;
                        case "USUARIOREPOSITORIOACCION":
                            break;
                        case "USUARIOREQUERIMIENTOSACCION":
                            break;
                        case "USUARIOS":
                            break;
                        case "USUARIOSUMARIASACCION":
                            break;
                        case "VISITAS":
                            break;

                    }
                    #endregion fin seleccion
                }
                if (string.IsNullOrEmpty(referencia))
                {
                    referencia = "Pendiente";
                }
                return referencia;
            }
            catch (Exception e)
            {
                MessageBox.Show("No fue posible la elaboracion del detalle\n" + e);
                return referencia ="-1";
            }
        }
        public static ObservableCollection<UniversalPTModelo> GetAllContenido(int? idEncargo)
        {
            string commandString = string.Empty;
            ObservableCollection<UniversalPTModelo> lista = new ObservableCollection<UniversalPTModelo>();
            //Lista de tablas a recorrerre
            ObservableCollection<TablasPTModelo> listaTablas = TablasPTModelo.GetAll();
            UniversalPTModelo temporalItem = new UniversalPTModelo();
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
                                            temporalItem = new UniversalPTModelo();
                                            temporalItem.idUpt = i;
                                            temporalItem.descripionUpt = "Evaluación de riesgo del " + papel.fechaevaluacionmr;
                                            temporalItem.idOrigenUpt = papel.idmr; //Almacena el id de la tabla origen
                                            temporalItem.referenciaTpt = papel.referenciamr;
                                            temporalItem.codOrigenUpt = item.idTpt; //Almacena el codigo para las tablas origen
                                            temporalItem.tablaUpt = item.tablaTpt; //Tabla de la que proviene los datos
                                            temporalItem.vistaUpt = item.vistaTpt; //vista de la que proviene los datos
                                            temporalItem.controladorUpt = item.controladorTpt; //controlador de la que proviene los datos
                                            temporalItem.nombreMostrarTpt = item.nombreMostrarTpt;
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
                                            temporalItem = new UniversalPTModelo();
                                            temporalItem.idUpt = i;
                                            temporalItem.descripionUpt = papel.nombrepapeles;
                                            temporalItem.idOrigenUpt = papel.idpapeles; //Almacena el id de la tabla origen
                                            temporalItem.referenciaTpt = papel.referenciapapeles;
                                            temporalItem.codOrigenUpt = item.idTpt; //Almacena el codigo para las tablas origen
                                            temporalItem.tablaUpt = item.tablaTpt; //Tabla de la que proviene los datos
                                            temporalItem.vistaUpt = item.vistaTpt; //vista de la que proviene los datos
                                            temporalItem.controladorUpt = item.controladorTpt; //controlador de la que proviene los datos
                                            temporalItem.nombreMostrarTpt = item.nombreMostrarTpt;
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
                                            temporalItem = new UniversalPTModelo();
                                            temporalItem.idUpt = i;
                                            temporalItem.descripionUpt = papel.descripcionmaf;
                                            temporalItem.idOrigenUpt = papel.idmaf; //Almacena el id de la tabla origen
                                            temporalItem.referenciaTpt = papel.referenciamaf;
                                            temporalItem.codOrigenUpt = item.idTpt; //Almacena el codigo para las tablas origen
                                            temporalItem.tablaUpt = item.tablaTpt; //Tabla de la que proviene los datos
                                            temporalItem.vistaUpt = item.vistaTpt; //vista de la que proviene los datos
                                            temporalItem.controladorUpt = item.controladorTpt; //controlador de la que proviene los datos
                                            temporalItem.nombreMostrarTpt = item.nombreMostrarTpt;
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
                                            temporalItem = new UniversalPTModelo();
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

                                        for (int p=0;p<listaRepositorio.Count();p++)
                                        {
                                            temporalItem = new UniversalPTModelo();
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
                                            temporalItem = new UniversalPTModelo();
                                            temporalItem.idUpt = i;
                                            temporalItem.descripionUpt = temporalCed[p].titulocedula;
                                            temporalItem.idOrigenUpt = temporalCed[p].idcedula; //Almacena el id de la tabla origen
                                            temporalItem.referenciaTpt = temporalCed[p].referenciacedula;
                                            temporalItem.codOrigenUpt = item.idTpt; //Almacena el codigo para las tablas origen
                                            temporalItem.tablaUpt = item.tablaTpt; //Tabla de la que proviene los datos
                                            temporalItem.vistaUpt = item.vistaTpt; //vista de la que proviene los datos
                                            temporalItem.controladorUpt = item.controladorTpt; //controlador de la que proviene los datos
                                            temporalItem.nombreMostrarTpt = temporalCed[p].titulocedula;
                                            lista.Add(temporalItem);
                                            i++;
                                        }
                                    }
                                    break;
                                case 7:
                                    break;
                            }
                        }
                        return lista;
                    }

                }
                catch (Exception e)
                {
                    MessageBox.Show("No fue posible la elaboracion del detalle\n" + e);
                    return new ObservableCollection<UniversalPTModelo>();
                }
            }
            else
            {
                return new ObservableCollection<UniversalPTModelo>();
            }
        }

        #endregion

        #region Filtro
        public UniversalPTModelo()
        {
            idUpt = 0;
            descripionUpt = string.Empty;
            idOrigenUpt = 0;//Almacena el id de la tabla origen
            codOrigenUpt = 0; //Almacena el codigo para las tablas origen
            tablaUpt =string.Empty ; //Tabla de la que proviene los datos
            vistaUpt = string.Empty; //vista de la que proviene los datos
            controladorUpt = string.Empty; //controlador de la que proviene los datos
            nombreMostrarTpt = string.Empty;
            referenciaTpt = string.Empty;
        }

        #endregion
    }
}
