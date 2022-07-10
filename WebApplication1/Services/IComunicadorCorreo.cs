namespace Biklas_API_V2.Services
{
    public interface IComunicadorCorreo
    {
        void EnviarCorreoRecuperacionContra(string emailDest,
            string contraDest,
            string emailOrig,
            string contraOrig);
    }
}