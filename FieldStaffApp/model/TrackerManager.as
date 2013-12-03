package model  {
	import flash.display.MovieClip;
	import flash.events.Event;
	import flash.events.MouseEvent;
	import flash.net.URLLoader;
	import flash.net.URLRequest;
	import flash.net.URLVariables;
	import flash.net.URLLoaderDataFormat;
	import flash.net.URLRequestMethod;
	import flash.events.IOErrorEvent;
	import flashx.textLayout.formats.Float;
	
	public class TrackerManager extends MovieClip{

		public function TrackerManager () {
						
		}
		
		public function saveTrack(latitude:Number,longitude:Number,personid:int){
			var TrackerObject:Object	= new Object();
			TrackerObject["Latitude"] 	= latitude;
			TrackerObject["Longitude"]	= longitude;
			TrackerObject["Tracktime"] 	= "2013-10-09T19:20:00";
			TrackerObject["PersonId"]	= personid;
			var jsonRequest:URLRequest 	= new URLRequest("http://fotonet.foto-bachmann.ch/api/Tracker"); 
			jsonRequest.contentType 	= "APPLICATION/JSON"; 
			jsonRequest.data 			= JSON.stringify(TrackerObject); 
			jsonRequest.method 			= URLRequestMethod.POST;
			var jsonLoader:URLLoader 	= new URLLoader(); 
			jsonLoader.addEventListener(Event.COMPLETE, handleResults); 
			jsonLoader.load(jsonRequest);
		}
		
		
		
		private function handleResults(e:Event):void{
			trace("yabi");
		}

	}
	
}
