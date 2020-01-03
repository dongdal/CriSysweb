Imports Microsoft.Reporting.WebForms
Imports System.Data.SqlClient
Imports System.IO

Public Class Report
    Inherits System.Web.UI.Page

    Private db As New ApplicationDbContext

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim type = Request("type")
            Select Case type
                Case "BordereauTransfert" '--------------------------------------------------Bordereau transfert'--------------------------------------------------

                    Dim BordereauId As Long = Request("BordereauId")
                    Dim ReportName As String = "BordereauTransfert"
                    Dim ViewName As String = "vBordereauTransfert"

                    ShowBordereauTransfert(ReportName, BordereauId, ViewName)

                Case "ListeHopitaux" '--------------------------------------------------Liste Des Hopitaux'--------------------------------------------------

                    Dim ReportName As String = "ListeDesHopitaux"
                    Dim ViewName As String = "vBordereauTransfert"

                    ShowListeDesHopitaux(ReportName, ViewName)

                Case "OrdreRecette"
                    'Dim Id As String = Request("Id")

                    'Dim OrdreRecet = (From elt In db.OrdreRecette Where elt.Id = Id Select elt).FirstOrDefault

                    'If Not (OrdreRecet.Controle.TypeControle.Libelle.Contains("Approbation")) Then
                    '    ShowOrdreRecette("OrdreDeRecette", DsOrdreRecette(Id, "OrdreRecetteId"), DsDetailOrdreRecette(Id, "OrdreRecetteId"))
                    'Else
                    '    ShowOrdreRecetteApprobationModele("OrdreRecetteApprobationModele", DsOrdreRecetteApprobationModele(Id, "OrdreRecetteId"), DsDetailOrdreRecette(Id, "OrdreRecetteId"))
                    'End If

            End Select
        End If

    End Sub


    Public Shared ReadOnly Property ConnectionString() As String
        Get
            Return ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
        End Get
    End Property



    Private Function GetData(viewName As String, ByVal id_value As String, Optional idName As String = "Id") As DataTable
        Dim matable As DataTable = Nothing
        Dim colonne As String = ""

        Dim cmd As String = String.Format(" SELECT * FROM {0} Where {1} = @id ", viewName, idName)

        Using myConnection As New SqlConnection(ConnectionString)
            Using macmd As SqlCommand = New SqlCommand(cmd, myConnection)
                macmd.Parameters.AddWithValue("@id", id_value)
                macmd.CommandTimeout = 0
                Try
                    myConnection.Open()
                    Using reader As SqlDataReader = macmd.ExecuteReader
                        matable = New DataTable
                        matable.Load(reader)
                        reader.Close()
                    End Using
                Catch ex As Exception
                    'logMessage(ex.Message)
                End Try
            End Using
            myConnection.Close()
        End Using

        Return matable
    End Function

    Public Function DsOrdreRecetteApprobationModele(ByVal parmValueId As Long, ByVal parIdName As String) As DataTable
        Return getData("V_OrdreRecetteApprobationModele", parmValueId, parIdName)
    End Function

    Public Function DsOrdreRecette(ByVal parmValueId As Long, ByVal parIdName As String) As DataTable
        Return getData("V_OrdreRecette", parmValueId, parIdName)
    End Function

    Public Function DsDetailOrdreRecette(ByVal parmValueId As Long, ByVal parIdName As String) As DataTable
        Return getData("V_DetailOrdreRecette", parmValueId, parIdName)
    End Function

    Private Sub ShowBordereauTransfert(reportName As String, BordereauId As Long, ViewName As String)
        SIPRECA_Report.Reset()
        SIPRECA_Report.LocalReport.ReportPath = Path.Combine(Server.MapPath("~/Report/Template"), reportName & ".rdlc")
        SIPRECA_Report.LocalReport.DataSources.Clear()

        Dim FilterField = "BordereauId"
        With SIPRECA_Report.LocalReport.DataSources
            .Add(New ReportDataSource("BordereauTransfert", DsBordereauTransfert(BordereauId, FilterField, ViewName)))
        End With
    End Sub

    Private Sub ShowListeDesHopitaux(reportName As String, ViewName As String)
        SIPRECA_Report.Reset()
        SIPRECA_Report.LocalReport.ReportPath = Path.Combine(Server.MapPath("~/Report/Template"), reportName & ".rdlc")
        SIPRECA_Report.LocalReport.DataSources.Clear()

        With SIPRECA_Report.LocalReport.DataSources
            .Add(New ReportDataSource("DataSet1", GetSQLDataForList(ViewName)))
        End With
    End Sub

    Private Sub ShowOrdreRecette(reportName As String, ds1 As Object, ds2 As Object)
        SIPRECA_Report.LocalReport.ReportPath = Path.Combine(Server.MapPath("~/Report/Template"), reportName & ".rdlc")
        SIPRECA_Report.LocalReport.DataSources.Clear()
        'Dim Parm As ReportParameter = New ReportParameter("FactureId", FactureId)
        'SIPRECA_Report.LocalReport.SetParameters(New ReportParameter() {Parm}))
        SIPRECA_Report.LocalReport.DataSources.Add(New ReportDataSource("DataSet1", ds1))
        SIPRECA_Report.LocalReport.DataSources.Add(New ReportDataSource("DataSet2", ds2))
    End Sub

    Private Sub ShowBordereauTransfert(reportName As String, ds1 As Object, ds2 As Object)
        SIPRECA_Report.LocalReport.ReportPath = Path.Combine(Server.MapPath("~/Report/Template"), reportName & ".rdlc")
        SIPRECA_Report.LocalReport.DataSources.Clear()
        'Dim Parm As ReportParameter = New ReportParameter("FactureId", FactureId)
        'SIPRECA_Report.LocalReport.SetParameters(New ReportParameter() {Parm}))
        SIPRECA_Report.LocalReport.DataSources.Add(New ReportDataSource("DataSet1", ds1))
        SIPRECA_Report.LocalReport.DataSources.Add(New ReportDataSource("DataSet2", ds2))
    End Sub

    Private Sub ShowOrdreRecetteApprobationModele(reportName As String, ds1 As Object, ds2 As Object)
        SIPRECA_Report.LocalReport.ReportPath = Path.Combine(Server.MapPath("~/Report/Template"), reportName & ".rdlc")
        SIPRECA_Report.LocalReport.DataSources.Clear()
        'Dim Parm As ReportParameter = New ReportParameter("FactureId", FactureId)
        'SIPRECA_Report.LocalReport.SetParameters(New ReportParameter() {Parm}))
        SIPRECA_Report.LocalReport.DataSources.Add(New ReportDataSource("DataSet1", ds1))
        SIPRECA_Report.LocalReport.DataSources.Add(New ReportDataSource("DataSet2", ds2))
    End Sub


    Private Function DsBordereauTransfert(BordereauId As Long, FilterField As String, ViewName As String) As Object
        Dim Filter As String = "AND " & FilterField & " = " & BordereauId.ToString()
        Return GetSQLDataWithCompleteFilter(ViewName, Filter, FilterField)
    End Function

    'Private Function DsListeDesHopitaux(ViewName As String) As Object
    '    Return GetSQLDataForList(ViewName)
    'End Function

    Private Function GetSQLDataForList(ViewName As String) As DataTable
        Dim matable As DataTable = Nothing
        Dim colonne As String = ""


        Dim cmd As String = ""

        cmd = String.Format("SELECT * FROM {0} WHERE 1=1 ", ViewName)

        Using myConnection As New SqlConnection(Util.ConnectionString)
            Using macmd As SqlCommand = New SqlCommand(cmd, myConnection)
                macmd.CommandTimeout = 0
                Try
                    myConnection.Open()
                    Using reader As SqlDataReader = macmd.ExecuteReader
                        matable = New DataTable
                        matable.Load(reader)
                        reader.Close()
                    End Using
                Catch ex As Exception
                    'logMessage(ex.Message)
                End Try
            End Using
            myConnection.Close()
        End Using

        Return matable
    End Function

    Private Function GetSQLDataWithCompleteFilter(ViewName As String, Filter As String, FilterField As String) As DataTable
        Dim matable As DataTable = Nothing
        Dim colonne As String = ""


        Dim cmd As String = ""

        cmd = String.Format("SELECT * FROM {0} WHERE 1=1 " & Filter & " ORDER BY " & FilterField & " ASC", ViewName)

        Using myConnection As New SqlConnection(Util.ConnectionString)
            Using macmd As SqlCommand = New SqlCommand(cmd, myConnection)
                macmd.CommandTimeout = 0
                Try
                    myConnection.Open()
                    Using reader As SqlDataReader = macmd.ExecuteReader
                        matable = New DataTable
                        matable.Load(reader)
                        reader.Close()
                    End Using
                Catch ex As Exception
                    'logMessage(ex.Message)
                End Try
            End Using
            myConnection.Close()
        End Using

        Return matable
    End Function

End Class