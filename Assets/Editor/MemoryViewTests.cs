using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class MemoryViewTests
{
  private MemoryView _memoryView;
  private Text _addressTextComponent;

  [SetUp]
  public void SetUp()
  {
    var manager = new GameObject();
    var emulator = manager.AddComponent<Emulator>();
    emulator.Awake();
    
    var address = new GameObject();
    _addressTextComponent = address.AddComponent<Text>();

    var memoryTextGameObject = new GameObject();
    var text = memoryTextGameObject.AddComponent<Text>();
    var memoryView = memoryTextGameObject.AddComponent<MemoryView>();
    
    _memoryView = memoryView;
    _memoryView.manager = manager;
    _memoryView.address = address;

    _memoryView.Start();
  }
  
  [TestCase("0006", "0x0006")]
  [TestCase("0010", "0x0010")]
  [TestCase("0x0010", "0x0010")]
  [TestCase(null, "0x0000")]
  [TestCase("0xFFFE", "0xFFFB")]
  public void CanParse(string input, string expected)
  {
    _addressTextComponent.text = input;
    string actual;
    _memoryView.TryFormat(1, out actual);
    Assert.That(actual, Does.StartWith(expected));
  }

  [TestCase("foo", false)]
  [TestCase("0x0020", true)]
  [TestCase(null, true)]
  [TestCase("FFFE", true)]
  [TestCase("FFFF", false)]
  [TestCase("FFFFF", false)]
  public void TryFormatReturns(string input, bool expected)
  {
    _addressTextComponent.text = input;
    string unused;
    Assert.That(_memoryView.TryFormat(1, out unused), Is.EqualTo(expected),
      $"TryFormat returned {!expected} for {(expected ? "valid" : "invalid")} input, which is not expected.");
  }
}