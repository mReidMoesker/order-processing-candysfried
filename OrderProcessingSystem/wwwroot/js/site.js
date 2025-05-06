'use strict';

document.addEventListener("DOMContentLoaded", function () {
    var forms = document.querySelectorAll(".delete-form");

    forms.forEach(function (form) {
        form.addEventListener("submit", function (e) {
            e.preventDefault();

            fetch(form.action, {
                method: "POST",
                headers: {
                    "Content-Type": "application/x-www-form-urlencoded",
                    "X-Requested-With": "XMLHttpRequest"
                },
                body: new URLSearchParams(new FormData(form))
            })
                .then(function (response) {
                    if (response.ok) {
                        // Close the modal
                        var orderId = form.querySelector('input[name="id"]').value;
                        var modal = bootstrap.Modal.getInstance(document.getElementById('deleteModal-' + orderId));
                        modal.hide();

                        // Reload the page to see changes
                        location.reload();
                    } else if (response.status === 404) {
                        alert("Order not found or already deleted.");
                    } else {
                        alert("Failed to delete order. Status: " + response.status);
                    }
                })
                .catch(function (error) {
                    console.error("Error:", error);
                    alert("An error occurred while deleting the order.");
                });
        });
    });

    document.querySelectorAll(".toggle-status").forEach(button => {
        button.addEventListener("click", async () => {
            const orderId = button.dataset.id;
            const newStatus = button.dataset.status === "true";

            const response = await fetch("/Orders/ToggleOrderStatus", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify({ id: orderId, isComplete: newStatus })
            });

            if (response.ok) {
                location.reload();
            } else {
                alert("Failed to toggle order status.");
            }
        });
    });
});