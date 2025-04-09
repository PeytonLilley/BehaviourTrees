using NodeCanvas.Framework;
using NodeCanvas.Tasks.Actions;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class PlayerInRange : ConditionTask {

		private float distanceToPlayer;
		public Transform playerTransform;
		public BBParameter<float> detectionDistance;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit(){
			
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
			
			distanceToPlayer = Vector3.Distance(playerTransform.transform.position, agent.transform.position);
			Debug.Log(distanceToPlayer);

			if (distanceToPlayer < detectionDistance.value)
			{
				Debug.Log("detected");
				return true;
            }
			else
			{
				return false;
			}

		}
	}
}