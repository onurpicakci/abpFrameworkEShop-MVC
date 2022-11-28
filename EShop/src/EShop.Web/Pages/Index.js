$(function () {
    var l = abp.localization.getResource('EShop');



    $(function () {
        abp.log.debug('Index.js initialized!');
    });



    $(function () {
        $('.add-basket-button').click(function () {
            var $this = $(this);
            var productId = $this.attr('data-product-id');
            eShop.baskets.basket.addProduct({
                productId: productId,
            }).then(function () {
                abp.notify.success("Added product to your basket.", "Successfully added");
            });
        });
    });
});

