Public Class login
    Dim Create As Boolean = False
    Dim clickcount, click As Integer
    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click, btnForgotPassword.Click

        If Create = False Then
            Try
                'checking username and password if existed
                expressquery1("Select * from Account where Username= '" & txtUsername.Text & "' and Password= '" & txtPassword.Text & "'", "Account")

                'checking what username selected to the database
                MsgBox(eset.Tables("Account").Rows(0).Item("Username").ToString & vbNewLine & Create)

                'dataset to get
                Dim username As String = eset.Tables("Account").Rows(0).Item("Username").ToString()
                Dim password As String = eset.Tables("Account").Rows(0).Item("Password").ToString()
                If username = txtUsername.Text And password = txtPassword.Text Then
                    succes = True
                End If

            Catch ex As Exception

            End Try

            clickcount += 1
            If succes = True Then
                Form1.Show()
                Me.Close()
            ElseIf clickcount = 3 Then
                lblLoginMessage.Text = "Forget Password?"
                btnForgotPassword.Show()
            Else
                lblLoginMessage.Text = "Incorrect Username and Password"
            End If

        ElseIf Create = True Then
            btnLogin.Text = "login"
            Create = False
            lblBirthDate.Hide()
            txtBirthDate.Hide()
            lblRepeatPassword.Hide()
            txtRepeatPassword.Hide()
            txtRepeatPassword.TabIndex = 0
            txtBirthDate.TabIndex = 0
            btnLogin.TabIndex = 3
            btnCreate.TabIndex = 4
            click = 0
        End If

    End Sub

    Private Sub login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblLoginMessage.Text = ""
        expressconnect1()
    End Sub
    Private Sub login_Closed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.FormClosed
        If succes = False Then
            Form1.Close()
        End If
    End Sub

    Private Sub btnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreate.Click
        lblBirthDate.Show()
        txtBirthDate.Show()
        Create = True
        btnLogin.Text = "Cancel"
        txtRepeatPassword.Show()
        lblRepeatPassword.Show()
        txtRepeatPassword.TabIndex = 3
        txtBirthDate.TabIndex = 4
        btnCreate.TabIndex = 5
        btnLogin.TabIndex = 6
        click += 1
        If click > 1 Then
            Dim username As String
            Dim password As String
            Try
                expressquery1("Select * from Account where Username= '" & txtUsername.Text & "'", "Account")
                username = eset.Tables("Account").Rows(0).Item("Username").ToString()
                password = eset.Tables("Account").Rows(0).Item("Password").ToString()
            Catch ex As Exception

            End Try

            If txtUsername.TextLength < 1 Or txtPassword.TextLength < 1 Or txtRepeatPassword.TextLength < 1 Or txtBirthDate.TextLength < 1 Then
                MsgBox("Pls fill up the missing box", vbInformation, "System")
            ElseIf txtPassword.Text <> txtRepeatPassword.Text Then
                MsgBox("hell")
            ElseIf txtUsername.Text = username Then
                MsgBox("That Username is already existed", vbInformation, "System")
            Else


                '              insert into Account (Username, Password) values ("testing","weee");
                'insertexpress("insert into Account (Username, Password) values ('testing','weee')", "testing", "")
                'insertexpress("insert into Account (Username,Password) values ('" & txtUsername.Text & "','" & txtPassword.Text & "')", "testing", "")
                'insertexpress("INSERT INTO Account ( Username , Password , Date_Create , Birthdate ) VALUES ('" & txtUsername.Text & "','" & txtPassword.Text & "','" & Format(Now(), ("mmm/dd/yyyy")).ToString & "','" & txtBirthDate.Text & "')", "testing", "")
                insertexpress("Insert into Account values ('" & txtUsername.Text & "','" & txtPassword.Text & "','" & Format(Now(), ("mmm/dd/yyyy")).ToString & "','" & txtBirthDate.Text & "')", "testing", "")
            End If

        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If txtPassword.PasswordChar = "*" Then
            txtPassword.PasswordChar = ""
            txtRepeatPassword.PasswordChar = ""
        Else
            txtRepeatPassword.PasswordChar = "*"
            txtPassword.PasswordChar = "*"
        End If
    End Sub
End Class