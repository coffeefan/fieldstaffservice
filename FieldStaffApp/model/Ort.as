package  model{
	
	public class Ort {
		private var  ortid:int;
		private var plz:String;
		private var bezeichnung:String;
		private var kantonid:int;
		
		public function Ort(ortid:int, plz:String, bezeichnung:String,kantonid:int) {
			this.ortid=ort;
			this.plz=plz;
			this.bezeichnung=bezeichnung;
			this.kantonid=kantonid;			
		}
		
		public function setOrtid(ortid:int):void{
			this.ortid=ortid;
		}
		public function getOrtid():int{
			return ortid;
		}
		
		public function setPLZ(plz:String):void{
			this.plz=plz;
		}
		public function getPLZ():String{
			return plz;
		}
		
		public  function setBezeichnung(bezeichnung:String):void{
			this.bezeichnung=bezeichnung;
		}
		public function getBezeichnung():String{
			return bezeichnung;
		}
		
		public function setKantonid(kantonid:int):void{
			this.kantonid=kantonid;
		}
		public function getKantonid():int{
			return kantonid;
		}

	}
	
}
