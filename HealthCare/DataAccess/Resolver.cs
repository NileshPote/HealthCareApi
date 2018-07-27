using DataAccess.UnitOfWork;
using GenericResolver;
using System.ComponentModel.Composition;

namespace DataAccess
{
    [Export(typeof(IComponent))]
    public class Resolver : IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            registerComponent.RegisterType<IUnitOfWork, UnitOfWork.UnitOfWork>();
        }
    }
}
