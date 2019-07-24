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


End Class