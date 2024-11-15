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
        this.GetNode<CheckBox>("Panel/chkBox_toggleSsao").ButtonPressed = Graphics.ssaoIsEnabled;

        this.GetNode<OptionButton>("Panel/optionBtn_changeResolution").AddItem("Default", 0);
        this.GetNode<OptionButton>("Panel/optionBtn_changeResolution").AddItem("720p", 1);
        this.GetNode<OptionButton>("Panel/optionBtn_changeResolution").AddItem("1080p", 2);
        this.GetNode<OptionButton>("Panel/optionBtn_changeResolution").AddItem("1440p", 2);
        this.GetNode<OptionButton>("Panel/optionBtn_changeResolution").AddItem("4k", 2);
        this.GetNode<OptionButton>("Panel/optionBtn_changeResolution").Selected = Graphics.resolutionIndex;

        this.GetNode<CheckBox>("Panel/chkBox_fullscreen").ButtonPressed = Graphics.fullscreenIsEnabled;
        this.GetNode<CheckBox>("Panel/chkBox_toggleVsync").ButtonPressed = Graphics.vsyncIsEnabled;

        this.GetNode<OptionButton>("Panel/optionBtn_chooseLanguage").AddItem("English", 0);
        this.GetNode<OptionButton>("Panel/optionBtn_chooseLanguage").Selected = Graphics.languageIndex;
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
        Graphics.light.ShadowEnabled = toggled_on;
    }

    public void _on_chk_box_toggle_ssao_toggled(bool toggled_on)
    {
        Graphics.ssaoIsEnabled = toggled_on;
        Graphics.worldEnvironment.Environment.SsaoEnabled = toggled_on;
    }

    public void _on_option_btn_change_resolution_item_selected(int index)
    {
        Graphics.resolutionIndex = index;
        switch (index)
        {
            case 1:
                DisplayServer.WindowSetSize(new Vector2I(1280, 720));
                break;
            case 2:
                DisplayServer.WindowSetSize(new Vector2I(1920, 1080));
                break;
            case 3:
                DisplayServer.WindowSetSize(new Vector2I(2560, 1440));
                break;
            case 4:
                DisplayServer.WindowSetSize(new Vector2I(3840, 2160));
                break;
            default:
                DisplayServer.WindowSetSize(new Vector2I(1152, 648));
                break;
        }
    }

    public void _on_chk_box_fullscreen_toggled(bool toggled_on)
    {
        Graphics.fullscreenIsEnabled = toggled_on;
        if (toggled_on)
        {
            DisplayServer.WindowSetMode(DisplayServer.WindowMode.Fullscreen);
        }
        else
        {
            DisplayServer.WindowSetMode(DisplayServer.WindowMode.Windowed);
        }
    }

    public void _on_chk_box_toggle_vsync_toggled(bool toggled_on)
    {
        Graphics.vsyncIsEnabled = toggled_on;
        if (toggled_on)
        {
            DisplayServer.WindowSetVsyncMode(DisplayServer.VSyncMode.Enabled);
        }
        else
        {
            DisplayServer.WindowSetVsyncMode(DisplayServer.VSyncMode.Disabled);
        }
    }

    public void _on_option_btn_choose_language_toggled(int index)
    {

    }
}
