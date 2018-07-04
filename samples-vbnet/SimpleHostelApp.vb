Public Class Form1

	Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
		Dim intTotalOccupied As Integer
		Dim intTotalVacant As Integer 
		Dim intRoomsOccupied As Integer
		Dim intRoomsVacant As Integer
		Dim strInput As String
		For value As Integer = 1 To 13
			Do 
				strInput = InputBox("How many rooms are occupied on floor " + value.ToString() + "?")
			While Not IsNumeric(strInput) Or Convert.ToInt32(strInput) < 0
			intRoomsOccupied = Convert.ToInt32(strInput)
			Do 
				strInput = InputBox("How many rooms are vacant on floor 1?")
			While Not IsNumeric(strInput) Or Convert.ToInt32(strInput) < 0
			intRoomsVacant = Convert.ToInt32(strInput)
			lbxFloors.Items.Add("Floor " + value.ToString() + " : Occupied - " + intRoomsOccupied.ToString() +
								" Vacant - " + intRoomsVacant.ToString())
			intTotalOccupied += intRoomsOccupied
			intTotalVacant += intRoomsVacant
		Next
		Dim strResult As String
		strResult = "Total rooms : " (intTotalOccupied + intTotalVacant).ToString() + Environment.NewLine
		strResult += "Occupied rooms : " intTotalOccupied.ToString() + Environment.NewLine
		strResult += "Vacant rooms : " intTotalVacant.ToString() + Environment.NewLine
		strResult += "Occupancy rate : " (intTotalOccupied / (intTotalOccupied + intTotalVacant)) * 100
	End Sub

	Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
		Application.Exit()
	End Sub
End Class