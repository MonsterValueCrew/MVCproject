using System.Web.Optimization;

namespace MonsterValueCrew
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/materializeCSS").Include(
                        "~/Content/materialize.css",
                        "~/Content/basic.css",
                        "~/Content/site.css",
                        "~/Content/jquery.dataTables.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));
                        
            bundles.Add(new ScriptBundle("~/bundles/materializeJS").Include(
                        "~/Scripts/materialize.js",
                        "~/Scripts/init.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jquery.dataTables").Include(
                        "~/Scripts/jquery.dataTables.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryajax").Include(
                        "~/Scripts/jquery.unobtrusive-ajax.js"));
        }
    }
}
