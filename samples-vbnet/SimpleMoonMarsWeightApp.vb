Public Class Form1
	
	Private Sub btnCalc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalc.Click
		Dim decWeight As Decimal
		Dim decMoon As Decimal
		Dim decMars As Decimal
		If Not IsNumeric(tbxWeight.Text) OrElse Convert.ToInt32(tbxWeight.Text) < 1 Then
			MessageBox.Show("Please, enter a valid weight", "Error")
			tbxWeight.Text = ""
			Return
		End If
		decWeight = Convert.ToInt32(tbxWeight.Text)
		If radLb.Checked = true Then
			decMoon = decWeight * 0.166
			decMars = decWeight * 0.377
			lblMoon.Text = "Your weight on Moon is " + decMoon.ToString("F1") + " Lbs"
			lblMars.Text = "Your weight on Mars is " + decMars.ToString("F1") + " Lbs"
		Else 
			decMoon = decWeight * 0.454 * 0.166
			decMars = decWeight * 0.454 * 0.377
			lblMoon.Text = "Your weight on Moon is " + decMoon.ToString("F1") + " Kgs"
			lblMars.Text = "Your weight on Mars is " + decMars.ToString("F1") + " Kgs"
		End If
	End Sub

	Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
		radLb.Checked = true
		tbxWeight.Text = ""
		lblMoon.Text = ""
		lblMars.Text = ""
	End Sub

	Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
		Application.Exit()
	End Sub
End Class