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

</head>
<body class="bg-coming-soon">

    <!-- Start wrapper-->
    <div id="wrapper">
        @RenderBody()
    </div>
    <!--End wrapper-->

    @Scripts.Render("~/bundles/TemplateScript")

    @RenderSection("scripts", required:=False)
</body>
</html>
