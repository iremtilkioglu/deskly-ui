(() => {
    "use strict";

    const cartForms = document.querySelectorAll(
        'form[action*="/Cart/Add"]'
    );

    if (!cartForms.length) return;

    let toastTimeout;

    function showToast(message) {
        let toast = document.getElementById("cartToast");

        if (!toast) {
            toast = document.createElement("div");
            toast.id = "cartToast";
            toast.setAttribute("role", "status");
            toast.setAttribute("aria-live", "polite");

            toast.className = [
                "fixed bottom-6 right-6 z-[100]",
                "rounded-2xl bg-[#1E2430]",
                "px-5 py-4 text-sm font-medium text-white",
                "shadow-xl transition-opacity duration-300"
            ].join(" ");

            document.body.appendChild(toast);
        }

        clearTimeout(toastTimeout);

        toast.textContent = message;
        toast.classList.remove("opacity-0");

        toastTimeout = setTimeout(() => {
            toast.classList.add("opacity-0");
        }, 3000);
    }

    function updateCartCount(count) {
        const badge = document.getElementById("headerCartCount");

        if (badge) {
            badge.textContent = `(${count})`;
        }
    }

    async function handleCartSubmit(event) {
        event.preventDefault();

        const form = event.currentTarget;
        const button = form.querySelector('[type="submit"]');

        if (form.dataset.submitting === "true") return;

        form.dataset.submitting = "true";

        if (button) button.disabled = true;

        try {
            const response = await fetch(form.action, {
                method: "POST",
                body: new FormData(form),
                headers: {
                    "X-Requested-With": "XMLHttpRequest",
                    "Accept": "application/json"
                }
            });

            if (!response.ok) {
                throw new Error("Sepete ekleme başarısız.");
            }

            const result = await response.json();

            if (!result.success) {
                throw new Error("Ürün sepete eklenemedi.");
            }

            updateCartCount(result.cartCount);
            showToast(result.message || "Ürün sepete eklendi.");

        } catch (error) {
            console.error("Cart error:", error);
            showToast("Bir hata oluştu. Lütfen tekrar deneyin.");

        } finally {
            form.dataset.submitting = "false";

            if (button) button.disabled = false;
        }
    }

    cartForms.forEach(form => {
        form.addEventListener("submit", handleCartSubmit);
    });
})();
