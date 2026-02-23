export function show(id, visibleMilliSeconds) {
    const toastEl = document.getElementById(id);
    const toast = new bootstrap.Toast(toastEl, {
        autohide: true,
        delay: visibleMilliSeconds
    });
    toast.show();
}
