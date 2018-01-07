using System.Web.Optimization;

namespace StudyLab
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
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootbox.js",
                      "~/Scripts/jasny-bootstrap.js",
                      "~/Scripts/toastr.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/questions").Include(
                "~/Scripts/questions.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/messages").Include(
                "~/Scripts/messages.js",
                "~/Scripts/moment.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/avatar").Include(
                "~/Scripts/avatar.js",
                "~/Scripts/jquery.unobtrusive-ajax.js"
            ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap-united.css",
                      "~/Content/toastr.css",
                      "~/Content/bootstrap-social.css",
                      "~/Content/jasny-bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
