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
    /// Repository for order detail
    /// </summary>
    public class OrderDetailRepository : GenericRepository<OrderDetail>, IOrderDetailRepository
    {
        #region Fields/Properties

        private OrderDataContext orderDBContext;

        #endregion

        #region Constructor
        public OrderDetailRepository(OrderDataContext context)
            : base(context)
        {
            orderDBContext = context;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Add order detail
        /// </summary>
        /// <param name="OrderDetail"></param>
        /// <returns></returns>
        public async Task AddOrderDetailAsync(OrderDetail orderDetail)
        {
            await this.InsertAsync(orderDetail, true);
        }

        #endregion
    }
}
