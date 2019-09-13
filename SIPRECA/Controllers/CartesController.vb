Imports System.Data.Entity
Imports System.Data.Entity.Validation
Imports System.Net
Imports Microsoft.AspNet.Identity
Imports PagedList

Namespace Controllers
    Public Class CartesController
        Inherits BaseController

        ' GET: Carte
        Function Index() As ActionResult

            Return View()

        End Function

    End Class
End Namespace
