using CapaDatos;
using SGPTWpf.Support;
using System;
using System.Collections.Generic;

namespace SGPTWpf.Model.Modelo.detalleherramientas
{

    public class FirmaModelo : UIBase
        {
            #region Model Attributes

            private static SGPTEntidades _context;

            #endregion

            #region Model Properties
            public static bool sincronizar { get; set; }

            public int idFirma { get; set; }
            public Nullable<int> iddepartamento { get; set; }
            public int idpais { get; set; }
            public int idmunicipio { get; set; }
            public Nullable<int> idusuario { get; set; }
            public string razonSocialFirma { get; set; }
            public string representantefirma { get; set; }
            public string nitfirma { get; set; }
            public string nrcfirma { get; set; }
            public string direccionfirma { get; set; }
            public Nullable<int> numerocvpafirma { get; set; }
            public string fechainscripcioncvpafirma { get; set; }
            public string fechacreadofirma { get; set; }
            public string urlfirma { get; set; }
            public byte[] logofirma { get; set; }
            public string estadofirma { get; set; }

            public virtual ICollection<correo> correos { get; set; }
            public virtual departamento departamento { get; set; }
            public virtual municipio municipio { get; set; }
            public virtual pais pais { get; set; }
            public virtual usuario usuario { get; set; }
            public virtual ICollection<telefono> telefonos { get; set; }

            #endregion

            #region Public Model Methods

            #endregion

            public static bool Insert(FirmaModelo modelo, Boolean insertar)
            {
            throw new NotImplementedException();
            }


            public static string Insert(FirmaModelo modelo)
            {
            throw new NotImplementedException();
            }

            //Devuelve el registro buscado con base al indice
            public static FirmaModelo Find(int id)
            {
                var entidadModelo = new FirmaModelo();
                if (!(id == 0))
                {
                    using (_context = new SGPTEntidades())
                    {
                        firma entidad = _context.firmas.Find(id);
                        if (entidad == null)
                        {
                            entidadModelo = null;
                        }
                        else
                        {
                            entidadModelo.idFirma = entidad.idfirma;
                            entidadModelo.logofirma = entidad.logofirma;
                            entidadModelo.razonSocialFirma = entidad.razonsocialfirma;
                            
                        }
                    return entidadModelo;
                    }
                }
                else
                {
                    return entidadModelo = null;
                }
            }

        //Devuelve el maximo del orden de un registro
        public static Nullable<decimal> FindOrden(int idHerramienta)
            {
            throw new NotImplementedException();
            }
            #region Metodos para string 

            public static void Delete(string id)
            {
            throw new NotImplementedException();
            }

            //Devuelve un booleano de éxito en caso de realizarse la eliminacion

            public static FirmaModelo Find(string id)
            {
            throw new NotImplementedException();
            }

            public static bool FindPK(string id)
            {
            throw new NotImplementedException();
            }

            public static bool FindPK(int? id)
            {
            throw new NotImplementedException();
            }
            //Verifica si el registro existe dentro de los eliminados
            public static bool FindPK(string id, Boolean eliminado)
            {
            throw new NotImplementedException();
            }

            //Devuelve un booleano de éxito en caso de realizarse la eliminacion

            #endregion

            public static bool FindPK(int id)
            {
            throw new NotImplementedException();
            }

            public static string FindNombreById(int? id)
            {
            throw new NotImplementedException();
            }
            public static Nullable<decimal> FindOrdenPadreById(int? id)
            {
            throw new NotImplementedException();
            }
            //Para realizar busquedas de texto
            public static List<FirmaModelo> TransformLista(string texto)
            {
            throw new NotImplementedException();
            }


            //Verifica si el registro existe dentro de los eliminados
            public static bool FindPK(int id, Boolean eliminado)
            {
                throw new NotImplementedException();
            }

            public static void UpdateModelo(FirmaModelo modelo)
            {
            throw new NotImplementedException();
            }

            public static bool UpdateModelo(FirmaModelo modelo, Boolean actualizar)
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

            public static List<FirmaModelo> GetAllTransform()
            {
            throw new NotImplementedException();
            }
            public static List<FirmaModelo> GetAll()
            {
            throw new NotImplementedException();
            }


            public static List<FirmaModelo> GetAll(int? idHerramienta)
            {
            throw new NotImplementedException();
            }


            public static Nullable<Decimal> SumaHora(int? idHerramienta)
            {
            throw new NotImplementedException();
            }

            public static List<FirmaModelo> GetAll(int? idHerramienta, int? idDhSeleccionado)
            {
            throw new NotImplementedException();
            }

            public static List<FirmaModelo> GetAll(int? idHerramienta, int? idDhSeleccionado, bool seleccion)
            {
            throw new NotImplementedException();
            }


            public static List<FirmaModelo> GetAllEncabezados(int? idHerramienta)
            {
            throw new NotImplementedException();
            }



            public static List<FirmaModelo> GetAllEncabezados()
            {
            throw new NotImplementedException();
            }


            #region Contar registros
            public static int ContarRegistros(int? id)
            {
            throw new NotImplementedException();
            }

            public static int ContarSubRegistros(int? id)
            {
            throw new NotImplementedException();
            }

            public static bool ReordenaSubRegistros(int? id)
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

            #endregion

            #region Limpieza de valores
            //Verifica si el registro existe dentro de los eliminados
            public static FirmaModelo Clear(FirmaModelo modelo)
            {
                return new FirmaModelo();
            }
            public static int FindTextoReturnId(string texto)
            {
            throw new NotImplementedException();
            }
            public static int FindTextoReturnId(string texto, int? idDh)
            {
            throw new NotImplementedException();
            }
            #endregion
        }

    }
