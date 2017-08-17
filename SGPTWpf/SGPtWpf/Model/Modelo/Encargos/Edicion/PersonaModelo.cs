using CapaDatos;
using SGPTWpf.SGPtWpf.Support.Validaciones.Atributos;
using SGPTWpf.Support;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace SGPTWpf.Model.Modelo.Encargos
{
    public class PersonaModelo : UIBase
    {
        #region Model Attributes

        private static SGPTEntidades _context;

        #endregion

        #region Model Properties

        public static bool sincronizar { get; set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("idduipersona")]
        public string idduipersona
        {
            get { return GetValue(() => idduipersona); }
            set { SetValue(() => idduipersona, value); }
        }

        public string nombrespersona
        {
            get { return GetValue(() => nombrespersona); }
            set { SetValue(() => nombrespersona, value); }
        }

        [DisplayName("apellidospersona")]
        [Required(ErrorMessage = "Dato requerido")]
        [MaxLength(40, ErrorMessage = "Excede de 40 caracteres permitidos")]
        [ExcludeChar("^Ç", ErrorMessage = "La razón social contiene símbolos inválidos")]
        public string apellidospersona
        {
            get { return GetValue(() => apellidospersona); }
            set { SetValue(() => apellidospersona, value); }
        }

        public string estadopersona
        {
            get { return GetValue(() => estadopersona); }
            set { SetValue(() => estadopersona, value); }
        }

        // Entidades relacionadas

        public string nombreCompleto
        {
            get { return GetValue(() => nombreCompleto); }
            set { SetValue(() => nombreCompleto, value); }
        }


        #endregion

        #region Public Model Methods


        public static bool Insert(PersonaModelo modelo)
        {
            throw new NotImplementedException();
        }

        public static string Insert(PersonaModelo modelo, bool valor)
        {
            throw new NotImplementedException();
        }

        //Devuelve el registro buscado con base al indice
        public static PersonaModelo Find(int id)
        {
            throw new NotImplementedException();
        }

        //Devuelve un booleano de éxito en caso de realizarse la eliminacion

        public static PersonaModelo Find(string id)
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
        public static List<PersonaModelo> GetAllPkContenido(string texto)
        {

            using (_context = new SGPTEntidades())
            {
                string Texto = texto.ToUpper();
                return _context.personas.Select(entidad =>
                new PersonaModelo
                {
                    idduipersona = entidad.idduipersona,
                    nombrespersona = entidad.nombrespersona,
                    apellidospersona = entidad.apellidospersona,
                    estadopersona = entidad.estadopersona,
                    nombreCompleto=entidad.nombrespersona + " " +entidad.apellidospersona
                    //Lista filtrada de elementos que fueron eliminados
                }).OrderBy(o => o.idduipersona).Where(x => x.estadopersona == "A").ToList();
                //La ordena por el idPrograma notar la notacion
            }
        }

        //Verifica si el registro existe dentro de los eliminados
        public static bool FindPK(int id, Boolean eliminado)
        {
            throw new NotImplementedException();
        }


        public static bool UpdateModelo(PersonaModelo modelo)
        {
            throw new NotImplementedException();
        }


        public static bool CopiarModelo(PersonaModelo modelo)
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

        public static List<PersonaModelo> GetAll()
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.personas.Select(entidad =>
                new PersonaModelo
                {
                    idduipersona = entidad.idduipersona,
                    nombrespersona = entidad.nombrespersona,
                    apellidospersona = entidad.apellidospersona,
                    estadopersona = entidad.estadopersona,
                    nombreCompleto = entidad.nombrespersona + " " + entidad.apellidospersona
                    //Lista filtrada de elementos que fueron eliminados
                }).OrderBy(o => o.nombrespersona).Where(x => x.estadopersona == "A").ToList();
                    //La ordena por el idPrograma notar la notacion
                    if (lista == null)
                    {
                        return new List<PersonaModelo>();
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

        public static PersonaModelo GetRegistro(int idBuscado)
        {
            throw new NotImplementedException();
        }
        public static PersonaModelo GetRegistro(string idduipersona)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var registro = _context.personas.Select(entidad =>
                    new PersonaModelo
                    {
                        idduipersona = entidad.idduipersona,
                        nombrespersona = entidad.nombrespersona,
                        apellidospersona = entidad.apellidospersona,
                        estadopersona = entidad.estadopersona,
                        nombreCompleto = entidad.nombrespersona + " " + entidad.apellidospersona
                        //Carga de  entidades
                        //Lista filtrada de elementos que fueron eliminados
                    }).Where(x => x.idduipersona == idduipersona).Where(x => x.estadopersona == "A").FirstOrDefault();
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

        public static bool UpdateBorradoModelo(PersonaModelo modelo, bool actualizar)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Limpieza de valores
        //Verifica si el registro existe dentro de los eliminados
        public static PersonaModelo Clear(PersonaModelo modelo)
        {
            throw new NotImplementedException();
        }
        public PersonaModelo()
        {
            idduipersona = string.Empty;
            nombrespersona = string.Empty;
            apellidospersona = string.Empty;
            estadopersona = "A";
            //Carga de  entidades
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
        #endregion
    }

}




