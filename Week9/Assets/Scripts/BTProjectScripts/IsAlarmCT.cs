using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class IsAlarmCT : ConditionTask {

		public BBParameter<bool> guard1Alarm;

		public BBParameter<GameObject> Guard1Object;

		protected override string OnInit(){
            
            return null;
		}

		protected override void OnEnable() {
			

			
		}

		protected override void OnDisable() {
			
		}

		protected override bool OnCheck() {
            
			// checks if guard 1 has raised the alarm
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