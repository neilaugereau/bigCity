using Godot;
using System;

public partial class GameOverMenu : Control
{
    public void _on_btn_continue_pressed()
    {
        GetTree().ChangeSceneToFile("res://scenes/MainMenu.tscn");
    }

    public void _on_btn_quit_pressed()
	{
        GetTree().Quit();
    }

}
