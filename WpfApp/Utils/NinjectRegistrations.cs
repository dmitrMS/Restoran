using BLL.Services;
using Interfaces.Services;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Utils
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IOrderService>().To<OrderService>();
            Bind<IReportService>().To<ReportService>();
            Bind<IdishService>().To<dishService>();
            Bind<IdeliveryService>().To<deliveryService>();
            Bind<IDishStringService>().To<DishStringService>();
            Bind<IstolService>().To<stolService>();
            Bind<IingrdientService>().To<IngredientService>();
            Bind<IingredientStringService>().To<IngredientStringService>();
            //ingredientStringService = kernel.Get<IingredientStringService>();
            //IingrdientService ingredientService;
        }
    }
}
