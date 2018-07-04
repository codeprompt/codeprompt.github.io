Public Class Form1

	Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
		Dim strTime As String
		Do
			strTime = InputBox("Enter Time")
			If strTime = "" Then
				If lbxTimes.Items.Count = 0 Then
					MsgBox("Enter some time first!")
				Else
					Dim decAverage As Decimal = 0
					For value = 0 To lbxTimes.Items.Count - 1
						decAverage += lbxTimes.Items(value)
					Next
					decAverage = decAverage / lbxTimes.Items.Count
					Dim intSecs As Integer = Math.Truncate(decAverage) * 60
					Dim x As Decimal = decAverage - Math.Truncate(decAverage)
					x = Math.Round(60 * x)
					intSecs += x
					lblResult.Text = Math.Truncate(intSecs / 60).ToString() + " min " + (intSecs Mod 60).ToString() + " sec"
					Return
				End If
			End If
		Loop While Not IsNumeric(strTime) OrElse Convert.ToInt32(strTime) <= 0
		lbxTimes.Items.Add(strTime)
		If lbxTimes.Items.Count = 10 Then
			Dim decAverage As Decimal = 0
			For value = 0 To lbxTimes.Items.Count - 1
				decAverage += lbxTimes.Items(value)
			Next
			decAverage = decAverage / lbxTimes.Items.Count
			Dim intSecs As Integer = Math.Truncate(decAverage) * 60
			Dim x As Decimal = decAverage - Math.Truncate(decAverage)
			x = Math.Round(60 * x)
			intSecs += x
			lblResult.Text = Math.Truncate(intSecs / 60).ToString() + " min " + (intSecs Mod 60).ToString() + " sec"
		End If
	End Sub

	Private Sub ClearToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearToolStripMenuItem.Click
		lbxTimes.Items.Clear()
		lblResult.Text = ""
	End Sub

	Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
		Application.Exit()
	End Sub
End Class