#version 330 core
out vec4 FragColor;

in vec3 FragPos;
in vec3 Normal;
in vec2 TexCoords;

uniform sampler2D texture_reflect1;
uniform sampler2D texture_diffuse1;
uniform sampler2D texture_specular1;

uniform vec3 cameraPos;
uniform samplerCube skybox;

void main()
{
	vec3 I = normalize(FragPos - cameraPos);
    vec3 R = reflect(I, normalize(Normal));
    
	vec3 reflect = texture(skybox, R).rgb;
    vec3 diffuse =  vec3(texture(texture_diffuse1, TexCoords));
    vec3 specular = vec3(texture(texture_specular1, TexCoords));
    vec3 result = reflect;
    FragColor = vec4(result, 1.0);
}