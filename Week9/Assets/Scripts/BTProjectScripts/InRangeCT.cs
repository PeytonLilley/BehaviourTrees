using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class InRangeCT : ConditionTask {
     

        private float distanceToPlayer;
        public Transform playerTransform;
        public BBParameter<float> detectionDistance;

        protected override string OnInit()
        {

            return null;
        }

        protected override void OnEnable()
        {

        }

        protected override void OnDisable()
        {

        }

        protected override bool OnCheck()
        {
            // checks if the player is closer to the enemy than the detection distance
            distanceToPlayer = Vector3.Distance(playerTransform.transform.position, agent.transform.position);

            if (distanceToPlayer < detectionDistance.value)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}