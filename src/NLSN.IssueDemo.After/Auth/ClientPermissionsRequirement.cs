using Microsoft.AspNetCore.Authorization;

namespace NLSN.IssueDemo.After;

public class ClientPermissionsRequirement : IAuthorizationRequirement
{
	public string ModelName { get; }
	public bool ReadWrite { get; }

	public ClientPermissionsRequirement(string modelName, bool readWrite = false)
	{
		this.ModelName = modelName;
		this.ReadWrite = readWrite;
	}
}
