using SGPTWpf.Support;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SGPTWpf.Model.Modelo.Encargos
{
    public class TipoClienteEncargoModelo : UIBase
    {
        public int idTipoCliente //correlativo
        {
            get { return GetValue(() => idTipoCliente); }
            set { SetValue(() => idTipoCliente, value); }
        }

        public bool? tipoclienteencargo
        {
            get { return GetValue(() => tipoclienteencargo); }
            set { SetValue(() => tipoclienteencargo, value); }
        }
        public string descripcionTipoClienteEncargo
        {
            get { return GetValue(() => descripcionTipoClienteEncargo); }
            set { SetValue(() => descripcionTipoClienteEncargo, value); }
        }

        #region Public Model Methods

        public static List<TipoClienteEncargoModelo> GetAll()
        {
            var lista = new ObservableCollection<TipoClienteEncargoModelo>
            {
               new TipoClienteEncargoModelo {
                                        idTipoCliente=1,
                                        tipoclienteencargo=false,
                                        descripcionTipoClienteEncargo="No recurrente"
                                      },
               new TipoClienteEncargoModelo {
                                        idTipoCliente=2,
                                        tipoclienteencargo=true,
                                        descripcionTipoClienteEncargo="Recurrente"
                                      },
            };
            return lista.OrderBy(x => x.idTipoCliente).ToList();
        }


        #endregion

        #region Filtro
        public static TipoClienteEncargoModelo seleccionTipoClienteEncargo(bool tipoclienteencargo)
        {
            TipoClienteEncargoModelo respuesta = null;
            if (!tipoclienteencargo)
            {
                    respuesta = new TipoClienteEncargoModelo
                    {
                        idTipoCliente = 1,
                        tipoclienteencargo = false,
                        descripcionTipoClienteEncargo = "No recurrente"
                    };
            }
               else
            {
                    respuesta = 
                   new TipoClienteEncargoModelo
                   {
                       idTipoCliente = 2,
                       tipoclienteencargo = true,
                       descripcionTipoClienteEncargo = "Recurrente"
                   };
            }
            return respuesta;
        }

        #endregion
    }
}
