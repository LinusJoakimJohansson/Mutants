using UnityEngine;
using System.Collections;
using Battle;

[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(SpriteRenderer))]

public class BaseCharacter : MonoBehaviour
{
	public SpriteRenderer _spriteRenderer;
	public Sprite Portrait;
	public float _movementSpeed = 0.5f;

	public Body Body = new Body()
	{
		Head = new HumanHead(),
		LeftArm = new HumanArm(),
		RightArm = new HumanArm(),
		Legs = new HumanLegs()
	};

	public BodyPart selectedBodyPart;

	public void UseAction()
	{
		if (selectedBodyPart != null && selectedBodyPart.Action != null)
			selectedBodyPart.Action.Use(this);
	}
}
