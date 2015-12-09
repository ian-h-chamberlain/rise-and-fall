using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class TrebleCharacter : ThirdPersonCharacter {

	void UpdateAnimator(Vector3 move) {

		// update the animator parameters
		m_Animator.SetFloat("Forward", m_ForwardAmount, 0.1f, Time.deltaTime);
		m_Animator.SetBool("OnGround", m_IsGrounded);

		// the anim speed multiplier allows the overall speed of walking/running to be tweaked in the inspector,
		// which affects the movement speed because of the root motion.
		if (m_IsGrounded && move.magnitude > 0)
		{
			m_Animator.speed = m_AnimSpeedMultiplier;
		}
		else
		{
			// don't use that while airborne
			m_Animator.speed = 1;
		}
	}

	public void AnimateFire() {
		m_Animator.SetTrigger("Fire");
	}

	void OnAnimatorMove() {

		Vector3 v = Vector3.Normalize(transform.forward) * m_ForwardAmount * m_MoveSpeedMultiplier / Time.deltaTime;

		v.y = m_Rigidbody.velocity.y;

		m_Rigidbody.velocity = v;

	}

	void HandleGroundedMovement(bool crouch, bool jump)
	{
		Debug.Log ("Jump is " + jump.ToString());
		// check whether conditions are right to allow a jump:
		if (jump)
		{
			Debug.Log ("jump!");
			// jump!
			m_Rigidbody.velocity = new Vector3(m_Rigidbody.velocity.x, m_JumpPower, m_Rigidbody.velocity.z);
			m_IsGrounded = false;
			m_GroundCheckDistance = 0.1f;
		}
	}
}
