$(function () {
    var l = abp.localization.getResource('EShop');

    var dataTable = $('#BasketTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: false,
            paging: true,
            order: [[1, "asc"]],
            searching: true,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(eShop.baskets.basketItem.getList),
            columnDefs: [
             
                    
                {
                    title: l('ProductId'),
                    data: "productId"
                },
                {
                    title: l('ProductCount'),
                    data: "productCount"
                },

                {
                    title: l('CreationTime'), data: "creationTime",
                    dataFormat: "datetime"

                }
            ]
        })
    );
});