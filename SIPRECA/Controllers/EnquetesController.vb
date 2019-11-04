Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports SIPRECA

Namespace Controllers
    Public Class EnquetesController
        Inherits System.Web.Mvc.Controller

        Private db As New ApplicationDbContext

        ' GET: Enquetes
        Function Index() As ActionResult
            Dim enquetes = db.Enquete.Include(Function(e) e.AspNetUser).Include(Function(e) e.Sinistre)
            Return View(enquetes.ToList())
        End Function

        ' GET: Enquetes/Details/5
        Function Details(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim enquete As Enquete = db.Enquete.Find(id)
            If IsNothing(enquete) Then
                Return HttpNotFound()
            End If
            Return View(enquete)
        End Function

        ' GET: Enquetes/Create
        Function Create() As ActionResult
            ViewBag.AspNetUserId = New SelectList(db.Users, "Id", "Nom")
            ViewBag.SinistreId = New SelectList(db.Sinistre, "Id", "Libelle")
            Return View()
        End Function

        ' POST: Enquetes/Create
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,SinistreId,Titre,Description,DateCreation,StatutExistant,AspNetUserId")> ByVal enquete As Enquete) As ActionResult
            If ModelState.IsValid Then
                db.Enquete.Add(enquete)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.AspNetUserId = New SelectList(db.Users, "Id", "Nom", enquete.AspNetUserId)
            ViewBag.SinistreId = New SelectList(db.Sinistre, "Id", "Libelle", enquete.SinistreId)
            Return View(enquete)
        End Function

        ' GET: Enquetes/Edit/5
        Function Edit(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim enquete As Enquete = db.Enquete.Find(id)
            If IsNothing(enquete) Then
                Return HttpNotFound()
            End If
            ViewBag.AspNetUserId = New SelectList(db.Users, "Id", "Nom", enquete.AspNetUserId)
            ViewBag.SinistreId = New SelectList(db.Sinistre, "Id", "Libelle", enquete.SinistreId)
            Return View(enquete)
        End Function

        ' POST: Enquetes/Edit/5
        'Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        'plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Id,SinistreId,Titre,Description,DateCreation,StatutExistant,AspNetUserId")> ByVal enquete As Enquete) As ActionResult
            If ModelState.IsValid Then
                db.Entry(enquete).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.AspNetUserId = New SelectList(db.Users, "Id", "Nom", enquete.AspNetUserId)
            ViewBag.SinistreId = New SelectList(db.Sinistre, "Id", "Libelle", enquete.SinistreId)
            Return View(enquete)
        End Function

        ' GET: Enquetes/Delete/5
        Function Delete(ByVal id As Long?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim enquete As Enquete = db.Enquete.Find(id)
            If IsNothing(enquete) Then
                Return HttpNotFound()
            End If
            Return View(enquete)
        End Function

        ' POST: Enquetes/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Long) As ActionResult
            Dim enquete As Enquete = db.Enquete.Find(id)
            db.Enquete.Remove(enquete)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
