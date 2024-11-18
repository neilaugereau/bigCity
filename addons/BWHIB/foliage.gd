@tool
extends EditorPlugin

var BWHIBFoliage = preload("BWHIBFoliage.gd")

var _gui_toolbar = null
var _plugin_activate: bool = true;

func _enter_tree():
	add_custom_type("BWHIBFoliage", "Node", BWHIBFoliage, preload("icon.png"))
	
	_gui_toolbar = load("res://scripts/Foliage/Foliage_Toolbar.tscn").instantiate()
	_gui_toolbar.visible = true
	
	add_control_to_container(EditorPlugin.CONTAINER_SPATIAL_EDITOR_MENU, _gui_toolbar)
	_gui_toolbar.generate_button.pressed.connect(_on_generate_button_pressed)

func _on_generate_button_pressed():
	if _plugin_activate != false:
		print("debug")
		#_selected_scatter.do_generate()
