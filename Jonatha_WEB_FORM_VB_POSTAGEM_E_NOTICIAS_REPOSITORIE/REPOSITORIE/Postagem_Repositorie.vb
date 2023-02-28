Imports System.Data.SqlClient
Imports Jonatha_WEB_FORM_VB_POSTAGEM_E_NOTICIAS_DOMAIN

Public Class Postagem_Repositorie
    Implements IPostagem

    Private PROJETOS01 As SqlConnection = New SqlConnection("data source=seu_servidor;initial catalog=seu_bd;user id=seu_usuario;password=sua-senha;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
    Private selecionar, inserir, deleta, atualizar As SqlCommand
    Private leitura As SqlDataReader

    Public Async Sub Deletar(Id As Integer) Implements IPostagem.Deletar
        Using PROJETOS01

            If PROJETOS01.State = ConnectionState.Closed Then
                PROJETOS01.Open()
            End If

            Using deleta = New SqlCommand("DELETE FROM POSTAGEM WHERE ID = @ID", PROJETOS01)
                deleta.Parameters.AddWithValue("@ID", Id)
                Await deleta.ExecuteNonQueryAsync()
            End Using
        End Using
    End Sub

    Public Async Function Registro(model_postagem As Postagem) As Task Implements IPostagem.Registro
        Try

            Using PROJETOS01

                If PROJETOS01.State = ConnectionState.Closed Then
                    PROJETOS01.Open()
                End If

                Using inserir = New SqlCommand("INSERT INTO POSTAGEM (DATA_REGISTRO, USUARIO, TITULO, ARQUIVO, CURTIDA, DESCRICAO, TIPO) " & "VALUES (FORMAT (GETDATE(), 'yyyy-MM-dd'), @USUARIO, @TITULO, @ARQUIVO, @CURTIDA, @DESCRICAO, @TIPO)", PROJETOS01)
                    inserir.Parameters.AddWithValue("@USUARIO", model_postagem.USUARIO)
                    inserir.Parameters.AddWithValue("@TITULO", model_postagem.TITULO)
                    inserir.Parameters.AddWithValue("@ARQUIVO", model_postagem.ARQUIVO)
                    inserir.Parameters.AddWithValue("@CURTIDA", model_postagem.CURTIDA)
                    inserir.Parameters.AddWithValue("@DESCRICAO", model_postagem.DESCRICAO)
                    inserir.Parameters.AddWithValue("@TIPO", model_postagem.TIPO)
                    Await inserir.ExecuteNonQueryAsync()
                End Using
            End Using

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Async Function Alterar(model_postagem As Postagem) As Task Implements IPostagem.Alterar
        Try

            Using PROJETOS01

                If PROJETOS01.State = ConnectionState.Closed Then
                    PROJETOS01.Open()
                End If

                Using atualizar = New SqlCommand("UPDATE POSTAGEM SET TITULO = @TITULO, DESCRICAO = @DESCRICAO, TIPO = @TIPO WHERE ID = @ID", PROJETOS01)
                    atualizar.Parameters.AddWithValue("@TITULO", model_postagem.TITULO)
                    atualizar.Parameters.AddWithValue("@DESCRICAO", model_postagem.DESCRICAO)
                    atualizar.Parameters.AddWithValue("@TIPO", model_postagem.TIPO)
                    atualizar.Parameters.AddWithValue("@ID", model_postagem.ID)
                    Await atualizar.ExecuteNonQueryAsync()
                End Using
            End Using

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Async Function Coletar_Dados_Postagem() As Task(Of IEnumerable(Of Postagem)) Implements IPostagem.Coletar_Dados_Postagem
        Try

            Using PROJETOS01

                If PROJETOS01.State = ConnectionState.Closed Then
                    PROJETOS01.Open()
                End If

                Dim lista_postagem As List(Of Postagem) = New List(Of Postagem)()

                Using selecionar = New SqlCommand("SELECT ID, DATA_REGISTRO, USUARIO, TITULO, ARQUIVO, " & "CURTIDA, DESCRICAO, TIPO FROM POSTAGEM", PROJETOS01)

                    Using leitura = Await selecionar.ExecuteReaderAsync()

                        Dim modelo_postagem As Postagem = Nothing

                        While Await leitura.ReadAsync()
                            modelo_postagem = New Postagem()
                            modelo_postagem.ID = Convert.ToInt32(leitura(0))
                            modelo_postagem.DATA_REGISTRO = Convert.ToDateTime(leitura(1))
                            modelo_postagem.USUARIO = Convert.ToString(leitura(2))
                            modelo_postagem.TITULO = Convert.ToString(leitura(3))

                            If Convert.ToString(leitura(7)) = "YOUTUBE" Then
                                modelo_postagem.ARQUIVO = "https://www.youtube.com/embed/" & Convert.ToString(leitura(4)).Substring(Convert.ToString(leitura(4)).IndexOf("?v=") + 3, (Convert.ToString(leitura(4)).Length - Convert.ToString(leitura(4)).IndexOf("?v=")) - 3)
                            Else
                                modelo_postagem.ARQUIVO = Convert.ToString(leitura(4))
                            End If

                            modelo_postagem.CURTIDA = Convert.ToInt32(leitura(5))
                            modelo_postagem.DESCRICAO = Convert.ToString(leitura(6))
                            modelo_postagem.TIPO = Convert.ToString(leitura(7))
                            lista_postagem.Add(modelo_postagem)
                        End While

                        Return lista_postagem
                    End Using
                End Using
            End Using

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Async Function Coletar_Dados_Postagem_ID(Id As Integer) As Task(Of IEnumerable(Of Postagem)) Implements IPostagem.Coletar_Dados_Postagem_ID
        Try

            Using PROJETOS01

                If PROJETOS01.State = ConnectionState.Closed Then
                    PROJETOS01.Open()
                End If

                Dim lista_postagem As List(Of Postagem) = New List(Of Postagem)()

                Using selecionar = New SqlCommand("SELECT ID, DATA_REGISTRO, USUARIO, TITULO, ARQUIVO, " & "CURTIDA, DESCRICAO, TIPO FROM POSTAGEM WHERE ID = @ID", PROJETOS01)
                    selecionar.Parameters.AddWithValue("@ID", Id)

                    Using leitura = Await selecionar.ExecuteReaderAsync()

                        Dim modelo_postagem As Postagem = Nothing

                        While Await leitura.ReadAsync()
                            modelo_postagem = New Postagem()
                            modelo_postagem.ID = Convert.ToInt32(leitura(0))
                            modelo_postagem.DATA_REGISTRO = Convert.ToDateTime(leitura(1))
                            modelo_postagem.USUARIO = Convert.ToString(leitura(2))
                            modelo_postagem.TITULO = Convert.ToString(leitura(3))

                            If Convert.ToString(leitura(7)) = "YOUTUBE" Then
                                modelo_postagem.ARQUIVO = "https://www.youtube.com/embed/" & Convert.ToString(leitura(4)).Substring(Convert.ToString(leitura(4)).IndexOf("?v=") + 3, (Convert.ToString(leitura(4)).Length - Convert.ToString(leitura(4)).IndexOf("?v=")) - 3)
                            Else
                                modelo_postagem.ARQUIVO = Convert.ToString(leitura(4))
                            End If

                            modelo_postagem.CURTIDA = Convert.ToInt32(leitura(5))
                            modelo_postagem.DESCRICAO = Convert.ToString(leitura(6))
                            modelo_postagem.TIPO = Convert.ToString(leitura(7))
                            lista_postagem.Add(modelo_postagem)
                        End While

                        Return lista_postagem
                    End Using
                End Using
            End Using

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
End Class
