﻿$(function () {

    var l = abp.localization.getResource("EShop");


    var $formCreate = $('#form-product-create');

    var $productImage = $('#Product_ImageName');


    var $buttonSubmit = $('#button-product-create');


    var $fileInput = $('#ProductImage');


    var UPPY_FILE_ID = "uppy-upload-file";

    var fileUploadUri = "/api/app/file/upload-image";

    $formCreate.on('submit', function (e) {
        e.preventDefault();

        if ($formCreate.valid()) {

            $formCreate.ajaxSubmit({
                success: function (result) {
                    abp.notify.success(l('SuccessfullySaved'));
                    uploadImage(result.id);
                  
                },
                error: function (result) {
                    abp.notify.error(result.responseJSON.error.message);
                    abp.ui.clearBusy();
                }
            });
        }
        else {
            abp.ui.clearBusy();
        }
    });

    function uploadImage(productId) {

        var UPPY_OPTIONS = {
            endpoint: fileUploadUri,
            formData: true,
            fieldName: "file",
            method: "post",
            headers: getUppyHeaders()
        };

        var UPPY = Uppy.Core().use(Uppy.XHRUpload, UPPY_OPTIONS);

        UPPY.reset();

        var file = $fileInput[0].files[0];

        if (file) {

            UPPY.addFile({
                id: UPPY_FILE_ID,
                name: productId, // file name
                type: file.type, // file type
                data: file  //file
            });

            UPPY.upload().then((result) => {
                if (result.failed.length > 0) {
                    abp.message.error(l("UploadFailedMessage"));
                }
            });
        }
    }

    function getUppyHeaders() {
        var headers = {};
        headers[abp.security.antiForgery.tokenHeaderName] = abp.security.antiForgery.getToken();

        return headers;
    }
});
