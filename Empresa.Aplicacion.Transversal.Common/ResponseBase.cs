namespace Empresa.Aplicacion.Transversal.Common
{
    public class ResponseBase<T>
    {
        public T Data { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public int Usuario_Id { get; set; }
        public int Perfil_Id { get; set; }
        public string Login { get; set; }
        public string Token { get; set; }
        public int? Valor_Calificacion { get; set; }
    }
}