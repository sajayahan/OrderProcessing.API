using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VG.OrderProcessing.Model;
using VG.OrderProcessing.BLL;

namespace VG.OrderProcessing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ApiController
    {
        #region Fields/Properties

        private readonly IOrderService _orderService;

        #endregion

        #region Constructor
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        #endregion

        #region API Methods

        /// <summary>
        /// Add order items
        /// System expects to pass Order Detail list along with the order
        /// </summary>
        /// <param name="Order"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("~/api/addorder")]
        public async Task<IActionResult> AddOrderItem([FromBody] Order order)
        {
            try
            {
                await _orderService.AddOrderAsync(order);
                return Success();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get all the orders
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/getallorders")]
        public async Task<IActionResult> GetAllOrders()
        {
            try
            {
                IEnumerable<Order> orderList = await _orderService.GetAllOrders();

                if (orderList.Count() == 0)
                    return NotFound();

                return new JsonResult(orderList, new JsonSerializerSettings { Formatting = Formatting.Indented });
            }
            catch (Exception ex)
            {
                return Fail(ex);
            }
        }

        /// <summary>
        /// Get order by ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/getorderbyid/{Id}")]
        public async Task<IActionResult> GetOrderByID(int Id)
        {
            try
            {
                Order OrderObj = await _orderService.GetOrderByID(Id);

                if (OrderObj == null)
                    return NotFound();

                return new JsonResult(OrderObj, new JsonSerializerSettings { Formatting = Formatting.Indented });
            }
            catch (Exception ex)
            {
                return Fail(ex);
            }
        }

        /// <summary>
        /// Get order by confirmation number
        /// This API call useful to get the order details for customers
        /// </summary>
        /// <param name="ConfirmationNumber"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/getorderbyconfirmationnumber/{confirmationNumber}")]
        public async Task<IActionResult> GetOrderByConfirmationNumber(string confirmationNumber)
        {
            try
            {
                Order orderObj = await _orderService.GetOrderByConfirmationNumber(confirmationNumber);

                if (orderObj == null)
                    return NotFound();

                return new JsonResult(orderObj, new JsonSerializerSettings { Formatting = Formatting.Indented });
            }
            catch (Exception ex)
            {
                return Fail(ex);
            }
        }

        #endregion
    }
}