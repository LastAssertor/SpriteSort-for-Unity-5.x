﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor (typeof(SpriteSort))]
public class SpriteSortInspector : Editor
{
	public override void OnInspectorGUI ()
	{
		SpriteRenderer renderer = (target as SpriteSort).GetComponent<SpriteRenderer> ();
		var property = serializedObject.FindProperty ("m_FloorHeight");
		property.floatValue = EditorGUILayout.Slider ("Floor Height", property.floatValue, 0, renderer.bounds.size.y);
		property = serializedObject.FindProperty ("m_RuntimeStatic");
		property.boolValue = EditorGUILayout.Toggle (new GUIContent("Runtime Static", 
			"If ture, Not mdify the z - axis depth of the Sprite at runtime."), property.boolValue);
		serializedObject.ApplyModifiedProperties ();
	}

}
