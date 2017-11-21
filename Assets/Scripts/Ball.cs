using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	private Paddle paddle;
	private bool hasStarted;
	private Vector3 paddleToBallVector;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
		hasStarted = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (!hasStarted) {
			LockBallRelativeToPaddle();
			WaitForMousePressToLaunch();
		}
	}

	void LockBallRelativeToPaddle() {
		this.transform.position = paddle.transform.position + paddleToBallVector;
	}

	void WaitForMousePressToLaunch() {
		if (Input.GetMouseButtonDown (0)) {
			hasStarted = true;
			this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (2f, 10f);
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (hasStarted) {
			if (other.gameObject.tag != "Breakable") {
				AudioSource audioSource = GetComponent<AudioSource> ();
				audioSource.Play ();
				BounceBall (other);
			}
		}
	}

	void BounceBall(Collision2D other)
	{
//		if (other.gameObject.tag == "Paddle") {
//			paddleToBallVector = this.transform.position - other.transform.position;
//			GetComponent<Rigidbody2D> ().velocity = new Vector2 (paddleToBallVector.x * 15.0f, 
//																 GetComponent<Rigidbody2D> ().velocity.y);
//		} else {
			Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
			GetComponent<Rigidbody2D> ().velocity += tweak;
//		}
	}
}
