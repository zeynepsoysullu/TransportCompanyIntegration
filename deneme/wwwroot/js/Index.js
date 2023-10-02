
//JQUERY ile search işlemu keyup kısmı yazıldı gibi kontrol etmeyi sağlar buton koysaydık click koyup tıklandıında tetiklettirecektik lowercase komutu ise büyük küçük harfı umursamadan arama yapmasını sağlar
//kargolistesinde bütün trlerin içerisinde arama yapar yani tablonun başlıkları dahil her satır
$(document).ready(function () {
    $("#search").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#kargoListesi tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });
});


function filterTableForCol(colIndex) {
    // Declare variables
    var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById("input" + colIndex);
    filter = input.value;
    table = document.getElementById("kargoListesi");
    tr = table.getElementsByTagName("tr");

    // Loop through all table rows, and hide those who don't match the search query
    for (i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("td")[colIndex];
        if (td) {
            txtValue = td.textContent || td.innerText;
            if (txtValue.indexOf(filter) <= -1) {
                tr[i].style.display = "none";
            }
        }
    }
}

function searchTable(colIndex) {
    // Declare variables
    var table, tr, i;
    table = document.getElementById("kargoListesi");
    tr = table.getElementsByTagName("tr");

    // Set all rows visible
    for (i = 0; i < tr.length; i++) {
        tr[i].style.display = "";
    }
    for (i = 0; i < 10; i++) {
        filterTableForCol(i);
    }
}
// sayfa açıldıktan 1 dakika sonra sayfayı yeniden yükler
setTimeout(function () {
    window.location.href = window.location;
}, 60000); 