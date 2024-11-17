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
	public Dictionary<E_Building, CardBase> Building;

	public Globals()
	{
		Building = new Dictionary<E_Building, CardBase>
		{
			{E_Building.FARM, new CardBase( (ECardColor)ECardColor.Blue, (ECardType)ECardType.Farm , "Farm", CardDescriptions.Blue(1), 1, (Mesh)this.GetMeta("FarmMesh"), 2, 2) },
			{E_Building.FIELD, new CardBase( (ECardColor)ECardColor.Blue, (ECardType)ECardType.Agricole , "Wheat Field", CardDescriptions.Blue(1), 0, (Mesh)this.GetMeta("FieldMesh"), 1, 1) },
			{E_Building.FOREST, new CardBase( (ECardColor)ECardColor.Blue, (ECardType)ECardType.Resources , "Forest", CardDescriptions.Blue(1), 3, (Mesh)this.GetMeta("ForestMesh"), 5, 5) },
			{E_Building.MINE, new CardBase( (ECardColor)ECardColor.Blue, (ECardType)ECardType.Resources , "Mine", CardDescriptions.Blue(5), 6, (Mesh)this.GetMeta("MineMesh"), 9, 9) },
			{E_Building.ORCHARD, new CardBase( (ECardColor)ECardColor.Blue, (ECardType)ECardType.Agricole , "Orchard", CardDescriptions.Blue(3), 3, (Mesh)this.GetMeta("OrchardMesh"), 10, 10) },

			{E_Building.CAFE, new CardBase( (ECardColor)ECardColor.Red, (ECardType)ECardType.Restauration , "Cafe", "Recieve 1 coin\nfrom the player\nthat threw the dices.", 2, (Mesh)this.GetMeta("CafeMesh"), 3, 3) },
			{E_Building.RESTAURANT, new CardBase( (ECardColor)ECardColor.Red, (ECardType)ECardType.Restauration , "Restaurant", "Recieve 2 coin\nfrom the player\nthat threw the dices.", 3, (Mesh)this.GetMeta("RestaurantMesh"), 9, 10) },

			{E_Building.BAKERY, new CardBase( (ECardColor)ECardColor.Green, (ECardType)ECardType.Shop , "Bakery", CardDescriptions.GreenBank(1), 0, (Mesh)this.GetMeta("BakeryMesh"), 2, 3) },
			{E_Building.SUPERMARKET, new CardBase( (ECardColor)ECardColor.Green, (ECardType)ECardType.Shop , "Supermarket", CardDescriptions.GreenBank(3), 2, (Mesh)this.GetMeta("SupermarketMesh"), 4, 4) },
			{E_Building.FURNITURE_FACTORY, new CardBase( (ECardColor)ECardColor.Green, (ECardType)ECardType.Factory , "Furniture Factory", CardDescriptions.GreenForeach(3),3, (Mesh)this.GetMeta("FurnitureFactoryMesh"), 8, 8) },
			{E_Building.VEGETABLES_MARKET, new CardBase( (ECardColor)ECardColor.Green, (ECardType)ECardType.Market , "Vegetables Market", CardDescriptions.GreenForeach(2), 2, (Mesh)this.GetMeta("VegetablesMarketMesh"), 11, 12) },
			{E_Building.CHEESE_SHOP, new CardBase( (ECardColor)ECardColor.Green, (ECardType)ECardType.Factory , "Cheese Shop", CardDescriptions.GreenForeach(3), 5, (Mesh)this.GetMeta("CheeseShopMesh"), 7, 7) },

			{E_Building.TV_CHANNEL, new CardBase( (ECardColor)ECardColor.Violet, (ECardType)ECardType.Special , "TV Channel", CardDescriptions.YOUR_TURN_ONLY + "Recieve 5 coins\nfrom your enemy.", 7, (Mesh)this.GetMeta("TvChannelMesh"), 6, 6) },
			{E_Building.STADIUM, new CardBase( (ECardColor)ECardColor.Violet, (ECardType)ECardType.Special , "Stadium", CardDescriptions.YOUR_TURN_ONLY + "Recieve 2 coins\nfrom your enemy.", 6, (Mesh)this.GetMeta("StadiumMesh"), 6, 6) },
			{E_Building.BUSINESS_CENTER, new CardBase( (ECardColor)ECardColor.Violet, (ECardType)ECardType.Special , "Business Center", CardDescriptions.YOUR_TURN_ONLY + "You can exchange\nwith your enemy\nany building\nexcept monuments.", 8, (Mesh)this.GetMeta("BusinessCenterMesh"), 6, 6) },

			{E_Building.TOWER, new CardBase( (ECardColor)ECardColor.Yellow, (ECardType)ECardType.Monument , "Tower", "Once each round\nyou can choose\nto throw your dice again.", 22, (Mesh)this.GetMeta("FarmMesh"), 0, 0) },
			{E_Building.TRAIN_STATION, new CardBase( (ECardColor)ECardColor.Yellow, (ECardType)ECardType.Monument , "Train Station", "You can throw\ntwo dices.", 4, (Mesh)this.GetMeta("TrainStationMesh"),0, 0) },
			{E_Building.AMUSEMENT_PARK, new CardBase( (ECardColor)ECardColor.Yellow, (ECardType)ECardType.Monument , "Amusement Park", "", 16, (Mesh)this.GetMeta("AmusementParkMesh"), 0, 0) },
			{E_Building.MALL, new CardBase( (ECardColor)ECardColor.Yellow, (ECardType)ECardType.Monument , "Mall", "", 10, (Mesh)this.GetMeta("MallMesh"), 0, 0) },
		};
	}
	
}
