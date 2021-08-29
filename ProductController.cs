using CodiNovaProductApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Model;
using CodiNovaRepo;
using CodiNovaProductApi.Helper;

namespace CodiNovaProductApi.Controllers
{
    //[Authorize]
    [CustomAuthorization]
    [RoutePrefix("api/Product")]
    public class ProductController : ApiController
    {
            
            IBalProductRepository _balProductRepository = null;
            public ProductController()
            {
                this._balProductRepository = new BalProductRepository();
            }           

            #region Product
            [HttpPost]
            [Route("AddProduct")]
            public IHttpActionResult AddProduct(Product product)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                this._balProductRepository.Product(product);

                return Ok();
            }

            [HttpPost]
            [Route("UpdateProduct")]
            public IHttpActionResult UpdateProduct(Product product)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                else if (product.id==0)
                {
                    ModelState.AddModelError("", "Please select Product ID");
                    return BadRequest(ModelState);
                }

                this._balProductRepository.Product(product);
                return Ok();
            }

            [HttpGet]
            [Route("GetProduct")]
            public IEnumerable<Product> GetProduct()
            {
                return this._balProductRepository.GetProduct();
            }

            [HttpGet]
            [Route("GetProductById")]
            public Product GetProductById(string id)
            {
                return this._balProductRepository.GetProductById(id);
            }

            [HttpPost]
            [Route("DeleteProduct")]
            public IHttpActionResult DeleteProduct(Product product)
            {
                if (!this._balProductRepository.DeleteProduct(product))
                {
                    return BadRequest();
                }

                return Ok();
            }


            //[HttpGet]
            //[Route("IsProductExists")]
            //public bool IsProductExists(string id, string custom)
            //{
            //    return this._balProductRepository.IsProductExists(id, custom);
            //}
            #endregion
        }
    }