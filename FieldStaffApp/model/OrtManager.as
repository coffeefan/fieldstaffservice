package model  {
	import flash.display.MovieClip;
	import flash.events.*;
	import flash.net.URLLoader;
	import flash.net.URLRequest;
	import flash.net.URLVariables;
	import flash.net.URLLoaderDataFormat;
	import flash.net.URLRequestHeader;
    import flash.net.URLRequestMethod;
	import model.DataHolder;
	
	public class OrtManager extends MovieClip{
		public function OrtManager() {
		}
		
		public function loadOrtschaften(){
			trace("hello");
			var jsonRequest:URLRequest 	= new URLRequest(Config.webserviceurl+"Ort/"); 
			jsonRequest.contentType 	= "application/json; charset=UTF-8"; 
			var acceptHeader:URLRequestHeader = new URLRequestHeader("Accept", "application/json");
			jsonRequest.requestHeaders.push(acceptHeader);
			jsonRequest.method 			= URLRequestMethod.GET;
			var jsonLoader:URLLoader 	= new URLLoader(); 
			jsonLoader.addEventListener(Event.COMPLETE, handleResults); 
			jsonLoader.load(jsonRequest);
		}
		
		private function handleResults(e:Event):void{
			var response:String = e.target.data as String;
			var container:Object = (JSON.parse(response) as Object);
			
			//buehne.dataloaded(container);
			DataHolder.setOrt=container;
			dispatchEvent(new Event("complete"));
			

		}

	}
	
}
