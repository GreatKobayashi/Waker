export function show(id) {
    if (document.querySelector('.modal-backdrop')) return;
    const modal = new bootstrap.Modal(document.getElementById(id));
    modal.show();
}

export function hide(id) {
    const modal = bootstrap.Modal.getInstance(document.getElementById(id));
    if (modal) modal.hide();
}