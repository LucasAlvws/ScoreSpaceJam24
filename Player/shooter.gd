extends Node2D

const bullet_scene = preload("res://Player/bala.tscn")

const angulo = 270.0
const spawn_point_count = 1
const radius = 1

func _ready():	
	var step = 2 * PI / spawn_point_count
	
	for i in range(spawn_point_count):
		var spawn_point = Node2D.new()
		var pos = Vector2(radius, 0).rotated(step * i)
		spawn_point.position = pos
		spawn_point.rotation = pos.angle()
		self.add_child(spawn_point)


func _process(delta):
	if Input.is_action_just_pressed("espaco", true):
		shoot()

func shoot():
	for s in self.get_children():
		var bullet = bullet_scene.instance()
		get_tree().root.add_child(bullet)
		bullet.position = Vector2(s.global_position.x + 50, s.global_position.y +50) 
		bullet.rotation = s.global_rotation	
		

