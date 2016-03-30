using System.Web.Optimization;

namespace MainSite.App_Start
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = false;

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                        "~/Scripts/jquery-{version}.js",                        
                        "~/Scripts/jquery.easing.1.3.js",
                        //"~/Scripts/jquery.flexslider.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/default.js"
                        ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/styles").Include(                                
                "~/Content/css/bootstrap.css",
                "~/Content/css/style.css"
                //"~/Content/css/flexslider.css"
                ));
                       
        }
    }
}