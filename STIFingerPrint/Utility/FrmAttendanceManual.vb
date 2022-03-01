Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid

Public Class FrmAttendanceManual
    Private Sub FrmAttendanceManual_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call SetGridDefult()
        Call GetDepartemen(cboDepartemen)
        Call GetDevice(cboLokasiAbsen)
        Call GetIOMode(cboIOMode)
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
            .Rows(0).Height = 30
            .Rows.Count = 2
            .Cols.Frozen = 0
            .Cols.Count = 6
            .Cols.Fixed = 1
            .Rows(0).AllowMerging = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "No" : .Cols(0).Name = "No" : .Cols(0).Width = 40
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "UserID" : .Cols(1).Name = "UserID" : .Cols(1).Width = 40 : .Cols(1).Visible = False
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "Nama" : .Cols(2).Name = "Nama" : .Cols(2).Width = 150
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "Nik" : .Cols(3).Name = "Nik" : .Cols(3).Width = 70
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "Departemen" : .Cols(4).Name = "Departemen" : .Cols(4).Width = 100
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "Status" : .Cols(5).Name = "Status" : .Cols(5).Width = 100
        End With
    End Sub

    Private Sub getData()
        Dim cek As Boolean = False
        Dim sql As String
        Dim i As Integer = 1
        sql = "select UserID,NAMA,NIK,StatusTK,DeptID,Departemen from vwMstUser where TGLKELUAR is null and DeptID='" & cboDepartemen.SelectedValue & "' "
        If Trim(txtNikNama.Text) <> "" Then
            sql = sql & " and ( Nik='" & Trim(txtNikNama.Text) & "' or Nama Like '%" & Trim(txtNikNama.Text) & "%' )"
        End If
        sql = sql & " order by StatusTK,NAMA "
        Using koneksi As New SqlCommand(sql, OpenKoneksi)
            koneksi.CommandTimeout = 0
            fg.Rows.Count = 1
            Using DR = koneksi.ExecuteReader
                If DR.HasRows Then
                    With fg
                        While DR.Read
                            .AddItem("")
                            .Item(i, "No") = i
                            .Item(i, "UserID") = DR!UserID
                            .Item(i, "NAMA") = DR!NAMA
                            .Item(i, "NIK") = DR!NIK
                            .Item(i, "Status") = DR!StatusTK
                            .Item(i, "Departemen") = DR!Departemen
                            i = i + 1
                        End While
                    End With
                Else
                    fg.Rows.Count = 1
                    fg.Rows.Count = 2
                    MsgBox("Data Tidak Ditemukan!", MessageBoxIcon.Warning)
                    Exit Sub
                End If
            End Using
        End Using
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If Trim(cboDepartemen.Text) = "" Then
            MsgBox("Silakan Pilih Departemen!", MessageBoxIcon.Stop)
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        Call getData()
        Me.Cursor = Cursors.Default
    End Sub

    Public Sub GetIOMode(ByVal cbo As ComboBox)
        With cbo
            Dim tb As New DataTable
            tb.Columns.Add("Text", GetType(String))
            tb.Columns.Add("Value", GetType(Integer))
            tb.Rows.Add("Masuk", 1)
            tb.Rows.Add("Ist Out", 2)
            tb.Rows.Add("Ist In", 3)
            tb.Rows.Add("Pulang", 4)
            .DataSource = tb
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = -1
        End With
    End Sub

    Private Sub fg_Click(sender As Object, e As EventArgs) Handles fg.Click
        With fg
            txtNama.Text = .Item(.Row, "Nama")
            txtNik.Text = .Item(.Row, "Nik")
            txtDepartemen.Text = .Item(.Row, "Departemen")
            txtUserID.Text = .Item(.Row, "UserID")
        End With
    End Sub

    Private Sub cboLokasiAbsen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLokasiAbsen.SelectedIndexChanged

    End Sub

    Private Sub cboLokasiAbsen_TextUpdate(sender As Object, e As EventArgs) Handles cboLokasiAbsen.TextUpdate
        ValidCombo(cboLokasiAbsen)
    End Sub

    Private Sub cboIOMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboIOMode.SelectedIndexChanged

    End Sub

    Private Sub cboIOMode_TextUpdate(sender As Object, e As EventArgs) Handles cboIOMode.TextUpdate
        ValidCombo(cboIOMode)
    End Sub

    Private Sub cboDepartemen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDepartemen.SelectedIndexChanged

    End Sub

    Private Sub cboDepartemen_TextUpdate(sender As Object, e As EventArgs) Handles cboDepartemen.TextUpdate
        ValidCombo(cboDepartemen)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Function simpan(ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As Boolean
        Dim cmd As SqlCommand = New SqlCommand
        simpan = False
        Dim mycon As SqlConnection = conn
        Dim mycontrans As SqlTransaction = trans
        With cmd
            .Connection = conn
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "spTrnImportHistorySave"
            .Transaction = mycontrans
            .Parameters.Add(New SqlParameter("@RETURN_VALUE", SqlDbType.BigInt, 3, ParameterDirection.ReturnValue, False, 0, 0, 0, DataRowVersion.Proposed, 0))
            .Parameters.Add("@UserID", SqlDbType.BigInt).Value = Trim(txtUserID.Text)
            .Parameters.Add("@TglJam", SqlDbType.DateTime, ParameterDirection.InputOutput).Value = Format(dtTime.Value, "dd/MM/yyyy HH:mm")
            .Parameters.Add("@Verifikasi", SqlDbType.Int, ParameterDirection.InputOutput).Value = 0
            .Parameters.Add("@DevID", SqlDbType.Int, ParameterDirection.InputOutput).Value = cboLokasiAbsen.SelectedValue
            .Parameters.Add("@IOMode", SqlDbType.Int, ParameterDirection.InputOutput).Value = cboIOMode.SelectedValue
            .Parameters.Add("@ImportBy", SqlDbType.VarChar, 20, ParameterDirection.InputOutput).Value = UserLogin
            .ExecuteNonQuery()
        End With
        cmd.Dispose()
        simpan = True
        Return simpan
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim Koneksi As SqlConnection = ModuleKoneksi.OpenKoneksi
        Dim Transaksi As SqlTransaction
        Transaksi = Koneksi.BeginTransaction
        Try
            Me.Cursor = Cursors.WaitCursor
            If simpan(Koneksi, Transaksi) = False Then
                MsgBox("Simpan Data Gagal!", vbCritical, "Failed")
                Me.Cursor = Cursors.Default
                Transaksi.Rollback()
                Exit Sub
            End If
            Transaksi.Commit()
            Me.Cursor = Cursors.Default
            MsgBox("Simpan Record Absensi Berhasil", MessageBoxIcon.Information, "Information")
        Catch ex As Exception
            Transaksi.Rollback()
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class