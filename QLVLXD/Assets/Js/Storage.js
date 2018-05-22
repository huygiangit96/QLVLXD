$('.status_vatlieu').off('click').on('click', function () {
    var id = $(this).data('id');
    $.ajax({
        url: '/Storage/ChangeStatus',
        data: { id: id },
        type: 'post',
        dataType: 'json',
        success: function () {
            alert('Thao tác thành công !');
            window.location.href = '/Storage/StockCur';
        },
        error: function () {
            alert('Bạn không có quyền thực hiện tác vụ này!');
        }
    })
})
$('.del_vatlieu').off('click').on('click', function () {
    var id = $(this).data('id');
    $.ajax({
        url: '/Storage/DeleteClick',
        data: { id: id },
        type: 'post',
        dataType: 'json',
        success: function () {
            alert('Thao tác thành công !');
            window.location.href = '/Storage/StockCur';
        },
        error: function () {
            alert('Bạn không có quyền thực hiện tác vụ này!');
        }
    })
})


$('#stockin_vl').change(function () {
    var x = $(this).attr('value');
    $('#input_idvl').attr('value', $(this).val());
})
$('#stockin_nhacc').change(function () {
    $('#input_idnhacc').attr('value', $(this).val());
})
