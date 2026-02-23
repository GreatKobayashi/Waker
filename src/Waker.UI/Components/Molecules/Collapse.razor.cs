namespace Waker.UI.Components.Molecules
{
    public partial class Collapse
    {
        private Module? _module;

        private partial async Task InitializeJS()
        {
            _module = await JSInterop.GetModule("collapse");
        }

        private partial async Task Show()
        {
            if (_module is not null)
            {
                await _module.CallScript("show", _id);
            }
        }

        private partial async Task Hide()
        {
            if (_module is not null)
            {
                await _module.CallScript("hide", _id);
            }
        }
    }
}
