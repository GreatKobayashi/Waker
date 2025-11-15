using Microsoft.JSInterop;

namespace Waker.UI
{
    public class JsInterop
    {
        public JsInterop(IJSRuntime jsRuntime)
        {
            Modal = new ModalModule(new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
                "import", "./_content/Waker.UI/js/modal.js").AsTask()));
        }

        public ModalModule Modal { get; }

        public class ModalModule : Module
        {
            public ModalModule(Lazy<Task<IJSObjectReference>> moduleModalTask) : base(moduleModalTask)
            {
            }

            public async ValueTask Show(string id)
            {
                await CallScript("show", id);
            }

            public async ValueTask Hide(string id)
            {
                await CallScript("hide", id);
            }
        }

        public abstract class Module : IAsyncDisposable
        {
            private readonly Lazy<Task<IJSObjectReference>> _moduleTask;
            private IJSObjectReference? _module;

            protected Module(Lazy<Task<IJSObjectReference>> moduleModalTask)
            {
                _moduleTask = moduleModalTask;
            }

            protected async ValueTask CallScript(string method, params object[] args)
            {
                if (_module is null)
                {
                    _module = await _moduleTask.Value;
                }
                await _module.InvokeVoidAsync(method, args);
            }

            public async ValueTask DisposeAsync()
            {
                if (_moduleTask.IsValueCreated)
                {
                    var module = await _moduleTask.Value;
                    await module.DisposeAsync();
                }
            }
        }
    }
}
