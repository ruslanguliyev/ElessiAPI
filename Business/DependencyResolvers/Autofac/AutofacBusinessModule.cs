using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>();
            builder.RegisterType<ProductDal>().As<IProductDal>();
            builder.RegisterType<BlogManager>().As<IBlogService>();
            builder.RegisterType<BlogDal>().As<IBlogDal>();
            builder.RegisterType<SliderDal>().As<ISliderDal>();
            builder.RegisterType<SliderManager>().As<ISliderService>();

        }
    }
}
