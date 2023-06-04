using Lefrut.Framework;

public class ViewProvider : IProvider
{
    public ViewComponent component;

    public override IData Data => component;
}