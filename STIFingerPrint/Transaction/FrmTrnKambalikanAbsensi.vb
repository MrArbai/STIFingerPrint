Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports WeifenLuo.WinFormsUI.Docking

Public Class FrmTrnKambalikanAbsensi : Inherits DockContent
    Private Sub FrmTrnKambalikanAbsensi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call SetGridDefult()
        dtPeriode1.Value = Now
        Call GetStatusTK(cboStatus)
        Call GetDepartemenAksesn(cboDepartemen)
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
            .AllowEditing = True
            .Rows.Fixed = 1
            .Rows.Count = 2
            .Rows(0).Height = 35
            .Cols.Frozen = 0
            .Cols.Count = 4
            .Cols.Fixed = 1
            .Rows(0).AllowMerging = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "No" : .Cols(0).Name = "No" : .Cols(0).Width = 40
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "Pilih" : .Cols(1).Name = "Pilih" : .Cols(1).Width = 50 : .Cols(1).TextAlign = TextAlignEnum.CenterCenter : .Cols(1).DataType = GetType(Boolean)
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "Tanggal" : .Cols(2).Name = "Tanggal" : .Cols(2).Width = 120 : .Cols(2).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "AbsenHdrID" : .Cols(3).Name = "AbsenHdrID" : .Cols(3).Width = 80 : .Cols(3).TextAlign = TextAlignEnum.CenterCenter : .Cols(3).Visible = False
        End With
    End Sub
    Private Sub GetData()
        Dim sql As String = ""
        Dim i As Integer = 0
        Try
            If cboStatus.SelectedValue = 1 Then
                sql = "select AbsenHdrID,PeriodeTgl from tblTrnAbsensiHdrKry where PeriodeBln='" & Format(dtPeriode1.Value, "yyyy-MM-01") & "' and DeptID='" & cboDepartemen.SelectedValue & "' and StatusTk='KARYAWAN' Order By PeriodeTgl"
            Else
                sql = "select AbsenHdrID,PeriodeTgl from tblTrnAbsensiHdrKry where PeriodeBln='" & Format(dtPeriode1.Value, "yyyy-MM-01") & "' and DeptID='" & cboDepartemen.SelectedValue & "' and StatusTk='HARIAN' Order By PeriodeTgl"
            End If
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
                                If IsDBNull(DR!PeriodeTgl) = False Then .Item(i, "Tanggal") = Format(DR!PeriodeTgl, "dd/MM/yyyy")
                                If IsDBNull(DR!AbsenHdrID) = False Then .Item(i, "AbsenHdrID") = DR!AbsenHdrID
                            End While
                        End With
                    Else
                        fg.Rows.Count = 1
                        fg.Rows.Count = 2
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If Trim(cboStatus.Text) = "" Then
            MsgBox("Status Silakan Pilih Terlebih Dahulu!", MessageBoxIcon.Stop)
            Exit Sub
        End If
        If Trim(cboDepartemen.Text) = "" Then
            MsgBox("Departemen Silakan Pilih Terlebih Dahulu!", MessageBoxIcon.Stop)
            Exit Sub
        End If
        Call GetData()
    End Sub

    Private Sub fg_Click(sender As Object, e As EventArgs) Handles fg.Click

    End Sub

    Private Sub fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles fg.BeforeEdit
        Select Case e.Col
            Case 1
                e.Cancel = False
            Case Else
                e.Cancel = True
        End Select
    End Sub

    Private Sub btnCloseDevice_Click(sender As Object, e As EventArgs) Handles btnCloseDevice.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim i As Integer = 1
            Dim ListAbsenHdrID As String = ""
            For i = 1 To fg.Rows.Count - 1
                If Convert.ToBoolean(fg.Item(i, "Pilih")) = True Then
                    If ListAbsenHdrID = "" Then
                        ListAbsenHdrID = fg.Item(i, "AbsenHdrID")
                    Else
                        ListAbsenHdrID = ListAbsenHdrID & "," & fg.Item(i, "AbsenHdrID")
                    End If
                End If
            Next
            If ListAbsenHdrID = "" Then
                MsgBox("Tidak Ada Data Yang Akan Dikembalikan!", MsgBoxStyle.Critical, "Stop")
                Exit Sub
            End If
            Call OpenKoneksi()
            CMD = Conn.CreateCommand
            With CMD
                .Connection = Conn
                .CommandType = CommandType.Text
                .CommandText = "Update tblTrnAbsensiHdrKry set CompleteStatus=0 WHERE AbsenHdrID in (" & ListAbsenHdrID & ") "
                .ExecuteNonQuery()
            End With
            MsgBox("Simpan Berhasil", vbInformation, "Success")
            For j As Integer = 1 To fg.Rows.Count - 1
                fg.Item(j, "Pilih") = False
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cboStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboStatus.SelectedIndexChanged

    End Sub

    Private Sub cboStatus_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboStatus.SelectionChangeCommitted

    End Sub
End Class