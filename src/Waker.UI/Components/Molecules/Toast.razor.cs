namespace Waker.UI.Components.Molecules
{
    public partial class Toast
    {
        private Module? _module;

        private partial async Task InitializeJS()
        {
            _module = await JSInterop.GetModule("toast");
        }

        private partial async Task Show(string id, int visibleMilliSeconds)
        {
            if (_module is not null)
            {
                await _module.CallScript("show", id, visibleMilliSeconds);
            }
        }
    }
}
