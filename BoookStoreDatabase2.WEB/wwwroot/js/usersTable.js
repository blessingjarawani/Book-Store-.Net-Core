TABLE = $('#dataTable');

class Initialize {
    constructor() {
        this._tableInit();
      
    };

    _tableInit() {

        if ($.fn.DataTable.isDataTable(TABLE))
            TABLE.DataTable().destroy();

        $.ajax({
            async: false,
            cache: false,
            type: 'GET',
            url: '/ApplicationUsers/GetUsers/',
            success: function (jsonResult) {
                if (!jsonResult.success) {
                    toastr.error(jsonResult.message);
                    return;
                }
                toastr.warning(jsonResult.message);
                TABLE.dataTable({
                    data: jsonResult.items,
                    deferRender: true,
                    language: {
                        search: "_INPUT_",
                        searchPlaceholder: "Search...",
                        lengthMenu: "Pokaż _MENU_"
                    },
                    columns: [
                        {
                            data: function (row) {
                                return `<input id="checkbox_${row.Id}" class="rowCheck" type="checkbox" />`;
                            },
                            orderable: false
                        },
                        {
                            data: 'Id'
                        },
                        {
                            data: 'UserName'
                        },
                        {
                            data: 'LastName'
                        },
                        {
                            data: 'FirstName'
                        },
                        {
                            data: 'User Type'
                        },
                        {
                            data: 'Email'
                        }
                    ]
                }).on('page.dt',
                    function () {
                        $('input[type="checkbox"]').prop('checked', false);
                    });

                $('#checkAll').on('click',
                    function () {
                        $('.rowCheck').prop('checked', this.checked);
                    });
            },
            timeout: 5000,
            error: function () {

            }
        });
    };

 }