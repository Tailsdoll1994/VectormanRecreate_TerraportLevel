$cd "C:\Users\Tailsdoll\Desktop\vectorman smd"
$modelname "player\lordvipes\Vectorman\Vectorman.mdl"
$model "Vectorman" "Vectorman.smd"
$cdmaterials "models\player\lordvipes\Vectorman\"
$hboxset "default"
$hbox 1 "ValveBiped.Bip01_Head1" -1.250  -6.500  -3.190  8.250  3.500  3.310
$hbox 4 "ValveBiped.Bip01_L_UpperArm" 0.000  -2.750  -2.750  12.510  1.750  2.250
$hbox 4 "ValveBiped.Bip01_L_Forearm" 0.000  -2.190  -2.380  13.000  1.810  1.620
$hbox 4 "ValveBiped.Bip01_L_Hand" 0.060  -2.000  -1.500  4.060  1.000  2.500
$hbox 5 "ValveBiped.Bip01_R_UpperArm" 0.000  -3.000  -2.250  12.390  2.000  2.750
$hbox 5 "ValveBiped.Bip01_R_Forearm" -0.500  -2.200  -1.550  12.500  1.800  2.450
$hbox 5 "ValveBiped.Bip01_R_Hand" 0.060  -2.000  -2.500  4.060  1.000  1.500
$hbox 6 "ValveBiped.Bip01_L_Thigh" 0.000  -3.750  -3.250  17.850  3.750  3.250
$hbox 6 "ValveBiped.Bip01_L_Calf" 0.000  -3.510  -3.280  15.640  3.490  2.720
$hbox 6 "ValveBiped.Bip01_L_Foot" -1.070  -2.000  -2.840  5.040  5.000  2.160
$hbox 7 "ValveBiped.Bip01_R_Thigh" 0.000  -3.750  -3.250  17.850  3.750  3.250
$hbox 7 "ValveBiped.Bip01_R_Calf" 0.000  -3.510  -2.820  15.640  3.490  3.180
$hbox 7 "ValveBiped.Bip01_R_Foot" -1.060  -2.010  -2.280  5.050  4.990  2.720
$hbox 3 "ValveBiped.Bip01_Pelvis" -7.500  -5.500  -6.000  7.500  8.500  5.000
$hbox 2 "ValveBiped.Bip01_Spine2" -2.500  -2.500  -7.000  14.500  7.500  7.000
// Model uses material "vectorgreen.vmt"
// Model uses material "vectorblack.vmt"
// Model uses material "stripeglow.vmt"
// Model uses material "vectorblueglow.vmt"
// Model uses material "vectordarkblue.vmt"
// Model uses material "vectoreyes.vmt"
$attachment "eyes" "ValveBiped.Bip01_Head1" 3.47 -3.99 -0.10 rotate -0.00 -80.10 -90.00
$attachment "mouth" "ValveBiped.Bip01_Head1" 0.80 -5.80 -0.15 rotate -0.00 -80.00 -90.00
$attachment "chest" "ValveBiped.Bip01_Spine2" 5.00 4.00 -0.00 rotate -0.00 90.00 90.00
$attachment "forward" "ValveBiped.forward" 0.00 0.00 0.00 rotate -0.00 0.00 0.00
$attachment "anim_attachment_RH" "ValveBiped.Anim_Attachment_RH" 0.00 0.00 0.00 rotate -90.00 -90.00 0.00
$attachment "anim_attachment_LH" "ValveBiped.Anim_Attachment_LH" 0.00 0.00 0.00 rotate -90.00 -90.00 0.00
$attachment "anim_attachment_head" "ValveBiped.Bip01_Head1" 0.00 0.00 0.00 rotate -90.00 -90.00 0.00
$includemodel "m_anm.mdl"
$includemodel "m_gst.mdl"
$includemodel "m_pst.mdl"
$includemodel "m_shd.mdl"
$includemodel "m_ss.mdl"
$surfaceprop "metal"
$illumposition 2.252 -0.000 35.325
$sequence ragdoll "ragdoll" ACT_DIERAGDOLL 1 fps 30.00
$ikchain rhand ValveBiped.Bip01_R_Hand knee  0.707 0.707 0.000
$ikchain lhand ValveBiped.Bip01_L_Hand knee  0.707 0.707 0.000
$ikchain rfoot ValveBiped.Bip01_R_Foot knee  0.707 -0.707 0.000
$ikchain lfoot ValveBiped.Bip01_L_Foot knee  0.707 -0.707 0.000
$collisionjoints "phymodel.smd" {

	$mass 90.0
	$inertia 10.00
	$damping 0.01
	$rotdamping 1.50
	$rootbone "valvebiped.bip01_pelvis"
	$jointmerge "ValveBiped.Bip01_Pelvis" "ValveBiped.Bip01_Spine1"

	$jointconstrain "valvebiped.bip01_l_thigh" x limit -12.00 12.00 0.00
	$jointconstrain "valvebiped.bip01_l_thigh" y limit -73.00 6.00 0.00
	$jointconstrain "valvebiped.bip01_l_thigh" z limit -93.00 30.00 0.00

	$jointconstrain "valvebiped.bip01_l_calf" x limit 0.00 0.00 0.00
	$jointconstrain "valvebiped.bip01_l_calf" y limit 0.00 0.00 0.00
	$jointconstrain "valvebiped.bip01_l_calf" z limit -8.00 126.00 0.00

	$jointconstrain "valvebiped.bip01_r_thigh" x limit -12.00 12.00 0.00
	$jointconstrain "valvebiped.bip01_r_thigh" y limit -8.00 75.00 0.00
	$jointconstrain "valvebiped.bip01_r_thigh" z limit -97.00 32.00 0.00

	$jointconstrain "valvebiped.bip01_r_calf" x limit 0.00 0.00 0.00
	$jointconstrain "valvebiped.bip01_r_calf" y limit 0.00 0.00 0.00
	$jointconstrain "valvebiped.bip01_r_calf" z limit -12.00 126.00 0.00

	$jointconstrain "valvebiped.bip01_r_foot" x limit 0.00 0.00 0.00
	$jointconstrain "valvebiped.bip01_r_foot" y limit -25.00 6.00 0.00
	$jointconstrain "valvebiped.bip01_r_foot" z limit -15.00 35.00 0.00

	$jointconstrain "valvebiped.bip01_spine2" x limit -48.00 48.00 0.00
	$jointconstrain "valvebiped.bip01_spine2" y limit -25.00 25.00 0.00
	$jointconstrain "valvebiped.bip01_spine2" z limit -25.00 50.00 0.00

	$jointconstrain "valvebiped.bip01_l_upperarm" x limit -30.00 30.00 0.00
	$jointconstrain "valvebiped.bip01_l_upperarm" y limit -95.00 84.00 0.00
	$jointconstrain "valvebiped.bip01_l_upperarm" z limit -86.00 26.00 0.00

	$jointconstrain "valvebiped.bip01_l_forearm" x limit 0.00 0.00 0.00
	$jointconstrain "valvebiped.bip01_l_forearm" y limit 0.00 0.00 0.00
	$jointconstrain "valvebiped.bip01_l_forearm" z limit -149.00 4.00 0.00

	$jointconstrain "valvebiped.bip01_r_upperarm" x limit -39.00 39.00 0.00
	$jointconstrain "valvebiped.bip01_r_upperarm" y limit -79.00 95.00 0.00
	$jointconstrain "valvebiped.bip01_r_upperarm" z limit -93.00 23.00 0.00

	$jointconstrain "valvebiped.bip01_r_forearm" x limit 0.00 0.00 0.00
	$jointconstrain "valvebiped.bip01_r_forearm" y limit 0.00 0.00 0.00
	$jointconstrain "valvebiped.bip01_r_forearm" z limit -149.00 4.00 0.00

	$jointconstrain "valvebiped.bip01_r_hand" x limit -60.00 60.00 0.00
	$jointconstrain "valvebiped.bip01_r_hand" y limit 0.00 0.00 0.00
	$jointconstrain "valvebiped.bip01_r_hand" z limit -57.00 70.00 0.00

	$jointconstrain "valvebiped.bip01_head1" x limit -20.00 20.00 0.00
	$jointconstrain "valvebiped.bip01_head1" y limit -25.00 25.00 0.00
	$jointconstrain "valvebiped.bip01_head1" z limit -13.00 30.00 0.00

	$jointconstrain "valvebiped.bip01_l_hand" x limit -37.00 37.00 0.00
	$jointconstrain "valvebiped.bip01_l_hand" y limit 0.00 0.00 0.00
	$jointconstrain "valvebiped.bip01_l_hand" z limit -57.00 59.00 0.00

	$jointconstrain "valvebiped.bip01_l_foot" x limit 0.00 0.00 0.00
	$jointconstrain "valvebiped.bip01_l_foot" y limit -19.00 19.00 0.00
	$jointconstrain "valvebiped.bip01_l_foot" z limit -15.00 35.00 0.00
	$animatedfriction 1.000 400.000 0.500 0.300 0.000
}
