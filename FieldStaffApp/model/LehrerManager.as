package model  {
	import flash.display.MovieClip;
	import flash.events.Event;
	import flash.events.MouseEvent;
	import flash.net.URLLoader;
	import flash.net.URLRequest;
	import flash.net.URLVariables;
	import flash.net.URLLoaderDataFormat;
	import flash.net.URLRequestHeader;
    import flash.net.URLRequestMethod;
	import flash.events.IOErrorEvent;
	import flashx.textLayout.formats.Float;
	import Config;
	import view.lehrerItem;
	import view.pageOne;
	
	public class LehrerManager extends MovieClip{
		var lehreritems:MovieClip;
		var buehne:pageOne;
		public function LehrerManager (_buehne:pageOne) {
			lehreritems=new MovieClip;
			buehne=_buehne;
		}
		
		
		public function loadLehrer(schoolid:int){
			
			var jsonRequest:URLRequest 	= new URLRequest(Config.webserviceurl+"Lehrer/?schuleid="+schoolid); 
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
			
			var anzahl:int=0;
		 	for each (var lehrertemp:Object in container) {
				trace("now");
				var lehreritem:lehrerItem=new mc_lehreritem();
				lehreritem.setLehrer(lehrertemp);
				lehreritem.y=(anzahl*lehreritem.height)+(5*anzahl);
				lehreritems.addChild(lehreritem);
				anzahl++;
				
			}
			buehne.setContent(lehreritems);
			

		}

	}
	
}
