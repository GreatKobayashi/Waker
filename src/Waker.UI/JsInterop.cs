using Microsoft.JSInterop;

namespace Waker.UI
{
    public class JSInterop
    {
        private IJSRuntime _jSRuntime;

        public JSInterop(IJSRuntime jsRuntime)
        {
            _jSRuntime = jsRuntime;
        }

        public async Task<Module> GetModule(string moduleName)
        {
            return new(await _jSRuntime.InvokeAsync<IJSObjectReference>("import", $"./_content/Waker.UI/js/{moduleName}.js"));
        }
    }

    public class Module : IAsyncDisposable
    {
        private IJSObjectReference _jSObjectReference;

        public Module(IJSObjectReference jSObjectReference)
        {
            _jSObjectReference = jSObjectReference;
        }

        public async ValueTask CallScript(string method, params object[] args)
        {
            await _jSObjectReference.InvokeVoidAsync(method, args);
        }

        public async ValueTask DisposeAsync()
        {
            await _jSObjectReference.DisposeAsync();
        }
    }
}
