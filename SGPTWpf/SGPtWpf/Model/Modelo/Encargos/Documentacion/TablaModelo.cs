using CapaDatos;
using SGPTWpf.Support;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Documentacion
{
    public class TablaModelo : UIBase
{

        //private static SGPTEntidades _context;
        public int idTabla//correlativo
        {
            get { return GetValue(() => idTabla); }
            set { SetValue(() => idTabla, value); }
        }
        public string tabla
        {
            get { return GetValue(() => tabla); }
            set { SetValue(() => tabla, value); }
        }
    #region Public Model Methods
    public static ObservableCollection<TablaModelo> GetAll()
    { 
           var lista = new ObservableCollection<TablaModelo>
            {
                new TablaModelo {   idTabla=1,  tabla="CLASESBALANCE"},
                new TablaModelo {   idTabla=2,  tabla="MOVIMIENTOS"},
                new TablaModelo {   idTabla=3,  tabla="COSTOHISTORICOHORAS"},
                new TablaModelo {   idTabla=4,  tabla="CORRESPONDENCIATIPOS"},
                new TablaModelo {   idTabla=5,  tabla="TIPORESPUESTACUESTIONARIO"},
                new TablaModelo {   idTabla=6,  tabla="DOCUMENTOS"},
                new TablaModelo {   idTabla=7,  tabla="PAISES"},
                new TablaModelo {   idTabla=8,  tabla="RAZONES"},
                new TablaModelo {   idTabla=9,  tabla="TIPOCONFIRMACIONES"},
                new TablaModelo {   idTabla=10, tabla="TIPOSPROGRAMA"},
                new TablaModelo {   idTabla=11, tabla="TIPOSHERRAMIENTAS"},
                new TablaModelo {   idTabla=12, tabla="ESTRUCTURAESTADOFINANCIEROS"},
                new TablaModelo {   idTabla=13, tabla="TIPOSTELEFONOS"},
                new TablaModelo {   idTabla=14, tabla="REQUERIMIENTOS"},
                new TablaModelo {   idTabla=15, tabla="ROLES"},
                new TablaModelo {   idTabla=16, tabla="PERSONAS"},
                new TablaModelo {   idTabla=17, tabla="MONEDAS"},
                new TablaModelo {   idTabla=18, tabla="BITACORA"},
                new TablaModelo {   idTabla=19, tabla="CONTACTOCLIENTE"},
                new TablaModelo {   idTabla=20, tabla="CEDULACORRESPONDENCIAS"},
                new TablaModelo {   idTabla=21, tabla="CEDULAREUNIONES"},
                new TablaModelo {   idTabla=22, tabla="CONEXIONES"},
                new TablaModelo {   idTabla=23, tabla="PAPELES"},
                new TablaModelo {   idTabla=24, tabla="DETALLECUESTIONARIOS"},
                new TablaModelo {   idTabla=25, tabla="TIPOPARTIDAS"},
                new TablaModelo {   idTabla=26, tabla="HALLAZGOS"},
                new TablaModelo {   idTabla=27, tabla="TIPOSAUDITORIA"},
                new TablaModelo {   idTabla=28, tabla="BALANCESSUMARIAS"},
                new TablaModelo {   idTabla=29, tabla="PROCESOSAUDITORIA"},
                new TablaModelo {   idTabla=30, tabla="TIPOCARPETA"},
                new TablaModelo {   idTabla=31, tabla="ENCARGOS"},
                new TablaModelo {   idTabla=32, tabla="TIPOPROCEDIMIENTO"},
                new TablaModelo {   idTabla=33, tabla="TIPOELEMENTOINDICE"},
                new TablaModelo {   idTabla=34, tabla="LEGALNORMAS"},
                new TablaModelo {   idTabla=35, tabla="ASIGNACIONES"},
                new TablaModelo {   idTabla=36, tabla="PERIODOS"},
                new TablaModelo {   idTabla=37, tabla="BALANCES"},
                new TablaModelo {   idTabla=38, tabla="TIPOSCEDULAS"},
                new TablaModelo {   idTabla=39, tabla="CLASIFICACIONES"},
                new TablaModelo {   idTabla=40, tabla="MATRIZANALISISFINANCIERO"},
                new TablaModelo {   idTabla=41, tabla="DETALLEBALANCES"},
                new TablaModelo {   idTabla=42, tabla="CATALOGOCUENTAS"},
                new TablaModelo {   idTabla=43, tabla="CEDULAREQUERIMIENTOS"},
                new TablaModelo {   idTabla=44, tabla="CEDULAS"},
                new TablaModelo {   idTabla=45, tabla="CEDULASLEGALES"},
                new TablaModelo {   idTabla=46, tabla="CLIENTES"},
                new TablaModelo {   idTabla=47, tabla="CLASECUENTAS"},
                new TablaModelo {   idTabla=48, tabla="VISITAS"},
                new TablaModelo {   idTabla=49, tabla="CONFIRMACIONES"},
                new TablaModelo {   idTabla=50, tabla="CONTACTOS"},
                new TablaModelo {   idTabla=51, tabla="CORREOS"},
                new TablaModelo {   idTabla=52, tabla="CORRESPONDENCIAS"},
                new TablaModelo {   idTabla=53, tabla="DEPARTAMENTOS"},
                new TablaModelo {   idTabla=54, tabla="DESIGNACIONES"},
                new TablaModelo {   idTabla=55, tabla="DETALLECONFIRMACIONES"},
                new TablaModelo {   idTabla=56, tabla="DETALLECEDULAS"},
                new TablaModelo {   idTabla=57, tabla="DETALLECRONOGRAMAS"},
                new TablaModelo {   idTabla=58, tabla="DETALLEDOCUMENTOS"},
                new TablaModelo {   idTabla=59, tabla="DETALLEHERRAMIENTAS"},
                new TablaModelo {   idTabla=60, tabla="DETALLEPLANTILLAINDICE"},
                new TablaModelo {   idTabla=61, tabla="DETALLESMAF"},
                new TablaModelo {   idTabla=62, tabla="DETALLETIEMPO"},
                new TablaModelo {   idTabla=63, tabla="ESTRUCTURASORGANICAS"},
                new TablaModelo {   idTabla=64, tabla="FIRMAS"},
                new TablaModelo {   idTabla=65, tabla="FORMULASAPLICADAS"},
                new TablaModelo {   idTabla=66, tabla="HISTORICOSCONTRASENIAS"},
                new TablaModelo {   idTabla=67, tabla="INFORMEACTIVIDADES"},
                new TablaModelo {   idTabla=68, tabla="MARCASESTANDARES"},
                new TablaModelo {   idTabla=69, tabla="MUNICIPIOS"},
                new TablaModelo {   idTabla=70, tabla="NORMATIVAS"},
                new TablaModelo {   idTabla=71, tabla="NOTASCONFIRMACIONES"},
                new TablaModelo {   idTabla=72, tabla="OBLIGACIONESLEGALES"},
                new TablaModelo {   idTabla=73, tabla="OPCIONESROLES"},
                new TablaModelo {   idTabla=74, tabla="ACTIVIDADES"},
                new TablaModelo {   idTabla=75, tabla="AGENDAS"},
                new TablaModelo {   idTabla=76, tabla="PARTIDAS"},
                new TablaModelo {   idTabla=77, tabla="PERMISOSROLESUSUARIOS"},
                new TablaModelo {   idTabla=78, tabla="PLANTILLAS"},
                new TablaModelo {   idTabla=79, tabla="PLANTILLAINDICE"},
                new TablaModelo {   idTabla=80, tabla="RATIOS"},
                new TablaModelo {   idTabla=81, tabla="REPOSITORIO"},
                new TablaModelo {   idTabla=82, tabla="REUNIONES"},
                new TablaModelo {   idTabla=83, tabla="SIMBOLOS"},
                new TablaModelo {   idTabla=84, tabla="SISTEMASCONTABLES"},
                new TablaModelo {   idTabla=85, tabla="TELEFONOS"},
                new TablaModelo {   idTabla=86, tabla="USUARIOAGENDAACCION"},
                new TablaModelo {   idTabla=87, tabla="USUARIOHERRAMIENTASACCION"},
                new TablaModelo {   idTabla=88, tabla="USUARIOMATANALISFINANCACCION"},
                new TablaModelo {   idTabla=89, tabla="USUARIOPROGRAMASACCION"},
                new TablaModelo {   idTabla=90, tabla="USUARIOREQUERIMIENTOSACCION"},
                new TablaModelo {   idTabla=91, tabla="USUARIOREPOSITORIOACCION"},
                new TablaModelo {   idTabla=92, tabla="USUARIOS"},
                new TablaModelo {   idTabla=93, tabla="USUARIOSUMARIASACCION"},
                new TablaModelo {   idTabla=94, tabla="ELEMENTOS"},
                new TablaModelo {   idTabla=95, tabla="MATERIALIDAD"},
                new TablaModelo {   idTabla=96, tabla="CRONOGRAMAS"},
                new TablaModelo {   idTabla=97, tabla="MARCASAUDITORIA"},
                new TablaModelo {   idTabla=98, tabla="MATRIZRIESGOS"},
                new TablaModelo {   idTabla=99, tabla="PROGRAMAS"},
                new TablaModelo {   idTabla=100,    tabla="NOTASPT"},
                new TablaModelo {   idTabla=101,    tabla="CEDULACONTACTOS"},
                new TablaModelo {   idTabla=102,    tabla="DETALLEPROGRAMAS"},
                new TablaModelo {   idTabla=103,    tabla="TIPOSDESCRIPTORES"},
                new TablaModelo {   idTabla=104,    tabla="DETALLEMATRIZRIESGOS"},
                new TablaModelo {   idTabla=105,    tabla="INDICES"},
                new TablaModelo {   idTabla=106,    tabla="DETALLETITULO"},
                new TablaModelo {   idTabla=107,    tabla="TITULOS"},
                new TablaModelo {   idTabla=108,    tabla="FORMULAS"},
                new TablaModelo {   idTabla=109,    tabla="PISTAS"},
                new TablaModelo {   idTabla=110,    tabla="HERRAMIENTAS"},
            };
            return lista;
    }

    #endregion
    }
}
