@Imports SIPRECA.My.Resources
<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="icon" href="~/assets/images/favicon.ico" type="image/x-icon">
    <title>@ViewBag.Title - @Resource.SIPRECA_Text</title>
    @Styles.Render("~/Assets/TemplateStyle")
    @Styles.Render("~/Assets/JQueryConfirmCSS")

    @*@Scripts.Render("~/bundles/TemplateScript")*@

</head>
<body @*onload="info_noti()"*@>

    <!-- Start wrapper-->
    <div id="wrapper">

        <!--Start sidebar-wrapper-->
        @Html.Partial("_LeftSideBarAlertes")
        <!--End sidebar-wrapper-->
        <!--Start topbar header-->
        @Html.Partial("_HeaderPrincipal")
        <!--End topbar header-->

        <div class="clearfix"></div>

        <!--Start content-wrapper-->
        <div class="content-wrapper">
            @RenderBody()
        </div>
        <!--End content-wrapper-->
        <!--Start Back To Top Button-->
        <a href="javaScript:void();" class="back-to-top"><i class="fa fa-angle-double-up"></i> </a>
        <!--End Back To Top Button-->
        <!--Start footer-->
        @Html.Partial("_Footer")
        <!--End footer-->

    </div>
    <!--End wrapper-->

    @Scripts.Render("~/bundles/TemplateScript")
    @Scripts.Render("~/bundles/JQueryConfirmJS")

    <!--DataTable Start-->
    <script>
        $(document).ready(function () {
            //Default data table
            //$('#default-datatable').DataTable();

            $('#default-datatable').dataTable(
                {
                    destroy: true,
                    searching: false,
                    sorting: false,
                    orderClasses: false,
                    info: false,
                    paging: false
                });


            var table = $('#example').DataTable({
                lengthChange: false,
                buttons: ['copy', 'excel', 'pdf', 'print', 'colvis']
            });

            table.buttons().container()
                .appendTo('#example_wrapper .col-md-6:eq(0)');

        });

    </script>
    <!--DataTable End-->
    <!--Bootstrap Datepicker Js-->
    @*<script src="assets/plugins/bootstrap-datepicker/js/bootstrap-datepicker.min.js"></script>*@
    <script>
        $('.default-datepicker').datepicker({
            todayHighlight: true,
            format: "dd/mm/yyyy"
        });
        $('#autoclose-datepicker').datepicker({
            autoclose: true,
            todayHighlight: true
        });

        $('#inline-datepicker').datepicker({
            todayHighlight: true
        });

        $('#dateragne-picker .input-daterange').datepicker({
        });

    </script>

    <!--Multi Select Js-->
    <script>
        $('.single-select').select2();

        $('.multiple-select').select2();

        //multiselect start

        $('#my_multi_select1').multiSelect();
        $('#my_multi_select2').multiSelect({
            selectableOptgroup: true
        });

        $('#my_multi_select3').multiSelect({
            selectableHeader: "<input type='text' class='form-control search-input' autocomplete='off' placeholder='search...'>",
            selectionHeader: "<input type='text' class='form-control search-input' autocomplete='off' placeholder='search...'>",
            afterInit: function (ms) {
                var that = this,
                    $selectableSearch = that.$selectableUl.prev(),
                    $selectionSearch = that.$selectionUl.prev(),
                    selectableSearchString = '#' + that.$container.attr('id') + ' .ms-elem-selectable:not(.ms-selected)',
                    selectionSearchString = '#' + that.$container.attr('id') + ' .ms-elem-selection.ms-selected';

                that.qs1 = $selectableSearch.quicksearch(selectableSearchString)
                    .on('keydown', function (e) {
                        if (e.which === 40) {
                            that.$selectableUl.focus();
                            return false;
                        }
                    });

                that.qs2 = $selectionSearch.quicksearch(selectionSearchString)
                    .on('keydown', function (e) {
                        if (e.which == 40) {
                            that.$selectionUl.focus();
                            return false;
                        }
                    });
            },
            afterSelect: function () {
                this.qs1.cache();
                this.qs2.cache();
            },
            afterDeselect: function () {
                this.qs1.cache();
                this.qs2.cache();
            }
        });

        $('.custom-header').multiSelect({
            selectableHeader: "<div class='custom-header'>Selectable items</div>",
            selectionHeader: "<div class='custom-header'>Selection items</div>",
            selectableFooter: "<div class='custom-header'>Selectable footer</div>",
            selectionFooter: "<div class='custom-header'>Selection footer</div>"
        });

        $('.summernoteEditor').summernote({
            //['insert', ['link', 'picture', 'video']],
            height: 400,
            tabsize: 2,
            toolbar: [
                ['style', ['style']],
                ['font', ['bold', 'underline', 'clear']],
                ['fontname', ['fontname']],
                ['color', ['color']],
                ['para', ['ul', 'ol', 'paragraph']],
                ['table', ['table']],
                ['insert', ['link']],
                ['view', ['fullscreen', 'codeview', 'help']],
            ]
        });

    </script>

    @RenderSection("scripts", required:=False)
</body>
</html>
