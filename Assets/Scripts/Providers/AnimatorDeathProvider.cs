using Lefrut.Framework;
using UnityEngine;

public class AnimatorDeathProvider : IProvider
{
	[SerializeField] private AnimatorDeathData animatorDeathData;
	public override IData Data => animatorDeathData;
}
