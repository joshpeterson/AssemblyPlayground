using Mos6510;
using UnityEngine;
using UnityEngine.UI;

public class MemoryView : MonoBehaviour
{
  public GameObject manager;

  private Memory memory;

  void Start()
  {
    memory = manager.GetComponent<Emulator>().memory;
  }

  void Update()
  {
    GetComponent<Text>().text = MemoryFormatter.Display(memory);
  }
}
