using Lefrut.Framework;

public class ViewProvider : MonoProvider
{
    public ViewComponent component;

    public override IData Data => component;
}