using GenericResolver;
using System.ComponentModel.Composition;

namespace BusinessLogic
{
    [Export(typeof(IComponent))]
    public class Resolver : IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            registerComponent.RegisterType<IContactServices,ContactService>();
        }
    }
}
