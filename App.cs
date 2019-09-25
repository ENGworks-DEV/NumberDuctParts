using Autodesk.Revit.UI;
using System;
using System.IO;
using System.Reflection;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace NumberDuctParts
{
    internal class App : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication application)
        {
            string ExecutingAssemblyPath = Assembly.GetExecutingAssembly().Location;
            RibbonPanel m_projectPanel = application.CreateRibbonPanel("NumberDuctParts");
            PushButton pushButton = m_projectPanel.AddItem(new PushButtonData("NumberDuctParts", 
                "NumberDuctParts", ExecutingAssemblyPath, 
                "NumberDuctParts.NumberMain")) as PushButton;
            pushButton.ToolTip = "NumberParts";
            pushButton.LongDescription = "This addin helps you to renumber MEP part with a prefix";
            pushButton.LargeImage = this.PngImageSource("NumberDuctParts.Resources.NumberDuctPartsLogo.png");
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string newpath = Path.GetFullPath(Path.Combine(path, "..\\"));
            ContextualHelp contextHelp = new ContextualHelp(ContextualHelpType.Url, "https://engworks.com/renumber-parts/");
            pushButton.SetContextualHelp(contextHelp);
            return Result.Succeeded;
        }

        private ImageSource PngImageSource(string embeddedPath)
        {
            Stream stream = base.GetType().Assembly.GetManifestResourceStream(embeddedPath);
            PngBitmapDecoder decoder = new PngBitmapDecoder(stream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            return decoder.Frames[0];
        }

        public Result OnShutdown(UIControlledApplication a)
        {
            return Result.Succeeded;
        }
    }
}
