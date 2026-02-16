let latestIndexes = [];

export function init(id, dotnetRef, defaultIndex) {
    const scrollContainer = document.getElementById(id);
    latestIndexes.push({ id: id, latestIndex: defaultIndex });

    scrollContainer.addEventListener('scrollend', () => {
        const containerRect = scrollContainer.getBoundingClientRect();
        const containerCenter = containerRect.top + containerRect.height / 2;

        const items = scrollContainer.querySelectorAll('.item');
        let closestItem = items[0];
        let minDist = Math.abs(containerCenter - (items[0].getBoundingClientRect().top + items[0].offsetHeight / 2));

        items.forEach(item => {
            const itemCenter = item.getBoundingClientRect().top + item.offsetHeight / 2;
            const dist = Math.abs(containerCenter - itemCenter);
            if (dist < minDist) {
                minDist = dist;
                closestItem = item;
            }
        });

        dotnetRef.invokeMethodAsync("OnItemChanged", closestItem.id);
    });

    onElementVisible(scrollContainer, () => {
        performChangeItemSelection(id, latestIndexes.find(x => x.id === id).latestIndex, 'instant');
    });
};

function onElementVisible(element, callback) {
    const observer = new MutationObserver(() => {
        if (element.offsetHeight > 0) {
            observer.disconnect();
            callback();
        }
    });

    observer.observe(document.body, { attributes: true, subtree: true });
}

function performChangeItemSelection(id, index, behavior) {
    const scrollContainer = document.getElementById(id);
    const target = scrollContainer.querySelectorAll('.item')[index];
    const offset = (target.offsetHeight / 2) + target.offsetHeight * index;
    scrollContainer.scrollTo({
        top: offset,
        behavior: behavior
    });
}

export function changeItemSelection(id, index, behavior) {
    const target = latestIndexes.find(x => x.id === id);
    if (target) {
        target.latestIndex = index;
        const scrollContainer = document.getElementById(id);
        const method = () => performChangeItemSelection(id, latestIndexes.find(x => x.id === id).latestIndex, behavior);
        if (scrollContainer.offsetHeight > 0) {
            method();
        } else {
            onElementVisible(scrollContainer, () => {
                method();
            });
        }
    }
}