using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectExample : MonoBehaviour {

	public int myIntField;
	[ColorLine (0.0f, 1f, 1f)]
	public float myFloatField;

	[SpriteShow (128.0f)]
	public Sprite mySprite;

	[VectorScale (0.5f, 10.0f)]
	public Vector3 myVector;

}
