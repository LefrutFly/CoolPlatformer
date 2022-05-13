using UnityEngine;
using DG.Tweening;

public class HighlightDamageSystem : BaseSystem, IEnableSystem, IDisableSystem
{
    public void Enable()
    {
        if (Providers.Has<HealthProvider>() == false) return;

        var healthComponent = Providers.Get<HealthProvider>().component;

        healthComponent.TakedDamage += Highlight;
    }

    public void Disable()
    {
        if (Providers.Has<HealthProvider>() == false) return;

        var healthComponent = Providers.Get<HealthProvider>().component;

        healthComponent.TakedDamage -= Highlight;
    }

    private void Highlight()
    {
        if (Providers.Has<ViewSpriteProvider>() == false)
            return;

        var sprite = Providers.Get<ViewSpriteProvider>().component.spriteRenderer;

        Color defaultColor = sprite.color;

        Bleach(sprite, defaultColor);
    }

    private void Bleach(SpriteRenderer sprite, Color defaultColor)
    {
        Color white = new Color(1, 1, 1, 0.2f);

        sprite.DOColor(white, 0.01f).OnComplete(() => ReturnBack(sprite, defaultColor));
    }

    private void ReturnBack(SpriteRenderer sprite, Color defaultColor)
    {
        sprite.DOColor(defaultColor, 0.05f);
    }
}