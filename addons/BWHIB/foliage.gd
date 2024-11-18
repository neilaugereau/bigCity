@tool
extends EditorPlugin

var BWHIBFoliage = preload("res://addons/BWHIB/BWHIBFoliage.gd")
	
var _gui_toolbar = null
var _selected_foliage: BWHIBFoliage = null  

func _enter_tree():
	add_custom_type("BWHIBFoliage", "Node3D", BWHIBFoliage, preload("res://addons/BWHIB/icon.png"))

	_gui_toolbar = preload("res://addons/BWHIB/Foliage_Toolbar.tscn").instantiate()
	add_control_to_container(EditorPlugin.CONTAINER_SPATIAL_EDITOR_MENU, _gui_toolbar)
	_gui_toolbar.generate_button.pressed.connect(_on_generate_button_pressed)

func _exit_tree():
	remove_custom_type("BWHIBFoliage")
	remove_control_from_container(EditorPlugin.CONTAINER_SPATIAL_EDITOR_MENU, _gui_toolbar)

func _on_generate_button_pressed():
	if _selected_foliage and _selected_foliage is BWHIBFoliage:
		_selected_foliage.update_foliage()
		print("Foliage updated.")
	else:
		push_error("No valid BWHIBFoliage node selected. Please select one in the editor.")
