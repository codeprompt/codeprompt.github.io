Public Class Form1
	Const cdecHoursPerWeek As Integer = 3
	
	Private Sub btnCalc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalc.Click
		Dim intDays As Integer
		intDays = 31 - Convert.ToInt32(tbxBirthDay.Text)
		intDays += (12 - Convert.ToInt32(tbxBirthMonth.Text)) * 30
		intDays += (Convert.ToInt32(tbxCurrentYear.Text) - Convert.ToInt32(tbxBirthYear.Text) + 1) * 365
		intDays += (Convert.ToInt32(tbxCurrentMonth.Text) - 1) * 30
		intDays += Convert.ToInt32(tbxCurrentDay.Text)
		Dim intHoursTotal As Integer = intDays * cdecHoursPerWeek 
		lblResult.Text = tbxName.Text + " has trained: " + intHoursTotal.ToString() + 
			" from the first day of your life, until yesterday!"
	End Sub

	Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
		tbxName.Text = ""
		tbxBirthYear.Text = ""
		tbxBirthMonth.Text = ""
		tbxBirthDay.Text = ""
		tbxCurrentYear.Text = ""
		tbxCurrentMonth.Text = ""
		tbxCurrentDay.Text = ""
		lblResult.Text = ""
	End Sub

	Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
		Application.Exit()
	End Sub
End Class