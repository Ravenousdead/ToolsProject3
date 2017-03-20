using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class VectorScaleAttribute : PropertyAttribute {

	public float minSlide;
	public float maxSlide;

	public VectorScaleAttribute (float minSlide, float maxSlide) {

		this.minSlide = minSlide;
		this.maxSlide = maxSlide;

	}

}


[CustomPropertyDrawer (typeof (VectorScaleAttribute))]
public class VectorScaleDrawer : PropertyDrawer {

	private float lineHeight = 16;

	VectorScaleAttribute vectorSlide {

		get { return ((VectorScaleAttribute)attribute); }

	}


	public override float GetPropertyHeight (SerializedProperty property, GUIContent label)
	{
		
		return base.GetPropertyHeight (property, label) * 5;

	}


	public override void OnGUI (Rect position, SerializedProperty property, GUIContent label)
	{

		Rect rectDraw = position;
		rectDraw.height = rectDraw.height / 5;

		float vectX = property.vector3Value.x;
		float vectY = property.vector3Value.y;
		float vectZ = property.vector3Value.z;

		float minS = vectorSlide.minSlide;
		float maxS = vectorSlide.maxSlide;

		GUIStyle titleStyle = new GUIStyle ();
		titleStyle.alignment = TextAnchor.MiddleCenter;
		titleStyle.fontStyle = FontStyle.Bold;

		rectDraw.y += lineHeight / 2;
		EditorGUI.LabelField (rectDraw, label, titleStyle);

		rectDraw.y += lineHeight;
		vectX = EditorGUI.Slider (rectDraw, "X:  ", vectX, minS, maxS);
		rectDraw.y += lineHeight;
		vectY = EditorGUI.Slider (rectDraw, "Y:  ", vectY, minS, maxS);
		rectDraw.y += lineHeight;
		vectZ = EditorGUI.Slider (rectDraw, "Z:  ", vectZ, minS, maxS);


		property.vector3Value = new Vector3 (vectX, vectY, vectZ);

	}

}