export function show(id) {
    const element = document.getElementById(id);
    if (!element) return;

    const collapse = new bootstrap.Collapse(element, { toggle: false });
    collapse.show();
}

export function hide(id) {
    const collapse = bootstrap.Collapse.getInstance(document.getElementById(id));
    if (collapse) collapse.hide();
}