using CapaDatos;
using SGPTmvvm.Soporte;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Configuration;
using Npgsql;
using System.ComponentModel.DataAnnotations;
namespace SGPTmvvm.Model
{
    public class usuariosModelo: CrudVMBase
    {
        
        #region Modelo Atributos
        private static SGPTEntidades dbb;
        #endregion
        #region Modelo propiedades
        [Required(ErrorMessage = "Id es Requerido")]
        [MaxLength(10, ErrorMessage = "DUI excede 10 caracteres")]
        [MinLength(9, ErrorMessage = "Nombre debe ser superior a 5 letras")]
        public int idusuarioModelo { get { return GetValue(() => idusuarioModelo); } set { SetValue(() => idusuarioModelo,value);} }
        public string idduipersonaModelo { get { return GetValue(() => idduipersonaModelo); } set { SetValue(() => idduipersonaModelo, value); } }
        public int idpistaModelo { get { return GetValue(() => idpistaModelo); } set { SetValue(() => idpistaModelo, value); } }
        public int usuidusuarioModelo { get { return GetValue(() => idpistaModelo); } set { SetValue(() => idpistaModelo, value); } }
        public int idrolModelo { get { return GetValue(() => idpistaModelo); } set { SetValue(() => idpistaModelo, value); } }
        public int idfirmaModelo { get { return GetValue(() => idpistaModelo); } set { SetValue(() => idpistaModelo, value); } }
        public string fecharegistrousuarioModelo { get { return GetValue(() => fecharegistrousuarioModelo); } set { SetValue(() => fecharegistrousuarioModelo, value); } }
        public string fechadebajaModelo { get { return GetValue(() => fechadebajaModelo); } set { SetValue(() => fechadebajaModelo, value); } }
        public string fechacontratacionModelo { get { return GetValue(() => fechacontratacionModelo); } set { SetValue(() => fechacontratacionModelo, value); } }
        public string nickusuariousuarioModelo { get { return GetValue(() => nickusuariousuarioModelo); } set { SetValue(() => nickusuariousuarioModelo, value); } }
        public string inicialesusuarioModelo { get { return GetValue(() => inicialesusuarioModelo); } set { SetValue(() => inicialesusuarioModelo, value); } }
        public string respuestapistausuarioModelo { get { return GetValue(() => respuestapistausuarioModelo); } set { SetValue(() => respuestapistausuarioModelo, value); } }
        public string numerocvpausuarioModelo { get { return GetValue(() => numerocvpausuarioModelo); } set { SetValue(() => numerocvpausuarioModelo, value); } }
        public string fechacvpausuarioModelo { get { return GetValue(() => fechacvpausuarioModelo); } set { SetValue(() => fechacvpausuarioModelo, value); } }
        public string estadousuarioModelo { get { return GetValue(() => estadousuarioModelo); } set { SetValue(() => estadousuarioModelo, value); } }
        public string contraseniausuarioModelo { get { return GetValue(() => contraseniausuarioModelo); } set { SetValue(() => contraseniausuarioModelo, value); } }
        #endregion
        #region Metodos Publicos
        public static void InsertarUsuarios(usuariosModelo usuariosModelo)
        {
            using (dbb = new SGPTEntidades())
            {
                Random rnd = new Random();
                #region 
                var usuario = new usuario
                        {

                            //idusuario = rnd.Next(1,10000),//db.usuarios.OrderByDescending(x => x.idusuario).Take(1).FirstOrDefault().idusuario + 1;
                            //idduipersona = usuariosModelo.idduipersona,
                            //idpista = usuariosModelo.idpista,
                            //usuidusuario= usuariosModelo.usuidusuario,
                            //idrol = usuariosModelo.idrol,
                            //idfirma =usuariosModelo.idfirma,
                            //fecharegistrousuario = usuariosModelo.fecharegistrousuario,
                            //fechadebaja = usuariosModelo.fechadebaja,
                            //fechacontratacion=usuariosModelo.fechacontratacion,
                            //nickusuariousuario = usuariosModelo.nickusuariousuario,
                            //contraseniausuario = usuariosModelo.contraseniausuario,
                            //inicialesusuario = usuariosModelo.inicialesusuario,
                            //respuestapistausuario = usuariosModelo.respuestapistausuario, 
                            //numerocvpausuario = usuariosModelo.numerocvpausuario,
                            //fechacvpausuario = usuariosModelo.fechacontratacion, 
                            //estadousuario = usuariosModelo.estadousuario,               
                        }; 
                #endregion

                try
                {
                    //Nota, por alguna razon de relaciones en la base, el EF no deja almacenar. Asi que fuerza bruta
                    //db.usuarios.Add(usuario);
                    //db.SaveChanges();
                    string cadenaConexion = ConfigurationManager.ConnectionStrings["myConexion"].ConnectionString;
                    //NpgsqlConnection cn = new NpgsqlConnection(cadenaConexion);

                    int p0    = rnd.Next(1,10000);//db.usuarios.OrderByDescending(x => x.idusuario).Take(1).FirstOrDefault().idusuario + 1;
                    string p1 = usuariosModelo.idduipersonaModelo;
                    int p2    = usuariosModelo.idpistaModelo;
                    int p3    = usuariosModelo.usuidusuarioModelo;
                    int p4    = usuariosModelo.idrolModelo; 
                    int p5    =usuariosModelo.idfirmaModelo; 
                    string p6 =usuariosModelo.fecharegistrousuarioModelo; 
                    string p7 =usuariosModelo.fechadebajaModelo; 
                    string p8 =usuariosModelo.fechacontratacionModelo; 
                    string p9 = usuariosModelo.nickusuariousuarioModelo; 
                    string p10= usuariosModelo.contraseniausuarioModelo; 
                    string p11= usuariosModelo.inicialesusuarioModelo; 
                    string p12= usuariosModelo.respuestapistausuarioModelo; 
                    string p13= usuariosModelo.numerocvpausuarioModelo; 
                    string p14= usuariosModelo.fechacontratacionModelo; 
                    string p15= usuariosModelo.estadousuarioModelo;
                    string cmdComando = String.Format("INSERT INTO usuarios VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}', '{10}','{11}','{12}','{13}','{14}','{15}')", p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14,p15);
                    try
                    {
                        using (NpgsqlConnection cn = new NpgsqlConnection(cadenaConexion))
                        {
                            using (NpgsqlCommand pgsqlcommand = new NpgsqlCommand(cmdComando, cn))
                            {
                                cn.Open();
                                pgsqlcommand.ExecuteNonQuery();
                                cn.Close();
                            }
                        }
                    }
                    catch (NpgsqlException ex) { throw ex; }
                    catch (Exception ex) { throw ex; }
                    MessageBox.Show("Usuario guardado con éxito");
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public static usuariosModelo BuscarUsuarios(int idusuario, string idduipersona)
        {
            
            using (dbb=new SGPTEntidades())
            {
                var UsuariosModelo = new usuariosModelo();
                usuario Usuarios = new usuario();
                if (idusuario == 0 && idduipersona=="")
                {
                    return UsuariosModelo = null;
                }
                else
                {
                    if (idusuario == 0) // && idduiusuario == "")
                    {
                        //var PERR = (from z in db.personas
                        //           where z.idduipersona == idduipersona
                        //           select z).ToList();

                       // var asd = (from z in dbb.usuarios
                       //where z.idduipersona == idduipersona
                       //select z).ToList();
                        //if (asd != null)
                        //{
                            //MessageBox.Show("TIENE");
                            try
                            {
                                Usuarios = dbb.usuarios.SingleOrDefault(z => z.idduipersona == idduipersona); //Devolvera excepcion si mas de un registro es igual
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Existen muchos registros similares de DUI o registros vacios. Verifique la base de datos "+ex);
                                //throw;
                                
                            }
                            
                        //}
                        //Usuarios = db.usuarios.Single(z => z.idduipersona == idduipersona);
                        //Usuarios=db.usuarios.select
                        #region
                        //foreach (var ddd in ddd) 
                        //{
                        //    Usuarios.idusuario = ddd.idusuario; 
                        //Usuarios.idduipersona = ddd.idduipersona;
                        //Usuarios.idpista = ddd.idpista;
                        //Usuarios.usuidusuario = ddd.usuidusuario;
                        //Usuarios.idrol = ddd.idrol;
                        //Usuarios.idfirma = ddd.idfirma;
                        //Usuarios.fecharegistrousuario = ddd.fecharegistrousuario;
                        //Usuarios.fechadebaja = ddd.fechadebaja;
                        //Usuarios.fechacontratacion = ddd.fechacontratacion;
                        //Usuarios.nickusuariousuario = ddd.nickusuariousuario;
                        //Usuarios.inicialesusuario = ddd.inicialesusuario;
                        //Usuarios.respuestapistausuario = ddd.respuestapistausuario;
                        //Usuarios.numerocvpausuario = ddd.numerocvpausuario;
                        //Usuarios.fechacvpausuario = ddd.fechacvpausuario;
                        //Usuarios.estadousuario = ddd.estadousuario;
                        //Usuarios.contraseniausuario = ddd.contraseniausuario;
                        //}
                        #endregion
                    }
                    else{
                        Usuarios=(dbb.usuarios.Find(idusuario));
                    }
                }
                
                if (Usuarios==null)
                {
                    return UsuariosModelo = null;
                }
                else
                {
                    UsuariosModelo.idusuarioModelo = Usuarios.idusuario;
                    UsuariosModelo.idduipersonaModelo = Usuarios.idduipersona;
                    UsuariosModelo.idpistaModelo = (int)Usuarios.idpista;
                    UsuariosModelo.usuidusuarioModelo = (int)Usuarios.usuidusuario;
                    UsuariosModelo.idrolModelo = (int)Usuarios.idrol;
                    //UsuariosModelo.idfirmaModelo = (int)Usuarios.idfirma;
                    UsuariosModelo.fecharegistrousuarioModelo = Usuarios.fecharegistrousuario;
                    UsuariosModelo.fechadebajaModelo = Usuarios.fechadebaja;
                    UsuariosModelo.fechacontratacionModelo = Usuarios.fechacontratacion;
                    UsuariosModelo.nickusuariousuarioModelo = Usuarios.nickusuariousuario;
                    UsuariosModelo.inicialesusuarioModelo = Usuarios.inicialesusuario;
                    UsuariosModelo.respuestapistausuarioModelo = Usuarios.respuestapistausuario;
                    UsuariosModelo.numerocvpausuarioModelo = Usuarios.numerocvpausuario;
                    UsuariosModelo.fechacvpausuarioModelo = Usuarios.fechacvpausuario;
                    UsuariosModelo.estadousuarioModelo = Usuarios.estadousuario;
                    UsuariosModelo.contraseniausuarioModelo = Usuarios.contraseniausuario;
                    return UsuariosModelo;
                }
            }
        }
        public static void ActualizarUsuarios(usuariosModelo usuariosModelo)
        {
            using (dbb = new SGPTEntidades())
            {
                var usuario = new usuario
                {
                    idusuario = usuariosModelo.idusuarioModelo,
                    idduipersona = usuariosModelo.idduipersonaModelo,
                    idpista = usuariosModelo.idpistaModelo,
                    idrol = usuariosModelo.idrolModelo,
                    //idfirma = usuariosModelo.idfirmaModelo,
                    fecharegistrousuario = usuariosModelo.fecharegistrousuarioModelo,
                    nickusuariousuario = usuariosModelo.nickusuariousuarioModelo,
                    contraseniausuario = usuariosModelo.contraseniausuarioModelo,
                    inicialesusuario = usuariosModelo.inicialesusuarioModelo,
                    respuestapistausuario = usuariosModelo.respuestapistausuarioModelo,
                    numerocvpausuario = usuariosModelo.numerocvpausuarioModelo,
                    fechacvpausuario = usuariosModelo.fechacontratacionModelo,
                    estadousuario = usuariosModelo.estadousuarioModelo
                };
                dbb.Entry(usuario).State = EntityState.Modified;
                dbb.SaveChanges();
                MessageBox.Show("Usuario Actualizado con éxito.");
            }
        }
        public static void EliminarUsuarios(int idusuario)
        {
            if(MessageBox.Show("El registro se eliminara definitivamente. Desea continuar?","Advertencia...",MessageBoxButton.YesNo,MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                usuario Usuario = dbb.usuarios.Find(idusuario);
                dbb.usuarios.Remove(Usuario);
                dbb.SaveChanges();
                MessageBox.Show("El registro se elimino definitivamente.");
            }
            else
            {
                MessageBox.Show("Eliminacion abortada...","Cancelado....",MessageBoxButton.OK,MessageBoxImage.Information);
            }
        }
        public static List<usuariosModelo> GetAllUsuarios()
        {
            using (dbb = new SGPTEntidades())
            {
                return dbb.usuarios.Select(Usuarios => new usuariosModelo
                {
                    idusuarioModelo = Usuarios.idusuario,
                    idduipersonaModelo = Usuarios.idduipersona,
                    idpistaModelo = (int)Usuarios.idpista,
                    usuidusuarioModelo = (int)Usuarios.usuidusuario,
                    idrolModelo = (int)Usuarios.idrol,
                    //idfirmaModelo = (int)Usuarios.idfirma,
                    fecharegistrousuarioModelo = Usuarios.fecharegistrousuario,
                    fechadebajaModelo = Usuarios.fechadebaja,
                    fechacontratacionModelo = Usuarios.fechacontratacion,
                    nickusuariousuarioModelo = Usuarios.nickusuariousuario,
                    inicialesusuarioModelo = Usuarios.inicialesusuario,
                    respuestapistausuarioModelo = Usuarios.respuestapistausuario,
                    numerocvpausuarioModelo = Usuarios.numerocvpausuario,
                    fechacvpausuarioModelo = Usuarios.fechacvpausuario,
                    estadousuarioModelo = Usuarios.estadousuario,
                    contraseniausuarioModelo = Usuarios.contraseniausuario
                }).OrderBy(o => o.idusuarioModelo).ToList();
            }
        }
        #endregion
    }
}
