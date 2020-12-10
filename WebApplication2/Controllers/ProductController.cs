using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiWithWebToken.Domain;
using ApiWithWebToken.Domain.Response;
using ApiWithWebToken.Domain.Service;
using ApiWithWebToken.DTO;
using ApiWithWebToken.Extension;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiWithWebToken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // 1) Ne ile haberleşir.
        //Dışardaki Servise ile haberleşecek.
        //fakat içerdeki Service Klasöründeki IProductService'İ çağıracağız bunu startupta bunu gördüğün zaman bunu çağırmış ol diyeceğiz.
        // 2) Mapping te çağrılır.

        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }



        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            ProductListResponse productListResponse = await _productService.ListAsync();
            if (productListResponse.Success)
            {
                return Ok(productListResponse.productList);
            }
            else
            {
                return BadRequest(productListResponse.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int productId)
        {
            ProductResponse productResponse = await _productService.FindByIdAsync(productId);
            if (productResponse.Success)
            {
                return Ok(productResponse.Product);
            }
            else
            {
                return BadRequest(productResponse.Message);
            }
        }


        //DTO Kullanılacak

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
            {
                Product product = _mapper.Map<ProductDto, Product>(productDto);
                var response = await _productService.AddProduct(product);
                if (response.Success)
                {
                    return Ok(response.Product);
                }
                else
                {
                    return BadRequest(response.Message);
                }
            }
        }


        [HttpPut]
        public async Task<IActionResult> Update(ProductDto productDto,int productId)
        {
            if (ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
            {
                Product product = _mapper.Map<ProductDto, Product>(productDto);
                var response =  await _productService.UpdateProduct(product, productId);
                if (response.Success)
                {
                    return Ok(response.Product);
                }
                else
                {
                    return BadRequest(response.Message);
                }
            }
        }


        [HttpDelete("{id :int}")]
        public async Task<IActionResult> Delete(int productId)
        {
            ProductResponse response = await _productService.RemoveProduct(productId);
            if(response.Success)
            {
                return Ok(response.Product);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }
    }
}
