shader_type canvas_item;

uniform vec4 color : source_color = vec4(1.0f,1.0f,1.0f,1.0f);

void fragment() {
	vec4 texColor = texture(TEXTURE, UV);
	float tex_color_fac = (texColor.r + texColor.g + texColor.b)/3.f;
	
	COLOR = color * tex_color_fac;
	COLOR.a = texColor.a;
}
