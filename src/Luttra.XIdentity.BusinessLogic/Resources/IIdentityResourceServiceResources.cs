using Luttra.XIdentity.BusinessLogic.Helpers;

namespace Luttra.XIdentity.BusinessLogic.Resources
{
    public interface IIdentityResourceServiceResources
    {
        ResourceMessage IdentityResourceDoesNotExist();

        ResourceMessage IdentityResourceExistsKey();

        ResourceMessage IdentityResourceExistsValue();

        ResourceMessage IdentityResourcePropertyDoesNotExist();

        ResourceMessage IdentityResourcePropertyExistsValue();

        ResourceMessage IdentityResourcePropertyExistsKey();
    }
}
