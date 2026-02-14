extends Node
class_name Caller

@export var receiver: Node

func _ready():
	print("Hello Friend! I am calling you")
	receiver.OnCalled()
