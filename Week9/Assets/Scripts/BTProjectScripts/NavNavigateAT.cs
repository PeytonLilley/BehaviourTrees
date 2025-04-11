using NodeCanvas.Framework;
using ParadoxNotion.Design;
//using System.Numerics;
using UnityEngine.AI;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class NavNavigateAT : ActionTask {

		public BBParameter<bool> hasArrived;


		public BBParameter <float> sampleRate;
		public BBParameter <float> sampleRadius;
		public BBParameter<Vector3> targetPosition;
		private NavMeshAgent navAgent;
		private Vector3 lastDestination;
		private float timeSinceLastSample;

		protected override string OnInit() {
			navAgent = agent.GetComponent<NavMeshAgent>();
			return null;
		}

		protected override void OnExecute() {
			
		}

		protected override void OnUpdate() {
			
			// sampling for navigation based on navigation taught in class
			timeSinceLastSample += Time.deltaTime;
			if (timeSinceLastSample > sampleRate.value)
			{
				timeSinceLastSample = 0;
				if (lastDestination != targetPosition.value)
				{
					lastDestination = targetPosition.value;

					NavMesh.SamplePosition(targetPosition.value, out NavMeshHit hitInfo, sampleRadius.value, NavMesh.AllAreas);
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