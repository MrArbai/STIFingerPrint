Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports WeifenLuo.WinFormsUI.Docking

Public Class FrmTrnCutiIzinFind : Inherits DockContent
    Private Sub FrmTrnCutiIzinFind_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call GetDepartemenAksesn(cboDepartemen)
        Call GetStatusTK(cboStatus)
        Call SetGridDefult()
        fg.Rows.Count = 1
        fg.Rows.Count = 2
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
            .AllowEditing = False
            .Rows.Fixed = 1
            .Rows.Count = 2
            .Rows(0).Height = 30
            .Cols.Frozen = 0
            .Cols.Count = 11
            .Cols.Fixed = 1
            .Rows(0).AllowMerging = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "No" : .Cols(0).Name = "No" : .Cols(0).Width = 40
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "Nama" : .Cols(1).Name = "Nama" : .Cols(1).Width = 200
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "Nik" : .Cols(2).Name = "Nik" : .Cols(2).Width = 70 : .Cols(2).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "Departemen" : .Cols(3).Name = "Departemen" : .Cols(3).Width = 140
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "Jabatan" : .Cols(4).Name = "Jabatan" : .Cols(4).Width = 140
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "HeaderID" : .Cols(5).Name = "HeaderID" : .Cols(5).Width = 100 : .Cols(5).Visible = False
            txt = .GetCellRange(0, 6, 0, 6) : txt.Data = "Status TK" : .Cols(6).Name = "StatusTK" : .Cols(6).Width = 80 : .Cols(6).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 7, 0, 7) : txt.Data = "Tgl.Mulai" : .Cols(7).Name = "TglMulai" : .Cols(7).Width = 80 : .Cols(7).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 8, 0, 8) : txt.Data = "Tgl.Akhir" : .Cols(8).Name = "TglAkhir" : .Cols(8).Width = 80 : .Cols(8).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 9, 0, 9) : txt.Data = "Jenis" : .Cols(9).Name = "Jenis" : .Cols(9).Width = 80 : .Cols(9).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 10, 0, 10) : txt.Data = "Keterangan" : .Cols(10).Name = "Keterangan" : .Cols(10).Width = 150
        End With
    End Sub
    Private Sub GetData()
        Dim sql As String = ""
        Dim baris As Integer = 1
        Try
            If cboStatus.SelectedValue = 1 Then
                sql = " select DISTINCT HeaderID,StatusTk,Nik,Nama,Departemen,JabatanName,TglAwal,TglAkhir,NamaTidakKerja,Keterangan,NamaTidakKerja from vwTrnCutiIzin where   StatusTK='KARYAWAN' AND Complete=0  "
            Else
                sql = " select DISTINCT HeaderID,StatusTk,Nik,Nama,Departemen,JabatanName,TglAwal,TglAkhir,NamaTidakKerja,Keterangan,NamaTidakKerja from vwTrnCutiIzin where   StatusTK='HARIAN' AND Complete=0 "
            End If
            If Trim(cboDepartemen.Text) <> "" Then
                sql = sql & " and DeptID =" & cboDepartemen.SelectedValue & " "
            End If
            Me.Cursor = Cursors.WaitCursor
            fg.Rows.Count = 1
            Using koneksi As New SqlCommand(sql, OpenKoneksi)
                koneksi.CommandTimeout = 0
                Using DR = koneksi.ExecuteReader
                    If DR.HasRows Then
                        With fg
                            While DR.Read
                                .AddItem("")
                                baris = .Rows.Count - 1
                                .Item(baris, "No") = baris
                                .Item(baris, "Nama") = DR!NAMA
                                .Item(baris, "Nik") = DR!Nik
                                .Item(baris, "HeaderID") = DR!HeaderID
                                If IsDBNull(DR!Departemen) = False Then .Item(baris, "Departemen") = DR!Departemen
                                If IsDBNull(DR!JabatanName) = False Then .Item(baris, "Jabatan") = DR!JabatanName
                                .Item(baris, "StatusTK") = DR!StatusTK
                                .Item(baris, "TglMulai") = DR!TglAwal
                                .Item(baris, "TglAkhir") = DR!TglAkhir
                                .Item(baris, "Jenis") = DR!NamaTidakKerja
                                If IsDBNull(DR!Keterangan) = False Then .Item(baris, "Keterangan") = DR!Keterangan
                            End While
                        End With
                    Else
                        fg.Rows.Count = 2
                        MsgBox("Data Tidak Ditemukan!", MessageBoxIcon.Stop)
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                End Using
            End Using
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If Trim(cboStatus.Text) = "" Then
            MsgBox("Status Belum Ditentukan!", MessageBoxIcon.Stop)
            Exit Sub
        End If
        Call GetData()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnChose_Click(sender As Object, e As EventArgs) Handles btnChose.Click
        If Convert.ToInt32((fg.Item(fg.Row, "HeaderID"))) > 0 Then
            FrmTrnCutiIzinInput.GetDataSudahDisimpan(fg.Item(fg.Row, "HeaderID"))
            Me.Close()
        End If
    End Sub

    Private Sub fg_Click(sender As Object, e As EventArgs) Handles fg.Click

    End Sub

    Private Sub fg_DoubleClick(sender As Object, e As EventArgs) Handles fg.DoubleClick
        btnChose_Click(sender, e)
    End Sub
End Class