Shader "Outlined Toon Detail" {
Properties {
 _Color ("Main Color ", Color) = (1,1,1,1)
 _OutlineColor ("Outline Color", Color) = (0,1,0,1)
 _Outline ("Outline width", Range(0.001,0.05)) = 0.01
 _ToonShade ("MatCap (RGB)", 2D) = "white" {}
 _MainTex ("MatCap (RGB)", 2D) = "black" {}
}
SubShader { 
 Tags { "RenderType"="Opaque" }
 UsePass "ToonDetail/BASE"
 Pass {
  Tags { "RenderType"="Opaque" }
  Cull Front
  Blend SrcAlpha OneMinusSrcAlpha
  ColorMask RGB
Program "vp" {
SubProgram "opengl " {
Bind "vertex" ATTR0
Bind "normal" ATTR1
Float 13 [_Outline]
Vector 14 [_OutlineColor]
"!!ARBvp1.0
# 15 ALU
PARAM c[15] = { program.local[0],
		state.matrix.modelview[0],
		state.matrix.projection,
		state.matrix.mvp,
		program.local[13..14] };
TEMP R0;
TEMP R1;
DP3 R0.x, vertex.attrib[1], c[1];
MUL R0.z, R0.x, c[5].x;
DP3 R0.y, vertex.attrib[1], c[2];
DP4 R0.x, vertex.attrib[0], c[11];
MUL R0.w, R0.y, c[6].y;
MUL R0.zw, R0, R0.x;
DP4 R0.y, vertex.attrib[0], c[3];
MUL R0.zw, R0, c[13].x;
RCP R0.y, -R0.y;
DP4 R1.x, vertex.attrib[0], c[9];
DP4 R1.y, vertex.attrib[0], c[10];
MAD result.position.xy, R0.zwzw, R0.y, R1;
MOV result.color, c[14];
DP4 result.position.w, vertex.attrib[0], c[12];
MOV result.position.z, R0.x;
END
# 15 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Bind "vertex" Vertex
Bind "normal" Normal
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [glstate_matrix_projection]
Matrix 8 [glstate_matrix_mvp]
Float 12 [_Outline]
Vector 13 [_OutlineColor]
"vs_2_0
; 15 ALU
dcl_position v0
dcl_normal v1
dp3 r0.x, v1, c0
mul r0.z, r0.x, c4.x
dp3 r0.y, v1, c1
dp4 r0.x, v0, c10
mul r0.w, r0.y, c5.y
mul r0.zw, r0, r0.x
dp4 r0.y, v0, c2
mul r0.zw, r0, c12.x
rcp r0.y, -r0.y
dp4 r1.x, v0, c8
dp4 r1.y, v0, c9
mad oPos.xy, r0.zwzw, r0.y, r1
mov oD0, c13
dp4 oPos.w, v0, c11
mov oPos.z, r0.x
"
}
}
Program "fp" {
SubProgram "opengl " {
"!!ARBfp1.0
# 1 ALU, 0 TEX
MOV result.color, fragment.color.primary;
END
# 1 instructions, 0 R-regs
"
}
SubProgram "d3d9 " {
"ps_2_0
; 1 ALU
dcl v0
mov_pp oC0, v0
"
}
}
  SetTexture [_ToonShade] { combine primary }
 }
}
Fallback "Diffuse"
}