using System.Web;
using System.Web.Optimization;

namespace MonsterValueCrew
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));


            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.

            bundles.Add(new StyleBundle("~/Content/materializeCSS").Include(
                        "~/Content/materialize.css",
                        "~/Content/site.css",
                        "~/Content/dropzone.css",
                        "~/Content/basic.css"));

            bundles.Add(new ScriptBundle("~/bundles/materializeJS").Include(
                        "~/Scripts/materialize.js",
                        "~/Scripts/init.js",
                        "~/Scripts/dropzone.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryajax").Include(
                "~/Scripts/jquery.unobtrusive-ajax.js"));
        }
    }
}
