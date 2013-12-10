package model  {
	
	import flash.display.MovieClip;
	
	import flash.events.MouseEvent;
	import flash.events.*;
	
	import fl.transitions.Tween;
	import fl.transitions.easing.*;
	import fl.transitions.TweenEvent;
	
	import view.pageOne;
	import view.mainnavigation;
	import view.opennavigation;
	import view.mqschulenuebersicht;
	import view.ortAuswahl;
	import model.OrtManager;
	
	public class initStartUp extends MovieClip {
		//private var pageOneItem:pageOne;
		private var opennavi:opennavigation;
		private var mainnavi:mainnavigation;
		private var mapq:mqschulenuebersicht;
		private var pageOneOrtAuswahl:ortAuswahl;
		private var orte:Object;
		
		public function initStartUp() {
			/* var pageOneItem:MovieClip=new mc_pageOne();
			pageOneItem.x = 0;
			pageOneItem.y = 0;
			addChild(pageOneItem);*/
			//mapq=new mc_mqschulenuebersicht();
			//addChild(mapq);
			loadData();
		}
		
		public function startShow(e:Event):void{
			trace("seee");
			pageOneOrtAuswahl= new mc_pageOrtAuswahl();
			addChild(pageOneOrtAuswahl);
			makeMainnavigationReady();
		}
		
		private function loadData():void{
			var ortmanager:OrtManager=new OrtManager();
			ortmanager.addEventListener("complete", startShow);
			ortmanager.loadOrtschaften();
		}

		
		private function makeMainnavigationReady(){
			opennavi = new mc_opennavigation();
			opennavi.x=8;
			opennavi.y=8;
			addChild(opennavi);			
			opennavi.clickme.addEventListener( MouseEvent.CLICK,openMainNavigation);
			opennavi.addEventListener(Event.REMOVED_FROM_STAGE,opennavigationRemovedFromStageHandler);
			
			mainnavi=new mc_mainnavigation();
			mainnavi.showNavigation();
			mainnavi.x = (-1*mainnavi.width-2);
			mainnavi.y = 50;
			addChild(mainnavi);
		}
		
		private function openMainNavigation(e:MouseEvent):void{
			if(mainnavi.x!=0){
				var myTween:Tween = new Tween(mainnavi, "x", Strong.easeOut, (-1*mainnavi.width-2), 0, 1, true);
			}else{
				var myTween:Tween = new Tween(mainnavi, "x", Strong.easeOut, 0, (-1*mainnavi.width-2), 1, true);
			}
		}
		
		private function opennavigationRemovedFromStageHandler(e:MouseEvent):void{
			trace("opennavigation has removed from stage");
			opennavi.clickme.removeEventListener( MouseEvent.CLICK,openMainNavigation);
			opennavi.removeEventListener(Event.REMOVED_FROM_STAGE,opennavigationRemovedFromStageHandler);
			trace("Eventlistener removed");
			
		}
	}
	
}
