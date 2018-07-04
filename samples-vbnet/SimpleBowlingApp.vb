Public Class Form1

	Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
		Dim strTime As String
		Do
			strTime = InputBox("Enter Time")
			If strTime = "" Then
				If lbxTimes.Items.Count = 0 Then
					MsgBox("Enter some value first!")
				Else
					Dim decAverage As Decimal = 0
					For value = 0 To lbxTimes.Items.Count - 1
						decAverage += lbxTimes.Items(value)
					Next
					decAverage = decAverage / lbxTimes.Items.Count
					lblResult.Text = decAverage.ToString("F2") + " sec"
					Return
				End If
			Else
				lbxTimes.Items.Add(strTime)
			End If
		Loop While lbxTimes.Items.Count < 7 
		Dim decAverage As Decimal = 0
		For value = 0 To lbxTimes.Items.Count - 1
			decAverage += lbxTimes.Items(value)
		Next
		decAverage = decAverage / lbxTimes.Items.Count
		lblResult.Text = decAverage.ToString("F2") + " sec"
	End Sub

	Private Sub ClearToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearToolStripMenuItem.Click
		lbxTimes.Items.Clear()
		lblResult.Text = ""
	End Sub

	Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
		Application.Exit()
	End Sub
End Class
