using System.Web;
using System.Web.Optimization;

namespace IKSnet
{
    public class BundleConfig
    {
        // Weitere Informationen zur Bündelung finden Sie unter https://go.microsoft.com/fwlink/?LinkId=301862.
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Verwenden Sie die Entwicklungsversion von Modernizr zum Entwickeln und Erweitern Ihrer Kenntnisse. Wenn Sie dann
            // bereit ist für die Produktion, verwenden Sie das Buildtool unter https://modernizr.com, um nur die benötigten Tests auszuwählen.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            //Include Scripts für Template
            bundles.Add(new ScriptBundle("~/bundles/jquerytheme").Include(
                      "~/Content/dist/js/adminlte.js",
                      "~/Content/bower_components/jquery/dist/jquery.js",
                      "~/Content/bower_components/bootstrap/dist/js/bootstrap.js",
                      "~/Content/bower_components/fastclick/lib/fastclick.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/csstheme").Include(
                      "~/Content/bower_components/bootstrap/dist/css/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/dist/css/AdminLTE.css",
                      "~/Content/bower_components/font-awesome/css/font-awesome.css",
                      "~/Content/bower_components/Ionicons/css/ionicons.min.css",
                      "~/Content/bower_components/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css",
                      "~/Content/dist/css/skins/skin-blue.css"));
        }
    }
}
