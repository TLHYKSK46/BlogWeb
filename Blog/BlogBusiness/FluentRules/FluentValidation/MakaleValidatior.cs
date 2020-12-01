using BlogEntities.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogBusiness.FluentRules.FluentValidation
{
    public class MakaleValidatior : AbstractValidator<Makale>
    {
        public MakaleValidatior()
        {

            /* RuleFor(p => p.CategoryID).NotEmpty().WithMessage("Kategori Boş Geçemez");//bu şekilde kendi mesajlarımızı verebiliyoruz..
             RuleFor(p => p.ProductName).NotEmpty();//boş olamaz
             RuleFor(p => p.UnitPrice).GreaterThan(0);//sıfırdan büyük olmalı
             RuleFor(p => p.QuantityPerUnit).NotEmpty();//boş olamaz
             RuleFor(p => p.ProductName).Length(2, 20);//min :2 max:20 olabilir
             RuleFor(p => p.UnitPrice).GreaterThan(20).When(p => p.CategoryID == 1);//kategori ıd 1 ise minumum degeri 20 olsun
             /*RuleFor(p => p.ProductName).Must(Kural);//Kendi Kurallarımızıda oluşturur
             */
            RuleFor(p => p.KategoriId).NotEmpty().WithMessage("Kategori Boş Geçemez");//bu şekilde kendi mesajlarımızı verebiliyoruz..
            RuleFor(p => p.MakaleBaslik).NotEmpty();//boş olamaz
            //RuleFor(p => p.).GreaterThan(0);//sıfırdan büyük olmalı
            RuleFor(p => p.KullaniciId).NotEmpty();//boş olamaz
        }


    }
}
