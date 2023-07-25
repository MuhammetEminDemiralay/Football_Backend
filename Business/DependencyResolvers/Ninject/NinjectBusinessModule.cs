using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Ninject
{
    public class NinjectBusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICareerStatService>().To<CareerStatManager>().InSingletonScope();
            Bind<ICareerStatDal>().To<EFCareerStatDal>().InSingletonScope();

            Bind<ICityService>().To<CityManager>().InSingletonScope();
            Bind<ICityDal>().To<EFCityDal>().InTransientScope();

            Bind<IClubService>().To<ClubManager>().InSingletonScope();
            Bind<IClubDal>().To<EFClubDal>().InSingletonScope();

            Bind<IContinentService>().To<ContinentManager>().InSingletonScope();
            Bind<IContinentDal>().To<EFContinentDal>().InSingletonScope();

            Bind<ICountryService>().To<CountryManager>().InSingletonScope();
            Bind<ICountryDal>().To<EFCountryDal>().InSingletonScope();

            Bind<IFootballerService>().To<FootballerManager>().InSingletonScope();
            Bind<IFootballerDal>().To<EFFootballerDal>().InSingletonScope();

            Bind<ILeagueService>().To<LeagueManager>().InSingletonScope();
            Bind<ILeagueDal>().To<EFLeagueDal>().InSingletonScope();

            Bind<INationalTeamService>().To<NationalTeamManager>().InSingletonScope();
            Bind<INationalTeamDal>().To<EFNationalTeamDal>().InSingletonScope();

            Bind<IPositionService>().To<PositionManager>().InSingletonScope();
            Bind<IPositionDal>().To<EFPositionDal>().InSingletonScope();

            Bind<ITransferHistoryService>().To<TransferHistoryManager>().InSingletonScope();
            Bind<ITransferHistoryDal>().To<EFTransferHistoryDal>().InSingletonScope();



        }
    }
}
