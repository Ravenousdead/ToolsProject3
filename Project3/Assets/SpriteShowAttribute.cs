using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Sprites;

public class SpriteShowAttribute : PropertyAttribute {

	public float spriteSize;

	public SpriteShowAttribute (float size) {

		this.spriteSize = size;

	}

}


[CustomPropertyDrawer (typeof (SpriteShowAttribute))]
public class SpriteShowDrawer : PropertyDrawer {

	SpriteShowAttribute spriteHeight {

		 get { return ((SpriteShowAttribute)attribute); }

	}


	public override float GetPropertyHeight (SerializedProperty property, GUIContent label)
	{

		if (property.propertyType == SerializedPropertyType.ObjectReference) {

			if ((property.objectReferenceValue as Sprite) != null) {

			return EditorGUI.GetPropertyHeight (property, label, true) + spriteHeight.spriteSize;

			}

		}

		return EditorGUI.GetPropertyHeight (property, label, true);

	}


	public override void OnGUI (Rect position, SerializedProperty property, GUIContent label)
	{

		EditorGUI.PropertyField (position, property, label, true);

		if (property.propertyType == SerializedPropertyType.ObjectReference) {

			Sprite spritie = property.objectReferenceValue as Sprite;

			if (spritie != null) {

				position.y += EditorGUI.GetPropertyHeight (property, label, true);
				position.height = spriteHeight.spriteSize;
				GUI.DrawTexture (position, spritie.texture, ScaleMode.ScaleToFit);

			}

		}

	}

}