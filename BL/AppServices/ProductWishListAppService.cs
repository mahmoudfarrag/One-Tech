﻿using BL.Bases;
using BL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Models;

namespace BL.AppServices
{
    public class ProductWishListAppService: AppServiceBase
    {

        public List<ProductWishListViewModel> GetAllProductWishList()
        {

            return Mapper.Map<List<ProductWishListViewModel>>(TheUnitOfWork.ProductWishList.GetAllProductWishList());
        }
      



        public bool SaveNewProductWishlist(ProductWishListViewModel productWishListViewModel)
        {
            if (productWishListViewModel == null)
                throw new ArgumentNullException();
            bool result = false;
            var productWishList = Mapper.Map<ProductWishList>(productWishListViewModel);
            if (TheUnitOfWork.ProductWishList.Insert(productWishList))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }
        public bool DeleteProductWishList(int id)
        {
            if (id <= 0)
                throw new InvalidOperationException();
            bool result = false;

            TheUnitOfWork.ProductWishList.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

       
    }
}
