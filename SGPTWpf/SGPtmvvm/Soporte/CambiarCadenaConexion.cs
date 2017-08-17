using System;
using System.Configuration;
using System.Threading.Tasks;

namespace SGPTWpf.SGPtmvvm.Soporte
{
    public class CambiarCadenaConexion
    {
        public CambiarCadenaConexion() { }
        public static bool CambiarCadenaConexionx(string Usr, string Psw, string ip, int pto)
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
                Task.Delay(1);
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
                        result += option + "=" + value+ "\"";
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
    }

    
}
