using GalaSoft.MvvmLight.CommandWpf;
using SGPTWpf.Model;
using System.Configuration;
using System;
using System.Threading.Tasks;
using MahApps.Metro.Controls.Dialogs;
using System.Linq;
using System.IO;
using System.Windows;

namespace SGPTWpf.ViewModel
{
    public class InicialViewModel : ViewModeloBase
    {
        private static InicialViewModel inicialViewModel;
        private DialogCoordinator dlg;

        #region InicialMainModel

        private MainModel _InicialMainModel = null;


        public MainModel InicialMainModel
        {
            get
            {
                return _InicialMainModel;
            }

            set
            {
                _InicialMainModel = value;
            }
        }


        #endregion

        #region ViewModel Commands

        public RelayCommand FacebookCommand { get; set; }
        public RelayCommand TwitterCommand { get; set; }

        public RelayCommand GoogleCommand { get; set; }
        public RelayCommand LoguinCommand { get; set; }

        #endregion

        #region ViewModel Public Methods
        public static InicialViewModel SharedViewModel()
        {
            return inicialViewModel ?? (inicialViewModel = new InicialViewModel());
        }
        public void Facebook()
        {
            System.Diagnostics.Process.Start("https://www.facebook.com");
        }

        public void Twitter()
        {
            System.Diagnostics.Process.Start("https://www.twitter.com");
        }

        private void Google()
        {
            System.Diagnostics.Process.Start("https://www.google.com");
        }

        private void Loguin()
        {
            InicialMainModel.TypeName = "LoguinView";
            CloseWindow();
        }

        #endregion

        #region Protected Methods

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                base.Dispose(disposing);
            }
            //das.ServiceDispose();
        }

        #endregion

        #region ViewModel Private Methods

        private void RegisterCommands()
        {
            FacebookCommand = new RelayCommand(Facebook);
            TwitterCommand = new RelayCommand(Twitter);
            GoogleCommand = new RelayCommand(Google);
            LoguinCommand = new RelayCommand(Loguin);
        }

        #endregion

        public InicialViewModel()
        {
            dlg = new DialogCoordinator();
            RegisterCommands();
            InicialMainModel = new MainModel();
            this.VerificarCadenaConexion();
        }

        private async void VerificarCadenaConexion()
        {
            string path = @"c:\sgptArchivos\IpServidor.txt";

            if (File.Exists(path))
            {
                #region +
                string leerTextConexion = File.ReadAllText(path);
                string[] ltc = leerTextConexion.Split(';');
                if (ltc.Count() == 2)
                {
                    string Usr = "sgpt";
                    string Psw = "sgpt2016";
                    //string Psw = ltc[0];
                    string ip = ltc[0]; //"localhost"; //ec2-54-242-235-149.compute-1.amazonaws.com
                    int pto = 5432;
                    await Task.Delay(1);
                    bool cambioCadena = await CambiarCadenaConexionx(Usr.Trim(), Psw.Trim(), ip.Trim(), pto); //CambiarCadenaConexion.CambiarCadenaConexionx(Usr.Trim(), Psw.Trim(), ip.Trim(), pto);
                    ConfigurationManager.RefreshSection("connectionStrings");
                    await Task.Delay(1);
                    //bool cambioCadena = false;
                    if (cambioCadena)
                        MessageBox.Show("Se cambio una conexion existente a: " + ip);
                    //await AvisaYCerrateVosSolo("Se cambio una conexion", "", 1);
                    else
                        MessageBox.Show("No fue posible cambiar la conexion existente a: " + ip);
                    //await AvisaYCerrateVosSolo("Noooo fue posible cambiar la conexion", "", 1);
                } 
                #endregion
            }
        }

        public async Task<bool> CambiarCadenaConexionx(string Usr, string Psw, string ip, int pto)
        {
            try
            {
                #region +
                //<add name="SGPTEntidades" connectionString="metadata=res://*/Modelo.csdl|res://*/Modelo.ssdl|res://*/Modelo.msl;provider=Npgsql;provider connection string=&quot;Application Name=SGPT;Database=SGPT;Host=ec2-54-242-235-149.compute-1.amazonaws.com;Password=Pa$$w0rd;Username=programador3&quot;" providerName="System.Data.EntityClient" />
                //<add name="SGPTEntidades" connectionString="metadata=res://*/Modelo.csdl|res://*/Modelo.ssdl|res://*/Modelo.msl;provider=Npgsql;provider connection string=&quot;Application Name=SGPT;Database=SGPT;Host=localhost;Password=sgpt2016;Username=sgpt&quot;" providerName="System.Data.EntityClient" /> //asi debe de quedar
                //<add name="SGPTEntidades" connectionString="metadata=res://*/Modelo.csdl|res://*/Modelo.ssdl|res://*/Modelo.msl;provider=Npgsql;provider connection string=&quot;Application Name=SGPT;Database=SGPT;Host=localhost;Password=sgpt2016;Username=sgpt&quot;" providerName="System.Data.EntityClient" />

                var cnSection = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                String connString = cnSection.ConnectionStrings.ConnectionStrings["SGPTEntidades"].ConnectionString;
                //String connStringx = connString;
                //connString = changeConnStringItem(connString, "provider connection string=\"data source", cp.DataSource);
                connString = changeConnStringItem(connString, "Host", ip);
                connString = changeConnStringItem(connString, "Username", Usr);
                connString = changeConnStringItem(connString, "Password", Psw);
                //connString = changeConnStringItem(connString, "initial catalog", cp.InitCatalogue);
                //connString = changeConnStringItem(connString, "database", cp.InitCatalogue);
                cnSection.ConnectionStrings.ConnectionStrings["SGPTEntidades"].ConnectionString = connString.Trim();
                cnSection.ConnectionStrings.ConnectionStrings["SGPTEntidades"].ProviderName = "System.Data.EntityClient";
                cnSection.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("connectionStrings");
                await Task.Delay(1);
                return true;
                #endregion
            }
            catch (Exception)
            {
                return false;
            }
        }


        private static String changeConnStringItem(string connString, string option, string value)
        {
            String[] conItems = connString.Split(';');
            String result = "";
            foreach (String item in conItems)
            {
                if (item.StartsWith(option))
                {
                    //result += option + "=" + value + ";";
                    if (item.StartsWith("Username"))
                        result += option + "=" + value + "\"";
                    else
                        result += option + "=" + value + ";";
                }
                else
                {
                    if (item.StartsWith("Username"))
                        result += item;
                    else
                        result += item + ";";
                }
            }
            return result;
        }
        //private Task AvisaYCerrateVosSolo(string v1, string v2, int v3)
        //{
        //    throw new NotImplementedException();
        private async Task AvisaYCerrateVosSolo(string titulo, string contenido, int segundos)
        {
            await Task.Delay(segundos);
            var dialog = new CustomDialog()
            {
                Title = titulo,
                Content = contenido,
                DialogMessageFontSize = 12,
            };
            await dlg.ShowMetroDialogAsync(this, dialog);

            await Task.Delay(segundos * 1000);
            await dlg.HideMetroDialogAsync(this, dialog);
        }

    }
}