using GalaSoft.MvvmLight;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace SGPTWpf.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    /// Se crea una clase para ampliar los métodos de ViewModelBase incluidos en la biblioteca de Galasoft
    /// Fuente: http://social.technet.microsoft.com/wiki/contents/articles/13536.easy-mvvm-examples-in-extreme-detail.aspx
    public abstract class ViewModeloBase : ViewModelBase, INotifyPropertyChanged,IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelBase class.
        /// </summary>
        //08-05-2017**************
        //public new  event PropertyChangedEventHandler PropertyChanged = delegate { };
        //**********************

        public ViewModeloBase()
        {
        }



        //Extra Stuff, shows why a base ViewModel is useful
        bool? _CloseWindowFlag;
        public bool? CloseWindowFlag
        {
            get { return _CloseWindowFlag; }
            set
            {
                _CloseWindowFlag = value;
                RaisePropertyChanged("CloseWindowFlag");
            }
        }

        public virtual void CloseWindow(bool? result = true)
        {
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
            {
                CloseWindowFlag = CloseWindowFlag == null
                    ? true
                    : !CloseWindowFlag;
                Mouse.OverrideCursor = null;
            }));
        }

        //08-05-2017***************************************************
        //Tomadode  curso  10261A Developin Windows Applicacion  with Microsoft capitulo 14 ejercicio
        //AdventureWorks.WorkOrders.Views
        ~ViewModeloBase()
        {
            this.Dispose(false);
            //Debug.Fail("No se puede eliminar el modelo de vista modelo.");
        }
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
        }

        /*protected virtual void OnPropertyChanged(string propertyName)
        {
            this.EnsureProperty(propertyName);
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }*/

        [Conditional("DEBUG")]
        private void EnsureProperty(string propertyName)
        {
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
            {
                throw new ArgumentException("Property does not exist.", "propertyName");
            }
        }
        //*******************************************************************************

    }
}