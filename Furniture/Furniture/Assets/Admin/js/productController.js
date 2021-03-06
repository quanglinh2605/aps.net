﻿var product = {
    init: function () {
        product.registerEvents();
    },
    registerEvents: function () {

        $('.btn-images').off('click').on('click', function (e) {
            e.preventDefault();
            $('#imagesManage').modal('show');
            $('#hidProductID').val($(this).data('id'));
            product.loadImages();
        });

        $("#btnChooseImages").off('click').on('click', function (e) {
            e.preventDefault();
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileURL) {

                $('.imageList').append('<div style="float:left;"><img src="' + fileURL + '" width="100" /><a href="#" class="btn-delImage"><i class="fa fa-times"></i></a></div>');
                $('.btn-delImage').off('click').on('click', function (e) {
                    e.preventDefault();
                    $(this).parent().remove();
                });
            };  
            finder.popup();
        });

        $('#btnsaveImages').off('click').on('click', function () {
            var images = [];
            var id = $('#hidProductID').val();
            $.each($('.imageList img'), function (i, item) {
                images.push($(item).prop('src'));
            });
            $.ajax({
                url: '/Admin/Product/SaveImages',
                type: 'POST',
                data: {
                    id: id,
                    images: JSON.stringify(images)
                },
                dataType: 'json',
                success: function (response) {
                    $('#imagesManage').modal('hide');
                    $('.imageList').html('');
                    if (response.status == true) {
                        alert("Thanh cong");
                    }
                }
            });
        });

        $('select.cbbCategory').on("change", function () {
            var id = $(this).val();
            $.ajax({
                url: '/Admin/CategoryDetail/listCateDetail',
                type: 'GET',
                data: {
                    id : id
                },
                dataType: 'json',
                success: function (response) {
                    var listCate = response.data;
                    var s = '<option value="-1">Select Category Detail</option>';
                    for (var i = 0; i < listCate.length; i++) {
                        s += '<option value="' + listCate[i].ID + '">' + listCate[i].Name + '</option>'
                    }
                    $('select.cbbCateDetail').html(s);
                }
            });
        });

        $('select.cbbCateDetail').on("change", function () {
            var id = $(this).val();
            $.ajax({
                url: '/Admin/ProductCate/listProCate',
                type: 'GET',
                data: {
                    id: id
                },
                dataType: 'json',
                success: function (response) {
                    var listCate = response.data;
                    var s = '<option value="-1">Select One</option>';
                    for (var i = 0; i < listCate.length; i++) {
                        s += '<option value="' + listCate[i].ID + '">' + listCate[i].Name + '</option>'
                    }
                    $('select.cbbProCate').html(s);
                }
            });
        });

        $('#btn-photo').off('click').on('click', function (e) {
            e.preventDefault();
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileURL) {
                document.getElementById("imgpreview").src = fileURL;
                $('#photo').val(fileURL);
            }
            finder.popup();
        });
    },

    loadImages: function () {
        $.ajax({
            url: '/Admin/Product/LoadImages',
            type: 'GET',
            data: {
                id: $('#hidProductID').val()
            },
            dataType: 'json',
            success: function (response) {               
                    var data = response.data;
                    var html = '';
                    $.each(data, function (i, item) {
                        html += '<div style="float:left;"><img src="' + item + '" width="100" /><a href="#" class="btn-delImage"><i class="fa fa-times"></i></a></div>'
                    });
                    $('.imageList').html(html);
                    $('.btn-delImage').off('click').on('click', function (e) {
                        e.preventDefault();
                        $(this).parent().remove();
                    });                
            }
        });
    }
}
product.init();