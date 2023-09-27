$(document).ready(function () {

    const orderURL = "https://localhost:7297/api/orders";
    const orderDetailURL = "https://localhost:7297/api/orders/details";

    class Order {
        constructor(_orderId, _orderDate) {
                this.orderId = _orderId,
                this.orderDate = _orderDate
        }
        static orderList = new Array();
    }

    class OrderaAPI {
        static getOrders() {
            $.ajax({
                url: `${orderURL}`,
                type: "Get",
                success: function (data) {
                    data.forEach(function (value, index) {
                        const order = new Order(value.orderId, value.orderDate);
                        Order.orderList.push(order);
                    })
                    fillOrderTable();
                },
                error: function (err) {
                    console.log(err);
                }
            })
        }

        static getOrderDetails(id) {
            $.ajax({
                url: `${orderDetailURL}/${id}`,
                type: "Get",
                success: function (data) {
                    $("#orderIdValue").text(`${data.orderId}`);
                    $("#orderDateValue").text(`${data.orderDate}`);
                    const productBody = $("#productBody");
                    productBody.text(``);
                    data.orderDetail.forEach(function (value, index) {
                        const tr = `
                            <tr>
                                <td>${value.productId}</td>
                                <td>${value.unitPrice}</td>
                                <td>${value.quantity}</td>
                            </tr>
                        `;
                        productBody.append(tr);
                    });
                    
                    $("#orderCard").removeClass("d-none").addClass("d-block");
                    
                },
                error: function (err) {
                    console.log(err);
                }
            })
            
        }
    }

    function fillOrderTable() {
        const tbody = $("#orderBody");
        if (Order.orderList.length > 0) {
            Order.orderList.forEach(function (value, index) {
                const tr = `
                <tr>
                    <td>${value.orderId}</td>
                    <td>${value.orderDate}</td>
                    <td>
                        <button name="orderDetails" id="${value.orderId}" class="btn btn-primary">Detay</button>
                    </td>
                </tr>
                `;
                tbody.append(tr);
            })
        }
    }

    $("#orderBody").on("click", function (e) {
        if (e.target.name == "orderDetails") {
            OrderaAPI.getOrderDetails(e.target.id);
        }
    })


    OrderaAPI.getOrders();

})