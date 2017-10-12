using Mos6510;
using NUnit.Framework;

public class MemoryFormatterTests
{
  [Test]
  public void FormatsTheFirstMemoryAddress()
  {
    var memory = new Memory();
    memory.SetValue(0x0000, 0x42);
    Assert.That(MemoryFormatter.Display(memory), Does.StartWith("0x0000:0x0003 - 0x42 0x00 0x00 0x00"));
  }
  
  [Test]
  public void FormatsTheManyMemoryAddresses()
  {
    var memory = new Memory();
    for (var i = 0; i < 8; ++i)
      memory.SetValue((ushort)(0x0000 + i), (byte)(0x42 + 0x10*i));

    var expected = string.Join("\n",
      "0x0000:0x0003 - 0x42 0x52 0x62 0x72",
      "0x0004:0x0007 - 0x82 0x92 0xA2 0xB2");
    
    Assert.That(MemoryFormatter.Display(memory), Does.StartWith(expected));
  }
}