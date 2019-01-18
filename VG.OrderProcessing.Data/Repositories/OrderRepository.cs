using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using VG.OrderProcessing.Model;

namespace VG.OrderProcessing.Data
{
    /// <summary>
    /// Repository for order
    /// </summary>
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        #region Fields/Properties

        private OrderDataContext orderDBContext;

        #endregion

        #region Constructor
        public OrderRepository(OrderDataContext context)
            : base(context)
        {
            orderDBContext = context;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get order by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Order> GetOrderById(int id)
        {
            var result = await orderDBContext.Orders                 
                 .Where(i => i.ID == id)
                 .ToListAsync();

            return result.FirstOrDefault();
        }

        /// <summary>
        /// Get order by confirmation number
        /// </summary>
        /// <param name="ConfirmationNumber"></param>
        /// <returns></returns>
        public async Task<Order> GetOrderByConfirmationNumber(string confirmationNumber)
        {
            var result = await orderDBContext
                            .Orders.Where(i => i.OrderConformationNumber == confirmationNumber)
                            .ToListAsync();

            return result.FirstOrDefault();
        }

        /// <summary>
        /// Get all the orders
        /// </summary>
        /// <returns></returns>
        public async Task<IList<Order>> GetAllOrders()
        {
            IQueryable<Order> query = orderDBContext.Orders;
            return await query.ToListAsync();
        }

        /// <summary>
        /// Add order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public async Task AddOrderAsync(Order order)
        {
            await this.InsertAsync(order, true);
        }

        /// <summary>
        /// To be implemented
        /// </summary>
        /// <param name="Order"></param>
        /// <returns></returns>
        public Task UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// To be implemented
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task DeleteOrder(int id)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
