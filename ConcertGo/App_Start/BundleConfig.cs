using System.Web.Optimization;

namespace ConcertGo
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                        "~/Scripts/jquery-3.1.1.min.js", // todo version.
                        "~/Scripts/uikit.min.js",
                        "~/Scripts/uikit-icons.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/forms").Include(
                        "~/Scripts/jquery.validate.*",
                        "~/Scripts/geohash.js"));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                        "~/Content/uikit.min.css",
                        "~/Content/core.css"));
        }
    }
}
