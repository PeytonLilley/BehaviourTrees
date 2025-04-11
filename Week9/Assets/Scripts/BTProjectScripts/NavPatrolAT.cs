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

        MeshRenderer guardColour;
        public BBParameter<Material> GuardMat;

        protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {

			// set up for colour changing
            guardColour = agent.GetComponent<MeshRenderer>();
            guardColour.material = GuardMat.value;

			// set up for patrol points
            currentPointIndex = 0;
			pointTransforms.Clear();

			int childrenCount = pointsHolder.childCount;
			for (int i = 0; i < childrenCount; i++)
			{
				pointTransforms.Add(pointsHolder.GetChild(i));
			}

			targetPosition.value = pointTransforms[currentPointIndex].position;
			
		}

		protected override void OnUpdate() {
			
			// sets target position based on patrol points
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

		protected override void OnStop() {
			
		}

		protected override void OnPause() {
			
		}
	}
}