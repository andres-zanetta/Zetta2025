using Microsoft.AspNetCore.Components.Forms;
using Microsoft.VisualBasic;
using System.Runtime.ConstrainedExecution;
using Zetta.BD.DATA.ENTITY;

namespace Zetta.Server.Repositorios
{
    public interface IPresupuestoRepositorio : IRepositorio<Presupuesto>

    {
        Task<IEnumerable<Presupuesto>> GetPresupuestosConDetallesAsync();

        Task<Presupuesto?> GetPresupuestoConDetallesPorIdAsync(int id);

        Task<IEnumerable<Presupuesto>> GetPresupuestosPorClienteIdAsync(int clienteId);

        Task<IEnumerable<Presupuesto>> GetPresupuestosPorEstadoAsync(string estado);

        Task<bool> PresupuestoExisteAsync(int id);

        Task<List<Presupuesto>> SelectAllAsync();

        Task<Presupuesto?> SelectById(int id);



        #region Comentarios
        //        Explicación de los métodos en IPresupuestoRepositorio
        //•	GetPresupuestosConDetallesAsync
        //Recupera todos los presupuestos junto con sus detalles(ítems asociados). Es útil para mostrar información completa en listados o reportes.
        //•	GetPresupuestoConDetallesPorIdAsync(int id)
        //Obtiene un presupuesto específico por su ID, incluyendo sus detalles.Se usa cuando necesitas ver o editar un presupuesto concreto con toda su información.
        //•	GetPresupuestosPorClienteIdAsync(int clienteId)
        //Devuelve todos los presupuestos asociados a un cliente.Permite filtrar presupuestos por cliente, útil para consultas personalizadas.
        //•	GetPresupuestosPorEstadoAsync(string estado)
        //Filtra presupuestos según su estado (ejemplo: "Pendiente", "Aceptado"). Facilita la gestión y seguimiento de presupuestos según su progreso.
        //•	PresupuestoExisteAsync(int id)
        //Verifica si existe un presupuesto con el ID dado. Es útil para validaciones antes de realizar operaciones como actualizaciones o eliminaciones.
        //•	SelectAllAsync
        //Recupera todos los presupuestos sin detalles adicionales. Es una consulta básica para obtener la lista general.
        //•	SelectById(int id)
        //Obtiene un presupuesto por su ID, sin incluir detalles.Se usa para operaciones simples donde no se requieren los ítems asociados.

        #endregion

    }
}