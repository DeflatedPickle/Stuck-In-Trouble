﻿using UnityEngine;

/*
 * Credit: Unity
 * Link: https://unity3d.com/learn/tutorials/topics/2d-game-creation/creating-basic-platformer-game
 */
public class Move : MonoBehaviour {
	public float MoveForce = 25f;
	public float MaxSpeed = 5f;

	private Rigidbody2D _rigidbody2D;
	private Jump _jump;

	private void Awake() {
		_rigidbody2D = GetComponent<Rigidbody2D>();
		_jump = GetComponent<Jump>();
	}

	private void Update () {
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) {
			var horizontal = Input.GetAxis("Horizontal");

			// IsGrounded bug needs to be fixed first.
			/* if (!_jump.IsGrounded) {
				MaxSpeed /= 2;
			} */

			if (horizontal * _rigidbody2D.velocity.x < MaxSpeed) {
				_rigidbody2D.AddForce(Vector2.right * horizontal * MoveForce);
			}

			if (Mathf.Abs(_rigidbody2D.velocity.x) > MaxSpeed) {
				_rigidbody2D.velocity = new Vector2(Mathf.Sign(_rigidbody2D.velocity.x) * MaxSpeed, _rigidbody2D.velocity.y);
			}
		}
	}
}