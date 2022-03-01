Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports WeifenLuo.WinFormsUI.Docking

Public Class FrmTrnRestorRecodFinger : Inherits DockContent
    Private Sub FrmTrnRestorRecodFinger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call SetGridDefult()
        dtTanggal.Value = Now
    End Sub
    Private Sub SetGridDefult()
        Dim txt As CellRange
        With fg
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
            .Cols.Frozen = 0
            .Cols.Count = 5
            .Cols.Fixed = 1
            .Rows(0).AllowMerging = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "No" : .Cols(0).Name = "No" : .Cols(0).Width = 40
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "Nama" : .Cols(1).Name = "Nama" : .Cols(1).Width = 200 : .Cols(1).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "Nik" : .Cols(2).Name = "Nik" : .Cols(2).Width = 80 : .Cols(2).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "Tgl.Jam" : .Cols(3).Name = "TglJam" : .Cols(3).Width = 150 : .Cols(3).TextAlign = TextAlignEnum.LeftCenter
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "UserID" : .Cols(4).Name = "UserID" : .Cols(4).Width = 80 : .Cols(4).TextAlign = TextAlignEnum.LeftCenter : .Cols(4).Visible = False
        End With
    End Sub
    Private Sub GetData()
        Dim sql As String = ""
        Dim i As Integer = 0
        Try
            sql = "select aa.UserID,b.NAMA,b.NIK,aa.TglJam from ( " &
               " select UserID,TglJam FROM tblTrnImportHistoryDelete " &
               " union all " &
               " Select UserID,TglJam FROM tblTrnTempLogDelete ) aa join vwMstUser b On aa.UserID=b.UserID where convert(Date,aa.TglJam)='" & Format(dtTanggal.Value, "yyyy-MM-dd") & "' and b.nik='" & Trim(txtNik.Text) & "' Order By aa.TglJam "
            Using koneksi As New SqlCommand(sql, OpenKoneksi)
                koneksi.CommandTimeout = 0
                fg.Rows.Count = 1
                Using DR = koneksi.ExecuteReader()
                    If DR.HasRows Then
                        With fg
                            While DR.Read
                                .AddItem("")
                                i = .Rows.Count - 1
                                .Item(i, "No") = i
                                If IsDBNull(DR!NAMA) = False Then .Item(i, "Nama") = DR!NAMA
                                If IsDBNull(DR!NIK) = False Then .Item(i, "NIK") = DR!NIK
                                If IsDBNull(DR!TglJam) = False Then .Item(i, "TglJam") = DR!TglJam
                                If IsDBNull(DR!UserID) = False Then .Item(i, "UserID") = DR!UserID
                            End While
                        End With
                    Else
                        MsgBox("Data Tidak Ditemukan!", MessageBoxIcon.Information)
                        fg.Rows.Count = 1
                        fg.Rows.Count = 2
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnCloseDevice_Click(sender As Object, e As EventArgs) Handles btnCloseDevice.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim Koneksi As SqlConnection = ModuleKoneksi.OpenKoneksi
        Dim Transaksi As SqlTransaction
        Transaksi = Koneksi.BeginTransaction
        Try
            If Trim(txtNik.Text) = "" Then
                MsgBox("Silakan Isi NIK!", MessageBoxIcon.Stop)
                Exit Sub
            End If
            If Convert.ToString(fg.Item(1, "Nama")) = "" Then
                MsgBox("Tidak Ada Data Yang Akan Dihapus!", MessageBoxIcon.Stop)
                Exit Sub
            End If
            If RestorRecord(Koneksi, Transaksi) = False Then
                MsgBox("Restor Data Gagal!", vbCritical, "Failed")
                Me.Cursor = Cursors.Default
                Transaksi.Rollback()
                Exit Sub
            End If
            Transaksi.Commit()
            Me.Cursor = Cursors.Default
            MsgBox("Record Berhasil Restor", MessageBoxIcon.Information, "Information")
            fg.Rows.Count = 1
            fg.Rows.Count = 2
        Catch ex As Exception
            Transaksi.Rollback()
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Function RestorRecord(ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As Boolean
        Dim cmd As SqlCommand = New SqlCommand
        RestorRecord = False
        Dim mycon As SqlConnection = conn
        Dim mycontrans As SqlTransaction = trans
        With cmd
            .Connection = conn
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "spRestorRecordFinger"
            .Transaction = mycontrans
            .Parameters.Add(New SqlParameter("@RETURN_VALUE", SqlDbType.BigInt, 3, ParameterDirection.ReturnValue, False, 0, 0, 0, DataRowVersion.Proposed, 0))
            .Parameters.Add("@PeriodeTgl", SqlDbType.DateTime).Value = Format(dtTanggal.Value, "yyyy-MM-dd")
            .Parameters.Add("@Nik", SqlDbType.VarChar, 20).Value = Trim(txtNik.Text)
            .Parameters.Add("@Flag", SqlDbType.Int, ParameterDirection.InputOutput).Value = 0
            .ExecuteNonQuery()
        End With
        If CInt(cmd.Parameters("@Flag").Value) <> 0 Then
            cmd.Dispose()
            Exit Function
        End If
        cmd.Dispose()
        RestorRecord = True
        Return RestorRecord
    End Function

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Call GetData()
    End Sub
End Class