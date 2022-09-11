namespace Biklas_API_V2.Services
{
    public interface IEncriptador
    {
        byte[] Llave { get; }

        byte[] IV { get; }

        byte[] Encriptar(string textoPlano, byte[] llave, byte[] IV);
        
        string Desencriptar(byte[] textoCifr, byte[] llave, byte[] IV);
    }
}