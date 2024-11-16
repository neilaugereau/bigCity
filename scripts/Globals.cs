using Godot;
using System;
using System.Collections.Generic;

public partial class Globals : Node
{
	public static float globalVolume = 100;
	public static float soundVolume = 100;
	public static float musicVolume = 100;

	//public static int[,] gridPosition = new int[100, 100];
	public static Dictionary<Vector2, E_Building> gridPositions = new Dictionary<Vector2, E_Building>();
	public enum E_Building
	{
		// Blue Cards
		FARM,
		FIELD,
		FOREST,
		MINE,
		ORCHARD, // Verger

		// Red Cards
		CAFE,
		RESTAURANT,

		// Green Cards
		BAKERY,
		SUPERMARKET,
		FURNITURE_FACTORY,
		VEGETABLES_MARKET,
		CHEESE_SHOP,

		// Special Cards
		TV_CHANNEL,
		STADIUM,
		BUSINESS_CENTER,

		// Monument Cards
		TOWER,
		TRAIN_STATION,
		AMUSEMENT_PARK,
		MALL

	}
	public Dictionary<E_Building, Card> Building;

	public Globals()
	{
		Building = new Dictionary<E_Building, Card>
		{
			{E_Building.FARM, new Card( (ECardColor)ECardColor.Blue , "Farm", CardDescriptions.Blue(1), 1, (Mesh)this.GetMeta("FarmMesh"), 2, 2) },
			{E_Building.FIELD, new Card( (ECardColor)ECardColor.Blue , "Wheat Field", CardDescriptions.Blue(1), 0, (Mesh)this.GetMeta("FieldMesh"), 1, 1) },
			{E_Building.FOREST, new Card( (ECardColor)ECardColor.Blue , "Forest", CardDescriptions.Blue(1), 3, (Mesh)this.GetMeta("ForestMesh"), 5, 5) },
			{E_Building.MINE, new Card( (ECardColor)ECardColor.Blue , "Mine", CardDescriptions.Blue(5), 6, (Mesh)this.GetMeta("MineMesh"), 9, 9) },
			{E_Building.ORCHARD, new Card( (ECardColor)ECardColor.Blue , "Orchard", CardDescriptions.Blue(3), 3, (Mesh)this.GetMeta("OrchardMesh"), 10, 10) },

			{E_Building.CAFE, new Card( (ECardColor)ECardColor.Red , "Cafe", "Recieve 1 coin\nfrom the player\nthat threw the dices.", 2, (Mesh)this.GetMeta("CafeMesh"), 3, 3) },
			{E_Building.RESTAURANT, new Card( (ECardColor)ECardColor.Red , "Restaurant", "Recieve 2 coin\nfrom the player\nthat threw the dices.", 3, (Mesh)this.GetMeta("RestaurantMesh"), 9, 10) },

			{E_Building.BAKERY, new Card( (ECardColor)ECardColor.Green , "Bakery", CardDescriptions.GreenBank(1), 0, (Mesh)this.GetMeta("BakeryMesh"), 2, 3) },
			{E_Building.SUPERMARKET, new Card( (ECardColor)ECardColor.Green , "Supermarket", CardDescriptions.GreenBank(3), 2, (Mesh)this.GetMeta("SupermarketMesh"), 4, 4) },
			{E_Building.FURNITURE_FACTORY, new Card( (ECardColor)ECardColor.Green , "Furniture Factory", CardDescriptions.GreenForeach(3),3, (Mesh)this.GetMeta("FurnitureFactoryMesh"), 8, 8) },
			{E_Building.VEGETABLES_MARKET, new Card( (ECardColor)ECardColor.Green , "Vegetables Market", CardDescriptions.GreenForeach(2), 2, (Mesh)this.GetMeta("VegetablesMarketMesh"), 11, 12) },
			{E_Building.CHEESE_SHOP, new Card( (ECardColor)ECardColor.Green , "Cheese Shop", CardDescriptions.GreenForeach(3), 5, (Mesh)this.GetMeta("CheeseShopMesh"), 7, 7) },

			{E_Building.TV_CHANNEL, new Card( (ECardColor)ECardColor.Special , "TV Channel", CardDescriptions.YOUR_TURN_ONLY + "Recieve 5 coins\nfrom your enemy.", 7, (Mesh)this.GetMeta("TvChannelMesh"), 6, 6) },
			{E_Building.STADIUM, new Card( (ECardColor)ECardColor.Special , "Stadium", CardDescriptions.YOUR_TURN_ONLY + "Recieve 2 coins\nfrom your enemy.", 6, (Mesh)this.GetMeta("StadiumMesh"), 6, 6) },
			{E_Building.BUSINESS_CENTER, new Card( (ECardColor)ECardColor.Special , "Business Center", CardDescriptions.YOUR_TURN_ONLY + "You can exchange\nwith your enemy\nany building\nexcept monuments.", 8, (Mesh)this.GetMeta("BusinessCenterMesh"), 6, 6) },

			{E_Building.TOWER, new Card( (ECardColor)ECardColor.Monument , "Tower", "Once each round\nyou can choose\nto throw your dice again.", 22, (Mesh)this.GetMeta("FarmMesh"), 0, 0) },
			{E_Building.TRAIN_STATION, new Card( (ECardColor)ECardColor.Monument , "Train Station", "You can throw\ntwo dices.", 4, (Mesh)this.GetMeta("TrainStationMesh"),0, 0) },
			{E_Building.AMUSEMENT_PARK, new Card( (ECardColor)ECardColor.Monument , "Amusement Park", "", 16, (Mesh)this.GetMeta("AmusementParkMesh"), 0, 0) },
			{E_Building.MALL, new Card( (ECardColor)ECardColor.Monument , "Mall", "", 10, (Mesh)this.GetMeta("MallMesh"), 0, 0) },
		};
	}
	
}
