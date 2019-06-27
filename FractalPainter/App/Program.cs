using System;
using System.Windows.Forms;
using FractalPainting.App.Actions;
using FractalPainting.App.Fractals;
using FractalPainting.Infrastructure.Common;
using FractalPainting.Infrastructure.UiActions;
using Ninject;
using Ninject.Extensions.Factory;
using Ninject.Extensions.Conventions;

namespace FractalPainting.App
{
    internal static class Program
    {
        /// <summary>
        /// he main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            try
            {
                var container = new StandardKernel();

                container.Bind(x => x.FromThisAssembly().SelectAllClasses().InheritedFrom<IUiAction>().BindAllInterfaces());
                container.Bind<IImageHolder, PictureBoxImageHolder>().To<PictureBoxImageHolder>().InSingletonScope();
                container.Bind<Palette>().ToConstant(new Palette());
                container.Bind<IDragonPainterFactory>().ToFactory();
                container.Bind<IObjectSerializer>().To<XmlObjectSerializer>();
                container.Bind<IBlobStorage>().To<FileBlobStorage>();
                container.Bind<AppSettings, IImageDirectoryProvider>().ToMethod(cnt => cnt.Kernel.Get<SettingsManager>().Load());
                
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(container.Get<MainForm>());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}