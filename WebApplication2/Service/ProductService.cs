using ApiWithWebToken.Domain;
using ApiWithWebToken.Domain.Repository;
using ApiWithWebToken.Domain.Response;
using ApiWithWebToken.Domain.Service;
using ApiWithWebToken.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWithWebToken.Service
{
    public class ProductService : IProductService
    {
        //Repository İle İletişime Geç.
        private readonly IProductRepository _productRepository;

        //UnitOfWork İle İletişime Geç.
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }





        public async Task<ProductResponse> AddProduct(Product product)
        {
            try
            {
                await _productRepository.AddProductAsync(product);
                await _unitOfWork.CompleteAsync(); //vt ye yansıt...
                return new ProductResponse(product);
            }
            catch (Exception ex)
            {
                return new ProductResponse($" Ürün eklenirken bir hata meydana geldi :{ex.Message}");
            }
        }

        public async Task<ProductResponse> FindByIdAsync(int productId)
        {
            try
            {
                var urunVarmi = await _productRepository.FindByIdAsync(productId);
                if (urunVarmi == null)
                {
                    return new ProductResponse("Aranan Ürün Bulunamadı");
                }
                else
                {
                    return new ProductResponse(urunVarmi);
                }
            }
            catch (Exception ex)
            {
                return new ProductResponse($" Ürünü Bulma Sırasında Hata Meydana Geldi : { ex.Message } ");
            }
        }

        public async Task<ProductListResponse> ListAsync()
        {
            try
            {
                IEnumerable<Product> products = await _productRepository.ListAsync();
                return new ProductListResponse(products);
            }
            catch (Exception ex)
            {
                return new ProductListResponse($"Ürünler Listelenirken Bir Hata Meydana Geldi{ex.Message}");
            }
        }

        public async Task<ProductResponse> RemoveProduct(int productId)
        {
            try
            {
                var urunuBul = await _productRepository.FindByIdAsync(productId);
                if (urunuBul == null)
                {
                    return new ProductResponse("Silmeye Çalıştığınız Ürün Bulunamadı");
                }
                else
                {
                    await _productRepository.RemoveProductAsync(productId);
                    await _unitOfWork.CompleteAsync();//vt ye yansıt...
                    return new ProductResponse(urunuBul);
                }
            }
            catch (Exception ex)
            {
                return new ProductResponse($"Ürün Silinmeye Çalışılırken Bir Hata Meydana Geldi: {ex.Message}");
            }
        }

        public async Task<ProductResponse> UpdateProduct(Product product, int productId)
        {
            try
            {
                var urunuBul = await _productRepository.FindByIdAsync(productId);
                if (urunuBul == null)
                {
                    return new ProductResponse("Güncellemeye Çalıştığınız Ürün Yoktur");
                }
                else
                {
                    urunuBul.Name = product.Name; //mapper kullanılacak...
                    urunuBul.Category = product.Category;
                    urunuBul.Price = product.Price;
                    _productRepository.UpdateProduct(urunuBul);
                    await _unitOfWork.CompleteAsync();//vt ye yansıt...
                    return new ProductResponse(urunuBul);
                }
            }
            catch (Exception ex)
            {

                return new ProductResponse($"Ürün Güncelleme Sırasında Hata Meydana Geldi : {ex.Message}");
            }
        }
    }
}
