// (c) Copyright HutongGames, LLC 2010-2017. All rights reserved.
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;
using UnityEngine.Playables;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Timeline")]
	[Tooltip("Get the timeline's current time. This value is incremented according to the time update mode.")]

	public class  getTimelineCurrentTime : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(PlayableDirector))]
		[Tooltip("The game object to hold the unity timeline components.")]
		public FsmOwnerDefault gameObject;
		
		[Tooltip("Returns the current time of the timeline")]
		[UIHint(UIHint.Variable)]
		public FsmFloat currentTime;

		[Tooltip("Check this box to preform this action every frame.")]
		public FsmBool everyFrame;

		private PlayableDirector timeline;

		public override void Reset()
		{

			gameObject = null;
			everyFrame = false;
			currentTime = null;
		}

		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			timeline = go.GetComponent<PlayableDirector>();

			timelineAction();
			
			if (!everyFrame.Value)
			{
				Finish();
			}

		}

		public override void OnUpdate()
		{

				timelineAction();

		}

		void timelineAction()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			if (go == null || timeline == null)
			{
				return;
			}

			currentTime.Value = (float)timeline.time;
				
		}

	}
}