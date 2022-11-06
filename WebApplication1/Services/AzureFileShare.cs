using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using System.Security.Cryptography.X509Certificates;

namespace Biklas_API_V2.Services
{
    public class AzureFileShare : IFileShare
    {
        public async Task<Stream?> DescargarArchivo(string cadenaConexion, string nombreShare, string rutaCarpeta, string nombreArchivo)
        {
            // Basado en gran medida en ejemplos de la documentación oficial
            // https://learn.microsoft.com/en-us/azure/storage/files/storage-dotnet-how-to-use-files?tabs=dotnet

            // Instantiate a ShareClient which will be used to create and manipulate the file share
            ShareClient share = new ShareClient(cadenaConexion, nombreShare);

            // Ensure that the share exists
            if (!await share.ExistsAsync())
            {
                // No existe el share, no es posible continuar
                throw new Exception("No existe el share especificado");
            }

            // Existe el share, obtenemos la referencia de la carpeta
            ShareDirectoryClient directory = share.GetDirectoryClient(rutaCarpeta);

            // Ensure that the directory exists
            if (!await directory.ExistsAsync())
            {
                // No existe la carpeta, no es posible continuar
                throw new Exception("No existe la carpeta especificada");
            }

            // Get a reference to a file object
            ShareFileClient file = directory.GetFileClient(nombreArchivo);

            // Ensure that the file exists
            if (!await file.ExistsAsync())
            {
                // No existe el archivo, no es posible continuar
                throw new Exception("No existe el archivo especificado");
            }

            // Download the file
            ShareFileDownloadInfo download = await file.DownloadAsync();

            FileStream stream = File.OpenWrite("mapaTemp.pbf");
            await download.Content.CopyToAsync(stream);
            await stream.FlushAsync();
            stream.SetLength(stream.Position);
            stream.Close();

            // Retornamos el stream del archivo
            return File.OpenRead("mapaTemp.pbf");
        }
    }
}
