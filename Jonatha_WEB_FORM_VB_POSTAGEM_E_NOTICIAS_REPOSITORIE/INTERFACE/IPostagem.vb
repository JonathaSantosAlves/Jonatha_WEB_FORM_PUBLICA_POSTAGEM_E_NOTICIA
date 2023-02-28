Imports Jonatha_WEB_FORM_VB_POSTAGEM_E_NOTICIAS_DOMAIN

Public Interface IPostagem

    Function Registro(ByVal model_postagem As Postagem) As Task
    Function Alterar(ByVal model_postagem As Postagem) As Task
    Function Coletar_Dados_Postagem() As Task(Of IEnumerable(Of Postagem))
    Function Coletar_Dados_Postagem_ID(ByVal Id As Integer) As Task(Of IEnumerable(Of Postagem))
    Sub Deletar(ByVal Id As Integer)

End Interface
