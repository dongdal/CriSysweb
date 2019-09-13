Imports System.Data.Entity
Imports System.Data.Entity.Spatial
Imports System.Data.Entity.Validation
Imports System.Net
Imports Microsoft.AspNet.Identity
Imports PagedList

Namespace Controllers
    Public Class ElementsController
        Inherits BaseController

        Private _db As New ApplicationDbContext

        Public Property Db As ApplicationDbContext
            Get
                Return _db
            End Get
            Set(value As ApplicationDbContext)
                _db = value
            End Set
        End Property

        Private Function GetCurrentUser() As ApplicationUser
            Dim id = User.Identity.GetUserId
            Dim aspuser = Db.Users.Find(id)
            Return aspuser
        End Function

        ' GET: Element
        Function Index(sortOrder As String, currentFilter As String, searchString As String, page As Integer?) As ActionResult
            ViewBag.CurrentSort = sortOrder
            ViewBag.NomSort = If(sortOrder = "Nom", "Nom_desc", "Nom")
            ViewBag.UniteMesureSort = If(sortOrder = "UniteMesure", "UniteMesure_desc", "UniteMesure")
            ViewBag.ValeurParUniteSort = If(sortOrder = "ValeurParUnite", "ValeurParUnite_desc", "ValeurParUnite")
            ViewBag.CodeSort = If(sortOrder = "Code", "Code_desc", "Code")
            ViewBag.LongueurSort = If(sortOrder = "Longueur", "Longueur_desc", "Longueur")
            ViewBag.LargeurSort = If(sortOrder = "Largeur", "Largeur_desc", "Largeur")
            ViewBag.AnneeFabricationSort = If(sortOrder = "AnneeFabrication", "AnneeFabrication_desc", "AnneeFabrication")
            ViewBag.PoidsSort = If(sortOrder = "Poids", "Poids_desc", "Poids")
            ViewBag.HauteurSort = If(sortOrder = "Hauteur", "Hauteur_desc", "Hauteur")
            ViewBag.PrixAchatSort = If(sortOrder = "PrixAchat", "PrixAchat_desc", "PrixAchat")
            ViewBag.CategorieElementSort = If(sortOrder = "CategorieElement", "CategorieElement_desc", "CategorieElement")
            ViewBag.MarqueElementSort = If(sortOrder = "MarqueElement", "MarqueElement_desc", "MarqueElement")
            ViewBag.DeviseSort = If(sortOrder = "Devise", "Devise_desc", "Devise")
            ViewBag.DateCreationSort = If(sortOrder = "DateCreation", "DateCreation_desc", "DateCreation")
            ViewBag.StatutExistantSort = If(sortOrder = "StatutExistant", "StatutExistant_desc", "StatutExistant")

            If Not String.IsNullOrEmpty(searchString) Then
                page = 1
            Else
                searchString = currentFilter
            End If

            ViewBag.CurrentFilter = searchString

            Dim entities = (From e In Db.Element Where e.StatutExistant = 1 Select e)
            If Not String.IsNullOrEmpty(searchString) Then
                entities = entities.Where(Function(e) e.Nom.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.Code.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.MarqueElement.Libelle.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.CategorieElement.Libelle.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.Hauteur.Equals(searchString) Or
                                              e.Devise.Libelle.ToUpper.Contains(value:=searchString.ToUpper) Or
                                              e.AnneeFabrication.Equals(searchString) Or
                                              e.PrixAchat.Equals(searchString))
            End If
            ViewBag.EnregCount = entities.Count

            Select Case sortOrder

                Case "Nom"
                    entities = entities.OrderBy(Function(e) e.Nom)
                Case "Nom_desc"
                    entities = entities.OrderByDescending(Function(e) e.Nom)
                Case "Code"
                    entities = entities.OrderBy(Function(e) e.Code)
                Case "Code_desc"
                    entities = entities.OrderByDescending(Function(e) e.Code)
                Case "UniteMesure"
                    entities = entities.OrderBy(Function(e) e.UniteMesure)
                Case "UniteMesure_desc"
                    entities = entities.OrderByDescending(Function(e) e.UniteMesure)
                Case "ValeurParUnite"
                    entities = entities.OrderBy(Function(e) e.ValeurParUnité)
                Case "ValeurParUnite_desc"
                    entities = entities.OrderByDescending(Function(e) e.ValeurParUnité)
                Case "Longueur"
                    entities = entities.OrderBy(Function(e) e.Longueur)
                Case "Longueur_desc"
                    entities = entities.OrderByDescending(Function(e) e.Longueur)
                Case "Largeur"
                    entities = entities.OrderBy(Function(e) e.Largeur)
                Case "Largeur_desc"
                    entities = entities.OrderByDescending(Function(e) e.Largeur)
                Case "AnneeFabrication"
                    entities = entities.OrderBy(Function(e) e.AnneeFabrication)
                Case "AnneeFabrication_desc"
                    entities = entities.OrderByDescending(Function(e) e.AnneeFabrication)
                Case "Poids"
                    entities = entities.OrderBy(Function(e) e.Poids)
                Case "Poids_desc"
                    entities = entities.OrderByDescending(Function(e) e.Poids)
                Case "PrixAchat"
                    entities = entities.OrderBy(Function(e) e.PrixAchat)
                Case "PrixAchat_desc"
                    entities = entities.OrderByDescending(Function(e) e.PrixAchat)
                Case "CategorieElement"
                    entities = entities.OrderBy(Function(e) e.CategorieElement.Libelle)
                Case "CategorieElement"
                    entities = entities.OrderByDescending(Function(e) e.CategorieElement.Libelle)
                Case "MarqueElement"
                    entities = entities.OrderBy(Function(e) e.MarqueElement)
                Case "MarqueElement_desc"
                    entities = entities.OrderByDescending(Function(e) e.MarqueElement)
                Case "Devise"
                    entities = entities.OrderBy(Function(e) e.Devise.Libelle)
                Case "Devise_desc"
                    entities = entities.OrderByDescending(Function(e) e.Devise.Libelle)
                Case Else
                    entities = entities.OrderBy(Function(e) e.Nom)
                    Exit Select
            End Select

            Dim pageSize As Integer = ConfigurationManager.AppSettings("pageSize")
            Dim pageNumber As Integer = If(page, 1)

            Return View(entities.ToPagedList(pageNumber, pageSize))
        End Function

        ' GET: Element/Details/5
        'Function Details(ByVal id As Long?) As ActionResult
        '    If IsNothing(id) Then
        '        Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
        '    End If
        '    Dim Element As Element = Db.Element.Find(id)
        '    If IsNothing(Element) Then
        '        Return HttpNotFound()
        '    End If
        '    Return View(Element)
        'End Function

        Private Sub LoadComboBox(entityVM As ElementViewModel)
            Dim AspNetUser = (From e In Db.Users Where e.Etat = 1 Select e)
            Dim LesUtilisateurs As New List(Of SelectListItem)
            Dim CategorieElement = (From e In Db.CategorieElement Where e.StatutExistant = 1 Select e)
            Dim LesCategorieElements As New List(Of SelectListItem)
            Dim MarqueElement = (From e In Db.MarqueElement Where e.StatutExistant = 1 Select e)
            Dim LesMarqueElements As New List(Of SelectListItem)
            Dim Devise = (From e In Db.Devise Where e.StatutExistant = 1 Select e)
            Dim LesDevises As New List(Of SelectListItem)

            For Each item In AspNetUser
                If String.IsNullOrEmpty(item.Prenom) Then
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom})
                Else
                    LesUtilisateurs.Add(New SelectListItem With {.Value = item.Id, .Text = item.Nom & " | " & item.Prenom})
                End If
            Next

            For Each item In CategorieElement
                LesCategorieElements.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            For Each item In MarqueElement
                LesMarqueElements.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            For Each item In Devise
                LesDevises.Add(New SelectListItem With {.Value = item.Id, .Text = item.Libelle})
            Next

            entityVM.LesUtilisateurs = LesUtilisateurs
            entityVM.LesMarqueElements = LesMarqueElements
            entityVM.LesCategorieElements = LesCategorieElements
            entityVM.LesDevises = LesDevises
        End Sub

        ' GET: Element/Create
        Function Create() As ActionResult
            Dim entityVM As New ElementViewModel
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function


        '<HttpPost()>
        'Function Create(ByVal entityVM As InstallationsJS) As ActionResult
        '    Dim Ent As New Element
        '    Ent = entityVM.GetEntity(GetCurrentUser.Id)

        '    If (IsNothing(Ent.Location)) Then
        '        ModelState.AddModelError("", "Veuillez remplir le champ location")
        '    End If
        '    ' DbGeography.FromText("POINT(-122.336106 47.605049)")
        '    If ModelState.IsValid Then
        '        Db.Element.Add(Ent)
        '        Try
        '            Db.SaveChanges()
        '            Return Json(New With {.Result = "OK"})
        '        Catch ex As DbEntityValidationException
        '            Util.GetError(ex, ModelState)
        '        Catch ex As Exception
        '            Util.GetError(ex, ModelState)
        '        End Try
        '    End If
        '    'LoadComboBox(entityVM)
        '    Return Json(New With {.Result = "Error"})
        '    'Return View(entityVM)
        'End Function

        ' POST: Element/Create
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(ByVal entityVM As ElementViewModel) As ActionResult
            entityVM.AspNetUserId = GetCurrentUser.Id
            If ModelState.IsValid Then

                Db.Element.Add(entityVM.GetEntity)
                Try
                    Db.SaveChanges()
                    Return RedirectToAction("Index")
                Catch ex As DbEntityValidationException
                    Util.GetError(ex, ModelState)
                Catch ex As Exception
                    Util.GetError(ex, ModelState)
                End Try
            End If
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' GET: Element/Edit/5
        Function Edit(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim Element As Element = Db.Element.Find(id)
            If IsNothing(Element) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New ElementViewModel(Element)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: Element/Edit/5
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(ByVal entityVM As ElementViewModel) As ActionResult
            If ModelState.IsValid Then
                Db.Entry(entityVM.GetEntity).State = EntityState.Modified
                Try
                    Db.SaveChanges()
                    Return RedirectToAction("Index")
                Catch ex As DbEntityValidationException
                    Util.GetError(ex, ModelState)
                Catch ex As Exception
                    Util.GetError(ex, ModelState)
                End Try
            End If
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' GET: Element/Delete/5
        Function Delete(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim Element As Element = Db.Element.Find(id)
            If IsNothing(Element) Then
                Return HttpNotFound()
            End If
            Dim entityVM As New ElementViewModel(Element)
            LoadComboBox(entityVM)
            Return View(entityVM)
        End Function

        ' POST: Element/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Long) As ActionResult
            Dim Element As Element = Db.Element.Find(id)
            Db.Element.Remove(Element)
            Try
                Db.SaveChanges()
                Return RedirectToAction("Index")
            Catch ex As DbEntityValidationException
                Util.GetError(ex, ModelState)
            Catch ex As Exception
                Util.GetError(ex, ModelState)
            End Try
            Return View(New ElementViewModel(Element))
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                Db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class


End Namespace
