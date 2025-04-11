using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class ChasePlayerAT : ActionTask {

		public Transform playerTransform;
		public BBParameter<Vector3> targetPosition;

		private AudioSource audioSource;
		MeshRenderer guardColour;
		public BBParameter<Material> GuardChaseMat;

		protected override string OnInit() {
			audioSource = agent.GetComponent<AudioSource>();
			Renderer renderer = agent.GetComponent<Renderer>();
			
			return null;
		}

		protected override void OnExecute() {

			// play audio and change colour
			audioSource.Play();
			guardColour = agent.GetComponent<MeshRenderer>();
			guardColour.material = GuardChaseMat.value;
		}

		protected override void OnUpdate() {

			// set new destination to follow the player
			Vector3 directionToTarget = playerTransform.position - agent.transform.position;

			Vector3 target = agent.transform.position + directionToTarget.normalized * directionToTarget.magnitude;
			targetPosition.value = target;
		}

		protected override void OnStop() {
			
		}

		protected override void OnPause() {
			
		}
	}
}