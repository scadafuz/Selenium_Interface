/*
 * Created by SharpDevelop.
 * User: blopes
 * Date: 01/06/2017
 * Time: 14:52
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace SeleniumTest
{
	/// <summary>
	/// Description of TypeField.
	/// </summary>
	public static class TypeField
	{
	
		public static string[] Alfa=new String[]{"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z","a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z"};
		public static string[] Number=new String[]{"1","2","3","4","5","6","7","8","9","0"};
		public static string[] AlfaNumber=new String[]{"\"","#","$","%","&","'","(",")","*","+",",","–",".","/","0","1","2","3","4","5","6","7","8","9",":",";","<","=",">","?","@","A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z","[","\\","]","\u005e","_","\u0027","a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z","{","|","}","\u007e","Ç","ü","é","â","ä","à","å","ç","ê","ë","è","ï","î","ì","Ä","Å","É","æ","Æ","ô","ö","ò","û","ù","ÿ","Ö","Ü","ø","£","Ø","×","ƒ","á","ù","ó","ú","ñ","Ñ","ª","º","¿","®","¬","½","¼","¡","«","»","░","▒","▓","│","┤","Á","Â","À","©","╣","║","╗","╝","¢","¥","┐","└","┴","┬","├","─","┼","ã","Ã","╚","╔","╩","╦","╠","═","╬","¤","ð","Ð","Ê","Ë","È","ı","Í","Î","Ï","┘","┌","█","▄","¦","Ì","▀","Ó","ß","Ô","Ò","õ","Õ","µ","þ","Þ","Ú","Û","Ù","ý","Ý","¯","\u00b4","±","‗","¾","¶","§","÷","¸","°","\u00a8","·","¹","³","²","■"};
    	public static string[] other=new String[1];
		
		
		 ///<summary>
		///Seta o Tipo
		///</summary>
		///<remarks>
		///Gambiarreation
		///</remarks>
		 public static string[] GetArrayType(string Type=""){
			if(Type=="Alfa"){
			    return Alfa;
			}
			else if(Type=="Numérico"){
			    return Number;
			}
			else if(Type=="Alfanumérico"){
			    return AlfaNumber;
			}
			else if(Type=="other"){
				return other;
			}
			else{
				return AlfaNumber;
			}
		 
		 }
		 public static string GetType(string TipoElemento,string tipo){
			if(!(TipoElemento.Equals(string.Empty))){
				return TipoElemento;
			}
			else{
				
				if(tipo=="number"){
					return "other";			
				}
				else if(tipo=="date"){
					return "other";
					
				}
				else if(tipo=="email"){
					return "other";
				}
				else if(tipo=="range"){
					return "other";
				}
				else if(tipo=="search"){
					return "other";
				}
				else if(tipo=="tel"){
					return "other";
				}
				else if(tipo=="time"){
					return "other";
				}
				else if(tipo=="week"){
					return "other";
				}
				else if(tipo=="url"){
					return "other";
				}
				else if(tipo=="month"){
					return "other";
				}
				else if(tipo=="datetime-local"){
					return "other";
				}
				else if(tipo=="color"){
					return "other";
				}
				else{
					return "Alfanumérico";
				
				}
			}
		}

		 public static string GetDefaultString(string Type=""){
			if(Type=="Alfa"){
			    return "g";
			}
			else if(Type=="Numérico"){
			    return "7";
			}
			else if(Type=="Alfanumérico"){
			    return "g";
			}
			else if(Type=="NumberHtml"){
				return "7";
			}
			else if(Type=="Date"){
				return "7";
			}
			else{
				return "g";
				
			}
		 
		 }
		
		
		
	}
}
