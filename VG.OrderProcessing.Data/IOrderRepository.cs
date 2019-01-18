using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VG.OrderProcessing.Model;

namespace VG.OrderProcessing.Data
{
    /// <summary>
    /// Interface for order repository
    /// </summary>
    public interface IOrderRepository : IGenericRepository<Order>
    {
        /// <summary>
        /// Get order by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Order> GetOrderById(int id);

        /// <summary>
        /// Get order by confirmation number
        /// </summary>
        /// <param name="ConfirmationNumber">Number sent to customer as a reference</param>
        /// <returns></returns>
        Task<Order> GetOrderByConfirmationNumber(string ConfirmationNumber);

        /// <summary>
        /// Get all the orders
        /// </summary>
        /// <returns></returns>
        Task<IList<Order>> GetAllOrders();

        /// <summary>
        /// Add order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        Task AddOrderAsync(Order order);

        /// <summary>
        /// Update order
        /// </summary>
        /// <param name="Order"></param>
        /// <returns></returns>
        Task UpdateOrder(Order Order);

        /// <summary>
        /// Delete order
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteOrder(int id);
    }
}
