// (c) Copyright HutongGames, LLC 2010-2017. All rights reserved.
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using System;
using UnityEngine;
using UnityEngine.Playables;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Timeline")]
	[Tooltip("Enables the timeline component 'Playable Director'")]

	public class  enableTimeline : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(PlayableDirector))]
		[Tooltip("The game object to hold the unity timeline components.")]
		public FsmOwnerDefault gameObject;
		
		[Tooltip("Set to true to enable the playable director. Set to false to disable it.")]
		public FsmBool enable;

		[Tooltip("Check this box to preform this action every frame.")]
		public FsmBool everyFrame;

		private PlayableDirector timeline;

		public override void Reset()
		{

			gameObject = null;
			everyFrame = false;
			enable = true;
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

			timeline.enabled = enable.Value;

		}

	}
}