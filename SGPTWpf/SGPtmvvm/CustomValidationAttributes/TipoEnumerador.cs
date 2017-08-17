using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGPTmvvm.CustomValidationAttributes
{
        public enum TipoEnumerador
        {
            A, //aprobdo
            R, //Rechazado
            P, //Pendiente
            Editar,
            Consultar,
            Eliminar,
            Guardar,
            Aprobar,
            Refrescar,
            Desactivarse,
            ExportarExcel,
            ExportarWord,
            ExportarPDF
        }
}
