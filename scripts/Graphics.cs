using Godot;
using System;

public partial class Graphics : Node
{
	public static WorldEnvironment worldEnvironment;
	public static DirectionalLight3D light;

	public static int lightModeIndex = 2;
    public static int resolutionIndex = 0;
	public static int languageIndex = 0;

    public static bool lightIsEnabled = true;
	public static bool ssaoIsEnabled = true;
	public static bool fullscreenIsEnabled = false;
	public static bool vsyncIsEnabled = true;
}
