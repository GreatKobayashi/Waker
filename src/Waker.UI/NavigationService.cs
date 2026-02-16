using Microsoft.AspNetCore.Components;

namespace Waker.UI
{
    public static class NavigationService
    {
        public static readonly Dictionary<Url, string> _urlKeyValuePairs = new() { { Url.Home, "/" }, { Url.Stop, "/stop" } };
        private static readonly string _reloadQuery = "reload=1";

        private static string _redirectURL = "";
        private static NavigationManager? _navigationManager;

        public static void Initialize(NavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
        }

        public static async Task DelayReload()
        {
            await Task.Delay(700);
            if (_navigationManager is not null)
            {
                _navigationManager.NavigateTo($"/?{_reloadQuery}", true);
            }
        }

        public static void NavigateTo(Url url)
        {
            _navigationManager?.NavigateTo(_urlKeyValuePairs[url], true);
        }

        public static void Redirect()
        {
            if (_redirectURL != "" && _navigationManager is not null)
            {
                _navigationManager.NavigateTo(_redirectURL);
                _redirectURL = "";
            }
        }

        public static void SetRedirectUrl(Url url)
        {
            _redirectURL = _urlKeyValuePairs[url];
        }
    }

    public enum Url
    {
        Stop, Home
    }
}
