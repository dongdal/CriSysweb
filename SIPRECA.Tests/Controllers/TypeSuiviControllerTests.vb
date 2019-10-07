Imports System.Web.Mvc
Imports SIPRECA.Controllers

<TestClass()> Public Class TypeSuiviControllerTests

    <TestMethod()> Public Sub Index()
        ' Arrange
        Dim controller As New TypeSuivisController()
        ' Act
        Dim result As ActionResult = DirectCast(controller.Index("", "", "", 1), ViewResult)
        ' Assert
        Assert.IsNotNull(result)
    End Sub

End Class