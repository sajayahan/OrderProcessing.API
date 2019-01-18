using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VG.OrderProcessing.Data;
using VG.OrderProcessing.Model;
using VG.OrderProcessing.BLL;

namespace VG.OrderProcessing.BLL
{
    /// <summary>
    /// Interface for order service
    /// </summary>
    public interface IOrderService
    {
        /// <summary>
        /// Get all the orders
        /// </summary>
        /// <returns></returns>
        Task<IList<Order>> GetAllOrders();

        /// <summary>
        /// Get order by ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        Task<Order> GetOrderByID(int id);

        /// <summary>
        /// Get order by confirmation number
        /// </summary>
        /// <param name="ConfirmationNumber"></param>
        /// <returns></returns>
        Task<Order> GetOrderByConfirmationNumber(string confirmationNumber);

        /// <summary>
        /// Add order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        Task AddOrderAsync(Order order);
    }
}
