package model  {
	
	import flash.display.MovieClip;
	import model.Geolocator;
	import view.pageOne;

	
	public class initStartUp extends MovieClip {
		private var pageOneItem:pageOne;
		
		public function initStartUp() {
			var pageOneItem:MovieClip=new mc_pageOne();
			pageOneItem.x = 0;
			pageOneItem.y = 0;
			addChild(pageOneItem);
		}
	}
	
}
