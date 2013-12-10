
package view {
	import flash.display.MovieClip;
	import flash.system.Security;
	import com.umapper.umap.core.UMap;

			
			
	public class mqschulenuebersicht extends MovieClip {
		public function mqschulenuebersicht():void    {
				var map:UMap = new UMap({apiKey:"b7be6030ef1677127676512c918087fb"});
				map.setSize(550,400);
				addChild(map);
			
			
            
		}
	}
}