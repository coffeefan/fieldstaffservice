package model  {
	import flash.display.MovieClip;
	import flash.events.MouseEvent;
	import fl.controls.Label;
	
	import flash.events.GeolocationEvent;
    import flash.sensors.Geolocation;
	
	public class Geolocator extends MovieClip {
		var geolocation:Geolocation;
		var labLatitude:Label;
		var labLongitude:Label;
		public function Geolocator(labLatitude:Label, labLongitude:Label) {
			this.labLatitude=labLatitude;
			this.labLongitude=labLongitude;
			geolocation = new Geolocation();
            geolocation.setRequestedUpdateInterval( 1000 );
            geolocation.addEventListener( GeolocationEvent.UPDATE, handleGeolocationUpdate );
		}
		
		public function handleGeolocationUpdate(e:GeolocationEvent):void{
			labLatitude.text=e.latitude.toString();
			labLongitude.text=e.longitude.toString();
		}

	}
	
}
