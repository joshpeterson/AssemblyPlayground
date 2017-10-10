using System.Collections;
using System.Collections.Generic;
using Mos6510;
using UnityEngine;
using UnityEngine.UI;

public class RegisterView : MonoBehaviour
{
  public GameObject manager;

  private ProgrammingModel model;
  
  // Use this for initialization
  void Start ()
  {
    model = manager.GetComponent<Emulator>().model;
  }
  
  // Update is called once per frame
  void Update ()
  {
    GetComponent<Text>().text = RegisterFormatter.Display(model);
  }
}
