
namespace SGPTmvvm.Mensajes
{
    class UsuarioMensaje
    {
        public string Mensaje { get; set; }
        public enum TipoComando
        {
            Insertar,
            Editar,
            Eliminar,
            Guardar,
            Refrescar,
            ExportarExcel,
            ExportarWord,
            ExportarPDF
        }
    }
}
