package view {
	
	import flash.display.MovieClip;
	import flash.events.Event;
	import flash.events.MouseEvent;
	import flash.events.TimerEvent;
	import flash.utils.Timer;
	import fl.events.ScrollEvent;
	import fl.containers.ScrollPane; 
	import fl.controls.ScrollPolicy; 
	import fl.controls.DataGrid; 
	import fl.data.DataProvider;
	import fl.transitions.*;
	import fl.controls.Button;

	import model.Geolocator;
	import model.LehrerManager;
	import view.lehrerItem;
	
	
	public class pageOne extends MovieClip {
		private var geolocator:Geolocator;
		private var scrollPane:ScrollPane;
		private var content_container:MovieClip;
		private var lehrerManager:LehrerManager;
		
		public function pageOne() {
			content_container=new MovieClip;
			generateScroller(0,0);
			lehrerManager=new LehrerManager(this);
			lehrerManager.loadLehrer(146);	
		}
		
		public function setContent(_content_container:MovieClip){
			content_container=_content_container;
			scrollPane.source = content_container;			
			scrollPane.refreshPane();
		}
		
		//Scroller
		private function generateScroller(startX_Int:Number, startY_Int:Number):void {
				
			var startX:Number 	= startX_Int;
			var startY:Number 	= startY_Int;			
			
			scrollPane = new ScrollPane(); 
			scrollPane.setSize(460, 700); 
			scrollPane.move(startX, startY);

			scrollPane.source 					= content_container;
			scrollPane.scrollDrag 				= true; 
			scrollPane.visible 					= true;
			scrollPane.horizontalScrollPolicy	= ScrollPolicy.OFF;
			scrollPane.verticalScrollPolicy		= ScrollPolicy.OFF;
			

			addChild(scrollPane);
		}
		
	}
	
	
	
}
