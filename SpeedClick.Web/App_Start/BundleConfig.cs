using System.Web;
using System.Web.Optimization;

namespace SpeedClick.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Scripts
            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                        "~/Scripts/jquery.js",
                        "~/Scripts/bootstrap.min.js"));

            // Style
            bundles.Add(new StyleBundle("~/bundles/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/site.css",
                      "~/font-awesome/css/font-awesome.min.css"));
        }
    }
}
