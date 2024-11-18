@tool
extends Node3D

@export var square_size: int = 40
@export var foliage_mesh: Mesh
@export var foliage_count: int = 100

var multi_mesh_instance: MultiMeshInstance3D

func _ready() -> void:
	if Engine.is_editor_hint():
		update_foliage()
	else:
		initialize_foliage()

func initialize_foliage() -> void:
	if not multi_mesh_instance:
		multi_mesh_instance = MultiMeshInstance3D.new()
		add_child(multi_mesh_instance)

	var multimesh = multi_mesh_instance.multimesh
	if not multimesh:
		multimesh = MultiMesh.new()
		multi_mesh_instance.multimesh = multimesh

	multimesh.transform_format = MultiMesh.TRANSFORM_3D
	multimesh.instance_count = foliage_count
	multimesh.mesh = foliage_mesh

	update_foliage()

func update_foliage() -> void:
	if not multi_mesh_instance or not multi_mesh_instance.multimesh:
		initialize_foliage()
		return

	if foliage_mesh == null:
		push_error("need mesh")
		return

	randomize()
	for i in range(foliage_count):
		var random_pos = Vector3(
							 randf_range(-square_size / 2, square_size / 2),
							 0,
							 randf_range(-square_size / 2, square_size / 2)
						 )
		var random_scale = Vector3.ONE * randf_range(0.8, 1.2)
		var random_rotation = Basis(Vector3.UP, randf_range(0, TAU))
		var transform = Transform3D(random_rotation, random_pos).scaled(random_scale)
		multi_mesh_instance.multimesh.set_instance_transform(i, transform)
