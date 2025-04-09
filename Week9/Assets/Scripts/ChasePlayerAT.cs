using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class ChasePlayerAT : ActionTask {

		public Transform playerTransform;
		public BBParameter<Vector3> targetPosition;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			Debug.Log("chasing");
			//EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			Vector3 directionToTarget = playerTransform.position - agent.transform.position;

			Vector3 target = agent.transform.position + directionToTarget.normalized * directionToTarget.magnitude;
			targetPosition.value = target;
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}