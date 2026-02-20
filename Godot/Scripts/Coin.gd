extends Area3D

func _ready():
	body_entered.connect(_on_body_entered)

func _on_body_entered(body: Node):
	if not body.is_in_group("Player"):
		return

	print("You Touched The Coin!")
