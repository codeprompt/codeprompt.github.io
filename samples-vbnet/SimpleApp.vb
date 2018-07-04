Public Class Form1
	Private Sub btnHeight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHeight.Click
		Dim intFeet As Integer
        Dim strInches As String
        Dim intInches As Integer
        strInches = "24"                'to avoid null reference

        intInches = Convert.ToInt32(strInches)
        intFeet = intInches / 12
        lblFeet.Text = intFeet.ToString("F")
	End Sub
End Class