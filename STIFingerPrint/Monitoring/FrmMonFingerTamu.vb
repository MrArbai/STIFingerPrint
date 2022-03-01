Imports System.Data.SqlClient
Imports C1
Imports C1.Win.C1FlexGrid
Imports WeifenLuo.WinFormsUI.Docking

Public Class FrmMonFingerTamu : Inherits DockContent
    Private Sub FrmMonFingerTamu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call SetGridDefult()
        dtPeriode1.Value = Now
    End Sub
    Private Sub SetGridDefult()
        Dim txt As CellRange
        With fg1
            .Styles.Alternate.BackColor = Color.PapayaWhip
            .Styles.Fixed.BackColor = Color.Aquamarine
            .Styles.Fixed.ForeColor = Color.Black
            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .BorderStyle = Util.BaseControls.BorderStyleEnum.None
            .Styles.Normal.WordWrap = True
            .SelectionMode = SelectionModeEnum.Row
            .AllowMerging = AllowMergingEnum.FixedOnly
            .AllowEditing = False
            .Rows.Fixed = 1
            .Rows.Count = 2
            .Rows(0).Height = 35
            .Cols.Frozen = 3
            .Cols.Count = 7
            .Cols.Fixed = 1
            .Rows(0).AllowMerging = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "No" : .Cols(0).Name = "No" : .Cols(0).Width = 40
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "UserID" : .Cols(1).Name = "UserID" : .Cols(1).Width = 80 : .Cols(1).TextAlign = TextAlignEnum.CenterCenter : .Cols(1).Visible = False
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "Nama" : .Cols(2).Name = "Nama" : .Cols(2).Width = 200 : .Cols(2).TextAlign = TextAlignEnum.LeftCenter
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "Nik" : .Cols(3).Name = "NIK" : .Cols(3).Width = 80 : .Cols(3).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "Departemen" : .Cols(4).Name = "Departemen" : .Cols(4).Width = 100 : .Cols(4).TextAlign = TextAlignEnum.LeftCenter
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "Jabatan" : .Cols(5).Name = "Jabatan" : .Cols(5).Width = 150 : .Cols(5).TextAlign = TextAlignEnum.RightCenter
            txt = .GetCellRange(0, 6, 0, 6) : txt.Data = "Tgl.Jam" : .Cols(6).Name = "TglJam" : .Cols(6).Width = 150 : .Cols(6).TextAlign = TextAlignEnum.CenterCenter
        End With
    End Sub
    Private Sub GetData()
        Dim sql As String = ""
        Dim i As Integer = 0
        Dim Total As Integer = 0
        Try
            sql = " select a.UserID,b.Nik,b.Nama,b.Departemen,b.JabatanName,TglJam from tblTrnTempLog a join vwMstUserTamu b on a.UserID=b.UserID " &
                    " where convert(date,TglJam) BETWEEN '" & Format(DateAdd(DateInterval.Month, -1, dtPeriode1.Value), "yyyy-MM") & "-26" & "' AND '" & Format(dtPeriode1.Value, "yyyy-MM") & "-25" & "' Order By a.UserID,TglJam"
            Using koneksi As New SqlCommand(sql, OpenKoneksi)
                koneksi.CommandTimeout = 0
                fg1.Rows.Count = 1
                Using DR = koneksi.ExecuteReader()
                    If DR.HasRows Then
                        With fg1
                            While DR.Read
                                .AddItem("")
                                i = .Rows.Count - 1
                                .Item(i, "No") = i
                                If IsDBNull(DR!UserID) = False Then .Item(i, "UserID") = DR!UserID
                                If IsDBNull(DR!NIK) = False Then .Item(i, "NIK") = DR!NIK
                                If IsDBNull(DR!NAMA) = False Then .Item(i, "NAMA") = DR!NAMA
                                If IsDBNull(DR!Departemen) = False Then .Item(i, "Departemen") = DR!Departemen
                                If IsDBNull(DR!JabatanName) = False Then .Item(i, "Jabatan") = DR!JabatanName
                                If IsDBNull(DR!TglJam) = False Then .Item(i, "TglJam") = Format(DR!TglJam, "dd/MM/yyyy HH:mm")
                            End While
                        End With
                    Else
                        MsgBox("Data Tidak Ditemukan!", MessageBoxIcon.Information)
                        fg1.Rows.Count = 1
                        fg1.Rows.Count = 2
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Me.Cursor = Cursors.WaitCursor
        Call GetData()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnCloseDevice_Click(sender As Object, e As EventArgs) Handles btnCloseDevice.Click
        Me.Close()
    End Sub

    Private Sub btnExecl_Click(sender As Object, e As EventArgs) Handles btnExecl.Click
        Me.Cursor = Cursors.WaitCursor
        Call ExportExcelInpoiFlexgrid(fg1, 0, 0, True, "Record Finger 01" & Format(dtPeriode1.Value, "MMyyyy"))
        Me.Cursor = Cursors.Default
    End Sub
End Class