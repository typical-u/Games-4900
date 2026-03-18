extends Node

var attack_held := false

func _process(delta: float) -> void:
	if Input.is_action_just_pressed("attack"):
<<<<<<< HEAD
		attack_held = true
		print("Attack Pressed")
=======
		#attack_held = true
		print("Attack!!")
>>>>>>> a04-attack-input
	
	if Input.is_action_just_released("attack"):
		attack_held = false
		print("Attack Released")
		
	if attack_held:
		print("Attack Held")

	var move := Input.get_vector("move_down","move_up","move_left","move_right")
	if move != Vector2.ZERO:
		print("Move", move)
