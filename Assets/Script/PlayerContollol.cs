using UnityEngine;
using System.Collections;

public class PlayerContollol : MonoBehaviour {
	float Count;
	Animator animator;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 temp;
		if (Count == 0) {
			if (Input.GetKey (KeyCode.UpArrow)) {
				float m_pos_z = Input.GetAxis ("Vertical") * 0.3f;
				transform.Translate (0, 0, m_pos_z);
				if (Input.GetKeyUp (KeyCode.UpArrow))
					Count++;
			}
		}
		if (Count == 1) {
			if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.RightArrow)) {
				float m_pos_x = Input.GetAxis ("Horizontal") * 0.3f;
				transform.Translate (m_pos_x, 0, 0);
				if (Input.GetKeyUp (KeyCode.LeftArrow))
					Count++;
				else if (Input.GetKeyUp (KeyCode.RightArrow))
					Count++;
			}
		}
		temp = transform.position;
		temp.x = Mathf.Clamp(transform.position.x,-20.0f,20f);
		temp.y = Mathf.Clamp(transform.position.y,2.5f,20.0f);
		temp.z = Mathf.Clamp(transform.position.z,-20.0f,20f);
		transform.position = temp;
	}

	void OnCollisionEnter(){
		animator.Play ("PlayerAnimation");
	}

}
