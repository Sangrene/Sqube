shader_type canvas_item;

uniform float u_border_size : hint_range(0.0, 1.0) = 0.1;
uniform float u_alpha = 1.0;

void vertex() {
	// Called for every vertex the material is visible on.
}

void fragment() {
	if(UV.x < u_border_size || UV.x > 1.0 - u_border_size || UV.y < u_border_size || UV.y > 1.0 - u_border_size) {
		COLOR = vec4(0.0, 1.0, 0.0, u_alpha);
	}
}

//void light() {
	// Called for every pixel for every light affecting the CanvasItem.
	// Uncomment to replace the default light processing function with this one.
//}
