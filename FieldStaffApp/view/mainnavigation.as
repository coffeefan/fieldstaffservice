package view {
	
	import flash.display.MovieClip;
	import view.navbutton;
	
	
	public class mainnavigation extends MovieClip {
		private var home:navbutton;
		private var gesamtliste:navbutton;
		
		public function showNavigation():void {
			home=new mc_navbutton();
			home.navbuttontext.text="Startseite";
			home.x=0;
			home.y=42;
			addChild(home);
			
			gesamtliste=new mc_navbutton();
			gesamtliste.navbuttontext.text="Gesamtliste";
			gesamtliste.x=0;
			gesamtliste.y=92;
			addChild(gesamtliste);
		}
		
	}
	
}
