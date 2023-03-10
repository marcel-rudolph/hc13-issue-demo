using HotChocolate.Authorization;
using NLSN.IssueDemo.Shared;

namespace NLSN.IssueDemo.After;

[QueryType]
public static class ColorQueryResolvers
{
	[Authorize(Policy = "ColorReadOnly")]
	public static IEnumerable<Color> GetColors([Service] ColorRepository repository)
		=> repository.GetColors();
}
