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
            builder.RegisterType<FeatureManager>().As<IFeatureService>().SingleInstance();
            builder.RegisterType<EfFeatureDal>().As<IFeatureDal>().SingleInstance();

            builder.RegisterType<AboutManager>().As<IAboutService>().SingleInstance();
            builder.RegisterType<EfAboutDal>().As<IAboutDal>().SingleInstance();

            builder.RegisterType<ServiceManager>().As<IService>().SingleInstance();
            builder.RegisterType<EfServiceDal>().As<IServiceDal>().SingleInstance();

            builder.RegisterType<SkillManager>().As<ISkillService>().SingleInstance();
            builder.RegisterType<EfSkillDal>().As<ISkillDal>().SingleInstance();
        }
    }
}
