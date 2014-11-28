Shader "ToonBase" {
Properties {
 _Color ("Base Color ", Color) = (1,1,1,1)
 _ToonShade ("Shading Texture (RGB)", 2D) = "white" {}
}
SubShader { 
 Pass {
  Name "BASE"
  Fog { Mode Off }
Program "vp" {
SubProgram "opengl " {
Bind "vertex" Vertex
Bind "normal" Normal
"!!ARBvp1.0
# 7 ALU
PARAM c[9] = { { 0.5 },
		state.matrix.mvp,
		state.matrix.modelview[0].invtrans };
TEMP R0;
DP3 R0.x, vertex.normal, c[5];
DP3 R0.y, vertex.normal, c[6];
MAD result.texcoord[2].xy, R0, c[0].x, c[0].x;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 7 instructions, 1 R-regs
"
}
SubProgram "d3d9 " {
Bind "vertex" Vertex
Bind "normal" Normal
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [glstate_matrix_invtrans_modelview0]
"vs_2_0
; 7 ALU
def c8, 0.50000000, 0, 0, 0
dcl_position0 v0
dcl_normal0 v1
dp3 r0.x, v1, c4
dp3 r0.y, v1, c5
mad oT2.xy, r0, c8.x, c8.x
dp4 oPos.w, v0, c3
dp4 oPos.z, v0, c2
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
"
}
}
Program "fp" {
SubProgram "opengl " {
Vector 0 [_Color]
SetTexture 0 [_ToonShade] 2D
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
# 3 ALU, 1 TEX
PARAM c[2] = { program.local[0],
		{ 2 } };
TEMP R0;
TEX R0, fragment.texcoord[2], texture[0], 2D;
MUL R0, R0, c[0];
MUL result.color, R0, c[1].x;
END
# 3 instructions, 1 R-regs
"
}
SubProgram "d3d9 " {
Vector 0 [_Color]
SetTexture 0 [_ToonShade] 2D
"ps_2_0
; 3 ALU, 1 TEX
dcl_2d s0
def c1, 2.00000000, 0, 0, 0
dcl t2.xy
texld r0, t2, s0
mul r0, r0, c0
mul r0, r0, c1.x
mov_pp oC0, r0
"
}
}
 }
}
}