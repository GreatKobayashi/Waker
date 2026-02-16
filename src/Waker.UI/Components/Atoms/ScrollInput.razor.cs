using Microsoft.JSInterop;

namespace Waker.UI.Components.Atoms
{
    public partial class ScrollInput
    {
        private static Dictionary<Behavior, string> _behaviorMapping = new() { { Behavior.Instant, "instant" }, { Behavior.Smooth, "smooth" } };

        private Task<Module>? _task;
        private Module? _module;

        private partial async Task InitializeJS()
        {
            _task = JSInterop.GetModule("scrollInput");
        }

        private partial async Task InitializeScrollInput()
        {
            if (_task is not null)
            {
                _module = await _task;
                await _module.CallScript("init", _id, DotNetObjectReference.Create(this), _selectedIndex);
            }
        }

        private partial async Task PerformChangeItemSelection(Behavior behavior)
        {
            if (_module is not null)
            {
                await _module.CallScript("changeItemSelection", _id, _selectedIndex, GetMappedString(behavior));
            }
        }

        [JSInvokable]
        public void OnItemChanged(string itemId)
        {
            var itemIndex = Convert.ToInt32(itemId.Split('-')[1]);

            if (itemIndex != _selectedIndex)
            {
                SelectedItem = _itemsForVanity[itemIndex];
                _selectedIndex = itemIndex;
                _isInnerCall = true;
                SelectedItemChanged.InvokeAsync(SelectedItem);
            }
        }

        private static string GetMappedString(Behavior behavior)
        {
            return _behaviorMapping.First(x => x.Key == behavior).Value;
        }
    }
}
