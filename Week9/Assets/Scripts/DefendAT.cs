using NodeCanvas.Framework;
using ParadoxNotion.Design;
using TMPro;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class DefendAT : ActionTask {

		public Transform playerTransform;
		public BBParameter<Vector3> targetPosition;
		public float guardRotation;
		public BBParameter<float> strafeDistance;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			//EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {

            Vector3 directionToTarget = playerTransform.position - agent.transform.position;
			Vector3 enemyPosition = new Vector3 (agent.transform.position.x, agent.transform.position.y, agent.transform.position.z);
			Vector3 strafePosition = Vector3.Cross(directionToTarget, enemyPosition).normalized; // * strafeDistance.value;
			
			Vector3 target = strafePosition;
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