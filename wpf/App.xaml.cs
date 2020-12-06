using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using DAL.Interface;
using DAL.Concrete;
using Bll.Concrete;
using Bll.interfaces;
using Wpf.Windows;
using Unity;

namespace Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IUnityContainer Container;


        protected override void OnStartup(StartupEventArgs e)
        {

            Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;

            base.OnStartup(e);

           RegisterUnity();

            Container.RegisterInstance(ConfigurationManager.ConnectionStrings["IMDB"].ConnectionString);

            //Login lf = Container.Resolve<Login>();
            //bool result = lf.ShowDialog() ?? false;
            //if (result)
            //{
            //    PersonList ol = Container.Resolve<PersonList>();
            //    Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
            //    Current.MainWindow = ol;
            //    ol.Show();
            //}
            //else
            //{
            //    Current.Shutdown();
            //}
            PersonList ol = Container.Resolve<PersonList>();
            Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
            Current.MainWindow = ol;
            ol.Show();
        }

        private void RegisterUnity()
        {
            Container = new UnityContainer().AddExtension(new Diagnostic());

            Container.RegisterType<IAdminDAL, AdminDAL>()
                .RegisterType<IPersonDAL, PersonDAL>()
                .RegisterType<IRoleDAL, RoleDAL>()
                .RegisterType<IUserDAL, UserDAL>()
                .RegisterType<IAuthManager, AuthManager>()
                .RegisterType<IPersonManager, PersonManager>();
        }
    }

}
