$(document).ready(function () {
    $("#orderDate").datepicker({
        format: 'yyyy/mm/dd',
        changeMonth: true,
        changeYear: true,
        yearRange: "-60:+0"
    });

});


$(document).ready(function () {
    //$('#data').datatable();
    $('#example tbody tr:odd').addClass("silver");
    $('#example').DataTable({

        "order": [[0, "desc"]],
        "aaSorting": [[0, "desc"]],
        "sDom": '<"nav"lf>tr<"nav"i>',
        "sDom": '<"top"fli>rt<"bottom"p><"clear">',
        "bProcessing": true,
        "bSortClasses": false,
        "sScrollX": "100%",
        "bAutoWidth": true,
        "sScrollXInner": "100%",
        "bScrollCollapse": true,
        "oLanguage": {
            "sSearch": "<span>You can search by, Name, Address, Emaill or Combined:</span> _INPUT_", //search
            "sProcessing": "loading....",
            "sEmptyTable": "No Data"
        },


    });




});

//$(document).ready(function (){


//    var table = $('#example').DataTable({
    
//        'columnDefs': [
//           {
//               'targets': 0,
//               'checkboxes': {
//                   'selectRow': true
//               }
//           }
//        ],
//        'select': {
//            'style': 'multi'
//        },
//        'order': [[1, 'asc']]
//    });


//});







$(document).ready(function () {


jQuery.validator.methods.date = function (value, element) {
    var isChrome = /Chrome/.test(navigator.userAgent) && /Google Inc/.test(navigator.vendor);
    if (isChrome) {
        var d = new Date();
        return this.optional(element) || !/Invalid|NaN/.test(new Date(d.toLocaleDateString(value)));
    } else {
        return this.optional(element) || !/Invalid|NaN/.test(new Date(value));
    }
};


});



$(document).ready(function () {
    // Initialize Tooltip
    $('[data-toggle="tooltip"]').tooltip();

    // Add smooth scrolling to all links in navbar + footer link
    $(".navbar a, footer a[href='#myPage']").on('click', function (event) {

        // Make sure this.hash has a value before overriding default behavior
        if (this.hash !== "") {

            // Prevent default anchor click behavior
            event.preventDefault();

            // Store hash
            var hash = this.hash;

            // Using jQuery's animate() method to add smooth page scroll
            // The optional number (900) specifies the number of milliseconds it takes to scroll to the specified area
            $('html, body').animate({
                scrollTop: $(hash).offset().top
            }, 900, function () {

                // Add hash (#) to URL when done scrolling (default click behavior)
                window.location.hash = hash;
            });
        } // End if
    });
})




$(document).ready(function () {
    // Initialize Tooltip
    $('[data-toggle="tooltip"]').tooltip();


    // Add smooth scrolling to Intro's Links
    $("#intro a").on('click', function (event) {

        // Make sure this.hash has a value before overriding default behavior
        if (this.hash !== "") {

            // Prevent default anchor click behavior
            event.preventDefault();

            // Store hash
            var hash = this.hash;

            // Using jQuery's animate() method to add smooth page scroll
            // The optional number (900) specifies the number of milliseconds it takes to scroll to the specified area
            $('html, body').animate({
                scrollTop: $(hash).offset().top
            }, 900, function () {

                // Add hash (#) to URL when done scrolling (default click behavior)
                window.location.hash = hash;
            });
        } // End if
    });
})