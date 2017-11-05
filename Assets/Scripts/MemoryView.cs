using System;
using System.Globalization;
using Mos6510;
using UnityEngine;
using UnityEngine.UI;

public class MemoryView : MonoBehaviour
{
  public GameObject manager;
  public GameObject address;

  private Memory memory;

  public void Start()
  {
    memory = manager.GetComponent<Emulator>().memory;
  }

  void Update()
  {
    var textComponent = GetComponent<Text>();
    string newValue;
    if (TryFormat(textComponent.cachedTextGenerator.lineCount, out newValue))
      textComponent.text = newValue;
  }

  public bool TryFormat(int numberOfRows, out string formatted)
  {
    formatted = string.Empty;
    var addressTextComponent = address.GetComponent<Text>();
    int parsedAddress;
    if (TryParseAddressInput(addressTextComponent.text, out parsedAddress))
    {
      if (parsedAddress < 0xFFFF)
      {
        formatted = MemoryFormatter.Display(memory, parsedAddress, numberOfRows);
        return true;
      }
    }

    return false;
  }

  private static bool TryParseAddressInput(string input, out int address)
  {
    address = 0;
    if (string.IsNullOrEmpty(input))
      return true;

    if (input.StartsWith("0x"))
      input = input.Substring(2);

    return int.TryParse(input, NumberStyles.HexNumber, null, out address);
  }
}
