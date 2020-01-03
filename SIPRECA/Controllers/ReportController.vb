Imports System.Data.Entity
Imports System.Data.Entity.Validation
Imports System.Net
Imports SIPRECA
Imports SIPRECA.My.Resources

Public Class ReportController
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

    Function ListeHopitaux() As ActionResult
        Return View()
    End Function

    Function ListeHeliports() As ActionResult
        Return View()
    End Function

    Function ListePorts() As ActionResult
        Return View()
    End Function

    Function ListeAeroports() As ActionResult
        Return View()
    End Function

    Function ListeBureau() As ActionResult
        Return View()
    End Function

    Function ListeAbris() As ActionResult
        Return View()
    End Function

    Function ListeEntrepot() As ActionResult
        Return View()
    End Function
End Class



'Dim LesRegions = (From e In Db.Region Where e.StatutExistant = 1 Select e).ToList()
'For Each region In LesRegions
'    Dim LesDepartements = region.Departement.OrderBy(Function(e) e.Libelle).ToList()
'    Dim i As Integer = 1
'    For Each departement In LesDepartements
'        Dim CodeDep As String = ""
'        CodeDep = IIf(i < 10, region.Code & "0" & i.ToString(), region.Code & i.ToString())
'        departement.Code = CodeDep
'        Db.Entry(departement).State = EntityState.Modified
'        i = i + 1
'        Dim LesCommunes = departement.Commune.OrderBy(Function(e) e.Libelle).ToList()
'        Dim j As Integer = 1
'        For Each commune In LesCommunes
'            commune.Code = IIf(j < 10, CodeDep & "0" & j.ToString(), CodeDep & j.ToString())
'            Db.Entry(commune).State = EntityState.Modified
'            j = j + 1
'        Next
'    Next
'Next
'Try
'    Db.SaveChanges()
'    Return RedirectToAction("Index")
'Catch ex As DbEntityValidationException
'    Util.GetError(ex, ModelState)
'Catch ex As Exception
'    Util.GetError(ex, ModelState)
'End Try