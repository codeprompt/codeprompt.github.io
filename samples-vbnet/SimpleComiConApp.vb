Public Class Form1
	Const cdecPriceCon As Decimal = 199
	Const cdecPriceConAndAutographs As Decimal = 255
	Const cdecPriceConAndSuperhero As Decimal = 330
	Const cdecPreviewNight As Decimal = 59
	
	Private Sub btnCalc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalc.Click
		If Not IsNumeric(tbxNumberOfTickets.Text) Then
			MessageBox.Show("Please, enter a valid value", "Error")
		End If
		Dim intNumberOfTickets As Integer = Convert.ToInt32(tbxNumberOfTickets.Text)
		If intNumberOfTickets < 1 Then
			MessageBox.Show("Please, enter a valid value", "Error")
			tbxNumberOfTickets.Text = ""
			Return
		Else If intNumberOfTickets > 20 Then
			MessageBox.Show("Max 20 people in a group, sorry.", "Error")
			tbxNumberOfTickets.Text = ""
			Return
		End If
		Dim decPrice As Decimal 
		If cbxPreviewNight.Checked = true Then
			decPrice = cdecPreviewNight
		End If
		If radConS.Checked = true Then
			decPrice += cdecPriceConAndSuperhero
		Else If radConA.Checked = true Then
			decPrice += cdecPriceConAndAutographs
		Else If radCon.Checked = true Then
			decPrice += cdecPriceCon
		End If
		decPrice *= intNumberOfTickets
		lblPrice.Text = decPrice.ToString("C")
	End Sub

	Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
		tbxNumberOfTickets.Text = ""
		radConS.Checked = true
		cbxPreviewNight.Checked = false
		lblPrice.Text = ""
	End Sub

	Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
		Application.Exit()
	End Sub
End Class