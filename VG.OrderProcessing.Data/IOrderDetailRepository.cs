using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VG.OrderProcessing.Model;

namespace VG.OrderProcessing.Data
{
    /// <summary>
    /// Interface for Order detail repositiry
    /// </summary>
    public interface IOrderDetailRepository : IGenericRepository<OrderDetail>
    {
        /// <summary>
        /// Add order detail
        /// </summary>
        /// <param name="OrderDetail"></param>
        /// <returns></returns>
        Task AddOrderDetailAsync(OrderDetail OrderDetail);
    }
}
