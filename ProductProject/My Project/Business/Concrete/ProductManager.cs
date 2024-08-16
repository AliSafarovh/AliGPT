using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Apects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {

        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }


       [ValidationAspect(typeof (ProductValidator))] //Atribut-Add metodunu run etmemisden evvel Atributu ise sal 
       //Meselen: ProductValidator atributu ile dogralama et sonra Add metodunu run et
        public IResult Add(Product product)
        {
            #region Validation Temel kod
            //var context = new ValidationContext<Product>(product); (Product-<T> tipinden,(product- gonderilen entity)
            //dogrulama edecem)
            //ProductValidator productValidator = new ProductValidator();(ProdcutValidatorda yoxlayaraq dogrulama edecem)
            //var result = productValidator.Validate(context);  (context=product)  yeniki gonderilen context
            //validatorda yoxlanilir.
            //if (!result.IsValid) //eger sertler odenmirse
            //{
            //    throw new ValidationException(result.Errors); //error qaytar
            //}

            //Asagida bunu Tool halinda diger proyektler ucunde Generic yapacayiq
            #endregion

            #region Validation manuel kod
             //ValidationTool.Validate(new ProductValidator(), product);
            //(Product tipinde gonderilen productu yoxlamaq ucun,ValidationTooldan Validate metodunu cagir.
            #endregion
          

            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Messages.ProductDeleted);
        }
        public IDataResult <List<Product>> GetAll()
        {
            //if (DateTime.Now.Hour == 15)
            //{
            //    return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            //}
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductListed);
        }

        public IDataResult <List<Product>> GetByCategoryId(int id)
        {
            return new SuccessDataResult <List<Product>>(_productDal.GetAll(p=>p.CategoryId==id),Messages.ProductListed);
        }

        public IDataResult <Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p=>p.ProductId==productId),Messages.ProductListed);
        }

        public IDataResult <List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
           return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.UnitPrice>=min && p.UnitPrice<=max),Messages.ProductListed);
        }

        public IDataResult <List<ProductDetailDto>> GetProductDetails()
        {
           return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails(),Messages.ProductListed);  
        }
    }
}
