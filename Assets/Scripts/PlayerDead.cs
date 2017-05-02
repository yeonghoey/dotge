using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : StateMachineBehaviour {
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		// Stop Scoring
		GameObject scorer = GameObject.FindWithTag ("Scorer");
		if (scorer != null) {
			scorer.SetActive (false);
		}
	}

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		animator.gameObject.SetActive (false);
	}
}
