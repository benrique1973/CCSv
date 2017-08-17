using WindowFactoryNamespace.Helpers;

namespace SGPTWpf.Model
{
#pragma warning disable CS0436 // El tipo entra en conflicto con un tipo importado
    public class MainModel : NotificationObject
#pragma warning restore CS0436 // El tipo entra en conflicto con un tipo importado
    {
        #region TypeName

        private string _typeName = null;

        public string TypeName
        {
            get
            {
                return _typeName;
            }

            set
            {
                _typeName = value;
                NotifyPropertyChanged("TypeName");
            }
        }

        #endregion
    }
}