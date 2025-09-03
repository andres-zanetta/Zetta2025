using Zetta.BD.DATA;
using Microsoft.EntityFrameworkCore;

namespace Zetta.Server.Repositorios
{
    /// <summary>
    /// Clase genérica que implementa el patrón Repositorio para acceder a la base de datos.
    /// Permite realizar operaciones CRUD (Create, Read, Update, Delete) de manera genérica
    /// para cualquier entidad que se pase como tipo genérico T.
    /// </summary>
    public class Repositorio<T> : IRepositorio<T> where T : class,IEntityBase
    {
        /// <summary>
        /// Contexto de base de datos de Entity Framework Core.
        /// Protected para permitir el acceso desde clases heredadas.
        /// </summary>
        protected readonly Context _context;

        /// <summary>
        /// Constructor que recibe el contexto de la base de datos.
        /// </summary>
        public Repositorio(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtiene todos los registros de la entidad T desde la base de datos de forma asíncrona.
        /// Utiliza Entity Framework Core para acceder a la tabla correspondiente a T y trae todos los registros.
        /// </summary>
        public async Task<List<T>> GetAllAsync()
        {
            // Devuelve una lista de todas las entidades del tipo T
            return await _context.Set<T>().ToListAsync();
        }

        /// <summary>
        /// ZZ Busca un registro por su ID.
        /// Devuelve null si no se encuentra.
        /// </summary>
        public async Task<T?> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        /// <summary>
        /// Agrega una nueva entidad a la base de datos y devuelve el ID generado.PP
        /// </summary>
        public async Task<int> AddAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();

            // Obtiene el valor de la propiedad "Id" mediante reflexión
            var property = entity.GetType().GetProperty("Id");
            return property != null ? (int)property.GetValue(entity)! : 0;
        }

        /// <summary>
        /// Actualiza una entidad existente en la base de datos.
        /// </summary>
        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Elimina una entidad de la base de datos a partir de su ID.
        /// </summary>
        public async Task DeleteAsync(int id)
        {
            var z = await GetByIdAsync(id);
            if (z != null)
            {
                // Si la entidad existe, se elimina
                _context.Set<T>().Remove(z);
                await _context.SaveChangesAsync();
            }
            // Si no existe, simplemente no hace nada
        }

        public async Task<List<T>> SelectAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        /// <summary>
        /// Inserta una nueva entidad en la base de datos y devuelve el identificador generado.
        /// Utiliza reflexión para obtener el valor de la propiedad "Id" después de guardar.
        /// </summary>
        /// <param name="entity">Entidad a insertar</param>
        /// <returns>Identificador generado para la entidad</returns>
        public async Task<int> Insert(T entity)
        {
            // Agrega la entidad al contexto para ser insertada
            _context.Set<T>().Add(entity);

            // Guarda los cambios en la base de datos de forma asíncrona
            await _context.SaveChangesAsync();

            // Obtiene el valor de la propiedad "Id" mediante reflexión
            var property = entity.GetType().GetProperty("Id");

            // Si la propiedad existe, devuelve el valor del Id generado; si no, devuelve 0
            return property != null ? (int)property.GetValue(entity)! : 0;
        }
    }
}



