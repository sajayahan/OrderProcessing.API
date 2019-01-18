using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VG.OrderProcessing.Data;
using VG.OrderProcessing.Model;
using VG.OrderProcessing.Common;

namespace VG.OrderProcessing.BLL
{
    /// <summary>
    /// Business logic for order
    /// </summary>
    public class OrderService : IOrderService
    {
        #region Fields/Properties

        private IOrderRepository _orderRepository;
        private IOrderDetailRepository _orderDetailRepository;
        private readonly OrderHelper _orderHelper;

        #endregion

        #region Constructor

        public OrderService(IOrderRepository orderRepository,IOrderDetailRepository orderDetailRepository)
        {
            if (orderRepository != null)
                _orderRepository = orderRepository;

            if (orderDetailRepository != null)
                _orderDetailRepository = orderDetailRepository;

            _orderHelper = new OrderHelper();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get all the orders
        /// </summary>
        /// <returns></returns>
        public async Task<IList<Order>> GetAllOrders()
        {
            return await _orderRepository.GetAllOrders();
        }

        /// <summary>
        /// Get order by ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public async Task<Order> GetOrderByID(int id)
        {
            return await _orderRepository.GetOrderById(id);
        }

        /// <summary>
        /// Get order by conformation number
        /// </summary>
        /// <param name="ConfirmationNumber"></param>
        /// <returns></returns>
        public async Task<Order> GetOrderByConfirmationNumber(string confirmationNumber)
        {
            return await _orderRepository.GetOrderByConfirmationNumber(confirmationNumber);
        }

        /// <summary>
        /// Add order and order details
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public async Task AddOrderAsync(Order order)
        {
            //Insert order first
            Order newOrder = new Order
            {
                OrderConformationNumber = _orderHelper.GenerateOrderConformationNumber(),
                OrderedDate = DateTime.Now,
                OrderStatusId = (int)OrderStausEnum.ACTIVE,
                CustomerId = order.CustomerId
            };

            await _orderRepository.AddOrderAsync(newOrder);

            //Get newly insterted orderID
            int id = newOrder.ID;

            //Insert all the order details
            foreach (var orderDetail in order.OrderDetails)
            {
                OrderDetail newOrderDetail = new OrderDetail
                {
                    Quantity = orderDetail.Quantity,
                    OrderId = id,
                    ItemId = orderDetail.ItemId,
                    VendorId = orderDetail.VendorId,
                    OrderDetailStatusId = (int)OrderDetailStausEnum.ACTIVE
                };

                await _orderDetailRepository.AddOrderDetailAsync(newOrderDetail);
            }

        }

        #endregion
    }
}
