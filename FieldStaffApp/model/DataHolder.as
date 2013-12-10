package model  {
	
	public class DataHolder {
		private static var Ort:Object;
		public static function set setOrt(tempOrt:Object):void{
			Ort=tempOrt;
		}
		public static function get getOrt():Object{
			return Ort;
		}

	}
	
}
