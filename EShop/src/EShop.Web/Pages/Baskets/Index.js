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
    });
    return {
        init: init
    };
});