@*@ModelType FlashMoneyWeb.EditUserViewModel*@
@Imports Microsoft.AspNet.Identity
@Imports SIPRECA.My.Resources
@Code
    ViewBag.Title = Resource.GestUser_ManageAccount
    Dim MessageStatus = Resource.GestUser_PwdModify
    Layout = "~/Views/Shared/_LayoutParam.vbhtml"
End Code



<div class="page-header">
    <h1 class="page-title">@Resource.GestUser_ManageAccount</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Account")>@Resource.GestUser</a></li>
        <li class="breadcrumb-item active">@Resource.ChgPwd</li>
    </ol>
</div>

<div class="container-fluid">

    <div class="card">
        <div class="card-body">
            <div class="card-title text-uppercase"><i class="fa fa-address-book-o"></i> @Resource.ChgPwd</div>
            <hr>
            @Using Html.BeginForm("ChangeUserPassword", "Account", FormMethod.Post, New With {.autocomplete = "off"})
                @Html.AntiForgeryToken()
                @Html.Partial("_ChangePasswordPartial")

                @<div Class="form-group row">
                    <Label Class="col-sm-2 col-form-label"></Label>
                    <div Class="col-sm-10">
                        <Button type="submit" Class="btn btn-link btn-square bg-primary text-dark shadow px-5"><i Class="icon-lock"></i> @Resource.BtnSave</Button>
                        &nbsp;&nbsp;&nbsp;
                        @Html.ActionLink(Resource.BtnCancel, "Index", "Home", Nothing, New With {.class = "btn btn-link btn-square bg-white text-dark shadow px-5"})
                    </div>
                </div>

            End Using


        </div>
    </div>
</div>



@Section Scripts

    <script>

        var Message = '@ViewData("StatusMessage").ToString()';
        var UserName = '@User.Identity.GetUserName()';
        var MessageSucces = "@Resource.GestUser_PwdModify";
        var MessageImpossibleToChange = "@Resource.ChangePasswordImpossible";
        if (Message == MessageSucces) {
            //alert("Bonjour et " + Message);
            $.alert({
                title: '@Resource.SuccessAlertTitle',
                content: '@Resource.SuccesAlertBody',
                type: 'green',
                typeAnimated: true,
                buttons: {
                    close: {
                        text: '@Resource.BtnClose',
                        btnClass: 'btn-green',
                        action: function () {
                        }
                    }
                }
            });
        } else if (Message == MessageImpossibleToChange) {
            $.alert({
                title: '@Resource.ErrorAlertTitle',
                content: '@Resource.ChangePasswordImpossible',
                type: 'red',
                typeAnimated: true,
                buttons: {
                    close: {
                        text: '@Resource.BtnClose',
                        btnClass: 'btn-red',
                        action: function () {
                        }
                    }
                }
            });
        }


    </script>

End Section