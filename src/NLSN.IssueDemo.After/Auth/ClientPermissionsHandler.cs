using HotChocolate.Resolvers;
using Microsoft.AspNetCore.Authorization;

namespace NLSN.IssueDemo.After;

public class ClientPermissionsHandler
	: AuthorizationHandler<ClientPermissionsRequirement, IResolverContext>
{
	protected override Task HandleRequirementAsync(
		AuthorizationHandlerContext context,
		ClientPermissionsRequirement requirement,
		IResolverContext resolverContext)
	{
		context.Succeed(requirement);
		return Task.CompletedTask;
	}
}
