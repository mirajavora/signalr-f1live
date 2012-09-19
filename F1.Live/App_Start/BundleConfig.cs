using System.Web.Optimization;

namespace F1.Live.App_Start
{
    public static class BundleConfig
    {
         public static void RegisterBundles(BundleCollection bundles)
         {
             var jsBase = new ScriptBundle("~/Scripts/base.js")
                 .Include("~/Scripts/jquery-1.7.2.min.js", "~/Scripts/bootstrap.min.js", "~/Scripts/jsrender.js");


             var projectBundle = new ScriptBundle("~/Scripts/project.js")
                 .IncludeDirectory("~/Scripts/Project", "*.js", false);

             var cssBase = new StyleBundle("~/Styles/base.css")
                 .Include("~/Styles/bootstrap.min.css", "~/Styles/bootstrap-responsive.min.css", "~/Styles/skin.css");

             bundles.Add(jsBase);
             bundles.Add(projectBundle);
             bundles.Add(cssBase);
         }
    }
}