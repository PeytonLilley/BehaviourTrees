using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class IsAlarmCT : ConditionTask {

		public BBParameter<bool> guard1Alarm;

		public BBParameter<GameObject> Guard1Object;

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

            Blackboard Guard1Blackboard = Guard1Object.value.GetComponent<Blackboard>();
            
			guard1Alarm.value = Guard1Blackboard.GetVariableValue<bool>("alarm");
            
			if (guard1Alarm.value == true)
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