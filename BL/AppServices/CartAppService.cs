﻿using BL.Bases;
using BL.ViewModels;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppServices
{
    public class CartAppService : AppServiceBase
    {
        #region CURD

        public List<CartViewModel> GetAllCarts()
        {

            return Mapper.Map<List<CartViewModel>>(TheUnitOfWork.Cart.GetAllCart());
        }
        public CartViewModel GetCart(int id)
        {
            if (id < 0)
                throw new ArgumentNullException();
            return Mapper.Map<CartViewModel>(TheUnitOfWork.Cart.GetById(id));
        }



        public bool SaveNewCart(CartViewModel cartViewModel)
        {
            if(cartViewModel == null)
                throw new ArgumentNullException();
            bool result = false;
            var cart = Mapper.Map<Cart>(cartViewModel);
            if (TheUnitOfWork.Cart.Insert(cart))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }



        public bool DeleteCart(int id)
        {
            if (id < 0)
                throw new ArgumentNullException();

            bool result = false;

            TheUnitOfWork.Cart.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        #endregion
    }
}
