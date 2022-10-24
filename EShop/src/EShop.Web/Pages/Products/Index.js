$(function () {
    var l = abp.localization.getResource('EShop');
    
    var createModal = new abp.ModalManager(abp.appPath + 'Products/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Products/EditModal');

    var dataTable = $('#ProductsTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(eShop.products.product.getList),
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
                                        editModal.open({ id: data.record.id });
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
                    title: l('CreationTime'), data: "creationTime",
                    dataFormat:"datetime"
                    
                }
            ]
        })
    );
    

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewProductButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });

  

});

