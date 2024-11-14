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
}
