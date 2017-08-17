//https://code.msdn.microsoft.com/windowsdesktop/Handling-Unhandled-47492d0b

using GalaSoft.MvvmLight.Threading;
using MahApps.Metro.Controls;
using SGPTWpf.SGPtWpf.Support;
using SGPTWpf.SGPtWpf.Views.Compartidas;
using SGPTWpf.ViewModel;
using SGPTWpf.Views;
using SGPTWpf.Views.Compartidas;
using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Threading;
using UnhandledExceptionHandler.Helpers;

namespace SGPTWpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private PrincipalAlterna window;
        private InicialView windowInicial;
       // private LoguinView loguin;
        bool isApplicationActive;
        public App() : base()
        {
            //Startup += new StartupEventHandler(App_Startup); // Can be called from XAML
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-SV");
            //https://social.msdn.microsoft.com/Forums/vstudio/en-US/b4bb430b-b3bd-4a73-8d96-6959558214f4/thai-thth-culture-of-datepicker-control-in-wpf-is-not-working?forum=wpf
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-SV");
            FrameworkElement.LanguageProperty.OverrideMetadata(
                            typeof(FrameworkElement),
                            new FrameworkPropertyMetadata(
                                XmlLanguage.GetLanguage("es-SV")));
            DispatcherHelper.Initialize();

        }

        void App_Activated(object sender, EventArgs e)
        {
            // Application activated
            this.isApplicationActive = true;
        }

        void App_Deactivated(object sender, EventArgs e)
        {
            // Application deactivated
            this.isApplicationActive = false;
        }
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //Startup += new StartupEventHandler(App_Startup); // Can be called from XAML

        }
        /// <summary>
        /// Called when the application starts.
        /// </summary>
        /// <param name="e">The event arguments.</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            this.windowInicial = new InicialView();
            // Read the position settings and position the window accordingly.
            OptionsViewModel options = new OptionsViewModel();
            windowInicial.DataContext = new InicialViewModel();
            options.Dispose();
            windowInicial.Show();
        }

         private void App_OnExit(object sender, ExitEventArgs e)
        {
            // Save the position settings.
            OptionsViewModel options = new OptionsViewModel();
            options.Left = this.window.Left;
            options.Top = this.window.Top;
            options.Width = this.window.ActualWidth;
            options.Height = this.window.ActualHeight;
            options.Save();
            options.Dispose();
        }


       /*static App()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-SV");
            //https://social.msdn.microsoft.com/Forums/vstudio/en-US/b4bb430b-b3bd-4a73-8d96-6959558214f4/thai-thth-culture-of-datepicker-control-in-wpf-is-not-working?forum=wpf
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-SV");
            FrameworkElement.LanguageProperty.OverrideMetadata(
                            typeof(FrameworkElement),
                            new FrameworkPropertyMetadata(
                                XmlLanguage.GetLanguage("es-SV")));
            DispatcherHelper.Initialize();


        }*/


        /*
         Log log = Log.GetInstance();

             public App()
             {
                 Startup += new StartupEventHandler(App_Startup); // Can be called from XAML

                // DispatcherUnhandledException += App_DispatcherUnhandledException; //Example 2

                // TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException; //Example 4

                 System.Windows.Forms.Application.ThreadException += WinFormApplication_ThreadException; //Example 5
             //https://cmasdev.wordpress.com/2014/07/11/wpf-atrapar-errores-a-nivel-de-aplicacion/

             this.DispatcherUnhandledException += App_DispatcherUnhandledException;

             AppDomain currentDomain = AppDomain.CurrentDomain;
             currentDomain.UnhandledException += new UnhandledExceptionEventHandler(Exception_AppDomain);

             Application.Current.Dispatcher.UnhandledException += Dispatcher_UnhandledException;

             TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;

             Thread.CurrentThread.CurrentCulture = new CultureInfo("es-SV");
             //https://social.msdn.microsoft.com/Forums/vstudio/en-US/b4bb430b-b3bd-4a73-8d96-6959558214f4/thai-thth-culture-of-datepicker-control-in-wpf-is-not-working?forum=wpf
             Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-SV");
             FrameworkElement.LanguageProperty.OverrideMetadata(
                             typeof(FrameworkElement),
                             new FrameworkPropertyMetadata(
                                 XmlLanguage.GetLanguage("es-SV")));
           }

         void App_Startup(object sender, StartupEventArgs e)
             {
                 //Here if called from XAML, otherwise, this code can be in App()
                 AppDomain.CurrentDomain.FirstChanceException += CurrentDomain_FirstChanceException; // Example 1
                 AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException; // Example 3
             }

             // Example 1
             void CurrentDomain_FirstChanceException(object sender, System.Runtime.ExceptionServices.FirstChanceExceptionEventArgs e)
             {
                 MessageBox.Show("1. CurrentDomain_FirstChanceException "+ e.Exception.Message);
                 //ProcessError(e.Exception);   - This could be used here to log ALL errors, even those caught by a Try/Catch block
             }

             // Example 2
             void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
             {
                 MessageBox.Show("2. App_DispatcherUnhandledException "+e.Exception.Message);
                 log.ProcessError(e.Exception);
                 e.Handled = true;
             }

             // Example 3
             void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
             {
                 MessageBox.Show("3. CurrentDomain_UnhandledException");
                 var exception = e.ExceptionObject as Exception;
                 log.ProcessError(exception);
                 if (e.IsTerminating)
                 {
                     //Now is a good time to write that critical error file!
                     MessageBox.Show("Goodbye world!");
                 }
             }

             // Example 4
             void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
             {
                 MessageBox.Show("4. TaskScheduler_UnobservedTaskException " + e.Exception.Message);
                 log.ProcessError(e.Exception);
                 e.SetObserved();
             }

             // Example 5
             void WinFormApplication_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
             {
                 MessageBox.Show("5. WinFormApplication_ThreadException "+ e.Exception.Message);
                 log.ProcessError(e.Exception);
             }

         //https://cmasdev.wordpress.com/2014/07/11/wpf-atrapar-errores-a-nivel-de-aplicacion/

         //private void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
         //{
         //    this.ShowError(e.Exception);
         //    //Prevent default unhandled exception processing
         //    e.Handled = true;
         //}

         private void Dispatcher_UnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
         {
             this.ShowError(e.Exception);

             // Prevent default unhandled exception processing
             e.Handled = true;
         }

         private void Exception_AppDomain(object sender, UnhandledExceptionEventArgs e)
         {
             this.ShowError(e.ExceptionObject as Exception);
         }

         //private void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
         //{
         //    this.ShowError(e.Exception);
         //}
         private void ShowError(Exception ex)
         {
             if (ex != null)
             {
                 //Show error in a message
                 MessageBox.Show(ex.Message);
             }
         }*/
    }
    }
/*Description
This project contains everything you need to handle just about every unhandled exception in WPF.
 
1. AppDomain.CurrentDomain.FirstChanceException
This is new to .Net 4 and is extremely useful for ensuring that you ALWAYS log SOMETHING. Whenever any kind of exception is fired in your application, a FirstChangeExcetpion is raised, even if the exception was within a Try/Catch block and safely handled. This is GREAT for logging every wart and boil, but can often result in too much spam, if your application has a lot of expected/handled exceptions. In this example, because this handler is active, it will fire for every example, before the other handler reacts.
 
2. Application.DispatcherUnhandledException
This is the main exception event for most application unhandled exceptions. It also has a Handled property with which you can try to recover and continue after the exception.
 
3. AppDomain.CurrentDomain.UnhandledException
Although Application.DispatcherUnhandledException covers most issues in the current AppDomain, in extremely rare circumstances, you may be running a thread on a second AppDomain. This event conveys the other AppDomain unhandled exception, but there are no Handled property, just an IsTerminating flag.
 
4. TaskScheduler.UnobservedTaskException
If you are using Tasks, then you may have "unobserved task exceptions". This event allows you to trap them. It also has a method called SetObserved, which allows you to try to recover from the issue.
 
5. System.Windows.Forms.Application.ThreadException
If you are hosting any WinForm componants in your WPF application, this final event is one to watch. There's no way to influence events thereafter, but at least you get to see what the problem was.
 
Logging Exceptions and Inner Exceptions.
Inner exceptions are very commonly used in WPF, as XAML errors (like missing resources) are often more meaningfully detailed in the Inner Exception. All of the event handlers for the events above use one logging function, shown below:
*/