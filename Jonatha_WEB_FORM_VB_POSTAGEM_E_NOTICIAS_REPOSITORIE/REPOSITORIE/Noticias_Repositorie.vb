Imports System.Data.SqlClient
Imports Jonatha_WEB_FORM_VB_POSTAGEM_E_NOTICIAS_DOMAIN

Public Class Noticias_Repositorie
    Implements INoticia

    Private PROJETOS01 As SqlConnection = New SqlConnection("data source=seu_servidor;initial catalog=seu_bd;user id=seu_usuario;password=sua_senha;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
    Private selecionar, inserir, deleta, atualizar As SqlCommand
    Private leitura As SqlDataReader

    Public Async Sub Deletar(Id As Integer) Implements INoticia.Deletar
        Using PROJETOS01

            If PROJETOS01.State = ConnectionState.Closed Then
                PROJETOS01.Open()
            End If

            Using deleta = New SqlCommand("DELETE FROM NOTICIAS WHERE ID = @ID", PROJETOS01)
                deleta.Parameters.AddWithValue("@ID", Id)
                Await deleta.ExecuteNonQueryAsync()
            End Using
        End Using
    End Sub

    Public Async Function Registro(model_noticias As Noticias) As Task Implements INoticia.Registro
        Try

            Using PROJETOS01

                If PROJETOS01.State = ConnectionState.Closed Then
                    PROJETOS01.Open()
                End If

                Using inserir = New SqlCommand("INSERT INTO NOTICIAS (DATA_REGISTRO, USUARIO, TITULO, ARQUIVO, TIPO) " & "VALUES (FORMAT (GETDATE(), 'yyyy-MM-dd'), @USUARIO, @TITULO, @ARQUIVO, @TIPO)", PROJETOS01)
                    inserir.Parameters.AddWithValue("@USUARIO", model_noticias.USUARIO)
                    inserir.Parameters.AddWithValue("@TITULO", model_noticias.TITULO)
                    inserir.Parameters.AddWithValue("@ARQUIVO", model_noticias.ARQUIVO)
                    inserir.Parameters.AddWithValue("@TIPO", model_noticias.TIPO)
                    Await inserir.ExecuteNonQueryAsync()
                End Using
            End Using

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Async Function Alterar(model_noticias As Noticias) As Task Implements INoticia.Alterar
        Try

            Using PROJETOS01

                If PROJETOS01.State = ConnectionState.Closed Then
                    PROJETOS01.Open()
                End If

                Using atualizar = New SqlCommand("UPDATE NOTICIAS SET TITULO = @TITULO, TIPO = @TIPO WHERE ID = @ID", PROJETOS01)
                    atualizar.Parameters.AddWithValue("@TITULO", model_noticias.TITULO)
                    atualizar.Parameters.AddWithValue("@TIPO", model_noticias.TIPO)
                    atualizar.Parameters.AddWithValue("@ID", model_noticias.ID)
                    Await atualizar.ExecuteNonQueryAsync()
                End Using
            End Using

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Private Async Function INoticia_Coletar_Dados_Noticias() As Task(Of IEnumerable(Of Noticias)) Implements INoticia.Coletar_Dados_Noticias
        Try

            Using PROJETOS01

                If PROJETOS01.State = ConnectionState.Closed Then
                    PROJETOS01.Open()
                End If

                Dim lista_noticias As List(Of Noticias) = New List(Of Noticias)()

                Using selecionar = New SqlCommand("SELECT ID, DATA_REGISTRO, USUARIO, TITULO, ARQUIVO, TIPO FROM NOTICIAS", PROJETOS01)

                    Using leitura = Await selecionar.ExecuteReaderAsync()

                        Dim modelo_noticias As Noticias = Nothing

                        While Await leitura.ReadAsync()
                            modelo_noticias = New Noticias()
                            modelo_noticias.ID = Convert.ToInt32(leitura(0))
                            modelo_noticias.DATA_REGISTRO = Convert.ToDateTime(leitura(1))
                            modelo_noticias.USUARIO = Convert.ToString(leitura(2))
                            modelo_noticias.TITULO = Convert.ToString(leitura(3))

                            If Convert.ToString(leitura(5)) = "YOUTUBE" Then
                                modelo_noticias.ARQUIVO = "https://www.youtube.com/embed/" & Convert.ToString(leitura(4)).Substring(Convert.ToString(leitura(4)).IndexOf("?v=") + 3, (Convert.ToString(leitura(4)).Length - Convert.ToString(leitura(4)).IndexOf("?v=")) - 3)
                            Else
                                modelo_noticias.ARQUIVO = Convert.ToString(leitura(4))
                            End If

                            modelo_noticias.TIPO = Convert.ToString(leitura(5))
                            lista_noticias.Add(modelo_noticias)
                        End While

                        Return lista_noticias
                    End Using
                End Using
            End Using

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Private Async Function INoticia_Coletar_Dados_Noticias_ID(Id As Integer) As Task(Of IEnumerable(Of Noticias)) Implements INoticia.Coletar_Dados_Noticias_ID
        Try

            Using PROJETOS01

                If PROJETOS01.State = ConnectionState.Closed Then
                    PROJETOS01.Open()
                End If

                Dim lista_noticias As List(Of Noticias) = New List(Of Noticias)()

                Using selecionar = New SqlCommand("SELECT ID, DATA_REGISTRO, USUARIO, TITULO, ARQUIVO, TIPO FROM NOTICIAS WHERE ID = @ID", PROJETOS01)
                    selecionar.Parameters.AddWithValue("@ID", Id)

                    Using leitura = Await selecionar.ExecuteReaderAsync()

                        Dim modelo_noticias As Noticias = Nothing

                        While Await leitura.ReadAsync()
                            modelo_noticias = New Noticias()
                            modelo_noticias.ID = Convert.ToInt32(leitura(0))
                            modelo_noticias.DATA_REGISTRO = Convert.ToDateTime(leitura(1))
                            modelo_noticias.USUARIO = Convert.ToString(leitura(2))
                            modelo_noticias.TITULO = Convert.ToString(leitura(3))

                            If Convert.ToString(leitura(5)) = "YOUTUBE" Then
                                modelo_noticias.ARQUIVO = "https://www.youtube.com/embed/" & Convert.ToString(leitura(4)).Substring(Convert.ToString(leitura(4)).IndexOf("?v=") + 3, (Convert.ToString(leitura(4)).Length - Convert.ToString(leitura(4)).IndexOf("?v=")) - 3)
                            Else
                                modelo_noticias.ARQUIVO = Convert.ToString(leitura(4))
                            End If

                            modelo_noticias.TIPO = Convert.ToString(leitura(5))
                            lista_noticias.Add(modelo_noticias)
                        End While

                        Return lista_noticias
                    End Using
                End Using
            End Using

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
End Class
