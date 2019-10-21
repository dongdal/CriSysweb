@ModelType SIPRECA.CardreSendaiCibleAViewModel
@Imports SIPRECA.My.Resources
@Code
    ViewData("Title") = Resource.EditIndicateursCibleA
    Layout = "~/Views/Shared/_LayoutDesinventar.vbhtml"
End Code

<div class="page-header">
    <h1 class="page-title">@Resource.ManageEvenementZone</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "CardreSendaiCibleA")>@Resource.ManageEvenementZone</a></li>
        <li class="breadcrumb-item active">@Resource.EditIndicateursCibleA</li>
    </ol>
</div>


<div class="container-fluid">

    <div class="card">
        <div class="card-body">
            <div class="card-title text-uppercase"><i class="fa fa-address-book-o"></i> @Resource.EditIndicateursCibleA</div>
            <hr>
            @Using Html.BeginForm("Edit", "CardreSendaiCibleA", FormMethod.Post, New With {.autocomplete = "off"})
                @Html.AntiForgeryToken()
                @Html.HiddenFor(Function(model) model.Id)
                @Html.HiddenFor(Function(model) model.AspNetUserId)
                @Html.HiddenFor(Function(model) model.StatutExistant)
                @Html.HiddenFor(Function(model) model.DateCreation)

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.EvenementZoneId, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4 form-group">
                        @Html.DropDownListFor(Function(m) m.EvenementZoneId, New SelectList(Model.LesEvenementsZone, "Value", "Text"), Resource.ComboEvenement,
              New With {.class = "form-control single-select", .tabindex = "1", .Placeholder = Resource.EvenementCombo})
                        @Html.ValidationMessageFor(Function(m) m.EvenementZoneId, "", New With {.style = "color: #da0b0b"})
                    </div>
                    <p style="text-indent: 25px; text-align:justify; font-style:italic; font-size: 10px; color: red">
                        Veuillez enregistrer dans cette section le nombre de pertes humaines (en nombre de personnes) nécessaires pour atteindre la cible A, nombre de morts et de personnes
                        disparues imputables à une catastrophe. Ces champs seront utilisés pour calculer les indicateurs A2, A3, B2, B5 et autres. Si possible, entrez des chiffres désagrégés et
                        utilisez le bouton "<strong>Faire Somme</strong>" pour calculer la somme de chaque sous-groupe.
                    </p>
                </div>

                @<fieldset style="border:ridge;">
                    <legend style="font-size: 14px">@Resource.NombrePersonnesDecedees</legend>
                    <br />
                    <br />
                    <div Class="form-group row">
                        <div Class="col-md-3">
                            @Html.LabelFor(Function(m) m.NombreTotalDeces, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 8px;  height: 25px; width:100%"}) (A-2)
                            <div class="col-sm-8" style="max-width: 100%">
                                @Html.EditorFor(Function(model) model.NombreTotalDeces,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "2", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                @Html.ValidationMessageFor(Function(m) m.NombreTotalDeces, "", New With {.style = "color: #da0b0b"})
                            </div>
                            <br />
                            &nbsp;&nbsp;&nbsp;
                            &nbsp;&nbsp;&nbsp;
                            &nbsp;&nbsp;&nbsp;
                            &nbsp;&nbsp;&nbsp;
                            <button onclick="SommeDecedes();" type="button" class="btn btn-round btn-success waves-effect waves-light m-1"><i Class="icon-calculator"></i> @Resource.FaireSomme</button>
                        </div>

                        <div Class="col-md-3">
                            <fieldset style="border: ridge;">
                                <legend style="font-size: 14px">@Resource.ParSexe</legend>

                                @Html.LabelFor(Function(m) m.NombreDecesFemme, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 8px;  height: 25px; width:100%"})
                                <div class="col-sm-8" style="max-width: 100%">
                                    @Html.EditorFor(Function(model) model.NombreDecesFemme,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "3", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                    @Html.ValidationMessageFor(Function(m) m.NombreDecesFemme, "", New With {.style = "color: #da0b0b"})
                                </div>

                                @Html.LabelFor(Function(m) m.NombreDecesHomme, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 8px;  height: 25px; width:100%"})
                                <div class="col-sm-8" style="max-width: 100%">
                                    @Html.EditorFor(Function(model) model.NombreDecesHomme,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "4", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                    @Html.ValidationMessageFor(Function(m) m.NombreDecesHomme, "", New With {.style = "color: #da0b0b"})
                                </div>
                            </fieldset>
                        </div>

                        <div Class="col-md-3">
                            <fieldset style="border: ridge;">
                                <legend style="font-size: 14px">@Resource.ParAge</legend>

                                @Html.LabelFor(Function(m) m.NombreDecesEnfant, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 8px;  height: 25px; width:100%,"})
                                <div class="col-sm-8" style="max-width: 100%">
                                    @Html.EditorFor(Function(model) model.NombreDecesEnfant,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "5", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                    @Html.ValidationMessageFor(Function(m) m.NombreDecesEnfant, "", New With {.style = "color: #da0b0b"})
                                </div>

                                @Html.LabelFor(Function(m) m.NombreDecesAdult, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 8px;  height: 25px; width:100%"})
                                <div class="col-sm-8" style="max-width: 100%">
                                    @Html.EditorFor(Function(model) model.NombreDecesAdult,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "6", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                    @Html.ValidationMessageFor(Function(m) m.NombreDecesAdult, "", New With {.style = "color: #da0b0b"})
                                </div>

                                @Html.LabelFor(Function(m) m.NombreDecesVieux, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 8px;  height: 25px; width:100%;max-width: 100%"})
                                <div class="col-sm-8" style="max-width: 100%">
                                    @Html.EditorFor(Function(model) model.NombreDecesVieux,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "7", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                    @Html.ValidationMessageFor(Function(m) m.NombreDecesVieux, "", New With {.style = "color: #da0b0b"})
                                </div>
                            </fieldset>
                        </div>

                        <div Class="col-md-3">
                            <fieldset style="border: ridge;">
                                <legend style="font-size: 14px">@Resource.AutreDesagregation</legend>

                                @Html.LabelFor(Function(m) m.NombreDecesHandicape, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 8px;  height: 25px; width:100%;max-width: 100%"})
                                <div class="col-sm-8" style="max-width: 100%">
                                    @Html.EditorFor(Function(model) model.NombreDecesHandicape,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "8", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                    @Html.ValidationMessageFor(Function(m) m.NombreDecesHandicape, "", New With {.style = "color: #da0b0b"})
                                </div>

                                @Html.LabelFor(Function(m) m.NombreDecesPauvre, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 8px;  height: 25px; width:100%;max-width: 100%"})
                                <div class="col-sm-8" style="max-width: 100%">
                                    @Html.EditorFor(Function(model) model.NombreDecesPauvre,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "9", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                    @Html.ValidationMessageFor(Function(m) m.NombreDecesPauvre, "", New With {.style = "color: #da0b0b"})
                                </div>
                            </fieldset>
                        </div>

                    </div>

                </fieldset>

                @<br />
                @<br />

                @<fieldset style="border:ridge;">
                    <legend style="font-size: 14px">@Resource.NombrePersonnesDisparues</legend>
                    <br />
                    <br />
                    <div Class="form-group row">
                        <div Class="col-md-3">
                            @Html.LabelFor(Function(m) m.NombreTotalDisparue, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 8px;  height: 25px; width:100%;;max-width: 100%"}) (A - 3)
                            <div class="col-sm-8" style="max-width: 100%">
                                @Html.EditorFor(Function(model) model.NombreTotalDisparue,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "10", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                @Html.ValidationMessageFor(Function(m) m.NombreTotalDisparue, "", New With {.style = "color: #da0b0b"})
                            </div>
                            <br />
                            &nbsp;&nbsp;&nbsp;
                            &nbsp;&nbsp;&nbsp;
                            &nbsp;&nbsp;&nbsp;
                            &nbsp;&nbsp;&nbsp;
                            <button onclick="SommeDisparus();" type="button" class="btn btn-round btn-success waves-effect waves-light m-1"><i Class="icon-calculator"></i> @Resource.FaireSomme</button>
                        </div>

                        <div Class="col-md-3">
                            <fieldset style="border: ridge;">
                                <legend style="font-size: 14px">@Resource.ParSexe</legend>

                                @Html.LabelFor(Function(m) m.NombreDisparueFemme, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 8px;  height: 25px; width:100%"})
                                <div class="col-sm-8" style="max-width: 100%">
                                    @Html.EditorFor(Function(model) model.NombreDisparueFemme,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "11", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                    @Html.ValidationMessageFor(Function(m) m.NombreDisparueFemme, "", New With {.style = "color: #da0b0b"})
                                </div>

                                @Html.LabelFor(Function(m) m.NombreDisparueHomme, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 8px;  height: 25px; width:100%"})
                                <div class="col-sm-8" style="max-width: 100%">
                                    @Html.EditorFor(Function(model) model.NombreDisparueHomme,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "12", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                    @Html.ValidationMessageFor(Function(m) m.NombreDisparueHomme, "", New With {.style = "color: #da0b0b"})
                                </div>
                            </fieldset>
                        </div>

                        <div Class="col-md-3">
                            <fieldset style="border: ridge;">
                                <legend style="font-size: 14px">@Resource.ParAge</legend>

                                @Html.LabelFor(Function(m) m.NombreDisparueEnfant, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 8px;  height: 25px; width:100%,"})
                                <div class="col-sm-8" style="max-width: 100%">
                                    @Html.EditorFor(Function(model) model.NombreDisparueEnfant,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "13", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                    @Html.ValidationMessageFor(Function(m) m.NombreDisparueEnfant, "", New With {.style = "color: #da0b0b"})
                                </div>

                                @Html.LabelFor(Function(m) m.NombreDisparueAdult, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 8px;  height: 25px; width:100%"})
                                <div class="col-sm-8" style="max-width: 100%">
                                    @Html.EditorFor(Function(model) model.NombreDisparueAdult,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "14", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                    @Html.ValidationMessageFor(Function(m) m.NombreDisparueAdult, "", New With {.style = "color: #da0b0b"})
                                </div>

                                @Html.LabelFor(Function(m) m.NombreDisparueVieux, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 8px;  height: 25px; width:100%;max-width: 100%"})
                                <div class="col-sm-8" style="max-width: 100%">
                                    @Html.EditorFor(Function(model) model.NombreDisparueVieux,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "15", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                    @Html.ValidationMessageFor(Function(m) m.NombreDisparueVieux, "", New With {.style = "color: #da0b0b"})
                                </div>
                            </fieldset>
                        </div>

                        <div Class="col-md-3">
                            <fieldset style="border: ridge;">
                                <legend style="font-size: 14px">@Resource.AutreDesagregation</legend>

                                @Html.LabelFor(Function(m) m.NombreDisparueHandicape, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 8px;  height: 25px; width:100%;max-width: 100%"})
                                <div class="col-sm-8" style="max-width: 100%">
                                    @Html.EditorFor(Function(model) model.NombreDisparueHandicape,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "16", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                    @Html.ValidationMessageFor(Function(m) m.NombreDisparueHandicape, "", New With {.style = "color: #da0b0b"})
                                </div>

                                @Html.LabelFor(Function(m) m.NombreDisparuePauvre, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 8px;  height: 25px; width:100%;max-width: 100%"})
                                <div class="col-sm-8" style="max-width: 100%">
                                    @Html.EditorFor(Function(model) model.NombreDisparuePauvre,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "17", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                    @Html.ValidationMessageFor(Function(m) m.NombreDisparuePauvre, "", New With {.style = "color: #da0b0b"})
                                </div>
                            </fieldset>
                        </div>

                    </div>

                </fieldset>

                @<div Class="form-group row">

                    <Label Class="col-sm-1 col-form-label"></Label>
                    <div Class="col-sm-10">
                        <br />
                        <br />
                        <Button type="submit" Class="btn btn-link btn-square bg-warning text-dark shadow px-5"><i Class="icon-lock"></i> @Resource.Btn_Edit</Button>
                        &nbsp;&nbsp;&nbsp;
                        @Html.ActionLink(Resource.BtnCancel, "Index", "EvenementZones", Nothing, New With {.class = "btn btn-link btn-square bg-white text-dark shadow px-5"})
                    </div>
                </div>

            End Using

        </div>
    </div>
</div>

    <script>
        var NombreTotalDeces = '#NombreTotalDeces';
        var NombreDecesFemme = '#NombreDecesFemme';
        var NombreDecesHomme = '#NombreDecesHomme';
        var totalDecesParSexe = null;
        var NombreDecesEnfant = '#NombreDecesEnfant';
        var NombreDecesAdult = '#NombreDecesAdult';
        var NombreDecesVieux = '#NombreDecesVieux';
        var totalDecesParAge = null;
        var NombreDecesHandicape = '#NombreDecesHandicape';
        var NombreDecesPauvre = '#NombreDecesPauvre';
        var totalDecesAutreDesagregation = null;

        var NombreTotalDisparue = '#NombreTotalDisparue';
        var NombreDisparueFemme = '#NombreDisparueFemme';
        var NombreDisparueHomme = '#NombreDisparueHomme';
        var totalDisparuParSexe = null;
        var NombreDisparueEnfant = '#NombreDisparueEnfant';
        var NombreDisparueAdult = '#NombreDisparueAdult';
        var NombreDisparueVieux = '#NombreDisparueVieux';
        var totalDisparusParAge = null;
        var NombreDisparueHandicape = '#NombreDisparueHandicape';
        var NombreDisparuePauvre = '#NombreDisparuePauvre';
        var totalDisparusAutreDesagregation = null;




        function SommeDecedes() {
            initalisationPourDecedes();
            var totalDeces = $(NombreTotalDeces).val();
            var arrayDeces = [totalDecesParSexe, totalDecesParAge, totalDecesAutreDesagregation, totalDeces];
            var result = null;

            var i = 0;
            arrayDeces.forEach(function (item) {
                if (item !== null && typeof (item) === 'number' && item > 0) {
                    result = (result === null) ? +item : (+result + +item);
                    i++;
                }
            });
            var ratio = (result / i);
            var nbre_error = 0;
            if (totalDeces === null || typeof (totalDeces) === undefined) {
                nbre_error = 0;
                arrayDeces.forEach(function (item) {
                    if (item !== null && typeof (item) === 'number' && item > 0) {
                        nbre_error = (item === ratio) ? nbre_error : (+nbre_error + +1);
                        alert(nbre_error);
                    }
                });
                if (nbre_error > 0) {
                    $.alert("Veuillez vous assurer que la somme de chaque sous groupe donne la même valeur.");
                    document.getElementById("NombreTotalDeces").value = null;
                }
                else {
                    document.getElementById("NombreTotalDeces").value = ratio;
                }
            }
            else {
                nbre_error = 0;
                if (totalDeces !== null & typeof (totalDeces) !== undefined) {
                    arrayDeces.forEach(function (item) {
                        if (item !== null && typeof (item) === 'number' && item > 0) {
                            nbre_error = (item === ratio) ? nbre_error : (+nbre_error + +1);
                        }
                    });
                    if (nbre_error > 0) {
                        $.alert("Rassurez-vous que la somme de chaque sous groupe donne le même résultat.");
                        document.getElementById("NombreTotalDeces").value = null;
                    }
                    else if (nbre_error === 0) {
                        if (ratio == totalDeces) {
                            document.getElementById("NombreTotalDeces").value = ratio;
                        } else if (typeof (totalDeces) != 'number' && typeof (totalDeces) != undefined && (+totalDeces) == 0) {
                            document.getElementById("NombreTotalDeces").value = ratio;
                        } else {
                            $.alert("Veuillez vous assurer que la somme de chaque sous groupe donne le même résultat.");
                            document.getElementById("NombreTotalDeces").value = null;
                        }
                    }
                }

            }
        }

        function SommeDisparus() {
            initalisationPourDisparus();
            var totalDisparus = $(NombreTotalDisparue).val();
            var arrayDisparus = [totalDisparuParSexe, totalDisparusParAge, totalDisparusAutreDesagregation, totalDisparus];
            var result = null;

            var i = 0;
            arrayDisparus.forEach(function (item) {
                if (item !== null && typeof (item) === 'number' && item > 0) {
                    result = (result === null) ? +item : (+result + +item);
                    i++;
                }
            });
            var ratio = (result / i);
            var nbre_error = 0;
            if (totalDisparus === null || typeof (totalDisparus) === undefined) {
                nbre_error = 0;
                arrayDisparus.forEach(function (item) {
                    if (item !== null && typeof (item) === 'number' && item > 0) {
                        nbre_error = (item === ratio) ? nbre_error : (+nbre_error + +1);
                        alert(nbre_error);
                    }
                });
                if (nbre_error > 0) {
                    $.alert("Veuillez vous assurer que la somme de chaque sous groupe donne la même valeur.");
                    document.getElementById("NombreTotalDisparue").value = null;
                }
                else {
                    document.getElementById("NombreTotalDisparue").value = ratio;
                }
            }
            else {
                nbre_error = 0;
                if (totalDisparus !== null & typeof (totalDisparus) !== undefined) {
                    arrayDisparus.forEach(function (item) {
                        if (item !== null && typeof (item) === 'number' && item > 0) {
                            nbre_error = (item === ratio) ? nbre_error : (+nbre_error + +1);
                        }
                    });
                    if (nbre_error > 0) {
                        $.alert("Rassurez-vous que la somme de chaque sous groupe donne le même résultat.");
                        document.getElementById("NombreTotalDisparue").value = null;
                    }
                    else if (nbre_error === 0) {
                        if (ratio == totalDisparus) {
                            document.getElementById("NombreTotalDisparue").value = ratio;
                        } else if (typeof (totalDisparus) != 'number' && typeof (totalDisparus) != undefined && (+totalDisparus) == 0) {
                            document.getElementById("NombreTotalDisparue").value = ratio;
                        } else {
                            $.alert("Veuillez vous assurer que la somme de chaque sous groupe donne le même résultat.");
                            document.getElementById("NombreTotalDisparue").value = null;
                        }
                    }
                }

            }
        }


        function initalisationPourDisparus() {
            //var totalDeces = $(NombreTotalDeces).val();

            sexeDisparueFemale = $(NombreDisparueFemme).val();
            sexeDisparueMale = $(NombreDisparueHomme).val();
            var arrayDisparueSexe = [sexeDisparueFemale, sexeDisparueMale];
            totalDisparuParSexe = checkByGender(arrayDisparueSexe);

            ageDisparueEnfant = $(NombreDisparueEnfant).val();
            ageDisparueAdulte = $(NombreDisparueAdult).val();
            ageDisparueAges = $(NombreDisparueVieux).val();
            var arrayDisparueAge = [ageDisparueEnfant, ageDisparueAdulte, ageDisparueAges];
            totalDisparusParAge = checkByAge(arrayDisparueAge);


            handicapDisparue = $(NombreDisparueHandicape).val();
            pauvreDisparue = $(NombreDisparuePauvre).val();
            var arrayDisparusAutreDesagregation = [handicapDisparue, pauvreDisparue];
            totalDisparusAutreDesagregation = checkByAutreDesagregation(arrayDisparusAutreDesagregation);
        }

        function initalisationPourDecedes() {
            //var totalDeces = $(NombreTotalDeces).val();

            sexeDecedeFemale = $(NombreDecesFemme).val();
            sexeDecedeMale = $(NombreDecesHomme).val();
            var arrayDecesSexe = [sexeDecedeFemale, sexeDecedeMale];
            totalDecesParSexe = checkByGender(arrayDecesSexe);

            ageDecedeEnfant = $(NombreDecesEnfant).val();
            ageDecedeAdulte = $(NombreDecesAdult).val();
            ageDecedeAges = $(NombreDecesVieux).val();
            var arrayDecesAge = [ageDecedeEnfant, ageDecedeAdulte, ageDecedeAges];
            totalDecesParAge = checkByAge(arrayDecesAge);


            handicapDecede = $(NombreDecesHandicape).val();
            pauvreDecede = $(NombreDecesPauvre).val();
            var arrayDecesAutreDesagregation = [handicapDecede, pauvreDecede];
            totalDecesAutreDesagregation = checkByAutreDesagregation(arrayDecesAutreDesagregation);
        }

        function checkByGender(array) {
            var result = null;
            array.forEach(function (item) {
                if (item !== null && typeof (item) !== undefined) {
                    result = (result === null) ? +item : (+result + +item);
                }
            });
            return result;
        }

        function checkByAge(array) {
            var result = null;
            array.forEach(function (item) {
                if (item !== null && typeof (item) !== undefined) {
                    result = (result === null) ? +item : (+result + +item);
                }
            });
            return result;
        }

        function checkByAutreDesagregation(array) {
            var result = null;
            array.forEach(function (item) {
                if (item !== null && typeof (item) !== undefined) {
                    result = (result === null) ? +item : (+result + +item);
                }
            });
            return result;
        }


    </script>
