using NodeCanvas.Framework;
using ParadoxNotion.Design;
//using System.Numerics;
using UnityEngine.AI;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class NavNavigateAT : ActionTask {

		public BBParameter<bool> hasArrived;


		public float sampleRate;
		public float sampleRadius;
		public BBParameter<Vector3> targetPosition;
		private NavMeshAgent navAgent;
		private Vector3 lastDestination;
		private float timeSinceLastSample;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			navAgent = agent.GetComponent<NavMeshAgent>();
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			timeSinceLastSample += Time.deltaTime;
			if (timeSinceLastSample > sampleRate)
			{
				timeSinceLastSample = 0;
				if (lastDestination != targetPosition.value)
				{
					lastDestination = targetPosition.value;

					NavMesh.SamplePosition(targetPosition.value, out NavMeshHit hitInfo, sampleRadius, NavMesh.AllAreas);
					navAgent.SetDestination(hitInfo.position);
				}
			}

			bool pathPending = navAgent.pathPending;
			bool haveArrived = navAgent.remainingDistance <= navAgent.stoppingDistance;
			bool currentlySampling = timeSinceLastSample == 0f;

			hasArrived.value = !pathPending && haveArrived && currentlySampling;
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}