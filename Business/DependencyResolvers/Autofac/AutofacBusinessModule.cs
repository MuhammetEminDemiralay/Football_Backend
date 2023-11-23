using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
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
            builder.RegisterType<CareerStatManager>().As<ICareerStatService>().SingleInstance();
            builder.RegisterType<EFCareerStatDal>().As<ICareerStatDal>().SingleInstance();

            builder.RegisterType<CityManager>().As<ICityService>().SingleInstance();
            builder.RegisterType<EFCityDal>().As<ICityDal>().SingleInstance();

            builder.RegisterType<ClubManager>().As<IClubService>().SingleInstance();
            builder.RegisterType<EFClubDal>().As<IClubDal>().SingleInstance();

            builder.RegisterType<ContinentManager>().As<IContinentService>().SingleInstance();
            builder.RegisterType<EFContinentDal>().As<IContinentDal>().SingleInstance();

            builder.RegisterType<CountryManager>().As<ICountryService>().SingleInstance();
            builder.RegisterType<EFCountryDal>().As<ICountryDal>().SingleInstance();

            builder.RegisterType<FootballerManager>().As<IFootballerService>().SingleInstance();
            builder.RegisterType<EFFootballerDal>().As<IFootballerDal>().SingleInstance();

            builder.RegisterType<LeagueManager>().As<ILeagueService>().SingleInstance();
            builder.RegisterType<EFLeagueDal>().As<ILeagueDal>().SingleInstance();

            builder.RegisterType<NationalTeamManager>().As<INationalTeamService>().SingleInstance();
            builder.RegisterType<EFNationalTeamDal>().As<INationalTeamDal>().SingleInstance();

            builder.RegisterType<PositionManager>().As<IPositionService>().SingleInstance();
            builder.RegisterType<EFPositionDal>().As<IPositionDal>().SingleInstance();

            builder.RegisterType<TransferHistoryManager>().As<ITransferHistoryService>().SingleInstance();
            builder.RegisterType<EFTransferHistoryDal>().As<ITransferHistoryDal>().SingleInstance();

            builder.RegisterType<CountryImageManager>().As<ICountryImageService>().SingleInstance();
            builder.RegisterType<EFCountryImageDal>().As<ICountryImageDal>().SingleInstance();

            builder.RegisterType<LeagueImageManager>().As<ILeagueImageService>().SingleInstance();
            builder.RegisterType<EFLeagueImageDal>().As<ILeagueImageDal>().SingleInstance();

            builder.RegisterType<ClubImageManager>().As<IClubImageService>().SingleInstance();
            builder.RegisterType<EFClubImageDal>().As<IClubImageDal>().SingleInstance();

            builder.RegisterType<FootballerImageManager>().As<IFootballerImageService>().SingleInstance();
            builder.RegisterType<EFFootballerImageDal>().As<IFootballerImageDal>().SingleInstance();

            builder.RegisterType<FootManager>().As<IFootService>().SingleInstance();
            builder.RegisterType<EFFootDal>().As<IFootDal>().SingleInstance();

            builder.RegisterType<EFUserDal>().As<IUserDal>().SingleInstance();
            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();

            builder.RegisterType<AuthenticationManager>().As<IAuthenticationService>().SingleInstance();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
