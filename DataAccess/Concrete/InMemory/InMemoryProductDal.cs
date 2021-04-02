﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;

        public InMemoryProductDal()
        {

            _products = new List<Product> 
            {
                new Product {ProductId = 1, CategoryId = 1, ProductName = "Bardak", UnitPrice = 15, UnitsInStock = 15},
                new Product {ProductId = 2, CategoryId = 1, ProductName = "Kamera", UnitPrice = 500, UnitsInStock = 3},
                new Product {ProductId = 31, CategoryId = 2, ProductName = "Telefon", UnitPrice = 1500, UnitsInStock = 2},
                new Product {ProductId = 4, CategoryId = 2, ProductName = "Klavye", UnitPrice = 150, UnitsInStock = 65},
                new Product {ProductId = 5, CategoryId = 2, ProductName = "Fare", UnitPrice = 85, UnitsInStock = 1}
            };

        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = productToUpdate.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
            
        }

        public void Delete(Product product)
        {
            //Product productToDelete = null;

            //foreach (var p in _products)
            //{
            //    if (p.ProductId == product.ProductId)
            //    {
            //        productToDelete = p;
            //    }

                
            //}

            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            
            _products.Remove(productToDelete);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategoryId(int categoryId)
        {
          return  _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
