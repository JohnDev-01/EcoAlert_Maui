using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Threading.Tasks;

namespace FirebaseConnectionDemo
{
    public class FirebaseConnection
    {
        private readonly string firebaseUrl = "https://<tu-base-de-datos>.firebaseio.com/"; // URL de tu base de datos Firebase
        private readonly string firebaseSecret = "<tu-clave-de-api>"; // Tu clave secreta o API Key
        private readonly FirebaseClient firebaseClient;

        public FirebaseConnection()
        {
            // Inicializar el cliente Firebase
            firebaseClient = new FirebaseClient(
                firebaseUrl,
                new FirebaseOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(firebaseSecret)
                });
        }

        /// <summary>
        /// Método para agregar datos a Firebase.
        /// </summary>
        /// <typeparam name="T">Tipo de dato a guardar.</typeparam>
        /// <param name="data">Objeto que se guardará.</param>
        /// <param name="node">Nodo en la base de datos donde se almacenará el dato.</param>
        /// <returns>Una tarea completada.</returns>
        public async Task AddDataAsync<T>(T data, string node)
        {
            await firebaseClient
                .Child(node)
                .PostAsync(data);
        }

        /// <summary>
        /// Método para obtener datos desde Firebase.
        /// </summary>
        /// <typeparam name="T">Tipo de dato esperado.</typeparam>
        /// <param name="node">Nodo en la base de datos desde donde se leerán los datos.</param>
        /// <returns>Una lista de objetos del tipo especificado.</returns>
        public async Task<T> GetDataAsync<T>(string node)
        {
            return await firebaseClient
                .Child(node)
                .OnceSingleAsync<T>();
        }

        /// <summary>
        /// Método para actualizar datos en Firebase.
        /// </summary>
        /// <typeparam name="T">Tipo de dato a actualizar.</typeparam>
        /// <param name="data">Nuevo dato que se actualizará.</param>
        /// <param name="node">Nodo en la base de datos donde se actualizará el dato.</param>
        /// <returns>Una tarea completada.</returns>
        public async Task UpdateDataAsync<T>(T data, string node)
        {
            await firebaseClient
                .Child(node)
                .PutAsync(data);
        }

        /// <summary>
        /// Método para eliminar datos en Firebase.
        /// </summary>
        /// <param name="node">Nodo en la base de datos que se eliminará.</param>
        /// <returns>Una tarea completada.</returns>
        public async Task DeleteDataAsync(string node)
        {
            await firebaseClient
                .Child(node)
                .DeleteAsync();
        }
    }
}
