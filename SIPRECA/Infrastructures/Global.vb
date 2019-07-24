Public Enum SYGERMEEnum

    ''' <summary>
    ''' Il s'agit du prix du billet (ticket) de voyage en formule classique.
    ''' </summary>
    PrixTicketClassique = 2500

    ''' <summary>
    ''' Il s'agit du prix du billet (ticket) de voyage en formule VIP.
    ''' </summary>
    PrixTicketVIP = 6000

    ''' <summary>
    ''' Il s'agit du pourcentage de réduction appliqué sur un billet de voyage aller-retour.
    ''' </summary>
    PourcentageReductionBilletAllerRetour = 62.5

    ''' <summary>
    ''' Il s'agit de la validité (durée de vie) d'un ticket appliqué pour un voyage simple.
    ''' </summary>
    ValiditeTicketVoyage = 15

    ''' <summary>
    ''' Il s'agit de la validité (durée de vie) d'un ticket appliqué pour un voyage aller-retour.
    ''' </summary>
    ValiditeTicketVoyageAllerRetour = 15

End Enum

'Public Enum EnumCurrentState
'Private Const _prixTicket As Double = 2500
'    ' green
'    <Description("#01DF3A:CONFIRMED")>
'    Initial = 0
'    <Description("#4B0082:CONFIRMED")>
'    EnCours = 3
'    <Description("#FF0000:BOOKED")>
'    EnRetard = 4 ' Automatique
'    <Description("#0000FF:CONFIRMED")>
'    Terminee = 5
'    <Description("#0000FF:CONFIRMED")>
'    CanceledPending = 10
'    <Description("#7F9B71:CONFIRMED")>
'    Canceled = 11
'    <Description("#9C7280:CONFIRMED")>
'    ReportedPending = 20
'    <Description("#254117:CONFIRMED")>
'    Reported = 21
'End Enum