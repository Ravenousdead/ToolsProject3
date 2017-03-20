using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ColorLineAttribute : PropertyAttribute {

	public Color lineColor;

	public ColorLineAttribute (float r, float g, float b, float a = 1f) {
		this.lineColor = new Color (r, g, b, a);
	}

}


[CustomPropertyDrawer (typeof (ColorLineAttribute))]
public class ColorLineDrawer : DecoratorDrawer {

	ColorLineAttribute colorLine {

		get { return ((ColorLineAttribute)attribute); }

	}


	public override float GetHeight ()
	{
		return base.GetHeight ()/4;
	}

	public override void OnGUI (Rect position)
	{
		float startX = position.x;
		float startY = position.y;

		Color oldGuiColor = GUI.color;
		GUI.color = colorLine.lineColor;
		EditorGUI.DrawPreviewTexture (new Rect (startX, startY, EditorGUIUtility.currentViewWidth - 20, 1), Texture2D.whiteTexture);
		GUI.color = oldGuiColor;
	}

}
