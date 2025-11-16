namespace Waker.UI.Components.Molecules
{
    public partial class ModalWindow
    {
        private Module? _module;

        private partial async Task InitializeJS()
        {
            _module = await JSInterop.GetModule("modal");
        }

        private partial async Task Show(string id)
        {
            if (_module is not null)
            {
                await _module.CallScript("show", id);
            }
        }

        private partial async Task Hide(string id)
        {
            if (_module is not null)
            {
                await _module.CallScript("hide", id);
            }
        }
    }
}
