$(function () {
    abp.log.debug('Index.js initialized!');
});


    $(function () {
        $('.add-basket-button').click(function () {
            var $this = $(this);
            var productId = $this.attr('data-product-id');
            eShop.baskets.basket.addProduct({
                productId: productId,
            });

                abp.notify.success("Added product to your basket.", "Successfully added");
            
        });
    });
