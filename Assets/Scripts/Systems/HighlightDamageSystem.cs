using UnityEngine;
using DG.Tweening;
using Lefrut.Framework;

public class HighlightDamageSystem : BaseSystem, IEnableSystem, IDisableSystem
{
    private bool isHighlightNow = false;


    public override void AddProviders()
    {
        NeededProviders.Set(new HealthProvider(), this);
        NeededProviders.Set(new ViewSpriteProvider(), this);
    }

    public void Enable()
    {
        var healthComponent = Providers.Get<HealthProvider>().component;

        healthComponent.TakedDamage += Highlight;
    }

    public void Disable()
    {
        var healthComponent = Providers.Get<HealthProvider>().component;

        healthComponent.TakedDamage -= Highlight;
    }

    private void Highlight()
    {
        var sprite = Providers.Get<ViewSpriteProvider>().component.spriteRenderer;

        Color defaultColor = sprite.color;

        if (isHighlightNow == false)
        {
            isHighlightNow = true;
            Bleach(sprite, defaultColor);
        }
    }

    private void Bleach(SpriteRenderer sprite, Color defaultColor)
    {
        Color white = new Color(1, 1, 1, 0.2f);

        sprite.DOColor(white, 0.01f).OnComplete(() => ReturnBack(sprite, defaultColor));
    }

    private void ReturnBack(SpriteRenderer sprite, Color defaultColor)
    {
        sprite.DOColor(defaultColor, 0.05f).OnComplete(() =>
        {
            isHighlightNow = false;
        });
    }
}