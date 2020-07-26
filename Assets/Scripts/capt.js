#pragma strict

var username:String;
var inputField:UnityEngine.UI.InputField;
var name:UnityEngine.UI.Text;

function gurdarNick(){
	//username=inputField.value;
	PlayerPrefs.SetString ("nick", username);

}
function cargarNick(){
	//name.text= PlayerPrefs.GetString("nick");
}

function QuaFastest(){
QualitySettings.currentLevel= QualityLevel.Fastest;
}

function QuaFast(){
QualitySettings.currentLevel= QualityLevel.Fast;
}

function QuaSimple(){
QualitySettings.currentLevel= QualityLevel.Simple;
}

function QuaGood(){
QualitySettings.currentLevel= QualityLevel.Good;
}

function QuaBeautiful(){
QualitySettings.currentLevel= QualityLevel.Beautiful;
}

function QuaFantastic(){
QualitySettings.currentLevel= QualityLevel.Fantastic;
}