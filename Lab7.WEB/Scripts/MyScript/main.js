$(document).ready(function () {
    var addLinks = document.querySelectorAll('.add-menu-item');
    var orderList = document.querySelector('.order-list');
    var currentPrice = document.querySelector('#current-price');
    var orderComliteLinks = document.querySelectorAll('.order-item a');
    console.log(orderComliteLinks);
    orderComliteLinks.forEach(function (item, idx) {
        item.addEventListener('click', function (e) {
            e.preventDefault();
            console.log(e);
            alert('click');
            $.ajax({
                type: "POST",
                url: "../Home/CompliteOrder/",
                data: {
                    id: e.path[0].attributes[1].value
                },
                success: function () {
                    e.path[1].children[7].innerText = e.path[1].children[7].innerText.substring(0, 10) + "true";
                    alert("success");
                }
            });
        })
    });
    addLinks.forEach(function (item,idx) {
        item.addEventListener('click', function (e) {
            alert(2);
            e.preventDefault();
            console.log(e);
            var h3 = e.path[1];
            var sizeName = e.path[2].children[1];
            var price = e.path[2].children[2];
            console.log(h3);
            console.log(sizeName);
            console.log(price);

            var orderName = h3.innerText.substring(0, h3.innerText.length - 2) + ' ' + sizeName.innerText;
            console.log(orderName);

            var h5Order = document.createElement('h5');
            h5Order.innerText = orderName;
            orderList.appendChild(h5Order);
            var id = document.createElement('p');
            id.hidden = true;
            id.innerText = e.path[0].attributes[2].value;
            orderList.appendChild(id);
            currentPrice.innerText = +currentPrice.innerText + +price.innerText;
        });
    });
    var orderBtn = document.querySelector('.order-btn');
    if (orderBtn !== null)
    orderBtn.addEventListener('click', createOrder);
});

function createOrder() {
    var orderIds = document.querySelectorAll('.order-list p');
    console.log(orderIds);
    var arrIds = [];
    if (orderIds.length > 0) {
        for (var i = 0; i < orderIds.length; i++) {
            arrIds[i] = orderIds[i].innerText;
        }
        alert(arrIds);
        var price = document.querySelector('#current-price').innerText;
        $.ajax({
            type: "POST",
            url: "../Home/CreateOrder/",
            data: {
                arrIds,
                price
            },
            success: orderSuccess
        });
    } else {
        alert("order list is empty!");
    }
}

function orderSuccess() {
    alert("order successful created");
}