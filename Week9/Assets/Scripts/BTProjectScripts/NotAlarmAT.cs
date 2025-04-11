using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class NotAlarmAT : ActionTask {

		public BBParameter<bool> alarm;

		MeshRenderer guardColour;
		public BBParameter<Material> GuardMat;

		protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {

			// alarm is no longer happening
			alarm.value = false;

			// change back to normal colour
            guardColour = agent.GetComponent<MeshRenderer>();
            guardColour.material = GuardMat.value;

            EndAction(true);
		}

		protected override void OnUpdate() {
			
		}

		protected override void OnStop() {
			
		}

		protected override void OnPause() {
			
		}
	}
}