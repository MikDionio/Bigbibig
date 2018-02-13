﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicInputScript : MonoBehaviour {

	public float MicLoudness;
	private string _device;

	//mic initialization
	void InitMic(){
		if(_device == null) _device = Microphone.devices[0];
		_clipRecord = Microphone.Start(_device, true, 999, 44100);
	}

	void StopMicrophone()
	{
		Microphone.End(_device);
	}


	AudioClip _clipRecord = new AudioClip();
	int _sampleWindow = 128;

	//get data from microphone into audioclip
	float  LevelMax()
	{
		float levelMax = 0;
		float[] waveData = new float[_sampleWindow];
		int micPosition = Microphone.GetPosition(null)-(_sampleWindow+1); // null means the first microphone
		if (micPosition < 0) return 0;
		_clipRecord.GetData(waveData, micPosition);
		// Getting a peak on the last 128 samples
		for (int i = 0; i < _sampleWindow; i++) {
			float wavePeak = waveData[i] * waveData[i];
			if (levelMax < wavePeak) {
				levelMax = wavePeak;
			}
		}
		return levelMax;
	}



	void Update()
	{
		// levelMax equals to the highest normalized value power 2, a small number because < 1
		// pass the value to a static var so we can access it from anywhere
		MicLoudness = LevelMax ();
		if (Input.GetKey("space")) {
			Debug.Log (MicLoudness);
		}
	}

	bool _isInitialized;
	// start mic when scene starts
	void OnEnable()
	{
		InitMic();
		_isInitialized=true;
	}

	//stop mic when loading a new level or quit application
	void OnDisable()
	{
		StopMicrophone();
	}

	void OnDestroy()
	{
		StopMicrophone();
	}

}
