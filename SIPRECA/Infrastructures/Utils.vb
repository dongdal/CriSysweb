Imports System.Data.SqlClient

Public Class Util

    'https://social.msdn.microsoft.com/Forums/vstudio/en-US/ef77dc83-2796-406f-a95d-4cbf82c2e431/vbnet-generate-a-random-string-of-numbers-and-letters?forum=vbgeneral
    Public Shared Function GetRandomString() As String
        Dim p As String = System.IO.Path.GetRandomFileName()
        p = p.Replace(".", "").ToUpper
        Return p
    End Function

    ''' <summary>
    ''' The connection string property that pulls from the web.config
    ''' </summary>
    Public Shared ReadOnly Property ConnectionString() As String
        Get
            Return ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
        End Get
    End Property

    Shared Sub GetError(cex As Exception, modelState As ModelStateDictionary)
        If TypeOf (cex) Is Entity.Validation.DbEntityValidationException Then
            Dim ex = CType(cex, Entity.Validation.DbEntityValidationException)
            Dim strError As String = ""
            For Each val_errors In ex.EntityValidationErrors
                For Each val_error In val_errors.ValidationErrors
                    modelState.AddModelError(val_error.PropertyName, val_error.ErrorMessage)
                    strError &= val_error.ErrorMessage & vbCrLf
                Next
            Next
            modelState.AddModelError("", strError)
        ElseIf TypeOf (cex) Is Exception Then
            Dim ex = cex
            Dim strError As String = ""
            Dim ie = ex
            While ie IsNot Nothing
                If Not ie.Message.StartsWith("Une erreur") Then
                    strError &= ie.Message & "|"
                End If

                ie = ie.InnerException
            End While
            Dim ar_errors = strError.Split("|".ToCharArray)
            For Each val_error In ar_errors
                modelState.AddModelError("", val_error)
            Next
        End If
    End Sub

    Shared Function GetError(cex As Exception) As String
        Dim strError As String = ""
        If TypeOf (cex) Is Entity.Validation.DbEntityValidationException Then
            Dim ex = CType(cex, Entity.Validation.DbEntityValidationException)
            For Each val_errors In ex.EntityValidationErrors
                For Each val_error In val_errors.ValidationErrors
                    strError &= val_error.ErrorMessage & vbCrLf
                Next
            Next

        ElseIf TypeOf (cex) Is Exception Then
            Dim ex = cex
            Dim ie = ex
            While ie IsNot Nothing
                If Not ie.Message.StartsWith("Une erreur") Then
                    strError &= ie.Message & "|"
                End If

                ie = ie.InnerException
            End While
        End If

        Return strError
    End Function

    Shared Function GetModelStateError(ms As ModelStateDictionary) As Object
        Dim query = From state In ms.Values
                    From erreur In state.Errors
                    Select erreur.ErrorMessage

        Dim strError As String = ""
        For Each val_error In query
            strError &= val_error & vbCrLf
        Next
        Return strError
    End Function

    'Public Shared Function GetNumeroSuivi() As String

    '    Dim LeNumeroSuivi As String = "" 'AppSession.ServiceUtilisateur.AbrService & "-"
    '    If Not (String.IsNullOrEmpty(AppSession.ServiceUtilisateur.AbrService)) Then
    '        LeNumeroSuivi = AppSession.ServiceUtilisateur.AbrService & "-"
    '    End If
    '    LeNumeroSuivi = LeNumeroSuivi & Now.DayOfYear().ToString & (Now.Hour * 3600 + Now.Minute * 60 + Now.Second).ToString & Now.ToString("yy") & "-"
    '    LeNumeroSuivi += AppSession.ServiceUtilisateur.AbrServiceEn
    '    Return LeNumeroSuivi.ToUpper
    'End Function

    '[Enum].GetName(GetType(Util.ElementsSuiviDemandes), Util.ElementsSuiviDemandes.Creation)

    Public Enum ElementsSuiviDemandes
        ''' <summary>
        ''' Valeur utilisée lors de la création de la demande d'indemnisation
        ''' </summary>
        Creation = 1

        ''' <summary>
        ''' Valeur utilisée lors de la validation au niveau communal
        ''' </summary>
        ValidationCommunale = 2

        ''' <summary>
        ''' Valeur utilisée lors du transfert d'un dossier de la commune vers le département
        ''' </summary>
        TransfertCommunal = 3

        ''' <summary>
        ''' Reception du dossier au niveau départemental
        ''' </summary>
        ReceptionDepartementale = 4

        ''' <summary>
        ''' Validation du dossier au niveau départemental
        ''' </summary>
        ValidationDepartementale = 5

        ''' <summary>
        ''' Transfert du dossier du niveau départemental au niveau régional
        ''' </summary>
        TransfertDepartemental = 6

        ''' <summary>
        ''' Reception du dossier au niveau régional
        ''' </summary>
        ReceptionRegionale = 7

        ''' <summary>
        ''' Validation du dossier au niveau régional
        ''' </summary>
        ValidationRegionale = 8

        ''' <summary>
        ''' Transfert du dossier du niveau régional au niveau national
        ''' </summary>
        TransfertRegional = 9

        ''' <summary>
        ''' Reception du dossier au niveau national
        ''' </summary>
        ReceptionNationale = 10

        ''' <summary>
        ''' Validation du dossier au niveau national
        ''' </summary>
        ValidationNationale = 11

        ''' <summary>
        ''' La demande d'indemnisation a été rejetée
        ''' </summary>
        DecisionDeRejet = 12

        ''' <summary>
        ''' La demande d'indemnisation a été approuvée
        ''' </summary>
        DecisionIndemnisation = 13
    End Enum

    Public Enum UserLevel
        ''' <summary>
        ''' Utilisateur de niveau communal
        ''' </summary>
        Communal = 1

        ''' <summary>
        ''' Utilisateur de niveau départemental
        ''' </summary>
        Departemental = 2

        ''' <summary>
        ''' Utilisateur de niveau régional
        ''' </summary>
        Regional = 3

        ''' <summary>
        ''' Utilisateur de niveau national
        ''' </summary>
        National = 4
    End Enum

End Class