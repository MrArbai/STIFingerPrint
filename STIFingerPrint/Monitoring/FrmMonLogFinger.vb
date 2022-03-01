Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports WeifenLuo.WinFormsUI.Docking

Public Class FrmMonLogFinger : Inherits DockContent
    Private Sub FrmMonLogFinger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call GetDepartemenAksesn(cboDepartemen)
        Call SetGridDefult()
    End Sub
    Private Sub SetGridDefult()
        Dim txt As CellRange
        With fg
            .Styles.Alternate.BackColor = Color.PapayaWhip
            .Styles.Fixed.BackColor = Color.Thistle
            .Styles.Fixed.ForeColor = Color.Black
            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .BorderStyle = Util.BaseControls.BorderStyleEnum.None
            .Styles.Normal.WordWrap = True
            .AllowMerging = AllowMergingEnum.FixedOnly
            .AllowEditing = True
            .Rows.Fixed = 1
            .Rows.Count = 2
            .Rows(0).Height = 30
            .Cols.Frozen = 0
            .Cols.Count = 8
            .Cols.Fixed = 1
            .Rows(0).AllowMerging = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "No" : .Cols(0).Name = "No" : .Cols(0).Width = 40
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "UserID" : .Cols(1).Name = "UserID" : .Cols(1).Width = 80
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "Nama" : .Cols(2).Name = "Nama" : .Cols(2).Width = 200
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "Nik" : .Cols(3).Name = "Nik" : .Cols(3).Width = 100
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "Jabatan" : .Cols(4).Name = "Jabatan" : .Cols(4).Width = 200
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "Status" : .Cols(5).Name = "Status" : .Cols(5).Width = 150
            txt = .GetCellRange(0, 6, 0, 6) : txt.Data = "Tgl.Jam" : .Cols(6).Name = "TglJam" : .Cols(6).Width = 100
            txt = .GetCellRange(0, 7, 0, 7) : txt.Data = "Device" : .Cols(7).Name = "Device" : .Cols(7).Width = 200
        End With
    End Sub

    Private Sub cboDepartemen_TextUpdate(sender As Object, e As EventArgs) Handles cboDepartemen.TextUpdate
        ValidCombo(cboDepartemen)
    End Sub
    Private Sub GetData()
        Dim sql As String = ""
        Dim i As Integer = 1
        Dim TglAwal, TglAkhir As Date
        TglAwal = DateAdd(DateInterval.Month, -1, (CDate(Format(CDate(txtPeriode.Text), "yyyy") & "-" & Format(CDate(txtPeriode.Text), "MM") & "-26")))
        TglAkhir = (CDate(Format(CDate(txtPeriode.Text), "yyyy") & "-" & Format(CDate(txtPeriode.Text), "MM") & "-25"))
        sql = "SELECT DISTINCT BB.UserID,C.NAMA,C.NIK,C.JabatanName,C.StatusTK,BB.TglJam,D.DevName,c.DeptID FROM ( " &
               " select UserID,TglJam,DevID from tblTrnTempLog " &
               " union all " &
               " select UserID,TglJam,DevID from tblTrnImportHistory) BB JOIN vwMstUser C ON BB.UserID=C.UserID " &
               " JOIN tblMstDevice D ON BB.DevID=D.DevID  where c.DeptID='" & cboDepartemen.SelectedValue & "' and (CONVERT(date,bb.TglJam) between '" & Format(TglAwal, "yyyy-MM-dd") & "' and '" & Format(TglAkhir, "yyyy-MM-dd") & "') "

        If Trim(txtNik.Text) <> "" Then
            sql = sql & " and (c.Nik='" & Trim(txtNik.Text) & "' or c.Nama like '%" & Trim(txtNik.Text) & "%') "
        End If
        sql = sql & " Order By C.NAMA, bb.UserID,BB.TglJam"

        Using koneksi As New SqlCommand(sql, OpenKoneksi)
            koneksi.CommandTimeout = 0
            fg.Rows.Count = 1
            Using DR = koneksi.ExecuteReader()
                If DR.HasRows Then
                    With fg
                        While DR.Read
                            .AddItem("")
                            .Item(i, "No") = i
                            .Item(i, "UserID") = DR!UserID
                            .Item(i, "NIK") = DR!NIK
                            .Item(i, "NAMA") = DR!NAMA
                            If IsDBNull(DR!JabatanName) = False Then .Item(i, "Jabatan") = DR!JabatanName
                            If IsDBNull(DR!StatusTK) = False Then .Item(i, "Status") = DR!StatusTK
                            If IsDBNull(DR!TglJam) = False Then .Item(i, "TglJam") = DR!TglJam
                            If IsDBNull(DR!DevName) = False Then .Item(i, "Device") = DR!DevName
                            i = i + 1
                        End While
                    End With
                Else
                    fg.Rows.Count = 1
                    fg.Rows.Count = 2
                    MsgBox("Data Tidak Ditemukan!", MessageBoxIcon.Stop)
                End If
            End Using
        End Using
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If txtPeriode.Text = "  :" Then
            MsgBox("Periode Belum Diisi!", MessageBoxIcon.Warning, "Warning!")
            Exit Sub
        End If
        If Trim(cboDepartemen.Text) = "" Then
            MsgBox("Departemen Belum Dipilih!", MessageBoxIcon.Stop)
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        Call GetData()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnExecl_Click(sender As Object, e As EventArgs) Handles btnExecl.Click
        ExportExcelInpoiFlexgrid(fg, 0, 0, True, "Log Finger Departemen " & cboDepartemen.Text)
    End Sub
End Class