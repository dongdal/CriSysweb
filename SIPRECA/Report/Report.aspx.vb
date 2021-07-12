Imports Microsoft.Reporting.WebForms
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.IO

Public Class Report
    Inherits System.Web.UI.Page

    Private db As New ApplicationDbContext
    Private _reportName As String
    Private _reportViewName As String
    Private Const ALL_ROWS As String = "ALL_ROWS"

    Public Property ReportName As String
        Get
            Return _reportName
        End Get
        Set(value As String)
            _reportName = value
        End Set
    End Property

    Public Shared ReadOnly Property ConnectionString() As String
        Get
            Return ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
        End Get
    End Property

    Public Property ReportViewName As String
        Get
            Return _reportViewName
        End Get
        Set(value As String)
            _reportViewName = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim type = Request("type")
            Select Case type
                Case "ExportCollectDatas" '--------------------------------------------------Exportation des données de collecte '--------------------------------------------------

                    Dim FormulaireId As Long = Request("FormulaireId")
                    Dim DateDebut As String = ConvertDate(Request("DateDebut"))
                    Dim DateFin As String = ConvertDate(Request("DateFin"))

                    ReportName = "ExportCollectDatas"
                    ReportViewName = "vExportCollectDatas"

                    Dim ChampDateFiltre = "DateCollecte" 'On effectuera un filtre sur les dates afin de classer les données de la plus récente à la plus ancienne.
                    Dim NomChampIdFiltre = "FormulaireId" 'on effectuera un filtre sur les formulaires afin de ne récupérer que les données liées à un seul formulaire précis

                    ShowExportCollectDatas(ReportName, DateDebut, DateFin, GetDataByDateFilter(ChampDateFiltre, DateDebut, DateFin, NomChampIdFiltre, FormulaireId))

                Case "BordereauTransfert" '--------------------------------------------------Bordereau transfert'--------------------------------------------------

                    Dim BordereauId As Long = Request("BordereauId")
                    Dim ReportName As String = "BordereauTransfert"
                    Dim ViewName As String = "vBordereauTransfert"

                    ShowBordereauTransfert(ReportName, BordereauId, ViewName)

                Case "ListeHopitaux" '--------------------------------------------------Liste Des Hopitaux'--------------------------------------------------

                    Dim ReportName As String = "ListeDesHopitaux"
                    Dim ViewName As String = "vHopitaux"

                    ShowListeDesHopitaux(ReportName, ViewName)

                Case "ListeDesAbris" '--------------------------------------------------Liste Des Abris'--------------------------------------------------

                    Dim ReportName As String = "ListeDesAbris"
                    Dim ViewName As String = "vAbris"

                    ShowListeItems(ReportName, ViewName)

                Case "ListeDesAeroports" '--------------------------------------------------Liste Des Aeroports'--------------------------------------------------

                    Dim ReportName As String = "ListeDesAeroports"
                    Dim ViewName As String = "vAeroport"

                    ShowListeItems(ReportName, ViewName)

                Case "ListeDesBureaux" '--------------------------------------------------Liste Des Bureaux'--------------------------------------------------

                    Dim ReportName As String = "ListeDesBureaux"
                    Dim ViewName As String = "vBureaux"

                    ShowListeItems(ReportName, ViewName)

                Case "ListeDesEntrepots" '--------------------------------------------------Liste Des Entrepots'--------------------------------------------------

                    Dim ReportName As String = "ListeDesEntrepots"
                    Dim ViewName As String = "vEntrepot"

                    ShowListeItems(ReportName, ViewName)

                Case "ListeDesPorts" '--------------------------------------------------Liste Des Ports'--------------------------------------------------

                    Dim ReportName As String = "ListeDesPorts"
                    Dim ViewName As String = "vPortDeMer"

                    ShowListeItems(ReportName, ViewName)

                Case "ListeDesHeliports" '--------------------------------------------------Liste Des Heliports'--------------------------------------------------

                    Dim ReportName As String = "ListeDesHeliports"
                    Dim ViewName As String = "vHeliport"

                    ShowListeItems(ReportName, ViewName)

            End Select
        End If

    End Sub


    Private Function ConvertDate(dateConvert As Date) As String
        Dim mydate() = dateConvert.ToString.Split(" ")
        Dim time = mydate(1)
        Dim tempoDateTable() = mydate(0).Split("/")

        Dim jour = tempoDateTable(0)
        Dim mois = tempoDateTable(1)
        Dim annee = tempoDateTable(2)
        Dim resultDate = annee & "-" & mois & "-" + jour
        Return resultDate
    End Function


    Private Function ConvertDate(dateConvert As String) As String
        Dim resultDate As New Date '= DateTime.ParseExact(dateConvert, format, CultureInfo.InvariantCulture)
        Date.TryParseExact(dateConvert, AppSession.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, resultDate)
        Return resultDate.ToString("yyyy-MM-dd")
    End Function

    Private Function GetDataByDateFilter(ByVal ChampDateFiltre As String, ByVal DateDebut As String, ByVal DateFin As String, ByVal NomChampIdFiltre As String, ByVal ChampIdFiltreValeur As String) As DataTable
        Dim matable As DataTable = Nothing
        Dim colonne As String = ""

        If (NomChampIdFiltre.ToUpper.Equals(ALL_ROWS)) Then
            ChampIdFiltreValeur = ALL_ROWS
        End If

        Dim datefilter = ChampDateFiltre & " >= (CONVERT(datetime2, @DateDebut, 120)) AND  " & ChampDateFiltre & " <= (CONVERT(datetime2, @DateFin, 120))"
        Dim cmd As String = ""

        cmd = String.Format(" SELECT * FROM {0} Where (" & datefilter & " AND {1} LIKE '" & ChampIdFiltreValeur & "%') ", ReportViewName, NomChampIdFiltre)

        Using myConnection As New SqlConnection(ConnectionString)
            Using macmd As SqlCommand = New SqlCommand(cmd, myConnection)
                macmd.Parameters.AddWithValue("@DateDebut", DateDebut + " 00:00:00")
                macmd.Parameters.AddWithValue("@DateFin", DateFin + " 23:59:59")
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

    Private Sub ShowExportCollectDatas(reportName As String, DateDebut As String, DateFin As String, ValeurSourceDonnees As Object)
        SIPRECA_Report.Reset()
        SIPRECA_Report.LocalReport.ReportPath = Path.Combine(Server.MapPath("~/Report/Template"), reportName & ".rdlc")
        SIPRECA_Report.LocalReport.DataSources.Clear()

        'Ajout des paramètres
        SIPRECA_Report.LocalReport.SetParameters(New ReportParameter() {New ReportParameter("DateDebut", DateDebut)})
        SIPRECA_Report.LocalReport.SetParameters(New ReportParameter() {New ReportParameter("DateFin", DateFin)})

        SIPRECA_Report.LocalReport.DataSources.Add(New ReportDataSource("DsExportCollectDatas", ValeurSourceDonnees))
    End Sub

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

    Private Sub ShowListeDesAbris(reportName As String, ViewName As String)
        SIPRECA_Report.Reset()
        SIPRECA_Report.LocalReport.ReportPath = Path.Combine(Server.MapPath("~/Report/Template"), reportName & ".rdlc")
        SIPRECA_Report.LocalReport.DataSources.Clear()

        With SIPRECA_Report.LocalReport.DataSources
            .Add(New ReportDataSource("DataSet1", GetSQLDataForList(ViewName)))
        End With
    End Sub

    Private Sub ShowListeItems(reportName As String, ViewName As String)
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