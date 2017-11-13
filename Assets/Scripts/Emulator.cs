using Mos6510;
using UnityEngine;

public class Emulator : MonoBehaviour
{
  public Memory memory;
  public ProgrammingModel model;

  public Repl repl;

  public void Awake()
  {
    model = new ProgrammingModel();
    memory = new Memory();
    repl = new Repl(model, memory);
  }
}