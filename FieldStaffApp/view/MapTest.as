package view  {
	
	public class MapTest {
		 import com.mapquest.*;
            import com.mapquest.services.geocode.*;
            import com.mapquest.tilemap.*;
            import com.mapquest.tilemap.controls.inputdevice.*;
            import com.mapquest.tilemap.controls.shadymeadow.*;
            import com.mapquest.tilemap.pois.*;
            
            import mx.collections.ArrayList;


            private var geocoder:OpenGeocoder;
            private var location:GeocoderLocation;
            [Bindable]private var alResults:ArrayList;
		public function MapTest() {
			// constructor code
		}

	}
	
}
