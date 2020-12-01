using BlogEntities.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogBusiness.FluentRules.FluentValidation
{
    public class KategoriValidatior : AbstractValidator<Kategori>
    {
        public KategoriValidatior()
        {

            RuleFor(p => p.KategoriId).NotEmpty().WithMessage("Kategori Boş Geçemez");//bu şekilde kendi mesajlarımızı verebiliyoruz..
            RuleFor(p => p.KategoriAdi).NotEmpty();//boş olamaz


        }


    }
}
