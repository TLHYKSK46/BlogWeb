using System;
using System.Collections.Generic;
using System.Text;

namespace BlogEntities.ComplexType
{
    //Burası indexde yaptıgın sorguları yapcağın yer 
    //burada gidip IMakaleDal.cs ye  "List<ProductDetail> GetProductDetails();" bunu ekle
    public class MakaleDetay
    {
        //buryada bu tarzda bi sorgu yazmalısın

        /*           public List<ProductDetail> GetProductDetails()
           {
               using (NortwindContext context=new NortwindContext()) {

                   var result = from p in context.Products
                                join c in context.Categories on p.CategoryId equals c.CategoryID
                                select new ProductDetail
                                {
                                    ProductId = p.ProductId,
                                    ProductName = p.ProductName,
                                    CategoryName = c.CategoryName
                                };
                   return result.ToList();
               }
           }*/

    }
}
