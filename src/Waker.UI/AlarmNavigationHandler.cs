using Waker.Aplication.Handlers;

namespace Waker.UI
{
    public class BlazorNavigationHandler : INavigationHandler
    {
        public void NavigateToStop() => NavigationService.NavigateTo(Url.Stop);
    }
}
