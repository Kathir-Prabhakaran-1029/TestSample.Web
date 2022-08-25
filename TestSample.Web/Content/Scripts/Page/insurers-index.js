$(function () {
    initSearch();
    initPagination();
    initDelete();
});

function initSearch() {
    $("#Search_Btn").on("click", function () {
        $('#PageNum').val(1);
        $("#InsurerSearch_Form").submit();
    });
}

function initDelete() {
    $(".delete-Btn").on("click", function () {
        $("#Id").val($(this).attr("data-id"));
        $("#delete").modal("show");
    });

    $("#Delete_Btn").on("click", function () {
        $("#InsurerDelete_Form").submit();
    });
}

function initPagination() {
    $(".pageNum").pagination({
        items: $('.pageNum').data('totalitems'),
        itemsOnPage: $('.pageNum').data('pagesize'),
        currentPage: $('#PageNum').val(),
        hrefTextPrefix: "",
        prevText: "<",
        nextText: ">",
        cssStyle: "",
        onPageClick: function (pageNumber, event) {
            event.preventDefault();
            $("#PageNum").val(pageNumber);
            $("#InsurerSearch_Form").submit();
        }
    });
}
