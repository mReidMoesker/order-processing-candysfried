'use strict';

document.addEventListener("DOMContentLoaded", function () {
    let forms = document.querySelectorAll(".delete-form");

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
                        let orderId = form.querySelector('input[name="id"]').value;
                        let modal = bootstrap.Modal.getInstance(document.getElementById('deleteModal-' + orderId));
                        modal.hide();

                        location.reload();
                    } else if (response.status === 404) {
                        alert("Order not found or already deleted.");
                    } else {
                        alert("Failed to delete order. Status: " + response.status + ". Call 204-312-7852 for help or email mathewmoesker@gmail.com");
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