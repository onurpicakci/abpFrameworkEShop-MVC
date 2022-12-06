$(function () {

    var init = $(function (filter) {
        $('.basket-item-remove').click(function () {
            let $this = $(this);
            let productId = $this.parents('.basket-list-item').attr('data-product-id');
            eShop.baskets.basket.removeProduct({
                productId: productId,
            }).then(function () {
                abp.notify.success("Removed the product from your basket.", "Removed basket item");
            });
        });

        $(function (e) {
            $('.basket-item-increase').click(function () {
                let $this = $(this);
                let productId = $this.parents('.basket-list-item').attr('data-product-id');
                eShop.baskets.basket.addProduct({
                    productId: productId,
                    count: 1
                });
            });
        });

        $(function (e) {
            $('.basket-item-decrease').click(function () {
                let $this = $(this);
                let productId = $this.parents('.basket-list-item').attr('data-product-id');
                eShop.baskets.basket.removeProduct({
                    productId: productId,
                    count: 1
                });
            });
        });
    });

    $('.basket-purchase-button').click(function (e) {
        e.preventDefault();

        window.location.href = "Payments/Index"
    });

    return {
        init: init
    };
});