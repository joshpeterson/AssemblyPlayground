using Mos6510;
using NUnit.Framework;

public class RegisterFormatterTests
{
  [Test]
  public void FormatsTheDefaultRegisters()
  {
    var model = new ProgrammingModel();
    var expected = string.Join("\n",
      "A:0x00 - X:0x00 - Y:0x00 - Status:00100000",
      "Stack:0xFF - PC:0x0000            NV-BDIZC");
    Assert.That(RegisterFormatter.Display(model), Is.EqualTo(expected));
  }
}
