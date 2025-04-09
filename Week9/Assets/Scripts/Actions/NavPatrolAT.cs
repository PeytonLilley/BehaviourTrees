using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;


namespace NodeCanvas.Tasks.Actions {

	public class NavPatrolAT : ActionTask {

		public Transform pointsHolder;
		public BBParameter<Vector3> targetPosition;
		public BBParameter<bool> hasArrived;

		private List<Transform> pointTransforms = new List<Transform>();
		private int currentPointIndex = 0;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			
			currentPointIndex = 0;
			pointTransforms.Clear();

			int childrenCount = pointsHolder.childCount;
			for (int i = 0; i < childrenCount; i++)
			{
				pointTransforms.Add(pointsHolder.GetChild(i));
			}

			targetPosition.value = pointTransforms[currentPointIndex].position;
			
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
			if(hasArrived.value)
			{
                currentPointIndex++;

				if(currentPointIndex >= pointTransforms.Count)
				{
					currentPointIndex = 0;
				}

                targetPosition.value = pointTransforms[currentPointIndex].position;

            }
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}