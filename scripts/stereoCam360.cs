using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using System.IO;
using System;

public class stereoCam360 : MonoBehaviour
{

		/*static List<byte> demoData = new List<byte>();
		static int initialDemoDataSize;
		static List<byte> demoNewData = new List<byte>();
		bool demoFinished = false;*/
		
		/*new byte[] {
1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,	
		}; */
		public bool stereoHUD;
		public GameObject sonikku;
		public int checkpointStart;
		GameObject checkpointObject;
		List<Texture2D> framesData = new List<Texture2D>();
		bool wrotted = false;

		public GameObject stereo3Dtext;
		TextMesh stereo3DtextComp;

		public static bool demoMode = false;
		//public bool recordDemo;
		public static byte demoInput = 0; // up down left right jump
        public GameObject playerCamera;
		Camera playerCameraComponent;
        public GameObject videoCamera;
		Quaternion cameraInitialRotation;
		int equiW, equiH;

		Camera videoCameraComponent;
		public int sizeTexture;
		int sizeTexture2;
		public int frameCount;
		//int presentFrameCount;
		//public GameObject testobj;
		public float waitTime;
		public RenderTexture leftEye;
		public RenderTexture rightEye;
		public RenderTexture equirect;
		//public bool renderStereo = true;
		public bool calcImages;
		float stereoSeparation;
		/*public float eyeMinConverge;
		public float maxEyeAngleToAdd;

		public float stereoSepMin;
		public float stereoSepAddMax;
		*/

		float cameraConvergePointMax; //400 // public
		public float stereoSeparationVal;
		public float cameraAngleVal;
		float convergeForce; // [0.0,1.0]


		float cameraConvergePointDistance;

		float cameraAngle;
		float cameraAngle2;
		//public float eyeConvergeDist;
		//GameObject HUD;
		public GameObject cameraAngleTextObject;
		Text cameraAngleText;
		//TextMesh cameraAngleTextWorld;
		Camera cam;
		bool convergePls = false;
	
	void Start() {
		stereo3DtextComp = stereo3Dtext.GetComponent<TextMesh>();
		checkpointObject = GameObject.Find("checkpoint" + checkpointStart);
		/*if (demoMode) {  string text = File.ReadAllText(@"C:\Users\ui\Desktop\oue\aa\demo\demo.txt"); 
			string[] tokens = text.Split('\n');
			foreach(string token in tokens) {
				demoData.Add(Convert.ToByte(token)); }
			initialDemoDataSize = demoData.Count; 
			File.Delete(@"C:\Users\ui\Desktop\oue\aa\demo\newDemo.txt");
			
			}*/

		cameraAngle = cameraAngleVal;
		cameraAngle2 = 2*cameraAngle;
		cameraInitialRotation = videoCamera.transform.rotation;
		cameraConvergePointDistance = cameraConvergePointMax;
		playerCameraComponent = playerCamera.GetComponent<Camera>();
		videoCameraComponent = videoCamera.GetComponent<Camera>();
		videoCameraComponent.stereoSeparation = stereoSeparationVal; //stereoSeparation;
		//HUD = GameObject.Find("HUD");
		cameraAngleText = (Text) cameraAngleTextObject.GetComponent<Text>();
		//cameraAngleTextWorld = (TextMesh) GameObject.Find("WorldHUD").GetComponent<TextMesh>();
			
		//frameCount = 0;
		//presentFrameCount = 0;
		sizeTexture2 = 2*sizeTexture;
		leftEye = new RenderTexture(sizeTexture, sizeTexture, 24, RenderTextureFormat.ARGB32);
		leftEye.dimension = TextureDimension.Cube;
		rightEye = new RenderTexture(sizeTexture, sizeTexture, 24, RenderTextureFormat.ARGB32);
		rightEye.dimension = TextureDimension.Cube;
		//equirect height should be twice the height of cubemap
		equirect = new RenderTexture(sizeTexture, sizeTexture2, 24, RenderTextureFormat.ARGB32);
		if (calcImages) { StartCoroutine(videoMaker()); }
		//StartCoroutine(introCamera());

	}

	/*IEnumerator introCamera() {
	/*	while (true) {
			yield return new WaitForSeconds(waitTime);

		}*/
			//demoInput = 16; 

	//}*/

	IEnumerator videoMaker()
    {
		//yield return new WaitForSeconds(1.5f); 

		while (!(Input.GetKeyUp("r"))) {
			yield return new WaitForSeconds(0.01f); 
		}

		while (true) { 
			videoCamera.transform.rotation = cameraInitialRotation;
				//cameraAngle += 0.25f;
		/*	if (cameraAngle > 22.0f) {
				cameraAngle = cameraAngleVal;
				switch(videoCameraComponent.stereoSeparation) {
					case 0.01f:
						videoCameraComponent.stereoSeparation = 0.2f;
					break;
					case 0.2f:
						videoCameraComponent.stereoSeparation = 0.5f;
					break;
					case 0.5f:
						videoCameraComponent.stereoSeparation = 1.0f;
					break;
					case 1.0f:
						videoCameraComponent.stereoSeparation = 0.01f;
					break;
						
					}
				}
				else { cameraAngle += 0.25f;}
			*/
				//else { cameraAngle += 0.5f; }

			
			
			/*cameraConvergePointDistance = Vector3.Distance(sonikku.transform.position,
															 checkpointObject.transform.position);
	 
			//cameraConvergePointDistance = cameraConvergePointMax;
			// HERE FIND OUT NEXT OBJECT'S DISTANCE
			if (cameraConvergePointDistance > cameraConvergePointMax) { cameraConvergePointDistance = cameraConvergePointMax; }
		
			convergeForce = Mathf.Cos((Mathf.PI/2) * ((cameraConvergePointMax-cameraConvergePointDistance)/cameraConvergePointMax));
			cameraAngle = eyeMinConverge + (maxEyeAngleToAdd - (maxEyeAngleToAdd * convergeForce));
			videoCameraComponent.stereoSeparation = stereoSepMin + (stereoSepAddMax - (stereoSepAddMax * convergeForce));	
			//videoCameraComponent.stereoSeparation = 0.8f;

			//Debug.Log(cameraAngle + " camera angle");
			//Debug.Log("angle is  " + cameraConvergePointDistance);

			//playerCamera.active = false;
			//videoCamera.active = true;
			

				
			//videoCameraComponent.stereoSeparation = 0.064f + (5.0f * (cameraAngle/maxEyeAngleToAdd));
				
				*/
				
			//if (renderStereo) { 
				//cam.stereoConvergence = eyeConvergeDist; //just doesn't work
				//GameObject.Find()
				//cameraAngle += 0.05f;
				//if (stereoHUD) { stereo3DtextComp.text = videoCameraComponent.stereoSeparation + " " + cameraAngle.ToString(); }
				//cameraAngleText.text = "sep = " + videoCameraComponent.stereoSeparation + " ang = " + cameraAngle.ToString();
				//cameraAngleText.text = "distance = " + cameraConvergePointDistance;
				
				
				//cameraAngle2 = 2*cameraAngle;

				/*cameraAngle += 3.0f;*/
				//cameraAngleTextWorld.text = "CA = " + cameraAngle.ToString();
				
					videoCamera.transform.Rotate(0.0f, cameraAngle, 0.0f);
					videoCameraComponent.RenderToCubemap(leftEye, 63, Camera.MonoOrStereoscopicEye.Left);
					videoCamera.transform.Rotate(0.0f, -cameraAngle2, 0.0f);
					videoCameraComponent.RenderToCubemap(rightEye, 63, Camera.MonoOrStereoscopicEye.Right);
					videoCamera.transform.Rotate(0.0f, cameraAngle, 0.0f); 
					leftEye.ConvertToEquirect(equirect, Camera.MonoOrStereoscopicEye.Left);
					rightEye.ConvertToEquirect(equirect, Camera.MonoOrStereoscopicEye.Right);
			//}
			//else { 
				//videoCameraComponent.RenderToCubemap(leftEye, 63, Camera.MonoOrStereoscopicEye.Mono);
				// }

			//optional: convert cubemaps to equirect

			//if (equirect == null)
			//    return;

			//if (renderStereo) { }
			//else { leftEye.ConvertToEquirect(equirect, Camera.MonoOrStereoscopicEye.Mono); }
			
			equiW = equirect.width; int equiH = equirect.height;
			Texture2D tempTexture = new Texture2D(equiW, equiH);
			RenderTexture currentActiveRT = RenderTexture.active;
			RenderTexture.active = equirect;
			videoCameraComponent.Render();
			tempTexture.ReadPixels(new Rect(0, 0, equiW, equiH), 0, 0);
			framesData.Add(tempTexture);

			RenderTexture.active = currentActiveRT;
			// WRITE PNGs
			// Creates buffer
				// Copies EquirectTexture into the tempTexture	 
				// Exports to a PNG

				if (Input.GetKeyDown("y") && !wrotted) { 
					//RenderTexture currentActiveRT = RenderTexture.active;
					for (int i = 0; i < framesData.Count; i++) {
						//RenderTexture.active = framesData[i];
						//tempTexture.ReadPixels(new Rect(0, 0, equiW, equiH), 0, 0);
						var bytes = framesData[i].EncodeToPNG();
						System.IO.File.WriteAllBytes(
							@"C:\Users\ui\Desktop\oue\aa\googleshit\oui" + 
							(frameCount+i).ToString().PadLeft(5, '0') + ".png",  bytes);

					}
					Debug.Log("written succesffuly!");
					wrotted = true;

				}
					//Debug.Log("goin!");

			// Restores the active render texture
			//playerCamera.active = true;
			//videoCamera.active = false;
				
			yield return new WaitForSeconds(waitTime); 
		}
		
    }
	/*
	void LateUpdate() {
		

        //if (cam == null) { cam = GetComponentInParent<Camera>(); }

       // if (cam == null) { Debug.Log("stereo 360 capture node has no camera or parent camera"); }

		
    }*/
/*
	void LateUpdate() {
		//videoCamera.transform.rotation = cameraInitialRotation;
		
	}*/
//
    //void FixedUpdate ()
    //{
		/*float v, h; bool jump = Input.GetButtonDown("A");
		h = Input.GetAxis("Horizontal"); v = Input.GetAxis("Vertical");

		byte recordInput = (byte) (((v == 1.0f) ? 1 : 0) +
							((v == -1.0f) ? 2 : 0) +
							((h == -1.0f) ? 4 : 0) +
							((h == 1.0f) ? 8 : 0) +
					 		(jump ? 16 : 0));

		if (recordInput > 0) { demoInput = recordInput; }
		else { demoInput = (frameCount < initialDemoDataSize) ? demoData[frameCount]  : (byte) 0; }
		//Debug.Log("demoInput " + demoInput);

		Debug.Log(  (((demoInput & (1 << 0)) != 0)? "up" : "") + (((demoInput & (1 << 1)) != 0)? "down" : "") + 
			(((demoInput & (1 << 2)) != 0)? "left" : "") + (((demoInput & (1 << 3)) != 0)? "right" : "") + 
			(((demoInput & (1 << 4)) != 0)? "JUMP" : ""));
		// adding the keybinds for that frame
		demoNewData.Add(demoInput);

		if (!demoFinished && Input.GetKeyDown("k")) { demoFinished = true;
			File.WriteAllText(@"C:\Users\ui\Desktop\oue\aa\demo\newDemo.txt", "");
            {
					int counting = demoNewData.Count; int countingd1 = counting -1;
				for(int i = 0; i < counting; i++) { 
					File.AppendAllText(@"C:\Users\ui\Desktop\oue\aa\demo\newDemo.txt", demoNewData[i].ToString() + 
						((i == countingd1) ? "" : "\n")); }
            }
			Debug.Log("wrote shit !");
		}
			*/
		/*if (Input.GetKeyUp("v")) { checkpointStart++;  
			checkpointObject = GameObject.Find("checkpoint" + checkpointStart); }*/

		
		
		//frameCount++;
		//presentFrameCount++;

    //}




}