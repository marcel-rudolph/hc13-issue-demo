namespace NLSN.IssueDemo.Shared;

public sealed class ColorRepository
{
	private readonly List<Color> items = new()
	{
		new("red", "#FF0000"),
		new("green", "#00FF00"),
		new("blue", "#0000FF"),
	};

	public IEnumerable<Color> GetColors() => this.items;
}
