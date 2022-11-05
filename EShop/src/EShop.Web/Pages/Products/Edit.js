$(function () {

    var l = abp.localization.getResource("EShop");


    var $formEdit = $('#form-product-edit');

    var $productImage = $('#Product_ImageName');


    var $buttonSubmit = $('#button-product-edit');


    var $fileInput = $('#ProductImage');


    var UPPY_FILE_ID = "uppy-upload-file";

    var fileUploadUri = "/api/app/file/upload-image";

    $formEdit.on('submit', function (e) {
        e.preventDefault();

        if ($formEdit.valid()) {

            $formEdit.ajaxSubmit({
                success: function (result) {
                    uploadImage(result.id);
                    abp.notify.success(l('SuccessfullySaved'));
                },
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
                data: file, // file
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
