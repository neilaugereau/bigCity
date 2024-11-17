using Godot;
using System;

public partial class CardDescriptions
{
	public const string ANY_PLAYER_TURN = "During any\nplayer's turn\n";
	public const string YOUR_TURN_ONLY = "During your\nturn only\n";
	public static string FromBank(int val) => $"Recieve {val} coin(s)\nfrom the bank.";
	public static string Foreach(int val) => $"Recieve {val} coin(s)\nfor each building\nof this type\nthat you possess.";

	public static string Blue(int val) => ANY_PLAYER_TURN + FromBank(val) ;
	public static string GreenBank(int val) => YOUR_TURN_ONLY + FromBank(val);
	public static string GreenForeach(int val) => YOUR_TURN_ONLY + Foreach(val);
}
