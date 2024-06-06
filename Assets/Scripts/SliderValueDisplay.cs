using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderValueDisplay : MonoBehaviour
{
	public Slider sld;
	public Text text;
	public Slider sld2;
	public Text text2;
	public Slider sld3;
	public Text text3;
	public Slider sld4;
	public Text text4;
	public TextMeshProUGUI textMeshPro;

	public void UpdateValue() 
	{
		text.text = sld.value.ToString();
	}

	public void UpdateValue2()
	{
		text2.text = sld2.value.ToString();
	}

	public void UpdateValue3()
	{
		text3.text = sld3.value.ToString();
	}

	public void UpdateValue4()
	{
		text4.text = sld4.value.ToString();
	}

	void Update()
	{
		// Convierte los textos a números enteros y suma los valores
		int value1 = int.Parse(text.text);
		int value2 = int.Parse(text2.text)*10;
		int value3 = int.Parse(text3.text)*100;
		int value4 = int.Parse(text4.text)*1000;

		int sum = value1 + value2 + value3 + value4;
		if (sum == 1902)
		{
			GameObject PuertaGaraje = GameObject.Find("PuertaGaraje"); // Reemplaza "NombreDelObjeto" con el nombre real del objeto
			if (PuertaGaraje != null)
			{
				textMeshPro.text = "Pistas encontradas: 3/3";
				PuertaGaraje.GetComponent<ControlPuertaGareja>().SubirBarrera();
			}
		}
	}
}

