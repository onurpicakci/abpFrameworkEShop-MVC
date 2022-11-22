$(function () {
    var l = abp.localization.getResource('EShop');

    var getFilter = function () {
        return {
            filter: $("input[name='Search'").val(),
        };
    };

    var dataTable = $('#ProductsTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: true,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(getFilter)
          
    );
    $("input[name='Search'").change(function () {
        dataTable.ajax.reload();
    });

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

