$(function () {
    var l = abp.localization.getResource('EShop');

    var getFilter = function () {
        return {
            filter: $("input[name='Search'").val(),
        };
    };

    var dataTable = $('#ProductsTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: false,
            paging: true,
            order: [[1, "asc"]],
            searching: true,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(eShop.products.product.getList, getFilter),
            columnDefs: [
                {
                    ttitle: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    visible:
                                        abp.auth.isGranted('EShop.Products.Edit'),
                                    action: function (data) {
                                        location.href = 'Products/Edit/' + data.record.id;
                                        //TODO: Redirect to edit
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    visible:
                                        abp.auth.isGranted('EShop.Products.Delete'),
                                    confirmMessage: function (data) {
                                        return l(
                                            'ProductDeleteMessage',
                                            data.record.name
                                        );
                                    },
                                    action: function (data) {
                                        eShop.products.product
                                            .delete(data.record.id)
                                            .then(function () {
                                                abp.notify.info(
                                                    l('SuccessfullyDeleted')
                                                );
                                                dataTable.ajax.reload();
                                            });
                                    }
                                }
                            ]
                    }
                },
                {
                    title: l('ProductName'),
                    data: "name"
                },
                {
                    title: l('ProductCode'),
                    data: "code"
                },
                {
                    title: l('ProductDescription'),
                    data: "productDescription"
                },
                {
                    title: l('Price'),
                    data: "price"
                },
                {
                    title: l('StockCount'),
                    data: "stockCount"
                },
                {
                    title: l('ImageName'),
                    data: "imageName"
                },
     
                {
                    title: l('CreationTime'), data: "creationTime",
                    dataFormat:"datetime"
                    
                }
            ]
        })
    );
    
    $('#NewProductButton').click(function (e) {
        e.preventDefault();

        window.location.href = "Products/Create"
    });

    $("input[name='Search'").change(function () {
        dataTable.ajax.reload();
    });
});

