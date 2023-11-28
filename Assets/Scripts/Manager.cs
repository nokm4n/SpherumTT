using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEngine.GraphicsBuffer;


public class Manager : MonoBehaviour
{
    [SerializeField] private GameObject _red, _green;
    [SerializeField] private GameObject _spheres;
    [SerializeField] private TextMeshProUGUI _distanceText;

    [SerializeField] private ParticleSystem _greenPart, _redPart;

	Vector3 movement, movement2;
	float speed = .01f;
	float _disance = 0;
    void Start()
    {
        _disance = Vector3.Distance(_red.transform.position, _green.transform.position);

	}
    void Update()
    {
		_disance = Vector3.Distance(_red.transform.position, _green.transform.position);
		_distanceText.text = "Distance is: " + _disance.ToString();
        if (_disance < 1) SceneManager.LoadScene(1);
		if (_disance < 2)
        {
            _spheres.SetActive(true);
        }
        else
        {
            _spheres.SetActive(false);
        }
        
		
		float inputX = Input.GetAxis("Horizontal1");
		float inputY = Input.GetAxis("Vertical1");
		float inputX2 = Input.GetAxis("Horizontal2");
		float inputY2 = Input.GetAxis("Vertical2");

		movement = new Vector3(speed * inputX, 0, speed * inputY);
        _red.transform.Translate(movement);		

		movement2 = new Vector3(speed * inputX2, 0, speed * inputY2);
		_green.transform.Translate(movement2);


        _greenPart.transform.LookAt(_red.transform);
        _redPart.transform.LookAt(_green.transform);
        _greenPart.startLifetime = _disance / 6;
        _redPart.startLifetime = _disance / 6;
	}
}
