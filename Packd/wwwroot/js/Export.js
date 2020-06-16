window.onload = function () {
    $('.export-list button').click(function (event) {
        let ListId = event.currentTarget.parentElement.parentElement.getAttribute('id');
        let ListToPrintTab = window.open('../List/DisplayList/' + ListId);

        ListToPrintTab.print();

        setTimeout(function () {
            ListToPrintTab.close();
        }, 500);
    });
}