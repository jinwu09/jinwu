Imports System.Data.OleDb
Module Module1
    Public conn As New OleDb.OleDbConnection
    Public eset As DataSet
    Public dt1 As DataTable
    Public conexpress1 As New OleDbConnection
    Public expresscount1 As New OleDbDataAdapter
    Public scom As New OleDbCommand

    Public succes As Boolean = False

    Public Sub expressconnect1()
        Try
            'open the database source
            conexpress1 = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Environment.CurrentDirectory & "\DTable.accdb")

            If conexpress1.State = ConnectionState.Open Then
                conexpress1.Close()
            End If
            conexpress1.Open()
            'MsgBox("ok")
        Catch ex As Exception
            MsgBox("Unable to connect. Program will now be terminated.", vbInformation, "Unable to connect")
            MsgBox(ex.ToString)
            End
        End Try
    End Sub

    Public Function expressquery1(ByVal str As String, ByVal tbl As String)

        Try
            expresscount1 = New OleDbDataAdapter(str, conexpress1)
            eset = New DataSet
            expresscount1.Fill(eset, tbl)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Public Function insertexpress(ByVal str As String, ByVal Mstr As String, ByVal Tstr As String)
        conexpress1.Close()
        conexpress1.Open()
        Try
            scom.CommandText = str
            scom.Connection = conexpress1
            scom.ExecuteNonQuery()
            If Mstr.Length > 0 Then

                Dim a = MsgBox(Mstr, vbInformation + vbOKOnly, Tstr)

            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
        conexpress1.Close()
    End Function
End Module
