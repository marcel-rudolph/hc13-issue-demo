using HotChocolate.Authorization;

namespace NLSN.IssueDemo.Before;

[QueryType]
public static class ColorQueryResolvers
{
	[Authorize(Policy = "ColorReadOnly")]
	public static IEnumerable<Color> GetColors([Service] ColorRepository repository)
		=> repository.GetColors();
}
