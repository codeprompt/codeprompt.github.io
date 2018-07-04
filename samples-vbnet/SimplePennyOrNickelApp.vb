Public Class Form1
Const cintMinWorkdaysPenny As Integer = 19 
Const cintMinWorkdaysNickel As Integer = 16
Const cintMaxEorkDays As Integer = 22

	Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
		Dim intMinWorkdays As Integer
		Dim intWorkDays As Integer
		If radPenny.Checked Then
			intMinWorkdays = cintMinWorkdaysPenny
		Else 
			intMinWorkdays = cintMinWorkdaysNickel
		EndIf
		If Not IsNumeric(tbxDays.Text)
			OrElse Convert.ToInt32(tbxDays.Text) < 0 Then
				MessageBox.Show("Please, enter a valid number of work days", "Error")
				tbxDays.Text = ""
				Return
		ElseIf Convert.ToInt32(tbxDays.Text) > cintMaxEorkDays Or 
			Convert.ToInt32(tbxDays.Text) < intMinWorkdays
				MessageBox.Show("Please, enter a valid number of work days", "Error")
				tbxDays.Text = ""
				Return
		End If
		intWorkDays = Convert.ToInt32(tbxDays.Text)
		Dim intPay As Integer = 1
		If radNickel.Checked Then
			intPay = 5 
		End If
		For value As Integer = 1 To intWorkDays
			intPay *= 2
		Next
		lblResult.Text = intPay.ToString()
	End Sub

	Private Sub ClearToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearToolStripMenuItem.Click
		tbxDays.Text = ""
		radPenny.Checked = True
		radNickel.Checked = false
		lblResult.Text = ""
	End Sub

	Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
		Application.Exit()
	End Sub
End Class