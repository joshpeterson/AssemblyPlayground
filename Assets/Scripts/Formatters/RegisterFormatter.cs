﻿using System;
using Mos6510;

public static class RegisterFormatter
{
  public static string Display(ProgrammingModel model)
  {
    var registerFormat = string.Join("\n",
      "A:0x{0:X2} - X:0x{1:X2} - Y:0x{2:X2} - S:{3}",
      "SP:0x{4:X2} - PC:0x{5:X4}          NV-BDIZC");

    return string.Format(registerFormat,
      model.GetRegister(RegisterName.A).GetValue(),
      model.GetRegister(RegisterName.X).GetValue(),
      model.GetRegister(RegisterName.Y).GetValue(),
      Convert.ToString(model.GetRegister(RegisterName.P).GetValue(), 2).PadLeft(8, '0'),
      model.GetRegister(RegisterName.S).GetValue(),
      model.GetRegister(RegisterName.PC).GetValue());
  }
}