using MahApps.Metro.Controls;
using SGPTWpf.ViewModel.Encargos.Edicion;
using System;
using System.Data;
using System.Windows.Controls;

namespace SGPTWpf.Views.Principales.Encargos.Gestion
{
    public partial class EncargosEdicionView : MetroWindow
    {
        public EncargosEdicionView()
        {
            InitializeComponent();
            var errors = GrdDatosCuerpo.GetValue(Validation.ErrorsProperty);
        }

        //private DataRowView rowBeingEdited = null;
        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added) EdicionEncargoCrudControllerViewModel.Errors += 1;
            if (e.Action == ValidationErrorEventAction.Removed) EdicionEncargoCrudControllerViewModel.Errors -= 1;
        }

        /*private void dataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            DataRowView rowView = e.Row.Item as DataRowView;
            rowBeingEdited = rowView;
        }*/

        //private void dataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        //{
        //    DataRowView rowView = e.Row.Item as DataRowView;
        //    e.Row.Item.ToString
        //    rowBeingEdited = rowView;
        //}
        //private void dataGrid_CurrentCellChanged(object sender, EventArgs e)
        //{
        //    if (rowBeingEdited != null)
        //    {
        //        rowBeingEdited.EndEdit();
        //    }
        //}
    }
}
