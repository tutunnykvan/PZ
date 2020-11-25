using Bll.interfaces;
using Bll.Concrete;
using DAL.Interface;
using DAL.Concrete;
using WindowsForms.AppSettings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using System.Configuration;

namespace WindowsForms
{
    static class Program
    {
        public static AppDataManager SettingsManager;
        public static UnityContainer Container;

        
        [STAThread]
        static void Main()
        {
            ConfigureUnity();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           
            SettingsManager = new AppDataManager();
            
            Form1 lf = Container.Resolve<Form1>();
           

            if (lf.ShowDialog() == DialogResult.OK)
            {
                Application.Run(Container.Resolve<Form2>());
            }
            else
            {
                Application.Exit();
            }

        }

        private static void ConfigureUnity()
        {
            Container = new UnityContainer();
           
            Container.RegisterType<IPersonDAL, PersonDAL>()
                .RegisterType<IUserDAL, UserDAL>()
                .RegisterType<IRoleDAL, RoleDAL>()
                .RegisterType<IAdminDAL, AdminDAL>()
                .RegisterType<IAuthManager, AuthManager>()
                .RegisterType<IPersonManager, PersonManager>();
        }
    }
}
