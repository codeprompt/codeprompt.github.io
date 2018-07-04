Public Class Form1
	Const cdecSingleDay As Decimal = 89.00
	Const cdecFestival As Decimal = 372.99

	Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
		Dim intTickets As Integer = ValidateData(tbxTickets.Text)
		If intTickets = 0 Then
			Return
		End If 
		If radSingle.Checked Then
			lblPrice.Text = CalcBasic(intTickets).ToString("C")
		Else
			lblPrice.Text = CalcDeluxe(intTickets).ToString("C")
		End If
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
	
	Private Function CalcSingle(ByVal intGBs)
		Return cdecSingleDay * intGBs
	End Function
		
	Private Function CalcFestival(ByVal intGBs)
		Return cdecFestival * intGBs
	End Function
	
	
	Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
		tbxTickets.Text = ""
		radSingle.Checked = True
		lblPrice.Text = ""
		lblFestivalQuestion.Visible = False
		lblSingleQuestion.Visible = False
		tbxTickets.Visible = False
	End Sub
	
	Private Sub radSingle_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radSingle.CheckedChanged
		If radSingle.Checked Then
			lblSingleQuestion.Visible = True
			lblFestivalQuestion.Visible = False
		Else 
			lblSingleQuestion.Visible = False
			lblFestivalQuestion.Visible = True
		End If 
		tbxTickets.Visible = True
	End Sub
	Private Sub radFestival_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radFestival.CheckedChanged
		If radSingle.Checked Then
			lblSingleQuestion.Visible = True
			lblFestivalQuestion.Visible = False
		Else 
			lblSingleQuestion.Visible = False
			lblFestivalQuestion.Visible = True
		End If 
		tbxTickets.Visible = True
	End Sub

	Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
		Application.Exit()
	End Sub
End Class