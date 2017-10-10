using System.Collections;
using System.Collections.Generic;
using Mos6510;
using UnityEngine;

public class Emulator : MonoBehaviour
{
  public ProgrammingModel model;

  public Memory memory;
  
  public Repl repl;

  private void Awake()
  {
    model = new ProgrammingModel();
    memory = new Memory();
    repl = new Repl(model, memory);
  }
}
