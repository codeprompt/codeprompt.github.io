Public Class Form1
	Const cdecAlmo As Decimal = 19.00
	Const cdecAlmoBattleground As Decimal = 29.0
	Const cdecAlmoDeluxe As Decimal = 49.00

	Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
		Dim intTickets As Integer = ValidateData(tbxTickets.Text)
		If intTickets = 0 Then
			Return
		End If 
		Dim decPrice As Decimal
		If cbxTours.SelectedIndex = 1 Then
			decPrice = CalcAlmo(intTickets)
		Else If cbxTours.SelectedIndex = 2 Then
			decPrice = CalcAlmoBattleground(intTickets)
		Else If cbxTours.SelectedIndex = 3 Then
			decPrice = CalcAlmoDeluxe(intTickets)
		Else
			lblPrice.Text = "Error"
			Return
		End If
		If radWeekday.Checked Then
			decPrice -= decPrice * 0.1
		End If
		decPrice += decPrice * 0.12
		lblPrice.Text = decPrice.ToString("C")
	End Sub
	
	Private Function ValidateData(ByVal strInput As String)
		If Not IsNumeric(strInput) 
			Return 0
		End If 
		Try
			intX = Convert.ToInt32(strInput)
			Return intX
		Catch ex As InvalidCastException
			MessageBox.Show("Please, enter valid value")
			Return 0
		End Try
	End Function
	
	Private Function CalcAlmo(ByVal intTickets)
		Return cdecAlmo * intTickets
	End Function
	Private Function CalcAlmoBattleground(ByVal intTickets)
		Return cdecAlmoBattleground * intTickets
	End Function
	Private Function CalcAlmoDeluxe(ByVal intTickets)
		Return cdecAlmoDeluxe * intTickets
	End Function
	
	Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
		tbxTickets.Text = ""
		radSingle.Checked = True
		lblPrice.Text = ""
		tbxTickets.Visible = False
		radWeekday.Visible = False
		radWeekend.Visible = False
		
	End Sub
	Private Sub cbxTours_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxTours.SelectedIndexChanged
		If cbxTours.SelectedIndex = 0 Then
			tbxTickets.Visible = True
			radWeekday.Visible = True
			radWeekend.Visible = True
		End If
	End Sub


	Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
		Application.Exit()
	End Sub
End Class