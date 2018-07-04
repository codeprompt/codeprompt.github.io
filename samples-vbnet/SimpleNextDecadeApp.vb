Public Class Form1

	Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
		Dim decHourWage As Decimal
		Dim decRaisePercent As Decimal
		Dim decPay As Decimal = 0
		If Not IsNumeric(tbxHourWage.Text) 
			OrElse Convert.ToInt32(tbxHourWage.Text) < 0 Then
				MessageBox.Show("Please, enter a valid hour wage", "Error")
				tbxHourWage.Text = ""
				Return
		End If 
		decHourWage = Convert.ToDecimal(tbxHourWage.Text)
		If Not IsNumeric(tbxRaisePercent.Text) 
			OrElse Convert.ToInt32(tbxRaisePercent.Text) < 0 Then
				MessageBox.Show("Please, enter a valid hour wage", "Error")
				tbxRaisePercent.Text = ""
				Return
		End If 
		tbxRaisePercent = Convert.ToDecimal(tbxRaisePercent.Text)
		For value As integer = 1 To 10 
			decPay += 40 * 52 * decHourWage
			decHourWage += (decHourWage * decRaisePercent) / 100
		Next 
		lblResult.Text = decPay.ToString()
	End Sub

	Private Sub ClearToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearToolStripMenuItem.Click
		tbxHourWage.Text = ""
		tbxRaisePercent.Text = ""
		lblResult.Text = ""
	End Sub

	Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
		Application.Exit()
	End Sub
End Class