﻿#pragma strict

var frames : Texture2D[];
var framesPorSegundo=10.0;


function Start () {

}

function Update () {
var index : int =Time.time* framesPorSegundo;
index = index % frames.Length;
GetComponent.<Renderer>().material.mainTexture = frames[index];

}