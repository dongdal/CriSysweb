'Public Class SharedFunctions

'    ''' <summary>
'    ''' Cette fonction permet de générer un matricule agent. Ledit matricule sera généré en fonction de la postion de l'agence sont l'identifiant correspond au paramètre "AgenceId".
'    ''' </summary>
'    ''' <param name="AgenceId"></param>
'    ''' <returns>Long (Entier long)</returns>
'    ''' <remarks></remarks>
'    Public Shared Function SetMatricule(AgenceId As Long) As String
'        Dim db As New ApplicationDbContext
'        Dim LeMatricule As String = ""
'        Dim isItOk As Boolean = False
'        Do
'            LeMatricule = "MA-" & Now.DayOfYear().ToString & (Now.Hour * 3600 + Now.Minute * 60 + Now.Second).ToString & Now.ToString("yy")
'            LeMatricule = LeMatricule & "-" & GetPositionAgence(AgenceId)
'            Dim CountMatricule = (From ag In db.Agent Where (ag.AgencyId = AgenceId And ag.Matricule.ToUpper.Equals(LeMatricule.ToUpper)) Select ag).Count
'            isItOk = IIf(CountMatricule = 0, True, False)
'        Loop Until isItOk
'        db.Dispose()
'        Return LeMatricule.ToUpper
'    End Function

'    ''' <summary>
'    ''' Cette fonction permet de déterminer la position de l'agence (parmi une liste d'agences) dont l'identifiant est passé en paramètre.
'    ''' </summary>
'    ''' <param name="IdAgence"></param>
'    ''' <returns>Long (Entier long)</returns>
'    ''' <remarks></remarks>
'    Private Shared Function GetPositionAgence(ByVal IdAgence As Long) As String
'        Dim db As New ApplicationDbContext
'        Dim agences = (From ag In db.Agency Select ag).ToList
'        Dim lagence = db.Agency.Find(IdAgence)
'        Dim position = 0
'        Dim position2 = 0
'        position = agences.IndexOf(lagence) + 1
'        'For Each agenc In agences
'        '    position2 += 1
'        '    If agenc.Id = IdAgence Then
'        '        Exit For
'        '    End If
'        'Next
'        Dim positionString As String = position
'        While positionString.Length < 3
'            positionString = "0" & positionString
'        End While
'        db.Dispose()
'        Return positionString
'    End Function
'End Class
