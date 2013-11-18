using Ch.Epyx.WindMobile.WP8.Resources;

namespace Ch.Epyx.WindMobile.WP8
{
    /// <summary>
    /// Provides access to string resources.
    /// </summary>
    public class LocalizedStrings
    {
        private static AppResources _localizedResources = new AppResources();

        public AppResources LocalizedResources { get { return _localizedResources; } }

        public string PivotHeaderNow { get { return AppResources.PivotHeaderNow; } }
    }
}