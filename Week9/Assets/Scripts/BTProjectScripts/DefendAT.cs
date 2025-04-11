using NodeCanvas.Framework;
using ParadoxNotion.Design;
using TMPro;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class DefendAT : ActionTask {

		public Transform playerTransform;
		public BBParameter<Vector3> targetPosition;
		public BBParameter<float> strafeDistance;

		protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {

		}

		protected override void OnUpdate() {

			// sets destination for strafe movement - for some reason the guard will move to the center of the navmesh and only strafe around the character if they are
			// also near the center of the navmesh. I'm not sure why this is happening since I can't identify any reason in the code I wrote that it would go to the middle,
			// but apart from that the guard does move in reaction to the player's position. I think it could be related to Vector3.Cross, which I tried using for the first 
			// time, but I'm not sure.

            Vector3 directionToTarget = playerTransform.position - agent.transform.position;
			Vector3 enemyPosition = new Vector3 (agent.transform.position.x, agent.transform.position.y, agent.transform.position.z);
			Vector3 strafePosition = Vector3.Cross(directionToTarget, enemyPosition).normalized;  // get a perpendicular vector to move to
			
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