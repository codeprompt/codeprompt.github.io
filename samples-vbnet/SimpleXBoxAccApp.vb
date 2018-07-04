Public Class Form1
	Const cdecSinglePrice As Decimal = 7 
	Const cdecFamilyPrice As Decimal = 12 
	Const cdecDevPrice As Decimal = 3
	
	Private Sub btnCalc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalc.Click
		Dim strName As String
		Dim intNumMonths As Integer
		Dim decPrice As Decimal
			'retrieve name
		If tbxName.Text = "" Or IsNumeric(tbxName.Text) Then
			MessageBox.Show("Please, enter a valid Name", "Error")
			tbxName.Text = ""
			Return
		End If
		strName = tbxName.Text
			'retrieve numer of months
		If Not IsNumeric(tbxNumMonths.Text) OrElse Convert.ToInt32(tbxNumMonths.Text) < 1 Then
			MessageBox.Show("Please, enter a valid number of months", "Error")
			tbxNumMonths.Text = ""
			Return
		End If
		intNumMonths = Convert.ToInt32(tbxNumMonths.Text)
			'calculate
		If radSingleMember.Checked = true Then
			decPrice = cdecSinglePrice * intNumMonths
		Else If radFamily.Checked = true Then
			decPrice = cdecFamilyPrice * intNumMonths
		Else If radDev.Checked = true Then
			decPrice = cdecDevPrice * intNumMonths
		End If
			'display
		lblPrice.Text = strName + " " + decPrice.ToString("C")
	End Sub

	Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
		radSingleMember.Checked = true
		tbxName.Text = ""
		tbxNumMonths.Text = ""
		lblPrice.Text = ""
	End Sub

	Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
		Application.Exit()
	End Sub
End Class