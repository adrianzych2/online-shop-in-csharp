using System;
using System.Linq;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Services;
using Microsoft.AspNetCore.Mvc;

namespace Codecool.CodecoolShop.Controllers
{
    public class OrderController : Controller
    {
        private static Order _order;
        private OrderService OrderService { get; set; }
        private CartService CartService { get; set; }

        public OrderController()
        {
            CartService = new CartService(
                CartDao.GetInstance(),
                ProductDaoMemory.GetInstance(),
                ProductCategoryDaoMemory.GetInstance(),
                SupplierDaoMemory.GetInstance());
            OrderService = new OrderService(OrderDao.GetInstance());
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult OrderDetails(int orderId)
        {
            Order order = OrderService.GetOrder(orderId);
            return View(order);
        }

        [HttpPost]
        public IActionResult MakePayment(CreditCard creditCard)
        {
            if (ModelState.IsValid)
            {
                _order.PaymentStatus = PaymentStatusEnum.Paid;
                OrderService.UpdateOrder(_order);
                OrderService.SaveToJson(_order);
                MailService.SendEmails(_order); //kiepska nazwa, jest to dobra nazwa na klase ale nie na metode. Lepiej nazwać SendEmails? albo coś co jest przymiotnikiem a nie rzeczownikiem.
                return RedirectToAction("OrderDetails", "Order", new {orderId = _order.Id});
            }
            else
            {
                return View();
            }
        }

        public IActionResult MakePayment()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UserDataDetails()
        {
            return View();

        }

        [HttpPost]
        public IActionResult UserDataDetails(UserData userData)
        {
            if (ModelState.IsValid)
            {
                _order = OrderService.MakeNewOrder(userData, CartService.GetCart());
                OrderService.AddOrder(_order);
                OrderService.SaveToJson(_order);
                return RedirectToAction("MakePayment", "Order");
            }
            else
            {
                return View();
            }
        }
    }
}
