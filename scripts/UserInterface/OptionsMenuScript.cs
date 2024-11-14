using Godot;
using System;
using System.Diagnostics;
using System.Text.Json;

public partial class OptionsMenuScript : Node
{
	// Called when the node enters the scene tree for the first time
    public override void _Ready()
	{
        this.GetNode<HSlider>("Panel/hSlider_globalVolume").Value = Globals.globalVolume;
        this.GetNode<HSlider>("Panel/hSlider_musicVolume").Value = Globals.musicVolume;
        this.GetNode<HSlider>("Panel/hSlider_soundVolume").Value = Globals.soundVolume;

        this.GetNode<OptionButton>("Panel/optionBtn_shadowQuality").AddItem("Fast", 0);
        this.GetNode<OptionButton>("Panel/optionBtn_shadowQuality").AddItem("Good", 1);
        this.GetNode<OptionButton>("Panel/optionBtn_shadowQuality").AddItem("Best", 2);
        this.GetNode<OptionButton>("Panel/optionBtn_shadowQuality").Selected = Graphics.lightModeIndex;

        this.GetNode<CheckBox>("Panel/chkBox_toggleShadow").ButtonPressed = Graphics.lightIsEnabled;

        this.GetNode<OptionButton>("Panel/optionBtn_ChangeResolution").AddItem("Default", 0);
        this.GetNode<OptionButton>("Panel/optionBtn_ChangeResolution").AddItem("720p", 1);
        this.GetNode<OptionButton>("Panel/optionBtn_ChangeResolution").AddItem("1080p", 2);
        this.GetNode<OptionButton>("Panel/optionBtn_ChangeResolution").AddItem("1440p", 3);
        this.GetNode<OptionButton>("Panel/optionBtn_ChangeResolution").AddItem("4k", 4);
        this.GetNode<OptionButton>("Panel/optionBtn_ChangeResolution").Selected = Graphics.resolutionIndex;

        this.GetNode<CheckBox>("Panel/chkBox_fullscreen").ButtonPressed = Graphics.fullscreenEnabled;
        this.GetNode<CheckBox>("Panel/chkBox_vsync").ButtonPressed = Graphics.vsyncEnabled;

        this.GetNode<OptionButton>("Panel/optionBtn_language").AddItem("English", 0);
        this.GetNode<OptionButton>("Panel/optionBtn_language").Selected = Globals.languageIndex;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
	}
    public void _on_btn_exit_pressed()
    {
        GetTree().ChangeSceneToFile("res://scenes/MainMenu.tscn");
    }


    public void _on_h_slider_global_volume_value_changed(float value)
	{
		Debug.WriteLine("Volume : " + value);
		Globals.globalVolume = value;
	}

    public void _on_h_slider_music_volume_value_changed(float value)
	{
        Debug.WriteLine("music : " + value);
        Globals.musicVolume = value;
    }

    public void _on_h_slider_sound_volume_value_changed(float value)
    {
        Debug.WriteLine("sound : " + value);
        Globals.soundVolume = value;
    }

    public void _on_option_btn_shadow_quality_item_selected(int index)
    {
        Graphics.lightModeIndex = index;
        switch (index)
        {
            case 0:
                Graphics.light.DirectionalShadowMode = DirectionalLight3D.ShadowMode.Orthogonal;
                break;
            case 1:
                Graphics.light.DirectionalShadowMode = DirectionalLight3D.ShadowMode.Parallel2Splits;
                break;
            default:
                Graphics.light.DirectionalShadowMode = DirectionalLight3D.ShadowMode.Parallel4Splits;
                break;
        }
    }

    public void _on_chk_box_toggle_shadow_toggled(bool toggled_on)
    {
        Graphics.lightIsEnabled = toggled_on;
    }

    public void _on_chk_box_toggle_ssao_toggled(bool toggled_on)
    {
        Graphics.worldEnvironment.Environment.SsaoEnabled = toggled_on;
    }

    public void _on_option_btn_change_resolution_item_selected(int index)
    {
        Graphics.resolutionIndex = index;
        switch (index)
        {
            case 1:
                GetWindow().Size = new Vector2I(1280, 720);
                break;
            case 2:
                GetWindow().Size = new Vector2I(1920, 1080);
                break;
            case 3:
                GetWindow().Size = new Vector2I(2560, 1440);
                break;
            case 4:
                GetWindow().Size = new Vector2I(3840, 2160);
                break;
            default:
                GetWindow().Size = new Vector2I(1152, 648);
                break;
        }
    }

    public void _on_chk_box_fullscreen_toggled(bool toggled_on)
    {
        Graphics.fullscreenEnabled = toggled_on;
        if (toggled_on)
        {
            DisplayServer.WindowSetMode(DisplayServer.WindowMode.Fullscreen);
        }
        else
        {
            DisplayServer.WindowSetMode(DisplayServer.WindowMode.Windowed);
        }
       
    }

    public void _on_chk_box_vsync_toggled(bool toggled_on)
    {
        Graphics.vsyncEnabled = toggled_on;
        if (toggled_on)
        {
            DisplayServer.WindowSetVsyncMode(DisplayServer.VSyncMode.Enabled);
        }
        else
        {
            DisplayServer.WindowSetVsyncMode(DisplayServer.VSyncMode.Disabled);
        }
    }

    public void _on_option_btn_language_item_selected(int index)
    {
        Globals.languageIndex = index;
    }
}
