using Lefrut.Framework;
using UnityEngine;

public class AnimatorDeathProvider : MonoProvider
{
	[SerializeField] private AnimatorDeathData animatorDeathData;
	public override IData Data => animatorDeathData;
}
