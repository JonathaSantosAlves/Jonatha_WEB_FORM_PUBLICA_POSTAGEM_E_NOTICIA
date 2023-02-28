Imports Jonatha_WEB_FORM_VB_POSTAGEM_E_NOTICIAS_DOMAIN

Public Interface INoticia

    Function Registro(ByVal model_noticias As Noticias) As Task
    Function Alterar(ByVal model_noticias As Noticias) As Task
    Function Coletar_Dados_Noticias() As Task(Of IEnumerable(Of Noticias))
    Function Coletar_Dados_Noticias_ID(ByVal Id As Integer) As Task(Of IEnumerable(Of Noticias))
    Sub Deletar(ByVal Id As Integer)
End Interface
