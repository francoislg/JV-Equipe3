Shader "ToonDetail" {
Properties {
 _Color ("Main Color ", Color) = (1,1,1,1)
 _ToonShade ("Shading Texture (RGBA)", 2D) = "white" {}
 _MainTex ("Detail(RGBA)", 2D) = "black" {}
}
SubShader { 
 Pass {
  Name "BASE"
  Fog { Mode Off }
Program "vp" {
SubProgram "opengl " {
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Vector 9 [_MainTex_ST]
"!!ARBvp1.0
# 8 ALU
PARAM c[10] = { { 0.5 },
		state.matrix.mvp,
		state.matrix.modelview[0].invtrans,
		program.local[9] };
TEMP R0;
DP3 R0.x, vertex.normal, c[5];
DP3 R0.y, vertex.normal, c[6];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[9], c[9].zwzw;
MAD result.texcoord[1].xy, R0, c[0].x, c[0].x;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 8 instructions, 1 R-regs
"
}
SubProgram "d3d9 " {
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [glstate_matrix_invtrans_modelview0]
Vector 8 [_MainTex_ST]
"vs_2_0
; 8 ALU
def c9, 0.50000000, 0, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
dp3 r0.x, v1, c4
dp3 r0.y, v1, c5
mad oT0.xy, v2, c8, c8.zwzw
mad oT1.xy, r0, c9.x, c9.x
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
SetTexture 1 [_MainTex] 2D
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
# 5 ALU, 2 TEX
PARAM c[2] = { program.local[0],
		{ 2 } };
TEMP R0;
TEMP R1;
TEX R0, fragment.texcoord[1], texture[0], 2D;
TEX R1, fragment.texcoord[0], texture[1], 2D;
MUL R0, R0, c[0];
MUL R0, R0, c[1].x;
MUL result.color, R0, R1;
END
# 5 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Vector 0 [_Color]
SetTexture 0 [_ToonShade] 2D
SetTexture 1 [_MainTex] 2D
"ps_2_0
; 4 ALU, 2 TEX
dcl_2d s0
dcl_2d s1
def c1, 2.00000000, 0, 0, 0
dcl t0.xy
dcl t1.xy
texld r1, t1, s0
texld r0, t0, s1
mul r1, r1, c0
mul r1, r1, c1.x
mul_pp r0, r1, r0
mov_pp oC0, r0
"
}
}
 }
}
}