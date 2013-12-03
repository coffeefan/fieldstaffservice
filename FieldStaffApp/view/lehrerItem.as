package view {
	import flash.display.MovieClip;
	import flash.events.Event;
	import flash.events.MouseEvent;
	import fl.controls.Button;
	import flash.display.SimpleButton;
	import Config;
	
	public class lehrerItem extends MovieClip {
		public var lehrer:Object;
		
		public function lehrerItem (){
			// constructor code
		}
		
		public function setLehrer(_lehrer:Object){
			lehrer=_lehrer;
			if(lehrer.festbenutzername==null){
				lehrername.text="Maria";
			}else{
				trace(lehrer.festbenutzername);
				lehrername.text="hallo";
			}
			makeSignal(lehrer.beziehungid);
		}
		
		public function makeSignal(beziehungid:int){
			var ampel:MovieClip=new mc_ampel_green();
			if(Config.noAdvertisment.indexOf(beziehungid)>=0){
				ampel=new mc_ampel_red();
			}

			ampel.x=this.width-20;
			ampel.y=this.height-20;
			addChild(ampel);
		}

	}
	
}
