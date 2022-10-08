namespace Biklas_API_V2.Services
{
    public interface IFileShare
    {
        Task<Stream?> DescargarArchivo(string cadenaConexion, string nombreShare, string rutaCarpeta, string nombreArchivo);
    }
}
