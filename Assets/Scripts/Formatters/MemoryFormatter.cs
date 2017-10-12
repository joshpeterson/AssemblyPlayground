using System.Text;
using Mos6510;

public static class MemoryFormatter
{
  public static string Display(Memory memory, int startAddress, int numberOfRows)
  {
    var output = new StringBuilder();
    var stride = 4;
    var endAddress = startAddress + numberOfRows * stride;
    for (var i = startAddress; i < endAddress; i += stride)
      output.AppendFormat("0x{0:X4}:0x{1:X4} - 0x{2:X2} 0x{3:X2} 0x{4:X2} 0x{5:X2}\n", i, i + stride - 1,
        memory.GetValue((ushort) i),
        memory.GetValue((ushort) (i + stride - 3)),
        memory.GetValue((ushort) (i + stride - 2)),
        memory.GetValue((ushort) (i + stride - 1)));
    return output.ToString();
  }
}