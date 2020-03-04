using Luttra.XIdentity.BusinessLogic.Helpers;

namespace Luttra.XIdentity.BusinessLogic.Resources
{
    public interface IApiResourceServiceResources
    {
        ResourceMessage ApiResourceDoesNotExist();
        ResourceMessage ApiResourceExistsValue();
        ResourceMessage ApiResourceExistsKey();
        ResourceMessage ApiScopeDoesNotExist();
        ResourceMessage ApiScopeExistsValue();
        ResourceMessage ApiScopeExistsKey();
        ResourceMessage ApiSecretDoesNotExist();
        ResourceMessage ApiResourcePropertyDoesNotExist();
        ResourceMessage ApiResourcePropertyExistsKey();
        ResourceMessage ApiResourcePropertyExistsValue();
    }
}