using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent (typeof(SpriteRenderer))]
public class SpriteSort : MonoBehaviour
{
	/// <summary>
	/// You can solve the "z-fighting" problem by increasing the value of zOffset.
	/// </summary>
	public static float zOffset = 0.05f;

	[SerializeField]
	float m_FloorHeight = 0f;

	[SerializeField]
	bool m_RuntimeStatic;

	Transform m_Transform;
	SpriteRenderer m_SpriteRenerer;

	bool m_Static;

	void Awake ()
	{
		m_Transform = transform;
		m_SpriteRenerer = GetComponent<SpriteRenderer> ();

		if (Application.isPlaying && m_RuntimeStatic) {
			m_Static = true;
		}
	}

	void LateUpdate ()
	{
		if (!m_Static) {
			// Dynamically modify the z - axis depth of the Sprite.
			m_Transform.position = new Vector3 (m_Transform.position.x, m_Transform.position.y, 
				(m_SpriteRenerer.bounds.min.y + m_FloorHeight) * zOffset);
		}
	}

	void OnBecameVisible ()
	{
		if (!m_Static) {
			enabled = true;
		}
	}

	void OnBecameInvisible ()
	{
		if (!m_Static) {
			enabled = false;
		}
	}

	#if UNITY_EDITOR
	void OnDrawGizmos ()
	{
		if (m_SpriteRenerer == null)
			m_SpriteRenerer = GetComponent<SpriteRenderer> ();
		if (m_Transform == null)
			m_Transform = transform;
		var x = m_Transform.position.x;
		var w = m_SpriteRenerer.bounds.size.x;
		var y = m_SpriteRenerer.bounds.min.y + m_FloorHeight;
		Gizmos.DrawLine (new Vector3 (x - w, y), new Vector3 (x + w, y));
	}
	#endif
}
