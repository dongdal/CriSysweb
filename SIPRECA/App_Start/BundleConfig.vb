Imports System.Web.Optimization

Public Module BundleConfig
    ' Pour plus d’informations sur le regroupement, rendez-vous sur http://go.microsoft.com/fwlink/?LinkId=301862
    Public Sub RegisterBundles(ByVal bundles As BundleCollection)

        bundles.Add(New ScriptBundle("~/bundles/jquery").Include(
                    "~/Scripts/jquery-{version}.js"))

        bundles.Add(New ScriptBundle("~/bundles/jqueryval").Include(
                    "~/Scripts/jquery.validate*"))

        ' Utilisez la version de développement de Modernizr pour développer et apprendre. Puis, lorsque vous êtes
        ' prêt pour la production, utilisez l’outil de génération sur http://modernizr.com pour sélectionner uniquement les tests dont vous avez besoin.
        bundles.Add(New ScriptBundle("~/bundles/modernizr").Include(
                    "~/Scripts/modernizr-*"))

        bundles.Add(New ScriptBundle("~/bundles/bootstrap").Include(
                  "~/Scripts/bootstrap.js",
                  "~/Scripts/respond.js"))

        bundles.Add(New StyleBundle("~/Content/css").Include(
                  "~/Content/bootstrap.css",
                  "~/Content/site.css"))


        bundles.Add(New StyleBundle("~/Assets/TemplateStyle").Include(
                  "~/assets/plugins/notifications/css/lobibox.min.css",
                  "~/assets/plugins/vectormap/jquery-jvectormap-2.0.2.css",
                  "~/assets/plugins/simplebar/css/simplebar.css",
                  "~/assets/css/bootstrap.min.css",
                  "~/assets/css/animate.css",
                  "~/assets/css/icons.css",
                  "~/assets/css/sidebar-menu.css",
                  "~/assets/plugins/select2/css/select2.min.css",
                  "~/assets/plugins/inputtags/css/bootstrap-tagsinput.css",
                  "~/assets/plugins/jquery-multi-select/multi-select.css",
                  "~/assets/plugins/bootstrap-datepicker/css/bootstrap-datepicker.min.css",
                  "~/assets/plugins/bootstrap-touchspin/css/jquery.bootstrap-touchspin.css",
                  "~/assets/css/PagedList.css",
                  "~/assets/css/app-style.css",
                  "~/assets/plugins/c3/css/c3.min.css",
                  "~/assets/plugins/summernote/dist/summernote-bs4.css"))

        bundles.Add(New ScriptBundle("~/bundles/TemplateScript").Include(
          "~/assets/js/jquery.min.js",
          "~/assets/js/popper.min.js",
          "~/assets/js/bootstrap.min.js",
          "~/assets/plugins/simplebar/js/simplebar.js",
          "~/assets/js/waves.js",
          "~/assets/js/sidebar-menu.js",
          "~/assets/js/app-script.js",
          "~/assets/plugins/bootstrap-touchspin/js/jquery.bootstrap-touchspin.js",
          "~/assets/plugins/bootstrap-touchspin/js/bootstrap-touchspin-script.js",
          "~/assets/plugins/select2/js/select2.min.js",
          "~/assets/plugins/inputtags/js/bootstrap-tagsinput.js",
          "~/assets/plugins/bootstrap-datepicker/js/bootstrap-datepicker.min.js",
          "~/assets/plugins/jquery-multi-select/jquery.multi-select.js",
          "~/assets/plugins/jquery-multi-select/jquery.quicksearch.js",
          "~/assets/plugins/vectormap/jquery-jvectormap-2.0.2.min.js",
          "~/assets/plugins/vectormap/jquery-jvectormap-world-mill-en.js",
          "~/assets/plugins/sparkline-charts/jquery.sparkline.min.js",
          "~/assets/plugins/Chart.js/Chart.min.js",
          "~/assets/plugins/notifications/js/lobibox.min.js",
          "~/assets/plugins/notifications/js/notifications.min.js",
          "~/assets/plugins/jquery.steps/js/jquery.steps.min.js",
          "~/assets/plugins/jquery-validation/js/jquery.validate.min.js",
          "~/assets/plugins/jquery.steps/js/jquery.wizard-init.js",
          "~/assets/js/index.js",
          "~/assets/plugins/d3/d3.min.js",
          "~/assets/plugins/c3/js/c3.min.js",
          "~/assets/plugins/c3/js/c3.js",
          "~/assets/plugins/summernote/dist/summernote-bs4.min.js"))


        bundles.Add(New StyleBundle("~/Assets/JQueryConfirmCSS").Include(
                  "~/assets/css/jquery-confirm.min.css"))

        bundles.Add(New ScriptBundle("~/bundles/JQueryConfirmJS").Include(
  "~/assets/js/jquery-confirm.min.js"))

        bundles.Add(New StyleBundle("~/Assets/LeafletCSS").Include(
                  "~/assets/plugins/leaflet/leaflet.css"))

        bundles.Add(New ScriptBundle("~/bundles/LeafletJS").Include(
            "~/assets/plugins/leaflet/leaflet.js"))

    End Sub
End Module

