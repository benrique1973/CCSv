using CapaDatos;
using SGPTWpf.SGPtWpf.Support.Validaciones.Atributos;
using SGPTWpf.SGPtWpf.Support.Validaciones.Metodos;
using SGPTWpf.Support;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Windows;

namespace SGPTWpf.Model.Modelo.Encargos
{
    public class ClienteModelo: UIBase
    {
        #region Model Attributes

        private static SGPTEntidades _context;

        #endregion

        #region Model Properties

        public static bool sincronizar { get; set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Nit de cliente")]
        public string idnitcliente
        {
            get { return GetValue(() => idnitcliente); }
            set { SetValue(() => idnitcliente, value); }
        }

        public int? idclasificacion
        {
            get { return GetValue(() => idclasificacion); }
            set { SetValue(() => idclasificacion, value); }
        }

        public int idpais
        {
            get { return GetValue(() => idpais); }
            set { SetValue(() => idpais, value); }
        }

        public string idcodigoactividad
        {
            get { return GetValue(() => idcodigoactividad); }
            set { SetValue(() => idcodigoactividad, value); }
        }

        public Nullable<int> idsc
        {
            get { return GetValue(() => idsc); }
            set { SetValue(() => idsc, value); }
        }

        public Nullable<int> iddepartamento
        {
            get { return GetValue(() => iddepartamento); }
            set { SetValue(() => iddepartamento, value); }
        }

        public Nullable<int> idmunicipio
        {
            get { return GetValue(() => idmunicipio); }
            set { SetValue(() => idmunicipio, value); }
        }

        [DisplayName("Razon social del cliente")]
        [Required(ErrorMessage = "Dato requerido")]
        [MaxLength(40, ErrorMessage = "Excede de 40 caracteres permitidos")]
        [ExcludeChar("^Ç", ErrorMessage = "La razón social contiene símbolos inválidos")]
        public string razonsocialcliente 
        {
            get { return GetValue(() => razonsocialcliente ); }
            set { SetValue(() => razonsocialcliente , value); }
        }

        public string nrccliente
        {
            get { return GetValue(() => nrccliente); }
            set { SetValue(() => nrccliente, value); }
        }

        public string direccioncliente
        {
            get { return GetValue(() => direccioncliente); }
            set { SetValue(() => direccioncliente, value); }
        }

        public string actividadcliente
        {
            get { return GetValue(() => actividadcliente); }
            set { SetValue(() => actividadcliente, value); }
        }

        public string paginawebcliente
        {
            get { return GetValue(() => paginawebcliente); }
            set { SetValue(() => paginawebcliente, value); }
        }

        [DisplayName("Fecha de creación")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true),
        Required(ErrorMessage = "Formato de fecha incorrecto")]
        [Range(typeof(DateTime), "1/1/1970", "31/12/2050",
        ErrorMessage = "El valor {0} debe estar entre  {1} y {2}")]
        [RegularExpression(@"^(?:3[01]|[12][0-9]|0?[1-9])([\-/.])(0?[1-9]|1[1-2])\1\d{4}$", ErrorMessage = "Deben ser números del formado dd-mm-aaaa")]
        public string fechaconstitucioncliente
        {
            get { return GetValue(() => fechaconstitucioncliente); }
            set { SetValue(() => fechaconstitucioncliente, value); }
        }


        public string estadocliente
        {
            get { return GetValue(() => estadocliente); }
            set { SetValue(() => estadocliente, value); }
        }

        // Entidades relacionadas

        public virtual ActividadModelo actividadModelo
        {
            get { return GetValue(() => actividadModelo); }
            set { SetValue(() => actividadModelo, value); }
        }

        public virtual ClasificacionModelo clasificacionModelo
        {
            get { return GetValue(() => clasificacionModelo); }
            set { SetValue(() => clasificacionModelo, value); }
        }

        public virtual PaisModelo paisModelo
        {
            get { return GetValue(() => paisModelo); }
            set { SetValue(() => paisModelo, value); }
        }

        public virtual DepartamentoModelo departamentoModelo
        {
            get { return GetValue(() => departamentoModelo); }
            set { SetValue(() => departamentoModelo, value); }
        }

        public virtual MunicipioModelo municipioModelo
        {
            get { return GetValue(() => municipioModelo); }
            set { SetValue(() => municipioModelo, value); }
        }

        #endregion

        #region Public Model Methods


        public static bool Insert(ClienteModelo modelo)
        {
            throw new NotImplementedException();
        }

        public static string Insert(ClienteModelo modelo, bool valor)
        {
            throw new NotImplementedException();
        }

        //Devuelve el registro buscado con base al indice
        public static ClienteModelo Find(int id)
        {
            throw new NotImplementedException();
        }

        //Devuelve un booleano de éxito en caso de realizarse la eliminacion

        public static ClienteModelo Find(string id)
        {
            throw new NotImplementedException();
        }

        public static bool FindPK(string id)
        {
            throw new NotImplementedException();
        }

        //Devuelve un booleano de éxito en caso de realizarse la eliminacion

        #endregion

        public static bool FindPK(int id)
        {
            throw new NotImplementedException();
        }
        //Para realizar busquedas de texto
        public static List<ClienteModelo> GetAllPkContenido(string texto)
        {

            using (_context = new SGPTEntidades())
            {
                string Texto = texto.ToUpper();
                return _context.clientes.Select(entidad =>
                new ClienteModelo
                {
                    idnitcliente = entidad.idnitcliente,
                    idclasificacion = entidad.idclasificacion,
                    idpais = entidad.idpais,
                    idcodigoactividad = entidad.idcodigoactividad,
                    idsc = entidad.idsc,
                    iddepartamento = entidad.iddepartamento,
                    idmunicipio = entidad.idmunicipio,
                    razonsocialcliente = entidad.razonsocialcliente,
                    nrccliente = entidad.nrccliente,
                    direccioncliente = entidad.direccioncliente,
                    actividadcliente = entidad.actividadcliente,
                    paginawebcliente = entidad.paginawebcliente,
                    fechaconstitucioncliente = entidad.fechaconstitucioncliente,
                    estadocliente = entidad.estadocliente,
                    //Carga de  entidades
                    actividadModelo = new ActividadModelo
                    {
                        id = entidad.actividade.idcodigoactividad,
                        descripcion = entidad.actividade.descripcionactividad,
                        sistema = entidad.actividade.sistemaactividad,
                        estado = entidad.actividade.estadoactividad
                    },
                    clasificacionModelo = new ClasificacionModelo 
                    {
                        id = entidad.clasificacione.idclasificacion,
                        descripcion = entidad.clasificacione.descripcionclasificacion,
                        sistema = entidad.clasificacione.sistemaclasificacion,
                        estado = entidad.clasificacione.estadoclasificacion
                    },
                    paisModelo = new PaisModelo 
                    {
                        id = entidad.pais.idpais,
                        descripcion = entidad.pais.nombrepais,
                        sistema = entidad.pais.sistemapais,
                        estado = entidad.pais.estadopais
                    },
                    departamentoModelo=new DepartamentoModelo 
                    {
                        id = entidad.departamento.iddepartamento,
                        descripcion = entidad.departamento.nombredepartamento,
                        sistema = entidad.departamento.sistemadepartamento,
                        idpais = entidad.departamento.idpais,
                        estado = entidad.departamento.estadodepartamento,
                        pais = new PaisModelo
                        {
                            id = entidad.departamento.pais.idpais,
                            descripcion = entidad.departamento.pais.nombrepais,
                            sistema = entidad.departamento.pais.sistemapais,
                            estado = entidad.departamento.pais.estadopais
                        }
                    },
                    municipioModelo= new MunicipioModelo 
                    {
                        id = entidad.municipio.idmunicipio,
                        descripcion = entidad.municipio.nombremunicipio,
                        sistema = entidad.municipio.sistemamunicipio,
                        estado = entidad.municipio.estadomunicipio,
                        nombrePais = entidad.municipio.departamento.pais.nombrepais,
                        nombreDepartamento = entidad.municipio.departamento.nombredepartamento,
                        iddepartamento = entidad.municipio.iddepartamento,
                        departamento = new DepartamentoModelo
                        {
                            id = entidad.municipio.departamento.iddepartamento,
                            descripcion = entidad.municipio.departamento.nombredepartamento,
                            sistema = entidad.municipio.departamento.sistemadepartamento,
                            idpais = entidad.municipio.departamento.idpais,
                            estado = entidad.municipio.departamento.estadodepartamento,
                            pais = new PaisModelo
                            {
                                id = entidad.municipio.departamento.pais.idpais,
                                descripcion = entidad.municipio.departamento.pais.nombrepais,
                                sistema = entidad.municipio.departamento.pais.sistemapais,
                                estado = entidad.municipio.departamento.pais.estadopais
                            }
                        }
                    }
                    //Lista filtrada de elementos que fueron eliminados
                    }).OrderBy(o => o.idnitcliente).Where(x => x.estadocliente=="A").ToList();
                //La ordena por el idPrograma notar la notacion
            }
        }

        //Verifica si el registro existe dentro de los eliminados
        public static bool FindPK(int id, Boolean eliminado)
        {
            throw new NotImplementedException();
        }


        public static bool UpdateModelo(ClienteModelo modelo)
        {
            throw new NotImplementedException();
        }


        public static bool CopiarModelo(ClienteModelo modelo)
        {
            throw new NotImplementedException();
        }
        //Pendiente el definir la forma de consulta y eliminacion
        public static bool DeleteBorradoLogico(int id, Boolean actualizar)
        {
            throw new NotImplementedException();
        }

        public static bool DeleteBorradoLogico(string id, Boolean actualizar)
        {
            throw new NotImplementedException();
        }
        public static void Delete(int id)
        {
            throw new NotImplementedException();
        }

        //Devuelve un booleano de éxito en caso de realizarse la eliminacion
        public static bool Delete(int id, Boolean actualizar)
        {
            throw new NotImplementedException();
        }

        public static bool Delete(string id, Boolean actualizar)
        {
            throw new NotImplementedException();
        }

        public static List<ClienteModelo> GetAll()
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.clientes.Select(entidad =>
                new ClienteModelo
                {
                    idnitcliente = entidad.idnitcliente,
                    idclasificacion = entidad.idclasificacion,
                    idpais = entidad.idpais,
                    idcodigoactividad = entidad.idcodigoactividad,
                    idsc = entidad.idsc,
                    iddepartamento = entidad.iddepartamento,
                    idmunicipio = entidad.idmunicipio,
                    razonsocialcliente = entidad.razonsocialcliente,
                    nrccliente = entidad.nrccliente,
                    direccioncliente = entidad.direccioncliente,
                    actividadcliente = entidad.actividadcliente,
                    paginawebcliente = entidad.paginawebcliente,
                    fechaconstitucioncliente = entidad.fechaconstitucioncliente,
                    estadocliente = entidad.estadocliente,
                    //Carga de  entidades
                    actividadModelo = new ActividadModelo
                    {
                        id = entidad.actividade.idcodigoactividad,
                        descripcion = entidad.actividade.descripcionactividad,
                        sistema = entidad.actividade.sistemaactividad,
                        estado = entidad.actividade.estadoactividad
                    },
                    clasificacionModelo = new ClasificacionModelo
                    {
                        id = entidad.clasificacione.idclasificacion,
                        descripcion = entidad.clasificacione.descripcionclasificacion,
                        sistema = entidad.clasificacione.sistemaclasificacion,
                        estado = entidad.clasificacione.estadoclasificacion
                    },
                    paisModelo = new PaisModelo
                    {
                        id = entidad.pais.idpais,
                        descripcion = entidad.pais.nombrepais,
                        sistema = entidad.pais.sistemapais,
                        estado = entidad.pais.estadopais
                    },
                    departamentoModelo = new DepartamentoModelo
                    {
                        id = entidad.departamento.iddepartamento,
                        descripcion = entidad.departamento.nombredepartamento,
                        sistema = entidad.departamento.sistemadepartamento,
                        idpais = entidad.departamento.idpais,
                        estado = entidad.departamento.estadodepartamento,
                        pais = new PaisModelo
                        {
                            id = entidad.departamento.pais.idpais,
                            descripcion = entidad.departamento.pais.nombrepais,
                            sistema = entidad.departamento.pais.sistemapais,
                            estado = entidad.departamento.pais.estadopais
                        }
                    },
                    municipioModelo = new MunicipioModelo
                    {
                        id = entidad.municipio.idmunicipio,
                        descripcion = entidad.municipio.nombremunicipio,
                        sistema = entidad.municipio.sistemamunicipio,
                        estado = entidad.municipio.estadomunicipio,
                        nombrePais = entidad.municipio.departamento.pais.nombrepais,
                        nombreDepartamento = entidad.municipio.departamento.nombredepartamento,
                        iddepartamento = entidad.municipio.iddepartamento,
                        departamento = new DepartamentoModelo
                        {
                            id = entidad.municipio.departamento.iddepartamento,
                            descripcion = entidad.municipio.departamento.nombredepartamento,
                            sistema = entidad.municipio.departamento.sistemadepartamento,
                            idpais = entidad.municipio.departamento.idpais,
                            estado = entidad.municipio.departamento.estadodepartamento,
                            pais = new PaisModelo
                            {
                                id = entidad.municipio.departamento.pais.idpais,
                                descripcion = entidad.municipio.departamento.pais.nombrepais,
                                sistema = entidad.municipio.departamento.pais.sistemapais,
                                estado = entidad.municipio.departamento.pais.estadopais
                            }
                        }
                    }
                    //Lista filtrada de elementos que fueron eliminados
                }).OrderBy(o => o.razonsocialcliente).Where(x => x.estadocliente == "A").ToList();
                    //La ordena por el idPrograma notar la notacion
                    if (lista == null)
                    {
                        return new List<ClienteModelo>();
                    }
                    else
                    {
                        return lista;
                    }
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("Exception en elaboracion de lista de Plantilla Indice Modelo " + e.Message);
                }
                return null;
            }
        }

        public static ClienteModelo GetRegistro(int idBuscado)
        {
            throw new NotImplementedException();
        }
        public static ClienteModelo GetRegistro(string idnitcliente)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                var registro = _context.clientes.Select(entidad =>
                new ClienteModelo
                {
                    idnitcliente = entidad.idnitcliente,
                    idclasificacion = entidad.idclasificacion,
                    idpais = entidad.idpais,
                    idcodigoactividad = entidad.idcodigoactividad,
                    idsc = entidad.idsc,
                    iddepartamento = entidad.iddepartamento,
                    idmunicipio = entidad.idmunicipio,
                    razonsocialcliente = entidad.razonsocialcliente,
                    nrccliente = entidad.nrccliente,
                    direccioncliente = entidad.direccioncliente,
                    actividadcliente = entidad.actividadcliente,
                    paginawebcliente = entidad.paginawebcliente,
                    fechaconstitucioncliente = entidad.fechaconstitucioncliente,
                    estadocliente = entidad.estadocliente,
                    //Carga de  entidades
                    actividadModelo = new ActividadModelo
                    {
                        id = entidad.actividade.idcodigoactividad,
                        descripcion = entidad.actividade.descripcionactividad,
                        sistema = entidad.actividade.sistemaactividad,
                        estado = entidad.actividade.estadoactividad
                    },
                    clasificacionModelo = new ClasificacionModelo
                    {
                        id = entidad.clasificacione.idclasificacion,
                        descripcion = entidad.clasificacione.descripcionclasificacion,
                        sistema = entidad.clasificacione.sistemaclasificacion,
                        estado = entidad.clasificacione.estadoclasificacion
                    },
                    paisModelo = new PaisModelo
                    {
                        id = entidad.pais.idpais,
                        descripcion = entidad.pais.nombrepais,
                        sistema = entidad.pais.sistemapais,
                        estado = entidad.pais.estadopais
                    },
                    departamentoModelo = new DepartamentoModelo
                    {
                        id = entidad.departamento.iddepartamento,
                        descripcion = entidad.departamento.nombredepartamento,
                        sistema = entidad.departamento.sistemadepartamento,
                        idpais = entidad.departamento.idpais,
                        estado = entidad.departamento.estadodepartamento,
                        pais = new PaisModelo
                        {
                            id = entidad.departamento.pais.idpais,
                            descripcion = entidad.departamento.pais.nombrepais,
                            sistema = entidad.departamento.pais.sistemapais,
                            estado = entidad.departamento.pais.estadopais
                        }
                    },
                    municipioModelo = new MunicipioModelo
                    {
                        id = entidad.municipio.idmunicipio,
                        descripcion = entidad.municipio.nombremunicipio,
                        sistema = entidad.municipio.sistemamunicipio,
                        estado = entidad.municipio.estadomunicipio,
                        nombrePais = entidad.municipio.departamento.pais.nombrepais,
                        nombreDepartamento = entidad.municipio.departamento.nombredepartamento,
                        iddepartamento = entidad.municipio.iddepartamento,
                        departamento = new DepartamentoModelo
                        {
                            id = entidad.municipio.departamento.iddepartamento,
                            descripcion = entidad.municipio.departamento.nombredepartamento,
                            sistema = entidad.municipio.departamento.sistemadepartamento,
                            idpais = entidad.municipio.departamento.idpais,
                            estado = entidad.municipio.departamento.estadodepartamento,
                            pais = new PaisModelo
                            {
                                id = entidad.municipio.departamento.pais.idpais,
                                descripcion = entidad.municipio.departamento.pais.nombrepais,
                                sistema = entidad.municipio.departamento.pais.sistemapais,
                                estado = entidad.municipio.departamento.pais.estadopais
                            }
                        }
                    }
                    //Lista filtrada de elementos que fueron eliminados
                     }).Where(x => x.idnitcliente == idnitcliente).Where(x => x.estadocliente == "A").FirstOrDefault();
                     return registro;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("No pudo recuperarse el registro del cliente " + e.Message);
                }
                return null;
            }
        }

        public static cliente GetRegistroByNitCapaDatos(string idnitcliente)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var registro = _context.clientes.Where(x => x.idnitcliente == idnitcliente).Where(x => x.estadocliente == "A").FirstOrDefault();
                    return registro;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("No pudo recuperarse el registro del cliente " + e.Message);
                }
                return null;
            }
        }
        #region Contar registros
        public static int ContarRegistros(int? idpais)
        {
            throw new NotImplementedException();
        }

        public static int ContarRegistros()
        {
            throw new NotImplementedException();
        }


        #endregion

        #region Busqueda duplicados
        //Verifica si el registro existe dentro de los eliminados
        public static bool FindTexto(string texto)
        {
            throw new NotImplementedException();
        }

        public static int FindTextoReturnId(string texto)
        {
            throw new NotImplementedException();
        }

        public static int FindTextoReturnIdBorrados(string texto)
        {
            throw new NotImplementedException();
        }

        public static bool UpdateBorradoModelo(ClienteModelo modelo, bool actualizar)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Limpieza de valores
        //Verifica si el registro existe dentro de los eliminados
        public static ClienteModelo Clear(ClienteModelo modelo)
        {
            throw new NotImplementedException();
        }
        public ClienteModelo()
        {
            
            idnitcliente = string.Empty;
                    idclasificacion = 0;
                    idpais = 0;
                    idcodigoactividad = string.Empty;
                    idsc = 0;
                    iddepartamento = 0;
                    idmunicipio = 0;
                    razonsocialcliente = string.Empty;
                    nrccliente = string.Empty;
                    direccioncliente = string.Empty;
                    actividadcliente = string.Empty;
                    paginawebcliente = string.Empty;
                    fechaconstitucioncliente = MetodosModelo.homologacionFecha();// DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
                    estadocliente = "A";
                    //Carga de  entidades
                    }

        public object Clone()
        {
            return MemberwiseClone();
        }
        #endregion
    }

}



