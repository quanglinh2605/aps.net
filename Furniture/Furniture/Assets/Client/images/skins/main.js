var product = {
    init: function () {
        product.registerEvents();
    },
    registerEvents: function () {
        $(document).on('click', '.show_morecat', function () {
            var id = $(this).attr('id');
            var val = $(this).attr('val');
            var count = $(this).attr('count');
            var dataString = "id=" + id + "&val=" + val + "&count=" + count;
            $.ajax({
                type: 'POST',
                url: '/Category/loadmore',
                data: dataString,
                success: function (response) {
                    $('.tutorial_list' + id).html(response.PartialView);
                    if (response.quantity != 0) {
                        $(".show_more" + id).attr("val", response.quantity);
                    }
                    else {
                        $(".show_more" + id).addClass("hideload");
                    }
                }
            });
        });

        if ($('#scrollheight').length) {
            var clientHeight = document.getElementById('scrollheight').clientHeight;
            //alert(clientHeight);
            if (clientHeight >= 500) {
                $(".read-more").click(function () {                  
                    $("#scrollheight").animate({
                        height: $("#scrollheight")[0].scrollHeight
                    }, 2000);
                    $(".read-more").css("display", "none");
                    $(".shadowdmx").css("display", "none");
                });
            }
        }

        if ($('select.property').length) {
            $("select.property").on("change", function () {
                var value = $(this).val();
                //alert(value);
                if (value != 0) {
                    var dataString = "value=" + value + "&action=sortsp";
                    $.ajax({
                        type: "POST",
                        url: "/Category/action",
                        data: dataString,
                        success: function (response) {
                            window.location.reload();
                            //alert(response);
                        }
                    });
                }
            })
        }

        $(document).on('click', '.showmore_khac', function () {
            var id = $(this).attr('id');
            var count = $(this).attr('count');
            var dataString = "id=" + id + "&count=" + count;
            $.ajax({
                type: 'POST',
                url: '/Product/loadMore',
                data: dataString,
                success: function (response) {
                    $('.tutorial_list').html(response.PartialView);
                    if (response.count == 0) {
                        $(".show_more").addClass("hideload");
                    } else {
                        $(".show_more").attr("count", response.count)
                        $(".show_more").html(response.title);
                    }
                }
            });
        });

        $('.buynow').on('click', function () {
            var id = $(".product").find('input[name=product_id]').val();
            var qty = $(".product").find('input[name=quantity]').val();
            //var giaban = $(".product").find('input[name=giaban]').val();
            //var giacty = $(".product").find('input[name=giacty]').val();
            //var size = $(".product").find('input[name=sizesp]').val();
            //var color = $(".product").find('input[name=colorsp]').val();
            //alert(color);
            var dataString = "ProductId=" + id + "&Quantity=" + qty/* + "&giaban=" + giaban + "&giacty=" + giacty + "&size=" + size + "&color=" + color + "&action=addcart"*/;
            $.ajax({
                type: "POST",
                url: "/Cart/AddItem",
                data: dataString,
                success: function (response) {
                    window.location.href = "gio-hang"
                }
            });
        });

        $('.intocart').on('click', function () {
            var id = $(".product").find('input[name=product_id]').val();
            var qty = $(".product").find('input[name=quantity]').val();
            var dataString = "ProductId=" + id + "&Quantity=" + qty/* + "&giaban=" + giaban + "&giacty=" + giacty + "&size=" + size + "&color=" + color + "&action=addcart"*/;
            $.ajax({
                type: "POST",
                url: "/Cart/AddItem",
                data: dataString,
                success: function (response) {
                    //window.location.href="gio-hang";     
                    alert('Đã thêm vào giỏ hàng');
                }
            });
        });
    }
}
product.init();