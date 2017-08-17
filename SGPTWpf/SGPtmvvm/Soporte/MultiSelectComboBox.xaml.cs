using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.ComponentModel;
using SGPTmvvm.Model;
using System.Runtime.CompilerServices;



namespace SGPTmvvm.Soporte
{
    /// <summary>
    /// Interaccion MultiSelectComboBox.xaml ORIGINAL
    /// 
    ///-----Composicion de la clase
    ///
    ///public class DiccioGenericTipoLista
    ///{
    ///    public bool esSeleccionado { get; set; }
    ///    public int id { get; set; }
    ///    public string Id { get; set; }
    ///    public string descripcion { get; set; }
    ///}
    ///-------Para usar este control es necesario bindiar el itemssource con una lista
    ///ListadoParticipantesInternos = new List<DiccioGenericTipoLista>();
        ///foreach (var a in ListadoUsuarios)
        ///{
        ///    DiccioGenericTipoLista di = new DiccioGenericTipoLista();
        ///    di.id = a.idusuario;
        ///    di.descripcion = a.nombreCompleto;
        ///    ListadoParticipantesInternos.Add(di);
        ///}
    ///</summary>
    public partial class MultiSelectComboBox : UserControl
    {
        //private ObservableCollection<Node> _nodeList;
        private ObservableCollection<DiccioGenericTipoLista> _nodeList2;
        public MultiSelectComboBox()
        {
            InitializeComponent();
            //_nodeList = new ObservableCollection<Node>();
            _nodeList2 = new ObservableCollection<DiccioGenericTipoLista>(); 
        }

        #region Dependency Properties

        #region Itemssource2
        public static readonly DependencyProperty ItemsSourceProperty =
                DependencyProperty.Register("ItemsSource", typeof(List<DiccioGenericTipoLista>), typeof(MultiSelectComboBox), new FrameworkPropertyMetadata(null,
           new PropertyChangedCallback(MultiSelectComboBox.OnItemsSourceChanged))); 
        #endregion
        //Fin Prb Itemssource2


        #region SelectedItems2
            public static readonly DependencyProperty SelectedItemsProperty =
            DependencyProperty.Register("SelectedItems", typeof(List<DiccioGenericTipoLista>), typeof(MultiSelectComboBox), new FrameworkPropertyMetadata(null,
            new PropertyChangedCallback(MultiSelectComboBox.OnSelectedItemsChanged)));
        #endregion

        public static readonly DependencyProperty TextProperty =
           DependencyProperty.Register("Text", typeof(string), typeof(MultiSelectComboBox), new UIPropertyMetadata(string.Empty));

        public static readonly DependencyProperty DefaultTextProperty =
            DependencyProperty.Register("DefaultText", typeof(string), typeof(MultiSelectComboBox), new UIPropertyMetadata(string.Empty));


        #region ItemsSource2 prbeli
        public List<DiccioGenericTipoLista> ItemsSource
        {
            get { return (List<DiccioGenericTipoLista>)GetValue(ItemsSourceProperty); }
            set
            {
                SetValue(ItemsSourceProperty, value);
                RaisePropertyChanged("ItemsSource");
            }
        } 
        #endregion


        #region SelectedItems2 prbeli
        public List<DiccioGenericTipoLista> SelectedItems
        {
            get { return (List<DiccioGenericTipoLista>)GetValue(SelectedItemsProperty); }
            set
            {
                SetValue(SelectedItemsProperty, value);
                RaisePropertyChanged("SelectedItems");
            }
        } 
        #endregion

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public string DefaultText
        {
            get { return (string)GetValue(DefaultTextProperty); }
            set { SetValue(DefaultTextProperty, value); }
        }
        #endregion

        #region Events
        private static void OnItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MultiSelectComboBox control = (MultiSelectComboBox)d;
            control.MostrarEnControl();
        }

        private static void OnSelectedItemsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MultiSelectComboBox control = (MultiSelectComboBox)d;
            control.NodosSeleccionados();
            control.SetearLeyenda();
        }

        private void CheckBox2_Click(object sender, RoutedEventArgs e)
        {
            CheckBox clickedBox = (CheckBox)sender;
            //******sacare que selecciono*****/
            String queSelecciono = clickedBox.Content.ToString();
            if (queSelecciono == "Todos")
            {
                if (clickedBox.IsChecked.Value)
                {
                    foreach (DiccioGenericTipoLista node in _nodeList2)
                    {
                        node.esSeleccionado = true;
                    }
                }
                else
                {
                    foreach (DiccioGenericTipoLista node in _nodeList2)
                    {
                        node.esSeleccionado = false;
                    }
                }
                
            }
            else
            {
                /*Introducire aqui el registro seleccionado 06122016*/

                if (clickedBox.IsChecked.Value)
                {
                    _nodeList2.FirstOrDefault(i => i.descripcion == queSelecciono).esSeleccionado = true;
                }
                else
                {
                    _nodeList2.FirstOrDefault(i => i.descripcion == queSelecciono).esSeleccionado = false;
                }
                /**Fin**/

                int _selectedCount = 0;
                foreach (DiccioGenericTipoLista s in _nodeList2)
                {
                    if (s.esSeleccionado && s.descripcion != "Todos")
                        _selectedCount++;
                }
                if (_selectedCount == _nodeList2.Count - 1)
                    _nodeList2.FirstOrDefault(i => i.descripcion == "Todos").esSeleccionado = true;
                else
                    _nodeList2.FirstOrDefault(i => i.descripcion == "Todos").esSeleccionado = false;
            }
            MultiSelectCombo.ItemsSource = null;
            MultiSelectCombo.ItemsSource = _nodeList2;
            RaisePropertyChanged();

            SetearItemsSeleccionados();
            SetearLeyenda();

        }
        #endregion


        #region Metodos

        private void NodosSeleccionados()
        {
            //foreach (KeyValuePair<string, object> keyValue in SelectedItems) *////////////////ojo aqui
                foreach (DiccioGenericTipoLista keyvalue in SelectedItems)
            {
                ////Node node = _nodeList.FirstOrDefault(i => i.Title == keyValue.Key);
                DiccioGenericTipoLista node = _nodeList2.FirstOrDefault(i => i.descripcion == keyvalue.descripcion);
                if (node != null)
                    node.esSeleccionado = true;
            }
                RaisePropertyChanged();
        }

        private void SetearItemsSeleccionados()
        {
            //if (SelectedItems == null)
            SelectedItems = new List<DiccioGenericTipoLista>();
            //SelectedItems2.Clear();
            foreach (DiccioGenericTipoLista node in _nodeList2)
            {
                //if (node.esSeleccionado && node.descripcion != "Todos")
                if (node.esSeleccionado)
                {
                    if (this.ItemsSource.Count > 0)

                        SelectedItems.Add(node);
                }
            }
            RaisePropertyChanged("SelectedItems");
            RaisePropertyChanged();
        }

        private void MostrarEnControl()
        {
            StringBuilder displayText = new StringBuilder();
            if (this.ItemsSource.Count > 0)
            {
                DiccioGenericTipoLista kl = new DiccioGenericTipoLista();
                kl.Id = "0";
                kl.descripcion = "Todos";

                _nodeList2.Add(kl);
            }
            int g = 0;
            foreach (DiccioGenericTipoLista keyValue in this.ItemsSource)
            {
                if (keyValue.esSeleccionado == true)
                {
                    displayText.Append(keyValue.descripcion);
                    displayText.Append(',');
                    g++;
                }
                _nodeList2.Add(keyValue);
            }
            MultiSelectCombo.ItemsSource = _nodeList2;
            if(g>0)
                this.Text = displayText.ToString().TrimEnd(new char[] { ',' });
            else
                this.Text = this.DefaultText;
                
            RaisePropertyChanged();
        }


        private void SetearLeyenda()
        {
            if (this.SelectedItems != null || this.SelectedItems.Count>0)
            {
                StringBuilder displayText = new StringBuilder();
                foreach (DiccioGenericTipoLista s in _nodeList2)
                {
                    if (s.esSeleccionado == true && s.descripcion == "Todos")
                    {
                        displayText = new StringBuilder();
                        displayText.Append("Todos");
                        break;
                    }
                    else if (s.esSeleccionado == true && s.descripcion != "Todos")
                    {
                        displayText.Append(s.descripcion);
                        displayText.Append(',');
                    }
                }
                this.Text = displayText.ToString().TrimEnd(new char[] { ',' });
            }
            if (string.IsNullOrEmpty(this.Text))
            {
                this.Text = this.DefaultText;
            }
        }

        #endregion
        #region Eventos
            public event PropertyChangedEventHandler PropertyChanged;
            public void RaisePropertyChanged([CallerMemberName] String propertyName = "")
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            } 
        #endregion
    }


}
