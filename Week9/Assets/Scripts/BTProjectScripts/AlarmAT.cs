using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class AlarmAT : ActionTask {

		public BBParameter<bool> alarm;

        public BBParameter<GameObject> Guard2Object;

        MeshRenderer guardColour;
        public BBParameter<Material> GuardChaseMat;

        protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {

			// set up materials for colour changing
            guardColour = agent.GetComponent<MeshRenderer>();
            guardColour.material = GuardChaseMat.value;

			// interaction with other enemy - send value of alarm to guard 2
            Blackboard Guard2Blackboard = Guard2Object.value.GetComponent<Blackboard>();
			Guard2Blackboard.SetVariableValue("guard1Alarm", true);
            alarm = true;
			
			EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}